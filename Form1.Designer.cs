namespace FileConverterUI
{
    partial class Form1
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

        private System.Windows.Forms.ComboBox cmbConversionType;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkKeepOriginal;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlSettings;
        private FileConverterUI.UI.CustomControls.DropZonePanel pnlFileDrop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblConversionType;

        private void InitializeComponent()
        {
            this.cmbConversionType = new System.Windows.Forms.ComboBox();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.chkKeepOriginal = new System.Windows.Forms.CheckBox();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblConversionType = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlFileDrop = new FileConverterUI.UI.CustomControls.DropZonePanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlFileDrop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Form1";
            this.Text = "AVX File Converter";
            this.AllowDrop = true;
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);

            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Name = "pnlHeader";
            
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "AVX Converter";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Name = "lblTitle";

            this.pnlHeader.Controls.Add(this.lblTitle);

            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 120;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBottom.Name = "pnlBottom";

            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Height = 10;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Name = "progressBar";
            
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Height = 30;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Name = "lblStatus";

            // 
            // btnConvert
            // 
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Text = "CONVERT NOW";
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);

            this.pnlBottom.Controls.Add(this.btnConvert);
            this.pnlBottom.Controls.Add(this.lblStatus);
            this.pnlBottom.Controls.Add(this.progressBar);

            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Name = "pnlContent";

            // 
            // pnlOptions
            // 
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Height = 80;
            this.pnlOptions.Name = "pnlOptions";
            
            // 
            // lblConversionType
            // 
            this.lblConversionType.Text = "Conversion Type:";
            this.lblConversionType.Location = new System.Drawing.Point(0, 5);
            this.lblConversionType.AutoSize = true;
            this.lblConversionType.Name = "lblConversionType";

            // 
            // cmbConversionType
            // 
            this.cmbConversionType.Location = new System.Drawing.Point(0, 25);
            this.cmbConversionType.Size = new System.Drawing.Size(300, 30);
            this.cmbConversionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConversionType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbConversionType.Name = "cmbConversionType";
            this.cmbConversionType.SelectedIndexChanged += new System.EventHandler(this.CmbConversionType_SelectedIndexChanged);

            // 
            // lblOutput
            // 
            this.lblOutput.Text = "Output Directory:";
            this.lblOutput.Location = new System.Drawing.Point(320, 5);
            this.lblOutput.AutoSize = true;
            this.lblOutput.Name = "lblOutput";

            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(320, 25);
            this.txtOutputFolder.Size = new System.Drawing.Size(350, 30);
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Name = "txtOutputFolder";

            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(680, 24);
            this.btnBrowseOutput.Size = new System.Drawing.Size(120, 27);
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Click += new System.EventHandler(this.BtnBrowseOutput_Click);

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
            this.pnlSettings.Name = "pnlSettings";
            
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.Text = "Overwrite existing files";
            this.chkOverwrite.Location = new System.Drawing.Point(0, 10);
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Name = "chkOverwrite";

            // 
            // chkKeepOriginal
            // 
            this.chkKeepOriginal.Text = "Keep original files";
            this.chkKeepOriginal.Location = new System.Drawing.Point(180, 10);
            this.chkKeepOriginal.AutoSize = true;
            this.chkKeepOriginal.Checked = true;
            this.chkKeepOriginal.Name = "chkKeepOriginal";

            this.pnlSettings.Controls.Add(this.chkOverwrite);
            this.pnlSettings.Controls.Add(this.chkKeepOriginal);

            // 
            // pnlFileDrop
            // 
            this.pnlFileDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFileDrop.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlFileDrop.Name = "pnlFileDrop";

            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectFiles.Height = 40;
            this.btnSelectFiles.Text = "SELECT FILES OR DRAG && DROP HERE";
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Click += new System.EventHandler(this.BtnSelectFiles_Click);

            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxFiles.IntegralHeight = false;
            this.listBoxFiles.Name = "listBoxFiles";

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
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
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
