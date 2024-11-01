using P_Fun_Forms.Class;           // R�f�rence � la classe ImportData pour importer des donn�es


namespace P_Fun_Forms.MyWindows
{
    // Classe formSeeData h�ritant de Form, permettant d'afficher des donn�es import�es � partir d'un fichier CSV
    public partial class formSeeData : System.Windows.Forms.Form
    {
        private string csvFilePath;  // Chemin du fichier CSV � importer

        // Constructeur prenant en param�tre le chemin du fichier CSV � importer
        public formSeeData(string importCsvFilePath)
        {
            InitializeComponent();   // Initialise les composants du formulaire
            csvFilePath = importCsvFilePath;  // Stocke le chemin du fichier CSV
        }

        // M�thode appel�e lorsque l'utilisateur clique sur le bouton Import
        private void ImportButton_Click(object sender, EventArgs e)
        {
            var importer = new ImportData();  // Cr�ation d'une instance de la classe ImportData pour importer les donn�es
            List<CovidData> covidDataList = importer.ImportCsvData(csvFilePath);  // Importe les donn�es du fichier CSV

            // Associe la liste des donn�es import�es � la source de donn�es du dataGridView pour les afficher
            dataGridView1.DataSource = covidDataList;
        }
    }
}
