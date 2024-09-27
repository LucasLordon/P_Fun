using P_Fun_Forms.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    public partial class formSeeData : System.Windows.Forms.Form

    {
        private string canton;
        public formSeeData(string canton)
        {
            this.canton = canton;
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

