using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FileConverterUI.Core;
using FileConverterUI.UI;

namespace FileConverterUI
{
    public partial class Form1 : Form
    {
        private List<string> selectedFiles = new List<string>();
        private ConversionManager conversionManager;

        public Form1()
        {
            InitializeComponent();
            conversionManager = new ConversionManager();
            ApplyTheme();
            InitializeUI();
        }

        private void ApplyTheme()
        {
            Theme.ApplyToForm(this);
            Theme.StylePanel(pnlHeader, isHeader: true);
            Theme.StyleLabel(lblTitle, isTitle: true);
            Theme.StylePanel(pnlBottom, isBottom: true);
            Theme.StyleLabel(lblStatus, isSecondary: true);
            Theme.StyleButton(btnConvert, isConvertButton: true);
            Theme.StyleLabel(lblConversionType);
            Theme.StyleComboBox(cmbConversionType);
            Theme.StyleLabel(lblOutput);
            Theme.StyleTextBox(txtOutputFolder);
            Theme.StyleButton(btnBrowseOutput);
            Theme.StyleCheckBox(chkOverwrite);
            Theme.StyleCheckBox(chkKeepOriginal);
            Theme.StyleButton(btnSelectFiles);
            Theme.StyleListBox(listBoxFiles);
        }

        private void InitializeUI()
        {
            txtOutputFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ConvertedFiles");

            foreach (var category in conversionManager.Options)
            {
                cmbConversionType.Items.Add($"--- {category.Key} ---");
                foreach (var option in category.Value)
                {
                    cmbConversionType.Items.Add($"    {option}");
                }
            }
            cmbConversionType.SelectedIndex = 2; // Default
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddFiles(files);
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select files to convert";

                string selectedType = cmbConversionType.SelectedItem?.ToString().Trim();
                if (selectedType != null && !selectedType.StartsWith("---"))
                {
                    openFileDialog.Filter = conversionManager.GetFilterForConversion(selectedType);
                }
                else
                {
                    openFileDialog.Filter = "All Files|*.*";
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddFiles(openFileDialog.FileNames);
                }
            }
        }

        private void AddFiles(string[] files)
        {
            foreach (string file in files)
            {
                if (!selectedFiles.Contains(file))
                {
                    selectedFiles.Add(file);
                    listBoxFiles.Items.Add(file);
                }
            }
            UpdateStatus($"{selectedFiles.Count} files selected");
        }

        private void BtnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select output folder";
                folderDialog.SelectedPath = txtOutputFolder.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void BtnConvert_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("Please select files to convert.", "No Files",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedType = cmbConversionType.SelectedItem?.ToString().Trim();
            if (string.IsNullOrEmpty(selectedType) || selectedType.StartsWith("---"))
            {
                MessageBox.Show("Please select a valid conversion type.", "Invalid Type",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string outputDir = txtOutputFolder.Text;
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            btnConvert.Enabled = false;
            progressBar.Maximum = selectedFiles.Count;
            progressBar.Value = 0;
            bool overwrite = chkOverwrite.Checked;

            var progress = new Progress<int>(value => 
            {
                if (progressBar.InvokeRequired)
                    progressBar.Invoke(new Action(() => progressBar.Value = value));
                else
                    progressBar.Value = value;
            });

            await conversionManager.ConvertFilesAsync(
                selectedFiles, 
                selectedType, 
                outputDir, 
                overwrite,
                progress,
                (file, error) => {
                    this.Invoke(new Action(() => {
                        MessageBox.Show($"Error converting {Path.GetFileName(file)}: {error}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                },
                (statusText) => {
                    UpdateStatus(statusText);
                }
            );

            btnConvert.Enabled = true;
            UpdateStatus("Conversion completed!");
            MessageBox.Show($"Successfully converted {selectedFiles.Count} files!",
                "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbConversionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFiles.Clear();
            listBoxFiles.Items.Clear();
            UpdateStatus("Ready");
        }

        private void UpdateStatus(string message)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action(() => lblStatus.Text = message));
            }
            else
            {
                lblStatus.Text = message;
            }
        }
    }
}