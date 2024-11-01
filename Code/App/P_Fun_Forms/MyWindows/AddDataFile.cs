using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    public partial class AddDataFile : Form
    {
        // Dictionnaire pour stocker les chemins de fichiers associés aux cantons
        private Dictionary<string, string> cantonPaths;

        // Constructeur initialisant le formulaire avec des chemins de fichiers existants
        public AddDataFile(Dictionary<string, string> existingPaths)
        {
            InitializeComponent();
            cantonPaths = existingPaths;
        }

        // Événement déclenché lors de la sélection d'un fichier CSV
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Affiche le chemin du fichier sélectionné
                txtFilePath.Text = openFileDialog.FileName;

                // Vérifie si le format du fichier est valide
                lblError.Text = IsFileFormatValid(openFileDialog.FileName) ? "" : "Invalid file format.";
            }
        }

        // Événement déclenché lors de l'ajout d'un fichier
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            // Récupère le nom personnalisé et le chemin du fichier saisis par l'utilisateur
            string customName = txtCustomName.Text.Trim();
            string filePath = txtFilePath.Text.Trim();

            // Vérifie que le nom et le chemin sont renseignés
            if (string.IsNullOrEmpty(customName) || string.IsNullOrEmpty(filePath))
            {
                lblError.Text = "Please enter a custom name and select a file.";
                return;
            }

            // Vérifie que le nom n'existe pas déjà dans le dictionnaire
            if (cantonPaths.ContainsKey(customName))
            {
                lblError.Text = $"The name '{customName}' already exists. Please choose a different name.";
                return;
            }

            // Vérifie la validité du format du fichier
            if (!IsFileFormatValid(filePath))
            {
                lblError.Text = "The file format is incorrect. Please select a compatible file.";
                return;
            }

            // Ajoute le fichier au dictionnaire et affiche un message de confirmation
            cantonPaths[customName] = filePath;
            MessageBox.Show($"File '{filePath}' successfully added with the name '{customName}'.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Vérifie si le format du fichier est valide en vérifiant la présence d'en-têtes spécifiques
        private bool IsFileFormatValid(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Lit la première ligne (en-tête) du fichier et vérifie son contenu
                    string header = sr.ReadLine();
                    return header.Contains("date,time,abbreviation_canton_and_fl");
                }
            }
            catch
            {
                // Retourne false si une exception est levée
                return false;
            }
        }

        // Propriétés pour le code du canton et le chemin du fichier
        public string CantonCode { get; private set; }
        public string FilePath { get; private set; }

        // Événement déclenché lors de la validation avec le bouton "OK"
        private void okButton_Click(object sender, EventArgs e)
        {
            CantonCode = txtCustomName.Text;
            FilePath = txtFilePath.Text;

            // Vérifie que les champs sont remplis avant de fermer le formulaire
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

        // Événement déclenché lors de l'annulation avec le bouton "Annuler"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
