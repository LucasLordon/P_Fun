using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_Fun_Forms.Class;
using P_Fun_Forms.MyWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class ImportDataTests
    {
        [TestMethod]
        public void ImportData_ValidCsvPath_ReturnsNonEmptyList()
        {
            // Arrange
            var importData = new ImportData();
            string testCsvPath = "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_VD_total.csv";

            // Act
            List<CovidData> result = importData.ImportCsvData(testCsvPath);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0, "The imported data list should not be empty.");
        }

        [TestMethod]
        public void ImportData_InvalidCsvPath_ReturnsEmptyList()
        {
            // Arrange
            var importData = new ImportData();
            string invalidCsvPath = "invalid_path.csv";

            // Act
            List<CovidData> result = importData.ImportCsvData(invalidCsvPath);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count, "The list should be empty when the file path is invalid.");
        }

        [TestMethod]
        public void ImportData_EmptyCsvFile_ReturnsEmptyList()
        {
            // Arrange
            var importData = new ImportData();
            string emptyCsvPath = "..\\..\\..\\..\\..\\Data\\testEmpty.csv";
            File.WriteAllText(emptyCsvPath, "");

            // Act
            List<CovidData> result = importData.ImportCsvData(emptyCsvPath);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count, "The list should be empty when the CSV file is empty.");
        }

        [TestMethod]
        public void ImportData_NullOrEmptyPath_ReturnsEmptyList()
        {
            // Arrange
            var importData = new ImportData();

            // Act & Assert for null path
            List<CovidData> resultNull = importData.ImportCsvData(null);
            Assert.IsNotNull(resultNull);
            Assert.AreEqual(0, resultNull.Count, "The list should be empty when the CSV file path is null.");

            // Act & Assert for empty path
            List<CovidData> resultEmpty = importData.ImportCsvData("");
            Assert.IsNotNull(resultEmpty);
            Assert.AreEqual(0, resultEmpty.Count, "The list should be empty when the CSV file path is empty.");
        }


    }
}