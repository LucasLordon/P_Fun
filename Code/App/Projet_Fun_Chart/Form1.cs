using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projet_Fun_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            string csvFilePath = "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_VD_total.csv";
            var importer = new ImportData();
            List<CovidData> covidDataList = importer.ImportCsvData(csvFilePath);
            dataGridView1.DataSource = covidDataList;
        }
    }
}
