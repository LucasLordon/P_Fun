using CsvHelper;
using CsvHelper.Configuration;
using Projet_Fun_Chart;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
                MissingFieldFound = null 
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