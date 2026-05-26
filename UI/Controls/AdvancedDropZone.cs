using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FileConverterUI.UI.CoreUI;

namespace FileConverterUI.UI.Controls
{
    public class AdvancedDropZone : Panel
    {
        public AdvancedDropZone()
        {
            this.DoubleBuffered = true;
            this.BackColor = ColorPalette.Background;
            this.Padding = new Padding(20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-2, -2); 

            using (SolidBrush brush = new SolidBrush(ColorPalette.Surface))
            {
                g.FillRectangle(brush, rect);
            }

            using (Pen pen = new Pen(ColorPalette.BorderHighlight, 2))
            {
                pen.DashStyle = DashStyle.Dash;
                pen.DashPattern = new float[] { 5, 5 };
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
