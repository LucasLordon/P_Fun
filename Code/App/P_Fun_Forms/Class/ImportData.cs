using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using P_Fun_Forms.Class;

// Classe ImportData permettant d'importer des données COVID depuis un fichier CSV
public class ImportData
{
    // Méthode pour importer les données d'un fichier CSV spécifié
    public List<CovidData> ImportCsvData(string csvFilePath)
    {
        // Création d'une liste pour stocker les enregistrements de données COVID
        var records = new List<CovidData>();

        try
        {
            // Utilisation de StreamReader pour lire le fichier CSV à l'emplacement spécifié
            using (var reader = new StreamReader(csvFilePath))
            // Initialisation de CsvReader avec une configuration pour les paramètres CSV
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",              // Spécification du délimiteur (virgule ici)
                MissingFieldFound = null,      // Ignore les champs manquants
                HeaderValidated = null         // Ignore les erreurs de validation des en-têtes
            }))
            {
                // Lecture et conversion des enregistrements du fichier CSV en objets CovidData
                records = new List<CovidData>(csv.GetRecords<CovidData>());
            }
        }
        // Gestion des erreurs lors de la lecture du fichier CSV
        catch (Exception ex)
        {
            // Affiche un message d'erreur dans la console si une exception est levée
            Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
        }

        // Retourne la liste des enregistrements de données COVID
        return records;
    }
}
