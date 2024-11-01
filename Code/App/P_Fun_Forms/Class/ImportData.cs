using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using P_Fun_Forms.Class;

public class ImportData
{
    // Méthode pour importer les données d'un fichier CSV et les stocker sous forme de liste de CovidData
    public List<CovidData> ImportCsvData(string csvFilePath)
    {
        // Initialisation de la liste pour stocker les enregistrements de CovidData
        var records = new List<CovidData>();

        try
        {
            // Utilisation d'un lecteur de flux pour lire le fichier CSV
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Définition du délimiteur comme une virgule
                Delimiter = ",",

                // Gestion des champs manquants et validation des en-têtes
                MissingFieldFound = null,
                HeaderValidated = null
            }))
            {
                // Extraction des enregistrements du fichier CSV et stockage dans la liste records
                records = new List<CovidData>(csv.GetRecords<CovidData>());
            }
        }
        // Gestion des erreurs qui peuvent survenir lors de la lecture du fichier CSV
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
        }

        // Retourne la liste des enregistrements importés
        return records;
    }
}
