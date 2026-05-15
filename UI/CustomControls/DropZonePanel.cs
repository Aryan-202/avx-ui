using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FileConverterUI.UI.CustomControls
{
    public class DropZonePanel : Panel
    {
        public DropZonePanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Draw industrial dashed border indicating it's a drop zone
            using (Pen pen = new Pen(Theme.BorderColor, 2))
            {
                pen.DashStyle = DashStyle.Dash;
                pen.DashPattern = new float[] { 6, 6 };
                
                Rectangle rect = this.ClientRectangle;
                rect.Inflate(-2, -2); // Padding inside the panel
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
