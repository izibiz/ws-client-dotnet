using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.COMMON.Language;
using System.Windows.Forms;
using System.Globalization;

namespace izibiz.UI
{
    public partial class FrmDespatch : Form
    {

        private string despactDirection;




        public FrmDespatch()
        {
            InitializeComponent();
        }


        private void FrmDespatch_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
        }



        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Lang.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lang.Culture = new CultureInfo("");
            }
            #region writeAllFormItem
            //eleman text yazdır
           
            #endregion
        }




        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //html goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconHtml,
                Name = EI.GridBtnClmName.previewHtml.ToString(),
                HeaderText = Lang.preview,
            });
        }


        private void FrmDespatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void selectPanelVisibilty(bool panelIncoming, bool panelSend, bool panelDraft)
        {
            pnlIncomingDespatch.Visible = panelIncoming;
            pnlSendDespatch.Visible = panelSend;
            pnlDraftDespatch.Visible = panelDraft;
        }




        private void itemIncomingInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.InvDirection.IN.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);


        }

        private void itemSentInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.InvDirection.OUT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);


        }

        private void itemDraftInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.InvDirection.DRAFT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);


        }

        private void itemTakeGibUsers_Click(object sender, EventArgs e)
        {
            despactDirection = EI.GibUser.GibUsers.ToString();
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);

        }



        private void itemListGibUserList_Click(object sender, EventArgs e)
        {
            despactDirection = EI.GibUser.GibUsers.ToString();
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);

        }






    }
}
