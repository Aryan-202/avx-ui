using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileConverterUI.UI
{
    public static class Theme
    {
        // Industrial Color Palette
        public static readonly Color Background = Color.FromArgb(20, 20, 22); // Deep matte black/steel
        public static readonly Color PanelBackground = Color.FromArgb(34, 34, 38); // Dark steel
        public static readonly Color TextPrimary = Color.FromArgb(230, 230, 230); // Off-white for readability
        public static readonly Color TextSecondary = Color.FromArgb(170, 170, 170); // Dimmer text
        public static readonly Color PrimaryAccent = Color.FromArgb(255, 140, 0); // Safety Orange
        public static readonly Color SecondaryAccent = Color.FromArgb(0, 188, 212); // Cyan terminal look
        public static readonly Color SuccessColor = Color.FromArgb(76, 175, 80); // Terminal green
        public static readonly Color InputBackground = Color.FromArgb(15, 15, 18); // Very dark for inputs
        public static readonly Color BorderColor = Color.FromArgb(80, 80, 80); // Distinct borders

        // Utilitarian Fonts
        public static readonly Font TitleFont = new Font("Consolas", 20f, FontStyle.Bold);
        public static readonly Font PrimaryFont = new Font("Consolas", 10.5f, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Consolas", 11.5f, FontStyle.Bold);

        public static void ApplyToForm(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = TextPrimary;
            form.Font = PrimaryFont;
            form.ShowIcon = false;
        }

        public static void StylePanel(Panel panel, bool isHeader = false, bool isBottom = false)
        {
            panel.BackColor = PanelBackground;
            
            if (isHeader)
            {
                panel.Paint += (s, e) =>
                {
                    // Draw industrial orange accent line at the bottom of the header
                    using (var brush = new SolidBrush(PrimaryAccent))
                    {
                        e.Graphics.FillRectangle(brush, 0, panel.Height - 4, panel.Width, 4);
                    }
                };
            }
            if (isBottom)
            {
                panel.Paint += (s, e) =>
                {
                    // Draw industrial orange accent line at the top of the bottom panel
                    using (var brush = new SolidBrush(BorderColor))
                    {
                        e.Graphics.FillRectangle(brush, 0, 0, panel.Width, 2);
                    }
                };
            }
        }

        public static void StyleButton(Button btn, bool isConvertButton = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = isConvertButton ? PrimaryAccent : BorderColor;
            btn.BackColor = isConvertButton ? Color.FromArgb(40, 25, 0) : PanelBackground;
            btn.ForeColor = isConvertButton ? PrimaryAccent : TextPrimary;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;

            // Hover effects
            btn.MouseEnter += (s, e) => {
                btn.BackColor = isConvertButton ? PrimaryAccent : BorderColor;
                btn.ForeColor = isConvertButton ? Color.Black : Color.White;
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = isConvertButton ? Color.FromArgb(40, 25, 0) : PanelBackground;
                btn.ForeColor = isConvertButton ? PrimaryAccent : TextPrimary;
            };
        }

        public static void StyleLabel(Label lbl, bool isTitle = false, bool isSecondary = false)
        {
            lbl.ForeColor = isTitle ? PrimaryAccent : (isSecondary ? TextSecondary : TextPrimary);
            lbl.BackColor = Color.Transparent;
            if (isTitle) lbl.Font = TitleFont;
        }

        public static void StyleCheckBox(CheckBox chk)
        {
            chk.ForeColor = TextPrimary;
            chk.BackColor = Color.Transparent;
            chk.Font = PrimaryFont;
            chk.Cursor = Cursors.Hand;
        }

        public static void StyleTextBox(TextBox txt)
        {
            txt.BackColor = InputBackground;
            txt.ForeColor = SecondaryAccent; // Cyan text for inputs looks industrial/terminal
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = PrimaryFont;
        }

        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.BackColor = InputBackground;
            cmb.ForeColor = SecondaryAccent;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = PrimaryFont;
            cmb.Cursor = Cursors.Hand;
        }

        public static void StyleListBox(ListBox lb)
        {
            lb.BackColor = InputBackground;
            lb.ForeColor = SecondaryAccent; // Cyan for files
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.Font = PrimaryFont;
        }
        
        public static void StyleProgressBar(ProgressBar pb)
        {
            pb.BackColor = InputBackground;
            pb.ForeColor = PrimaryAccent;
        }
    }
}
