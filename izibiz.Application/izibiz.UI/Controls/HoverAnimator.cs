using System.Drawing;
using System.Windows.Forms;

namespace izibiz.UI.Controls
{
    /// <summary>
    /// Bir kontrolün BackColor'ını fare üzerine gelip ayrılırken anlık değil,
    /// yumuşak (animasyonlu) bir geçişle değiştirir. Native FlatAppearance.MouseOverBackColor
    /// ile çakışmaması için o özelliği kullanan kontrollerde MouseOverBackColor'ı normalColor'a eşitleyin.
    /// </summary>
    public static class HoverAnimator
    {
        /// <summary>
        /// Bir kontrolün üzerine gelip ayrılırken, verilen callback'e yumuşak geçişli renk değerleri gönderir.
        /// BackColor dışında (örn. kenarlık rengi gibi) özel bir görsel özelliği animasyonlu değiştirmek için kullanılır.
        /// </summary>
        public static void AttachCustom(Control triggerControl, Color normalColor, Color hoverColor, System.Action<Color> onColorChanged)
        {
            var timer = new Timer { Interval = 15 };
            Color from = normalColor;
            Color to = normalColor;
            float progress = 0f;

            timer.Tick += (s, e) =>
            {
                progress += 0.18f;
                if (progress >= 1f)
                {
                    progress = 1f;
                    timer.Stop();
                }
                onColorChanged(Lerp(from, to, progress));
            };

            triggerControl.MouseEnter += (s, e) =>
            {
                from = normalColor;
                to = hoverColor;
                progress = 0f;
                timer.Start();
            };

            triggerControl.MouseLeave += (s, e) =>
            {
                from = hoverColor;
                to = normalColor;
                progress = 0f;
                timer.Start();
            };

            triggerControl.Disposed += (s, e) => timer.Dispose();
        }

        public static void Attach(Control control, Color normalColor, Color hoverColor)
        {
            var timer = new Timer { Interval = 15 };
            Color from = normalColor;
            Color to = normalColor;
            float progress = 0f;

            timer.Tick += (s, e) =>
            {
                progress += 0.18f;
                if (progress >= 1f)
                {
                    progress = 1f;
                    timer.Stop();
                }
                control.BackColor = Lerp(from, to, progress);
            };

            control.MouseEnter += (s, e) =>
            {
                from = control.BackColor;
                to = hoverColor;
                progress = 0f;
                timer.Start();
            };

            control.MouseLeave += (s, e) =>
            {
                from = control.BackColor;
                to = normalColor;
                progress = 0f;
                timer.Start();
            };

            control.Disposed += (s, e) => timer.Dispose();
        }

        private static Color Lerp(Color a, Color b, float t)
        {
            int r = (int)(a.R + (b.R - a.R) * t);
            int g = (int)(a.G + (b.G - a.G) * t);
            int bl = (int)(a.B + (b.B - a.B) * t);
            return Color.FromArgb(r, g, bl);
        }
    }
}
