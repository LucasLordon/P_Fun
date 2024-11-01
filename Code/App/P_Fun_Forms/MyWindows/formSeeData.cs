using P_Fun_Forms.Class;           // Référence à la classe ImportData pour importer des données


namespace P_Fun_Forms.MyWindows
{
    // Classe formSeeData héritant de Form, permettant d'afficher des données importées à partir d'un fichier CSV
    public partial class formSeeData : System.Windows.Forms.Form
    {
        private string csvFilePath;  // Chemin du fichier CSV à importer

        // Constructeur prenant en paramètre le chemin du fichier CSV à importer
        public formSeeData(string importCsvFilePath)
        {
            InitializeComponent();   // Initialise les composants du formulaire
            csvFilePath = importCsvFilePath;  // Stocke le chemin du fichier CSV
        }

        // Méthode appelée lorsque l'utilisateur clique sur le bouton Import
        private void ImportButton_Click(object sender, EventArgs e)
        {
            var importer = new ImportData();  // Création d'une instance de la classe ImportData pour importer les données
            List<CovidData> covidDataList = importer.ImportCsvData(csvFilePath);  // Importe les données du fichier CSV

            // Associe la liste des données importées à la source de données du dataGridView pour les afficher
            dataGridView1.DataSource = covidDataList;
        }
    }
}
