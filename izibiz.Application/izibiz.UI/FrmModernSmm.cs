using System;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.Singleton;
using izibiz.SERVICES.serviceCreditNote;
using izibiz.MODEL.Entities;
using System.Threading.Tasks;

namespace izibiz.UI
{
    public class FrmModernSmm : Form
    {
        private TableLayoutPanel mainLayout;
        private Panel pnlAction;
        private DataGridView tableGrid;
        
        private Button btnTakeSmmRest;
        private Button btnTakeSmmSoap;
        private Button btnView;
        
        private RadioButton rdViewHtml;
        private RadioButton rdViewPdf;
        private RadioButton rdViewXml;

        public FrmModernSmm()
        {
            InitializeComponents();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
        }

        private void InitializeComponents()
        {
            this.BackColor = UITheme.BackgroundColor;
            
            mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 2;
            mainLayout.ColumnCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.Controls.Add(mainLayout);

            // Action Panel
            pnlAction = new Panel();
            pnlAction.Dock = DockStyle.Fill;
            pnlAction.BackColor = UITheme.PanelColor;
            pnlAction.Margin = new Padding(10);
            mainLayout.Controls.Add(pnlAction, 0, 0);

            // Buttons
            btnTakeSmmRest = new Button();
            btnTakeSmmRest.Text = "REST ile SMM Çek";
            btnTakeSmmRest.Location = new Point(20, 20);
            btnTakeSmmRest.Size = new Size(150, 40);
            UITheme.ApplyFlatButton(btnTakeSmmRest, true);
            btnTakeSmmRest.Click += BtnTakeSmmRest_Click;
            pnlAction.Controls.Add(btnTakeSmmRest);

            btnTakeSmmSoap = new Button();
            btnTakeSmmSoap.Text = "SOAP ile SMM Çek";
            btnTakeSmmSoap.Location = new Point(180, 20);
            btnTakeSmmSoap.Size = new Size(150, 40);
            UITheme.ApplyFlatButton(btnTakeSmmSoap, false);
            btnTakeSmmSoap.Click += BtnTakeSmmSoap_Click;
            pnlAction.Controls.Add(btnTakeSmmSoap);

            rdViewHtml = new RadioButton() { Text = "HTML", Location = new Point(350, 30), AutoSize = true, Checked = true, Font = UITheme.MainFont };
            rdViewPdf = new RadioButton() { Text = "PDF", Location = new Point(420, 30), AutoSize = true, Font = UITheme.MainFont };
            rdViewXml = new RadioButton() { Text = "XML", Location = new Point(480, 30), AutoSize = true, Font = UITheme.MainFont };
            pnlAction.Controls.Add(rdViewHtml);
            pnlAction.Controls.Add(rdViewPdf);
            pnlAction.Controls.Add(rdViewXml);

            btnView = new Button();
            btnView.Text = "Görüntüle / İndir";
            btnView.Location = new Point(550, 20);
            btnView.Size = new Size(150, 40);
            UITheme.ApplyFlatButton(btnView, true);
            btnView.Click += BtnView_Click;
            pnlAction.Controls.Add(btnView);

            // Grid
            tableGrid = new DataGridView();
            tableGrid.Dock = DockStyle.Fill;
            tableGrid.Margin = new Padding(10);
            UITheme.ApplyDataGrid(tableGrid);
            mainLayout.Controls.Add(tableGrid, 0, 1);
        }

        private async void BtnTakeSmmRest_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = new izibiz.REST.Models.Request.ListFilter();
                var smmList = await Singl.SmmClientGet.ListAsync(filter);
                tableGrid.DataSource = smmList.Contents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTakeSmmSoap_Click(object sender, EventArgs e)
        {
            try
            {
                tableGrid.DataSource = Singl.smmDalGet.getSmmWithDraft(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void BtnView_Click(object sender, EventArgs e)
        {
            if (tableGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen tablodan bir satır seçin.");
                return;
            }

            try
            {
                var boundItem = tableGrid.SelectedRows[0].DataBoundItem;
                
                // REST item selected
                if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                {
                    string format = "pdf";
                    if (rdViewHtml.Checked) format = "html";
                    else if (rdViewXml.Checked) format = "xml";

                    if (format == "html")
                    {
                        var xmlResult = await Singl.SmmClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, "ubl");
                        byte[] xmlBytes = System.Linq.Enumerable.FirstOrDefault(xmlResult.Values);
                        string strContent = System.Text.Encoding.UTF8.GetString(xmlBytes);
                        FrmView previewInvoices = new FrmView(strContent, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts), isHtml: false);
                        previewInvoices.ShowDialog();
                    }
                    else
                    {
                        var downloadResult = await Singl.SmmClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, format);
                        byte[] downloadBytes = System.Linq.Enumerable.FirstOrDefault(downloadResult.Values);
                        string ext = format == "xml" ? ".xml" : ".pdf";
                        string path = FolderControl.smmFolderPath + restItem.Uuid + ext;
                        FolderControl.writeFileOnDiskWithByte(downloadBytes, path);
                        System.Diagnostics.Process.Start(path);
                    }
                    return;
                }

                // SOAP item selected
                string uuid = tableGrid.SelectedRows[0].Cells[nameof(EI.SelfEmploymentReceipt.uuid)].Value.ToString();
                CONTENT_TYPE docType = CONTENT_TYPE.XML;

                if (rdViewHtml.Checked)
                {
                    string xmlContent = Singl.smmControllerGet.getSmmContentXml(uuid);
                    if (xmlContent != null)
                    {
                        FrmView previewInvoices = new FrmView(xmlContent, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts));
                        previewInvoices.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(Lang.cantGetContent);
                    }
                }
                else
                {
                    if (rdViewXml.Checked) docType = CONTENT_TYPE.XML;
                    else docType = CONTENT_TYPE.PDF;

                    byte[] content = Singl.smmControllerGet.getSmmWithType(uuid, docType);
                    if (content != null)
                    {
                        string path = FolderControl.smmFolderPath + uuid + "." + docType;
                        FolderControl.writeFileOnDiskWithByte(content, path);
                        System.Diagnostics.Process.Start(path);
                    }
                    else
                    {
                        MessageBox.Show(Lang.cantGetContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
