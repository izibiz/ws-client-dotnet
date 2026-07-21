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
    public partial class DocumentActionsCard : UserControl
    {
        public event EventHandler<DocumentActionEventArgs> ViewRequested;
        public event EventHandler<DocumentActionEventArgs> DownloadRequested;
        public event EventHandler CancelRequested;

        private Color _borderColor = BrandColors.CardBorder;

        public DocumentActionsCard()
        {
            InitializeComponent();

            rdViewPdf.CheckedChanged += FormatOption_CheckedChanged;
            rdViewHtml.CheckedChanged += FormatOption_CheckedChanged;
            rdDownloadPdf.CheckedChanged += FormatOption_CheckedChanged;
            rdDownloadHtml.CheckedChanged += FormatOption_CheckedChanged;
            rdDownloadXml.CheckedChanged += FormatOption_CheckedChanged;

            btnView.Click += (s, e) => ViewRequested?.Invoke(this, new DocumentActionEventArgs(SelectedViewFormat));
            btnDownload.Click += (s, e) => DownloadRequested?.Invoke(this, new DocumentActionEventArgs(SelectedDownloadFormat));
            btnCancel.Click += (s, e) => CancelRequested?.Invoke(this, EventArgs.Empty);

            btnView.FlatAppearance.MouseOverBackColor = BrandColors.Neutral;
            HoverAnimator.Attach(btnView, BrandColors.Neutral, BrandColors.NeutralHover);

            btnDownload.FlatAppearance.MouseOverBackColor = BrandColors.Green;
            HoverAnimator.Attach(btnDownload, BrandColors.Green, BrandColors.GreenHover);

            btnCancel.FlatAppearance.MouseOverBackColor = BrandColors.Danger;
            HoverAnimator.Attach(btnCancel, BrandColors.Danger, BrandColors.DangerHover);

            HoverAnimator.AttachCustom(this, BrandColors.CardBorder, Color.FromArgb(148, 163, 184), c =>
            {
                _borderColor = c;
                Invalidate();
            });

            RestyleAllToggles();
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

        public bool CancelButtonEnabled
        {
            get => btnCancel.Enabled;
            set
            {
                btnCancel.Enabled = value;
                btnCancel.BackColor = value ? BrandColors.CardBorder : Color.LightGray;
            }
        }

        /// <summary>Görüntüleme için seçili format: "pdf" veya "html".</summary>
        public string SelectedViewFormat => rdViewHtml.Checked ? "html" : "pdf";

        /// <summary>İndirme için seçili format: "pdf", "html" veya "xml".</summary>
        public string SelectedDownloadFormat
        {
            get
            {
                if (rdDownloadHtml.Checked) return "html";
                if (rdDownloadXml.Checked) return "xml";
                return "pdf";
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            RoundedPathHelper.ApplyRoundedRegion(this, 16);
            RoundedPathHelper.ApplyRoundedRegion(btnView, 10);
            RoundedPathHelper.ApplyRoundedRegion(btnDownload, 10);
            RoundedPathHelper.ApplyRoundedRegion(btnCancel, 10);
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

            // Görüntüle/İndir/Sil bölümlerini ayıran ince dikey çizgiler.
            int dividerX1 = pnlDownloadFormats.Left - 20;
            int dividerX2 = lblCancelHeader.Left - 20;
            e.Graphics.DrawLine(new Pen(BrandColors.CardBorder), dividerX1, 90, dividerX1, 222);
            e.Graphics.DrawLine(new Pen(BrandColors.CardBorder), dividerX2, 90, dividerX2, 222);
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
