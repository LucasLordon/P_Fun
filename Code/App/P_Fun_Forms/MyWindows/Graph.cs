using P_Fun_Forms.Class; // Importation de la classe ImportData pour les opérations d'importation de données
using P_Fun_Forms.MyWindows;
using ScottPlot; // Bibliothèque pour la génération de graphiques
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    // Formulaire Graph pour afficher des graphiques de données Covid en fonction des cantons
    public partial class Graph : System.Windows.Forms.Form
    {
        // Dictionnaire contenant les chemins des fichiers CSV pour chaque canton
        public Dictionary<string, string> cantonPaths = new Dictionary<string, string>
        {
            { "AI", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_AI_total.csv" },
            // Autres cantons avec leurs chemins respectifs
        };

        readonly ScottPlot.Plottables.Crosshair CH; // Crosshair pour le graphique ScottPlot

        // Constructeur de la classe Graph
        public Graph()
        {
            InitializeComponent();
            InitializeCheckboxes(); // Initialisation des cases à cocher pour chaque canton
            ConfigGraph(); // Configuration du graphique

            CH = formsPlot1.Plot.Add.Crosshair(0, 0); // Ajout d'un Crosshair
            CH.TextBackgroundColor = CH.HorizontalLine.Color;

            formsPlot1.MouseMove += FormsPlot1_MouseMove; // Événement de mise à jour du Crosshair au déplacement de la souris
            formsPlot1.Refresh();
        }

        // Méthode pour importer des données à partir d'un fichier CSV
        public List<CovidData> ImportData(string csvFilePath)
        {
            var import = new ImportData();
            return import.ImportCsvData(csvFilePath);
        }

        // Configure les étiquettes et axes du graphique
        public void ConfigGraph()
        {
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.XLabel("Date");
            formsPlot1.Plot.YLabel("Nombre de cas covid");
        }

        // Met à jour le Crosshair en fonction des coordonnées de la souris
        public void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            Pixel mousePixel = new(e.X, e.Y);
            Coordinates mouseCoordinates = formsPlot1.Plot.GetCoordinates(mousePixel);
            this.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3}";

            CH.Position = mouseCoordinates;
            CH.VerticalLine.Text = $"{mouseCoordinates.X:N3}";
            CH.HorizontalLine.Text = $"{mouseCoordinates.Y:N3}";
            formsPlot1.Refresh();
        }

        // Initialise les cases à cocher pour sélectionner les cantons à afficher
        public void InitializeCheckboxes()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            foreach (var canton in cantonPaths.Keys)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = canton,
                    Checked = canton == "VD" // Pré-sélectionne le canton VD
                };

                string cantonPath = cantonPaths[canton];

                Button button = new Button
                {
                    Text = "See more"
                };
                button.Click += SeeDataButtonClick(cantonPath);

                flowLayoutPanel.Controls.Add(checkBox);
                flowLayoutPanel.Controls.Add(button);
            }

            cantonSelectionPanel.Controls.Add(flowLayoutPanel);
        }

        // Affiche les données sélectionnées dans le graphique lorsque l'utilisateur clique sur le bouton "Show Data"
        public void onShowDataButtonClick(object sender, EventArgs e)
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

                        // Limite les données si l'option de filtrage par date est activée
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

                        var scatterPlot = formsPlot1.Plot.Add.Scatter(dates, current_hosp);
                        scatterPlot.LegendText = selectedCanton;
                    }
                }

                formsPlot1.Plot.Axes.AutoScale();

                // Applique les limites personnalisées aux axes si activé
                if (isDefaultView.Checked)
                {
                    limitXAxys(formsPlot1.Plot, dateTimePicker1, dateTimePicker2);
                }

                formsPlot1.Refresh();
            }
        }

        // Limite les axes X du graphique entre deux dates
        public void limitXAxys(ScottPlot.Plot plot, System.Windows.Forms.DateTimePicker from, System.Windows.Forms.DateTimePicker to)
        {
            plot.Axes.SetLimits(from.Value.ToOADate(), to.Value.ToOADate());
        }

        // Ouvre le formulaire pour ajouter un nouveau fichier de données
        public void addDataButton_Click(object sender, EventArgs e)
        {
            using (AddDataFile addDataForm = new AddDataFile(cantonPaths))
            {
                if (addDataForm.ShowDialog() == DialogResult.OK)
                {
                    cantonSelectionPanel.Controls.Clear();
                    InitializeCheckboxes(); // Réinitialise les cases à cocher pour inclure les nouveaux fichiers
                }
            }
        }

        // Gestionnaire d'événement pour ouvrir le formulaire formSeeData pour voir les données d'un canton
        public static EventHandler SeeDataButtonClick(string cantonPath)
        {
            return (sender, e) =>
            {
                using (formSeeData formSeeData = new formSeeData(cantonPath))
                {
                    formSeeData.ShowDialog();
                }
            };
        }
    }
}
