using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using P_Fun_Forms.Class;
public class ImportData
{
    public List<CovidData> ImportCsvData(string csvFilePath)
    {
        var records = new List<CovidData>();

        try
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                MissingFieldFound = null,
                HeaderValidated = null
            }))
            {
                records = new List<CovidData>(csv.GetRecords<CovidData>());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
        }

        return records;
    }
}