using System;
using System.Drawing;
using System.Windows.Forms;
using FileConverterUI.UI.CoreUI;
using FileConverterUI.UI.Utilities;

namespace FileConverterUI.UI.Controls
{
    public class CustomTitleBar : Panel
    {
        private Label lblTitle;
        private Button btnClose;
        private Button btnMaximize;
        private Button btnMinimize;
        private Form _parentForm;

        public CustomTitleBar(Form parentForm, string title)
        {
            _parentForm = parentForm;
            this.Height = 32;
            this.Dock = DockStyle.Top;
            this.BackColor = ColorPalette.TitleBar;

            WindowDragger.Attach(this, _parentForm);

            lblTitle = new Label
            {
                Text = title,
                ForeColor = ColorPalette.TextSecondary,
                Font = ThemeManager.PrimaryFont,
                AutoSize = true,
                Location = new Point(10, 8),
                BackColor = Color.Transparent
            };
            WindowDragger.Attach(lblTitle, _parentForm);

            btnClose = CreateTitleBarButton("X");
            btnClose.Click += (s, e) => _parentForm.Close();
            btnClose.MouseEnter += (s, e) => { btnClose.BackColor = Color.FromArgb(232, 17, 35); btnClose.ForeColor = Color.White; };
            btnClose.MouseLeave += (s, e) => { btnClose.BackColor = ColorPalette.TitleBar; btnClose.ForeColor = ColorPalette.TextSecondary; };

            btnMaximize = CreateTitleBarButton("🗖");
            btnMaximize.Click += (s, e) => 
            {
                _parentForm.WindowState = _parentForm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            };

            btnMinimize = CreateTitleBarButton("—");
            btnMinimize.Click += (s, e) => _parentForm.WindowState = FormWindowState.Minimized;

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnClose);
            this.Controls.Add(btnMaximize);
            this.Controls.Add(btnMinimize);
        }

        private Button CreateTitleBarButton(string text)
        {
            var btn = new Button
            {
                Text = text,
                Dock = DockStyle.Right,
                Width = 46,
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorPalette.TitleBar,
                ForeColor = ColorPalette.TextSecondary,
                Font = new Font("Segoe UI", 9f),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => { btn.BackColor = ColorPalette.SurfaceElevated; btn.ForeColor = ColorPalette.TextPrimary; };
            btn.MouseLeave += (s, e) => { btn.BackColor = ColorPalette.TitleBar; btn.ForeColor = ColorPalette.TextSecondary; };
            return btn;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(ColorPalette.Border))
            {
                e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
            }
        }
    }
}
