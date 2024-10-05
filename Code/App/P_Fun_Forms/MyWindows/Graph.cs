using P_Fun_Forms.Class;
using P_Fun_Forms.MyWindows;
using P_Fun_Forms.MyWindows;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;


namespace P_Fun_Forms.MyWindows
{
    public partial class Graph : System.Windows.Forms.Form
    {
        private Dictionary<string, string> cantonPaths = new Dictionary<string, string>
    {
        { "AI", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_AI_total.csv" },
        { "AR", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_AR_total.csv" },
        { "BE", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_BE_total.csv" },
        { "BL", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_BL_total.csv" },
        { "BS", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_BS_total.csv" },
        { "FR", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_FR_total.csv" },
        { "GE", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_GE_total.csv" },
        { "GL", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_GL_total.csv" },
        { "GR", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_GR_total.csv" },
        { "JU", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_JU_total.csv" },
        { "LU", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_LU_total.csv" },
        { "NE", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_NE_total.csv" },
        { "NW", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_NW_total.csv" },
        { "OW", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_OW_total.csv" },
        { "SG", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_SG_total.csv" },
        { "SH", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_SH_total.csv" },
        { "SO", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_SO_total.csv" },
        { "SZ", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_SZ_total.csv" },
        { "TG", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_TG_total.csv" },
        { "TI", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_TI_total.csv" },
        { "UR", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_UR_total.csv" },
        { "VD", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_VD_total.csv" },
        { "VS", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_VS_total.csv" },
        { "ZG", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_ZG_total.csv" },
        { "ZH", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_ZH_total.csv" },
        { "AG", "C:\\Users\\pu61qgw\\Documents\\GitHub\\P_Fun\\Code\\Data\\COVID19_Fallzahlen_Kanton_AG_total.csv" }
    };
        readonly ScottPlot.Plottables.Crosshair CH;
        public Graph()
        {
            InitializeComponent();
            InitializeCheckboxes();
            ConfigGraph();

            CH = formsPlot1.Plot.Add.Crosshair(0, 0);
            CH.TextBackgroundColor = CH.HorizontalLine.Color;

            formsPlot1.MouseMove += FormsPlot1_MouseMove;

            formsPlot1.Refresh();
        }
        private void Graph_Load(object sender, EventArgs e)
        {

        }
        private List<CovidData> ImportData(string csvFilePath)
        {
            var import = new ImportData();
            List<CovidData> covidDataList = import.ImportCsvData(csvFilePath);
            return covidDataList;
        }
        private void ConfigGraph()
        {
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.XLabel("Date");
            formsPlot1.Plot.YLabel("Nombres de cas covid");
        }
        private void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            Pixel mousePixel = new(e.X, e.Y);
            Coordinates mouseCoordinates = formsPlot1.Plot.GetCoordinates(mousePixel);
            this.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3}";
            CH.Position = mouseCoordinates;
            CH.VerticalLine.Text = $"{mouseCoordinates.X:N3}";
            CH.HorizontalLine.Text = $"{mouseCoordinates.Y:N3}";
            formsPlot1.Refresh();
        }
        private void InitializeCheckboxes()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;

            foreach (var canton in cantonPaths.Keys)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = canton,
                    Checked = canton == "VD"
                };

                var cantonValue = cantonPaths[canton];

                flowLayoutPanel.Controls.Add(checkBox);

            }

            cantonSelectionPanel.Controls.Add(flowLayoutPanel);
        }
        private void onShowDataButtonClick(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();


            List<CovidData> combinedCovidDataList = new List<CovidData>();

            FlowLayoutPanel flowLayoutPanel = cantonSelectionPanel.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

            if (flowLayoutPanel != null)
            {
                foreach (CheckBox checkBox in flowLayoutPanel.Controls.OfType<CheckBox>())
                {
                    if (checkBox.Checked)
                    {
                        string selectedCanton = checkBox.Text;
                        string csvFilePath = cantonPaths[selectedCanton];

                        List<CovidData> covidDataList = ImportData(csvFilePath);

                        var dates = covidDataList.Select(d => d.date.ToOADate()).ToArray();

                        if (isLimitedData.Checked)
                        {
                            covidDataList = covidDataList
                                .Where(d => d.date >= limitDatatFrom.Value && d.date <= limitDataTo.Value)
                                .ToList();


                            dates = covidDataList.Select(d => d.date.ToOADate()).ToArray();
                        }

                        var current_hosp = covidDataList
                            .Where(h => h.current_hosp.HasValue)
                            .Select(h => (double)h.current_hosp.Value)
                            .ToArray();

                        formsPlot1.Plot.Add.Scatter(dates, current_hosp);
                    }
                }



                formsPlot1.Plot.Axes.AutoScale();
                if (isDefaultView.Checked)
                {
                    limitXAxys(formsPlot1.Plot, dateTimePicker1, dateTimePicker2);
                }
                formsPlot1.Refresh();
            }
        }

        private void limitXAxys (ScottPlot.Plot plot, System.Windows.Forms.DateTimePicker from, System.Windows.Forms.DateTimePicker to)
        {
            plot.Axes.SetLimits(from.Value.ToOADate(), to.Value.ToOADate());
        }

    }
}




