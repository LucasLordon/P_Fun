using P_Fun_Forms.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    public partial class formSeeData : System.Windows.Forms.Form
    {
        // Chemin du fichier CSV � importer
        private string csvFilePath;

        // Constructeur recevant le chemin du fichier CSV et initialisant le formulaire
        public formSeeData(string importCsvFilePath)
        {
            InitializeComponent();
            csvFilePath = importCsvFilePath;
        }

        // �v�nement d�clench� lors du clic sur le bouton d'importation
        private void ImportButton_Click(object sender, EventArgs e)
        {
            // Cr�ation d'une instance de la classe ImportData pour importer les donn�es
            var importer = new ImportData();

            // Importation des donn�es COVID � partir du fichier CSV
            List<CovidData> covidDataList = importer.ImportCsvData(csvFilePath);

            // Liaison des donn�es import�es au DataGridView pour affichage
            dataGridView1.DataSource = covidDataList;
        }
    }
}
