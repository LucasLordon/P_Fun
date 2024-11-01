using P_Fun_Forms.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    public partial class formSeeData : System.Windows.Forms.Form
    {
        // Chemin du fichier CSV à importer
        private string csvFilePath;

        // Constructeur recevant le chemin du fichier CSV et initialisant le formulaire
        public formSeeData(string importCsvFilePath)
        {
            InitializeComponent();
            csvFilePath = importCsvFilePath;
        }

        // Événement déclenché lors du clic sur le bouton d'importation
        private void ImportButton_Click(object sender, EventArgs e)
        {
            // Création d'une instance de la classe ImportData pour importer les données
            var importer = new ImportData();

            // Importation des données COVID à partir du fichier CSV
            List<CovidData> covidDataList = importer.ImportCsvData(csvFilePath);

            // Liaison des données importées au DataGridView pour affichage
            dataGridView1.DataSource = covidDataList;
        }
    }
}
