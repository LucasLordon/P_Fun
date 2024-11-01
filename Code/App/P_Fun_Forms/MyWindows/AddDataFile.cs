using OpenTK.Audio.OpenAL;  // Référence pour gérer l'audio (pas utilisé dans cette classe)
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    // Classe AddDataFile héritant de Form pour permettre à l'utilisateur d'ajouter un fichier de données avec un nom personnalisé
    public partial class AddDataFile : Form
    {
        private Dictionary<string, string> cantonPaths;  // Dictionnaire pour stocker les chemins de fichiers associés aux cantons

        // Constructeur qui initialise le formulaire et reçoit un dictionnaire de chemins existants
        public AddDataFile(Dictionary<string, string> existingPaths)
        {
            InitializeComponent();  // Initialise les composants du formulaire
            cantonPaths = existingPaths;  // Associe le dictionnaire reçu aux chemins existants
        }

        // Méthode appelée lorsque l'utilisateur clique sur le bouton de sélection de fichier
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            // Création d'un OpenFileDialog pour sélectionner un fichier CSV
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";  // Filtre pour afficher uniquement les fichiers CSV
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;  // Affiche le chemin du fichier sélectionné dans txtFilePath
                // Vérifie la validité du format du fichier et affiche un message d'erreur si nécessaire
                lblError.Text = IsFileFormatValid(openFileDialog.FileName) ? "" : "Invalid file format.";
            }
        }

        // Méthode appelée lorsque l'utilisateur clique sur le bouton pour ajouter le fichier
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string customName = txtCustomName.Text.Trim();  // Récupère le nom personnalisé
            string filePath = txtFilePath.Text.Trim();      // Récupère le chemin du fichier sélectionné

            // Vérifie que les champs ne sont pas vides, sinon affiche un message d'erreur
            if (string.IsNullOrEmpty(customName) || string.IsNullOrEmpty(filePath))
            {
                lblError.Text = "Please enter a custom name and select a file.";
                return;
            }

            // Vérifie si le nom existe déjà dans le dictionnaire, sinon affiche un message d'erreur
            if (cantonPaths.ContainsKey(customName))
            {
                lblError.Text = $"The name '{customName}' already exists. Please choose a different name.";
                return;
            }

            // Vérifie le format du fichier et affiche un message d'erreur si le format est incorrect
            if (!IsFileFormatValid(filePath))
            {
                lblError.Text = "The file format is incorrect. Please select a compatible file.";
                return;
            }

            // Ajoute le nom et le chemin du fichier au dictionnaire et affiche un message de confirmation
            cantonPaths[customName] = filePath;
            MessageBox.Show($"File '{filePath}' successfully added with the name '{customName}'.");

            this.DialogResult = DialogResult.OK;  // Indique que l'ajout a réussi
            this.Close();  // Ferme le formulaire
        }

        // Méthode pour vérifier la validité du format du fichier en lisant l'en-tête
        private bool IsFileFormatValid(string filePath)
        {
            try
            {
                // Lit la première ligne du fichier pour vérifier la présence des colonnes attendues
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string header = sr.ReadLine();
                    return header.Contains("date,time,abbreviation_canton_and_fl");  // Vérifie si les colonnes sont présentes
                }
            }
            catch
            {
                return false;  // Retourne false en cas d'exception (fichier illisible ou incorrect)
            }
        }

        // Propriétés pour récupérer le code du canton et le chemin du fichier
        public string CantonCode { get; private set; }
        public string FilePath { get; private set; }

        // Méthode appelée lorsque l'utilisateur clique sur le bouton OK
        private void okButton_Click(object sender, EventArgs e)
        {
            CantonCode = txtCustomName.Text;  // Récupère le code du canton
            FilePath = txtFilePath.Text;      // Récupère le chemin du fichier

            // Vérifie que les champs ne sont pas vides avant de fermer le formulaire avec un DialogResult OK
            if (!string.IsNullOrEmpty(CantonCode) && !string.IsNullOrEmpty(FilePath))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Affiche un message d'avertissement si des champs sont vides
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Méthode appelée lorsque l'utilisateur clique sur le bouton Annuler pour fermer le formulaire
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();  // Ferme le formulaire sans action supplémentaire
        }
    }
}
