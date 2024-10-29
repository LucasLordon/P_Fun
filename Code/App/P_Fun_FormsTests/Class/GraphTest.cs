using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_Fun_Forms.MyWindows;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScottPlot;
using System.Data;

namespace P_Fun_FormsTests.Class
{
    [TestClass]
    public class GraphTest
    {
        private Graph graph;

        [TestInitialize]
        public void Setup()
        {
            graph = new Graph();
        }

        [TestMethod]
        public void ImportData_ValidCsvPath_ReturnsNonEmptyList()
        {
            // Arrange
            string validCsvPath = "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_VD_total.csv";

            // Act
            var data = graph.ImportData(validCsvPath);

            // Assert
            Assert.IsNotNull(data, "La liste importée ne devrait pas être nulle.");
            Assert.IsTrue(data.Count > 0, "La liste importée devrait contenir des éléments.");
        }

        [TestMethod]
        public void ImportData_InvalidCsvPath_ReturnsEmptyList()
        {
            // Arrange
            string invalidCsvPath = "invalid_path.csv";

            // Act
            var data = graph.ImportData(invalidCsvPath);

            // Assert
            Assert.IsNotNull(data, "La liste ne devrait pas être nulle, même avec un chemin invalide.");
            Assert.AreEqual(0, data.Count, "La liste devrait être vide avec un chemin de fichier invalide.");
        }

    }
}
