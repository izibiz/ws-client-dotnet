using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace izibiz.UI.Controls
{
    public static class RoundedPathHelper
    {
        public static GraphicsPath GetPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void ApplyRoundedRegion(Control control, int radius)
        {
            var rect = new Rectangle(0, 0, control.Width, control.Height);
            using (var path = GetPath(rect, radius))
            {
                control.Region = new Region(path);
            }
        }

        public static void DrawBorder(Graphics g, Rectangle rect, int radius, Color color)
        {
            using (var path = GetPath(rect, radius))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(color, 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    }
}
