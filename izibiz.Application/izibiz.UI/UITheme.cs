using System;
using System.Drawing;
using System.Windows.Forms;

namespace izibiz.UI
{
    public static class UITheme
    {
        public static Color PrimaryColor = ColorTranslator.FromHtml("#4F46E5");
        public static Color SecondaryColor = ColorTranslator.FromHtml("#10B981");
        public static Color SidebarColor = ColorTranslator.FromHtml("#1E293B");
        public static Color SidebarTextColor = ColorTranslator.FromHtml("#F8FAFC");
        public static Color BackgroundColor = ColorTranslator.FromHtml("#F1F5F9");
        public static Color PanelColor = Color.White;
        public static Color TextColor = ColorTranslator.FromHtml("#0F172A");
        
        public static Font MainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static Font BoldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static Font TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);

        public static void ApplyFlatButton(Button btn, bool isPrimary = true)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = isPrimary ? PrimaryColor : SecondaryColor;
            btn.ForeColor = Color.White;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplySidebarButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = SidebarColor;
            btn.ForeColor = SidebarTextColor;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            
            // Hover events
            btn.MouseEnter += (s, e) => { btn.BackColor = ColorTranslator.FromHtml("#334155"); };
            btn.MouseLeave += (s, e) => { btn.BackColor = SidebarColor; };
        }

        public static void ApplyDataGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = PanelColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E2E8F0");
            dgv.DefaultCellStyle.SelectionForeColor = TextColor;
            dgv.DefaultCellStyle.BackColor = PanelColor;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.Font = MainFont;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 40;

            // Header styling
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = BoldFont;
            dgv.ColumnHeadersHeight = 40;
        }
    }
}
