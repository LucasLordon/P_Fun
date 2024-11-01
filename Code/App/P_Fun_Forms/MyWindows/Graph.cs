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
        // Dictionnaire pour stocker les chemins d'accès aux fichiers CSV des cantons
        public Dictionary<string, string> cantonPaths = new Dictionary<string, string>
        {
            { "AI", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_AI_total.csv" },
            { "AR", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_AR_total.csv" },
            { "BE", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_BE_total.csv" },
            { "BL", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_BL_total.csv" },
            { "BS", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_BS_total.csv" },
            { "FR", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_FR_total.csv" },
            { "GE", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_GE_total.csv" },
            { "GL", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_GL_total.csv" },
            { "GR", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_GR_total.csv" },
            { "JU", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_JU_total.csv" },
            { "LU", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_LU_total.csv" },
            { "NE", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_NE_total.csv" },
            { "NW", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_NW_total.csv" },
            { "OW", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_OW_total.csv" },
            { "SG", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_SG_total.csv" },
            { "SH", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_SH_total.csv" },
            { "SO", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_SO_total.csv" },
            { "SZ", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_SZ_total.csv" },
            { "TG", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_TG_total.csv" },
            { "TI", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_TI_total.csv" },
            { "UR", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_UR_total.csv" },
            { "VD", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_VD_total.csv" },
            { "VS", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_VS_total.csv" },
            { "ZG", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_ZG_total.csv" },
            { "ZH", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_ZH_total.csv" },
            { "AG", "..\\..\\..\\..\\..\\Data\\COVID19_Fallzahlen_Kanton_AG_total.csv" }
        };

        // Instance de Crosshair pour l'affichage des coordonnées de la souris
        readonly ScottPlot.Plottables.Crosshair CH;

        public Graph()
        {
            InitializeComponent(); // Initialisation des composants du formulaire
            InitializeCheckboxes(); // Appel pour initialiser les cases à cocher
            ConfigGraph(); // Configuration initiale du graphique

            // Création et configuration de Crosshair
            CH = formsPlot1.Plot.Add.Crosshair(0, 0);
            CH.TextBackgroundColor = CH.HorizontalLine.Color; // Couleur d'arrière-plan du texte du Crosshair

            // Événement pour suivre le mouvement de la souris sur le graphique
            formsPlot1.MouseMove += FormsPlot1_MouseMove;

            formsPlot1.Refresh(); // Rafraîchissement du graphique pour afficher les modifications
        }

        // Méthode pour importer les données à partir d'un fichier CSV
        public List<CovidData> ImportData(string csvFilePath)
        {
            var import = new ImportData(); // Création d'une instance pour l'importation de données
            List<CovidData> covidDataList = import.ImportCsvData(csvFilePath); // Importation des données
            return covidDataList; // Retourne la liste des données COVID
        }

        // Méthode pour configurer le graphique
        public void ConfigGraph()
        {
            formsPlot1.Plot.Axes.DateTimeTicksBottom(); // Configurer les ticks de l'axe des X pour des dates
            formsPlot1.Plot.XLabel("Date"); // Étiquette pour l'axe des X
            formsPlot1.Plot.YLabel("Nombres de cas covid"); // Étiquette pour l'axe des Y
        }

        // Gestionnaire d'événements pour le mouvement de la souris sur le graphique
        public void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            Pixel mousePixel = new(e.X, e.Y); // Récupération des coordonnées de la souris
            Coordinates mouseCoordinates = formsPlot1.Plot.GetCoordinates(mousePixel); // Conversion en coordonnées du graphique
            this.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3}"; // Mise à jour du titre du formulaire avec les coordonnées
            CH.Position = mouseCoordinates; // Mise à jour de la position du Crosshair
            CH.VerticalLine.Text = $"{mouseCoordinates.X:N3}"; // Texte de la ligne verticale du Crosshair
            CH.HorizontalLine.Text = $"{mouseCoordinates.Y:N3}"; // Texte de la ligne horizontale du Crosshair
            formsPlot1.Refresh(); // Rafraîchissement du graphique pour afficher les changements
        }

        public void InitializeCheckboxes()
        {
            // Création d'un FlowLayoutPanel pour contenir les cases à cocher et les boutons
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, // Remplit l'espace disponible
                AutoScroll = true // Active le défilement automatique si nécessaire
            };

            // Boucle sur chaque canton dans le dictionnaire cantonPaths pour créer une case à cocher et un bouton
            foreach (var canton in cantonPaths.Keys)
            {
                // Création d'une case à cocher pour chaque canton
                CheckBox checkBox = new CheckBox
                {
                    Text = canton, // Texte de la case à cocher
                    Checked = canton == "VD" // Coche la case si le canton est "VD"
                };

                // Récupération du chemin du fichier CSV pour le canton
                string cantonPath = cantonPaths[canton];

                // Création d'un bouton pour voir plus de détails
                Button button = new Button
                {
                    Text = "See more" // Texte du bouton
                };

                // Ajout d'un gestionnaire d'événements pour le clic sur le bouton
                button.Click += SeeDataButtonClick(cantonPath);

                // Ajout de la case à cocher et du bouton au FlowLayoutPanel
                flowLayoutPanel.Controls.Add(checkBox);
                flowLayoutPanel.Controls.Add(button);
            }

            // Ajout du FlowLayoutPanel au panneau de sélection de cantons
            cantonSelectionPanel.Controls.Add(flowLayoutPanel);
        }

        public void onShowDataButtonClick(object sender, EventArgs e)
        {
            // Efface le graphique avant d'afficher de nouvelles données
            formsPlot1.Plot.Clear();

            // Liste pour stocker les données COVID combinées de plusieurs cantons
            List<CovidData> combinedCovidDataList = new List<CovidData>();

            // Recherche le FlowLayoutPanel qui contient les cases à cocher
            FlowLayoutPanel flowLayoutPanel = cantonSelectionPanel.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

            // Si le FlowLayoutPanel est trouvé
            if (flowLayoutPanel != null)
            {
                // Boucle sur chaque case à cocher dans le FlowLayoutPanel
                foreach (CheckBox checkBox in flowLayoutPanel.Controls.OfType<CheckBox>())
                {
                    // Vérifie si la case à cocher est cochée
                    if (checkBox.Checked)
                    {
                        string selectedCanton = checkBox.Text; // Récupère le nom du canton
                        string csvFilePath = cantonPaths[selectedCanton]; // Récupère le chemin du fichier CSV

                        // Importation des données COVID à partir du fichier CSV
                        List<CovidData> covidDataList = ImportData(csvFilePath);

                        // Récupération des dates en format OADate pour les tracés
                        var dates = covidDataList.Select(d => d.date.ToOADate()).ToArray();

                        // Si l'option de limitation des données est cochée
                        if (isLimitedData.Checked)
                        {
                            // Filtre les données selon la plage de dates spécifiée
                            covidDataList = covidDataList
                                .Where(d => d.date >= limitDatatFrom.Value && d.date <= limitDataTo.Value)
                                .ToList();

                            // Récupération des dates filtrées
                            dates = covidDataList.Select(d => d.date.ToOADate()).ToArray();
                        }

                        // Récupération des données sur les hospitalisations actuelles
                        var current_hosp = covidDataList
                            .Where(h => h.current_hosp.HasValue)
                            .Select(h => (double)h.current_hosp.Value)
                            .ToArray();

                        // Ajout des données au graphique
                        var scatterPlot = formsPlot1.Plot.Add.Scatter(dates, current_hosp);
                        scatterPlot.LegendText = selectedCanton; // Légende pour la série de données
                    }
                }

                // Ajustement automatique des axes du graphique
                formsPlot1.Plot.Axes.AutoScale();

                // Si la vue par défaut est cochée, limite les axes X selon les sélecteurs de date
                if (isDefaultView.Checked)
                {
                    limitXAxys(formsPlot1.Plot, dateTimePicker1, dateTimePicker2);
                }

                // Rafraîchissement du graphique pour afficher les nouvelles données
                formsPlot1.Refresh();
            }
        }

        public void limitXAxys(ScottPlot.Plot plot, System.Windows.Forms.DateTimePicker from, System.Windows.Forms.DateTimePicker to)
        {
            // Limite les axes X du graphique selon les valeurs des DateTimePicker
            plot.Axes.SetLimits(from.Value.ToOADate(), to.Value.ToOADate());
        }

        public void addDataButton_Click(object sender, EventArgs e)
        {
            // Ouverture du formulaire d'ajout de fichier de données
            using (AddDataFile addDataForm = new AddDataFile(cantonPaths))
            {
                // Si l'utilisateur a ajouté un fichier avec succès
                if (addDataForm.ShowDialog() == DialogResult.OK)
                {
                    // Efface les contrôles précédents et réinitialise les cases à cocher
                    cantonSelectionPanel.Controls.Clear();
                    InitializeCheckboxes();
                }
            }
        }

        public static EventHandler SeeDataButtonClick(string cantonPath)
        {
            // Retourne un gestionnaire d'événements pour le clic sur le bouton "See more"
            return (sender, e) =>
            {
                using (formSeeData formSeeData = new formSeeData(cantonPath))
                {
                    // Affiche le formulaire de données du canton
                    formSeeData.ShowDialog();
                }
            };
        }
    }
}