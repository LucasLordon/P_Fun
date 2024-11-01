using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    public partial class AddDataFile : Form
    {
        private Dictionary<string, string> cantonPaths;

        public AddDataFile(Dictionary<string, string> existingPaths)
        {
            InitializeComponent();
            cantonPaths = existingPaths;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
                lblError.Text = IsFileFormatValid(openFileDialog.FileName) ? "" : "Invalid file format.";
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string customName = txtCustomName.Text.Trim();
            string filePath = txtFilePath.Text.Trim();

            if (string.IsNullOrEmpty(customName) || string.IsNullOrEmpty(filePath))
            {
                lblError.Text = "Please enter a custom name and select a file.";
                return;
            }

            if (cantonPaths.ContainsKey(customName))
            {
                lblError.Text = $"The name '{customName}' already exists. Please choose a different name.";
                return;
            }

            if (!IsFileFormatValid(filePath))
            {
                lblError.Text = "The file format is incorrect. Please select a compatible file.";
                return;
            }



            cantonPaths[customName] = filePath;
            MessageBox.Show($"File '{filePath}' successfully added with the name '{customName}'.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsFileFormatValid(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string header = sr.ReadLine();
                    return header.Contains("date,time,abbreviation_canton_and_fl");
                }
            }
            catch
            {
                return false;
            }
        }
        public string CantonCode { get; private set; }
        public string FilePath { get; private set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            CantonCode = txtCustomName.Text;
            FilePath = txtFilePath.Text;

            if (!string.IsNullOrEmpty(CantonCode) && !string.IsNullOrEmpty(FilePath))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
