using System.Drawing;
using System.Windows.Forms;
using FileConverterUI.UI.Controls;
using FileConverterUI.UI.CoreUI;

namespace FileConverterUI.UI.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private CustomTitleBar titleBar;
        private ComboBox cmbConversionType;
        private IndustrialButton btnSelectFiles;
        private IndustrialButton btnConvert;
        private ListBox listBoxFiles;
        private ProgressBar progressBar;
        private Label lblStatus;
        private CheckBox chkOverwrite;
        private CheckBox chkKeepOriginal;
        private TextBox txtOutputFolder;
        private IndustrialButton btnBrowseOutput;
        private AdvancedDropZone pnlFileDrop;
        private Panel pnlContent;
        private Panel pnlOptions;
        private Panel pnlSettings;
        private Panel pnlBottom;
        private Label lblOutput;
        private Label lblConversionType;

        private void InitializeComponent()
        {
            this.cmbConversionType = new System.Windows.Forms.ComboBox();
            this.btnSelectFiles = new IndustrialButton();
            this.btnConvert = new IndustrialButton();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.chkKeepOriginal = new System.Windows.Forms.CheckBox();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new IndustrialButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblConversionType = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlFileDrop = new AdvancedDropZone();
            this.pnlBottom = new System.Windows.Forms.Panel();
            
            this.titleBar = new CustomTitleBar(this, "AVX Converter Enterprise");

            this.pnlContent.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlFileDrop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 750);
            this.MinimumSize = new System.Drawing.Size(750, 550);
            this.Name = "MainForm";
            this.Text = "AVX File Converter";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = ColorPalette.Background;
            this.ForeColor = ColorPalette.TextPrimary;
            this.Font = ThemeManager.PrimaryFont;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AllowDrop = true;

            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 120;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBottom.BackColor = ColorPalette.Surface;

            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Height = 10;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.BackColor = ColorPalette.SurfaceElevated;
            
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Height = 30;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.ForeColor = ColorPalette.TextSecondary;
            this.lblStatus.Font = ThemeManager.PrimaryFont;

            // 
            // btnConvert
            // 
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Text = "START CONVERSION";
            this.btnConvert.IsPrimary = true;

            this.pnlBottom.Controls.Add(this.btnConvert);
            this.pnlBottom.Controls.Add(this.lblStatus);
            this.pnlBottom.Controls.Add(this.progressBar);

            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.BackColor = ColorPalette.Background;

            // 
            // pnlOptions
            // 
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Height = 80;
            
            // 
            // lblConversionType
            // 
            this.lblConversionType.Text = "Conversion Type:";
            this.lblConversionType.Location = new System.Drawing.Point(0, 5);
            this.lblConversionType.AutoSize = true;
            this.lblConversionType.ForeColor = ColorPalette.TextPrimary;

            // 
            // cmbConversionType
            // 
            this.cmbConversionType.Location = new System.Drawing.Point(0, 25);
            this.cmbConversionType.Size = new System.Drawing.Size(300, 30);
            this.cmbConversionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConversionType.Font = ThemeManager.MonospaceFont;
            this.cmbConversionType.BackColor = ColorPalette.Surface;
            this.cmbConversionType.ForeColor = ColorPalette.SecondaryAccent;
            this.cmbConversionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // 
            // lblOutput
            // 
            this.lblOutput.Text = "Output Directory:";
            this.lblOutput.Location = new System.Drawing.Point(320, 5);
            this.lblOutput.AutoSize = true;
            this.lblOutput.ForeColor = ColorPalette.TextPrimary;

            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(320, 25);
            this.txtOutputFolder.Size = new System.Drawing.Size(350, 30);
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Font = ThemeManager.MonospaceFont;
            this.txtOutputFolder.BackColor = ColorPalette.Surface;
            this.txtOutputFolder.ForeColor = ColorPalette.SecondaryAccent;
            this.txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(680, 24);
            this.btnBrowseOutput.Size = new System.Drawing.Size(120, 27);
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Text = "BROWSE";
            this.btnBrowseOutput.IsPrimary = false;

            this.pnlOptions.Controls.Add(this.lblConversionType);
            this.pnlOptions.Controls.Add(this.cmbConversionType);
            this.pnlOptions.Controls.Add(this.lblOutput);
            this.pnlOptions.Controls.Add(this.txtOutputFolder);
            this.pnlOptions.Controls.Add(this.btnBrowseOutput);

            // 
            // pnlSettings
            // 
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Height = 40;
            
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.Text = "Overwrite existing files";
            this.chkOverwrite.Location = new System.Drawing.Point(0, 10);
            this.chkOverwrite.AutoSize = true;

            // 
            // chkKeepOriginal
            // 
            this.chkKeepOriginal.Text = "Keep original files";
            this.chkKeepOriginal.Location = new System.Drawing.Point(180, 10);
            this.chkKeepOriginal.AutoSize = true;
            this.chkKeepOriginal.Checked = true;

            this.pnlSettings.Controls.Add(this.chkOverwrite);
            this.pnlSettings.Controls.Add(this.chkKeepOriginal);

            // 
            // pnlFileDrop
            // 
            this.pnlFileDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFileDrop.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectFiles.Height = 40;
            this.btnSelectFiles.Text = "ADD FILES OR DRAG HERE";
            this.btnSelectFiles.IsPrimary = false;

            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Font = ThemeManager.MonospaceFont;
            this.listBoxFiles.BackColor = ColorPalette.Surface;
            this.listBoxFiles.ForeColor = ColorPalette.SecondaryAccent;
            this.listBoxFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFiles.IntegralHeight = false;

            System.Windows.Forms.Panel pnlSpacer = new System.Windows.Forms.Panel();
            pnlSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSpacer.Height = 10;
            
            this.pnlFileDrop.Controls.Add(this.listBoxFiles);
            this.pnlFileDrop.Controls.Add(pnlSpacer);
            this.pnlFileDrop.Controls.Add(this.btnSelectFiles);

            // 
            // Assemble Form
            // 
            this.pnlContent.Controls.Add(this.pnlFileDrop);
            this.pnlContent.Controls.Add(this.pnlSettings);
            this.pnlContent.Controls.Add(this.pnlOptions);
            
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.titleBar);

            this.pnlContent.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlFileDrop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
