using System;
using System.Drawing;
using System.Windows.Forms;

namespace izibiz.UI.Controls
{
    /// <summary>
    /// Bir belgeyi görüntülemek/indirmek için format seçimi (PDF/HTML/XML) ve
    /// Görüntüle/İndir aksiyonlarını içeren yeniden kullanılabilir kart.
    /// XML seçiliyken Görüntüle otomatik devre dışı kalır (XML sadece indirilebilir).
    /// Yeni bir işlem/ürün eklerken bu kontrolü forma sürükleyip ViewRequested/DownloadRequested'ı dinlemek yeterli.
    /// </summary>
    public partial class DocumentActionsCard : UserControl
    {
        public event EventHandler<DocumentActionEventArgs> ViewRequested;
        public event EventHandler<DocumentActionEventArgs> DownloadRequested;

        private Color _borderColor = BrandColors.CardBorder;

        public DocumentActionsCard()
        {
            InitializeComponent();

            rdPdf.CheckedChanged += FormatOption_CheckedChanged;
            rdHtml.CheckedChanged += FormatOption_CheckedChanged;
            rdXml.CheckedChanged += FormatOption_CheckedChanged;

            btnView.Click += (s, e) => ViewRequested?.Invoke(this, new DocumentActionEventArgs(SelectedFormat));
            btnDownload.Click += (s, e) => DownloadRequested?.Invoke(this, new DocumentActionEventArgs(SelectedFormat));

            btnView.FlatAppearance.MouseOverBackColor = BrandColors.Neutral;
            HoverAnimator.Attach(btnView, BrandColors.Neutral, BrandColors.NeutralHover);

            btnDownload.FlatAppearance.MouseOverBackColor = BrandColors.Green;
            HoverAnimator.Attach(btnDownload, BrandColors.Green, BrandColors.GreenHover);

            HoverAnimator.AttachCustom(this, BrandColors.CardBorder, Color.FromArgb(148, 163, 184), c =>
            {
                _borderColor = c;
                Invalidate();
            });

            StyleFormatToggle(rdPdf);
            StyleFormatToggle(rdHtml);
            StyleFormatToggle(rdXml);
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

        /// <summary>Şu an seçili format: "pdf", "html" veya "xml".</summary>
        public string SelectedFormat
        {
            get
            {
                if (rdHtml.Checked) return "html";
                if (rdXml.Checked) return "xml";
                return "pdf";
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            RoundedPathHelper.ApplyRoundedRegion(this, 16);
            RoundedPathHelper.ApplyRoundedRegion(btnView, 10);
            RoundedPathHelper.ApplyRoundedRegion(btnDownload, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdPdf, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdHtml, 10);
            RoundedPathHelper.ApplyRoundedRegion(rdXml, 10);
        }

        private void DocumentActionsCard_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            RoundedPathHelper.DrawBorder(e.Graphics, rect, 16, _borderColor);
        }

        private void FormatOption_CheckedChanged(object sender, EventArgs e)
        {
            StyleFormatToggle(rdPdf);
            StyleFormatToggle(rdHtml);
            StyleFormatToggle(rdXml);

            if (rdXml.Checked)
            {
                btnView.Enabled = false;
                btnView.BackColor = BrandColors.NeutralDisabled;
            }
            else
            {
                btnView.Enabled = true;
                btnView.BackColor = BrandColors.Neutral;
            }
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
