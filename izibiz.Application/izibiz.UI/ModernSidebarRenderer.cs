using System.Drawing;
using System.Windows.Forms;
using izibiz.UI.Controls;

namespace izibiz.UI
{
    public class ModernSidebarRenderer : ToolStripProfessionalRenderer
    {
        public ModernSidebarRenderer() : base(new ModernSidebarColors())
        {
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BrandColors.SidebarDark), e.AffectedBounds);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var bounds = new Rectangle(Point.Empty, e.Item.Size);

            using (var brush = new SolidBrush(BrandColors.SidebarDark))
            {
                e.Graphics.FillRectangle(brush, bounds);
            }

            bool active = e.Item.Selected || e.Item.Pressed;
            var pillRect = new Rectangle(bounds.X + 14, bounds.Y + 4, bounds.Width - 28, bounds.Height - 8);

            using (var path = RoundedPathHelper.GetPath(pillRect, pillRect.Height))
            using (var brush = new SolidBrush(active ? BrandColors.Teal : BrandColors.SidebarHover))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // Sidebar'da icon marjı kullanılmıyor, boş bırakılıyor.
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Kenarlık çizmiyoruz, düz/modern görünüm için.
        }
    }

    internal class ModernSidebarColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected => BrandColors.Teal;
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuBorder => BrandColors.SidebarDark;
        public override Color ToolStripDropDownBackground => BrandColors.SidebarDark;
        public override Color ImageMarginGradientBegin => BrandColors.SidebarDark;
        public override Color ImageMarginGradientMiddle => BrandColors.SidebarDark;
        public override Color ImageMarginGradientEnd => BrandColors.SidebarDark;
    }
}
