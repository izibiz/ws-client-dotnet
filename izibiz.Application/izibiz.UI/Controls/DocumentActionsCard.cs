using System;
using System.Drawing;
using System.Windows.Forms;

namespace izibiz.UI.Controls
{
    /// <summary>
    /// Bir belgeyi görüntülemek/indirmek için ayrı ayrı format seçimi (Görüntüle: PDF/HTML,
    /// İndir: PDF/HTML/XML) ve Görüntüle/İndir aksiyonlarını içeren yeniden kullanılabilir kart.
    /// XML sadece indirme grubunda bulunur; görüntüleme grubunda hiç sunulmaz.
    /// Yeni bir işlem/ürün eklerken bu kontrolü forma sürükleyip ViewRequested/DownloadRequested'ı dinlemek yeterli.
    /// </summary>
    public enum DocumentCardMode
    {
        ViewDownload,
        AssignNumber
    }

    public partial class DocumentActionsCard : UserControl
    {
        public event EventHandler<DocumentActionEventArgs> ViewRequested;
        public event EventHandler<DocumentActionEventArgs> DownloadRequested;
        public event EventHandler CancelRequested;
        public event EventHandler<string> AssignNumberRequested;

        private DocumentCardMode _cardMode = DocumentCardMode.ViewDownload;

        private Color _borderColor = Color.Transparent;
        private ContextMenuStrip _ctxDownload;
        private ContextMenuStrip _ctxAssignNumber;

        public DocumentActionsCard()
        {
            InitializeComponent();

            _ctxDownload = new ContextMenuStrip();
            _ctxDownload.Items.Add("PDF").Click += (s, e) => { SelectedDownloadFormat = "pdf"; DownloadRequested?.Invoke(this, new DocumentActionEventArgs(SelectedDownloadFormat)); };
            _ctxDownload.Items.Add("HTML").Click += (s, e) => { SelectedDownloadFormat = "html"; DownloadRequested?.Invoke(this, new DocumentActionEventArgs(SelectedDownloadFormat)); };
            _ctxDownload.Items.Add("XML").Click += (s, e) => { SelectedDownloadFormat = "xml"; DownloadRequested?.Invoke(this, new DocumentActionEventArgs(SelectedDownloadFormat)); };

            rdViewPdf.CheckedChanged += FormatOption_CheckedChanged;
            rdViewHtml.CheckedChanged += FormatOption_CheckedChanged;
            rdDownloadPdf.CheckedChanged += FormatOption_CheckedChanged;
            rdDownloadHtml.CheckedChanged += FormatOption_CheckedChanged;
            rdDownloadXml.CheckedChanged += FormatOption_CheckedChanged;

            btnView.Click += (s, e) => ViewRequested?.Invoke(this, new DocumentActionEventArgs(SelectedViewFormat));
            btnDownload.Click += (s, e) => _ctxDownload.Show(btnDownload, new Point(0, btnDownload.Height));
            btnCancel.Click += (s, e) => CancelRequested?.Invoke(this, EventArgs.Empty);

            _ctxAssignNumber = new ContextMenuStrip();
            btnAssignNumber.Click += (s, e) => _ctxAssignNumber.Show(btnAssignNumber, new Point(0, btnAssignNumber.Height));

            btnView.FlatAppearance.MouseOverBackColor = BrandColors.Neutral;
            HoverAnimator.Attach(btnView, BrandColors.Neutral, BrandColors.NeutralHover);

            btnDownload.FlatAppearance.MouseOverBackColor = BrandColors.Green;
            HoverAnimator.Attach(btnDownload, BrandColors.Green, BrandColors.GreenHover);

            btnCancel.BackColor = Color.FromArgb(249, 115, 22);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 88, 12);
            HoverAnimator.Attach(btnCancel, Color.FromArgb(249, 115, 22), Color.FromArgb(234, 88, 12));

            btnAssignNumber.BackColor = Color.FromArgb(234, 179, 8); // Amber-500
            btnAssignNumber.FlatAppearance.MouseOverBackColor = Color.FromArgb(202, 138, 4); // Amber-600
            HoverAnimator.Attach(btnAssignNumber, Color.FromArgb(234, 179, 8), Color.FromArgb(202, 138, 4));

            // Prefix combosunu gizle ve butonu kaydır
            cmbPrefix.Visible = false;
            btnAssignNumber.Location = new Point(0, 0);
            btnAssignNumber.Size = new Size(130, 40);
            btnAssignNumber.Text = "Numara Ata ˅";

            // Remove custom border for toolbar style
            // RestyleAllToggles();
        }

        public string TitleText
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string DescriptionText
        {
            get => lblDesc.Text;
            set => lblDesc.Text = value;
        }

        public bool ViewButtonEnabled
        {
            get => btnView.Enabled;
            set
            {
                btnView.Enabled = value;
                btnView.BackColor = value ? BrandColors.CardBorder : Color.LightGray;
            }
        }

        public bool DownloadButtonEnabled
        {
            get => btnDownload.Enabled;
            set
            {
                btnDownload.Enabled = value;
            }
        }

        public bool CancelButtonEnabled
        {
            get => btnCancel.Visible;
            set
            {
                btnCancel.Visible = value;
            }
        }

        public DocumentCardMode CardMode
        {
            get => _cardMode;
            set
            {
                _cardMode = value;
                UpdateModeVisibility();
            }
        }

        public void SetPrefixes(string[] prefixes)
        {
            _ctxAssignNumber.Items.Clear();
            if (prefixes != null)
            {
                foreach (var prefix in prefixes)
                {
                    _ctxAssignNumber.Items.Add(prefix).Click += (s, e) => AssignNumberRequested?.Invoke(this, prefix);
                }
            }
        }

        private void UpdateModeVisibility()
        {
            bool isAssign = _cardMode == DocumentCardMode.AssignNumber;

            pnlAssignNumber.Visible = isAssign;

            // pnlAssignNumber'ı iptal butonunun yanına yerleştir (105 + 130 + 10 = 245)
            pnlAssignNumber.Location = new Point(btnCancel.Right + 10, 0);

            // Görüntüle/İndir/İptal butonları her iki modda da görünür olmalı!
            btnView.Visible = false; // Toolbar stilinde ayrı Görüntüle butonu yerine sadece indir/iptal kullanılıyor
            pnlViewFormats.Visible = false;
            pnlDownloadFormats.Visible = false;
            lblViewHeader.Visible = false;
            lblDownloadHeader.Visible = false;
            lblCancelHeader.Visible = false;
            
            btnDownload.Visible = true;
            btnCancel.Visible = true;
        }

        /// <summary>Görüntüleme için seçili format: "pdf" veya "html".</summary>
        public string SelectedViewFormat => rdViewHtml.Checked ? "html" : "pdf";

        /// <summary>İndirme için seçili format: "pdf", "html" veya "xml".</summary>
        public string SelectedDownloadFormat { get; private set; } = "pdf";

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            RoundedPathHelper.ApplyRoundedRegion(this, 16);
            RoundedPathHelper.ApplyRoundedRegion(btnView, 10);
            RoundedPathHelper.ApplyRoundedRegion(btnDownload, 10);
            RoundedPathHelper.ApplyRoundedRegion(btnCancel, 10);
            RoundedPathHelper.ApplyRoundedRegion(btnAssignNumber, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdViewPdf, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdViewHtml, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdDownloadPdf, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdDownloadHtml, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdDownloadXml, 10);
        }

        private void DocumentActionsCard_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            RoundedPathHelper.DrawBorder(e.Graphics, rect, 16, _borderColor);

            if (_cardMode == DocumentCardMode.ViewDownload)
            {
                // Görüntüle/İndir/Sil bölümlerini ayıran ince dikey çizgiler.
                int dividerX1 = pnlDownloadFormats.Left - 20;
                int dividerX2 = lblCancelHeader.Left - 20;
                e.Graphics.DrawLine(new Pen(BrandColors.CardBorder), dividerX1, 90, dividerX1, 222);
                e.Graphics.DrawLine(new Pen(BrandColors.CardBorder), dividerX2, 90, dividerX2, 222);
            }
        }

        private void FormatOption_CheckedChanged(object sender, EventArgs e)
        {
            RestyleAllToggles();
        }

        private void RestyleAllToggles()
        {
            StyleFormatToggle(rdViewPdf);
            StyleFormatToggle(rdViewHtml);
            StyleFormatToggle(rdDownloadPdf);
            StyleFormatToggle(rdDownloadHtml);
            StyleFormatToggle(rdDownloadXml);
        }

        private static void StyleFormatToggle(RadioButton rb)
        {
            if (rb.Checked)
            {
                rb.BackColor = BrandColors.Teal;
                rb.ForeColor = Color.White;
            }
            else
            {
                rb.BackColor = BrandColors.CardBorder;
                rb.ForeColor = BrandColors.TextMuted;
            }
        }
    }
}
