using System.Drawing;

namespace FileConverterUI.UI.CoreUI
{
    public static class ColorPalette
    {
        // Dark steel, industrial Adobe/Autodesk aesthetic
        public static readonly Color Background = Color.FromArgb(26, 26, 29); // Almost black
        public static readonly Color Surface = Color.FromArgb(36, 36, 40); // Dark gray
        public static readonly Color SurfaceElevated = Color.FromArgb(46, 46, 50); // Lighter gray
        public static readonly Color TextPrimary = Color.FromArgb(240, 240, 240);
        public static readonly Color TextSecondary = Color.FromArgb(150, 150, 150);
        
        public static readonly Color PrimaryAccent = Color.FromArgb(232, 93, 4); // Industrial Orange
        public static readonly Color PrimaryAccentHover = Color.FromArgb(250, 110, 20);
        public static readonly Color PrimaryAccentPressed = Color.FromArgb(200, 80, 0);

        public static readonly Color SecondaryAccent = Color.FromArgb(0, 180, 216); // Cyan
        
        public static readonly Color Border = Color.FromArgb(60, 60, 65);
        public static readonly Color BorderHighlight = Color.FromArgb(100, 100, 105);

        public static readonly Color TitleBar = Color.FromArgb(20, 20, 22);
        public static readonly Color WindowShadow = Color.FromArgb(0, 0, 0);
    }
}
