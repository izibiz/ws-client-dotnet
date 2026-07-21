using System.Drawing;

namespace izibiz.UI.Controls
{
    /// <summary>
    /// izibiz logosundaki gerçek üç renkten (mor, teal, yeşil) türetilmiş marka paleti.
    /// Tüm ekranlar bu sabitleri kullanır, böylece renk değişikliği tek yerden yönetilir.
    /// </summary>
    public static class BrandColors
    {
        public static readonly Color Purple = Color.FromArgb(90, 50, 77);
        public static readonly Color PurpleLight = Color.FromArgb(222, 214, 219);
        public static readonly Color PurpleHover = Color.FromArgb(115, 68, 99);

        public static readonly Color Teal = Color.FromArgb(24, 110, 97);
        public static readonly Color TealLight = Color.FromArgb(209, 226, 223);
        public static readonly Color TealHover = Color.FromArgb(32, 138, 122);

        public static readonly Color Green = Color.FromArgb(95, 130, 35);
        public static readonly Color GreenLight = Color.FromArgb(232, 241, 214);
        public static readonly Color GreenHover = Color.FromArgb(118, 160, 45);
        public static readonly Color GreenBright = Color.FromArgb(139, 187, 49);

        public static readonly Color SidebarDark = Color.FromArgb(32, 25, 30);
        public static readonly Color SidebarHover = Color.FromArgb(56, 43, 52);

        public static readonly Color PageBackground = Color.FromArgb(240, 247, 242);
        public static readonly Color CardBorder = Color.FromArgb(226, 232, 240);

        public static readonly Color Neutral = Color.FromArgb(71, 85, 105);
        public static readonly Color NeutralHover = Color.FromArgb(100, 116, 139);
        public static readonly Color NeutralDisabled = Color.FromArgb(190, 190, 190);
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);
        public static readonly Color TextDark = Color.FromArgb(30, 41, 59);

        public static readonly Color Danger = Color.FromArgb(185, 28, 28);
        public static readonly Color DangerHover = Color.FromArgb(220, 38, 38);
    }
}
