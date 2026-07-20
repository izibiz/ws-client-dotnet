using System;
using System.Drawing;
using System.Windows.Forms;

namespace izibiz.UI.Controls
{
    /// <summary>
    /// Bir veri kaynağını (SOAP, REST, vs.) temsil eden, "çek" butonu içeren yeniden kullanılabilir kart.
    /// Yeni bir ürüne aynı kartı eklemek için sadece bu kontrolü forma sürükleyip özelliklerini
    /// (Title, AccentColor, IconGlyph, Description, ButtonText) ayarlamak ve FetchClicked'ı dinlemek yeterli.
    /// </summary>
    public partial class SourceCard : UserControl
    {
        public event EventHandler FetchClicked;

        private Color _borderColor = Color.FromArgb(226, 232, 240);

        public SourceCard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            btnFetch.Click += (s, e) => FetchClicked?.Invoke(this, EventArgs.Empty);

            HoverAnimator.AttachCustom(this, Color.FromArgb(226, 232, 240), Color.FromArgb(148, 163, 184), c =>
            {
                _borderColor = c;
                Invalidate();
            });
        }

        public string TitleText
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string IconGlyph
        {
            get => lblIcon.Text;
            set => lblIcon.Text = value;
        }

        public string DescriptionText
        {
            get => lblDesc.Text;
            set => lblDesc.Text = value;
        }

        public string ButtonText
        {
            get => btnFetch.Text;
            set => btnFetch.Text = value;
        }

        public Color AccentColor
        {
            get => lblTitle.ForeColor;
            set
            {
                lblTitle.ForeColor = value;
                btnFetch.BackColor = value;
                // Native anlık hover yerine yumuşak geçişli animasyonu kullanıyoruz.
                btnFetch.FlatAppearance.MouseOverBackColor = value;
                HoverAnimator.Attach(btnFetch, value, ControlPaint.Light(value, 0.2f));
            }
        }

        public Color IconTintColor
        {
            get => lblIcon.ForeColor;
            set => lblIcon.ForeColor = value;
        }

        public bool FetchButtonVisible
        {
            get => btnFetch.Visible;
            set => btnFetch.Visible = value;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            RoundedPathHelper.ApplyRoundedRegion(this, 16);
            RoundedPathHelper.ApplyRoundedRegion(btnFetch, 10);
        }

        private void SourceCard_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            RoundedPathHelper.DrawBorder(e.Graphics, rect, 16, _borderColor);
        }
    }
}
