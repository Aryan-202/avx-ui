using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FileConverterUI.Core.Interfaces;

namespace FileConverterUI.UI.Views
{
    public partial class MainForm : Form, IMainView
    {
        private const int CS_DROPSHADOW = 0x00020000;

        public event EventHandler SelectFilesRequested;
        public event EventHandler ConvertRequested;
        public event EventHandler BrowseOutputRequested;
        public event EventHandler ConversionTypeChanged;

        public MainForm()
        {
            InitializeComponent();
            WireEvents();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void WireEvents()
        {
            this.btnSelectFiles.Click += (s, e) => SelectFilesRequested?.Invoke(this, EventArgs.Empty);
            this.btnConvert.Click += (s, e) => ConvertRequested?.Invoke(this, EventArgs.Empty);
            this.btnBrowseOutput.Click += (s, e) => BrowseOutputRequested?.Invoke(this, EventArgs.Empty);
            this.cmbConversionType.SelectedIndexChanged += (s, e) => ConversionTypeChanged?.Invoke(this, EventArgs.Empty);
            
            this.DragEnter += (s, e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            };
            this.DragDrop += (s, e) => {
            };
        }

        public event Action<string[]> FilesDropped;

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            FilesDropped?.Invoke(files);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedConversionType 
        { 
            get => cmbConversionType.SelectedItem?.ToString().Trim(); 
            set => cmbConversionType.SelectedItem = value; 
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OutputDirectory 
        { 
            get => txtOutputFolder.Text; 
            set => txtOutputFolder.Text = value; 
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OverwriteExisting 
        { 
            get => chkOverwrite.Checked; 
            set => chkOverwrite.Checked = value; 
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool KeepOriginal 
        { 
            get => chkKeepOriginal.Checked; 
            set => chkKeepOriginal.Checked = value; 
        }

        public void SetConversionOptions(IEnumerable<string> categories, Dictionary<string, List<string>> options)
        {
            cmbConversionType.Items.Clear();
            foreach (var category in categories)
            {
                cmbConversionType.Items.Add($"--- {category} ---");
                foreach (var option in options[category])
                {
                    cmbConversionType.Items.Add($"    {option}");
                }
            }
            if (cmbConversionType.Items.Count > 2) cmbConversionType.SelectedIndex = 2;
        }

        public void SetSelectedFiles(IEnumerable<string> files)
        {
            listBoxFiles.Items.Clear();
            foreach (var f in files) listBoxFiles.Items.Add(f);
        }

        public void UpdateProgress(int current, int total)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => { progressBar.Maximum = total; progressBar.Value = current; }));
            }
            else
            {
                progressBar.Maximum = total;
                progressBar.Value = current;
            }
        }

        public void UpdateStatus(string message)
        {
            if (lblStatus.InvokeRequired) lblStatus.Invoke(new Action(() => lblStatus.Text = message));
            else lblStatus.Text = message;
        }

        public void EnableConversion(bool enable)
        {
            if (btnConvert.InvokeRequired) btnConvert.Invoke(new Action(() => btnConvert.Enabled = enable));
            else btnConvert.Enabled = enable;
        }

        public void ShowError(string title, string message)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() => MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)));
            else MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string title, string message)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() => MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)));
            else MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
