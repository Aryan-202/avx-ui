using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FileConverterUI.UI.CoreUI;

namespace FileConverterUI.UI.Controls
{
    public class IndustrialButton : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPrimary { get; set; }

        public IndustrialButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = ThemeManager.ButtonFont;
            this.Cursor = Cursors.Hand;
            this.Resize += (s, e) => Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color bgColor = IsPrimary ? ColorPalette.PrimaryAccent : ColorPalette.Surface;
            Color borderColor = IsPrimary ? ColorPalette.PrimaryAccentHover : ColorPalette.Border;
            Color textColor = IsPrimary ? Color.White : ColorPalette.TextPrimary;

            // Hover states
            Point mousePos = this.PointToClient(Cursor.Position);
            bool isHovered = this.ClientRectangle.Contains(mousePos);

            if (isHovered)
            {
                bgColor = IsPrimary ? ColorPalette.PrimaryAccentHover : ColorPalette.SurfaceElevated;
            }

            using (var brush = new SolidBrush(bgColor))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            using (var pen = new Pen(borderColor, 1))
            {
                Rectangle rect = this.ClientRectangle;
                rect.Width -= 1; rect.Height -= 1;
                g.DrawRectangle(pen, rect);
            }

            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
