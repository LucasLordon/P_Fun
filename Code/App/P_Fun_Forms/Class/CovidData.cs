namespace P_Fun_Forms.Class
{
    // Classe représentant les données COVID, avec des propriétés pour divers champs de données.
    public class CovidData
    {
        // Date d'enregistrement des données
        public DateTime date { get; set; }

        // Heure d'enregistrement des données (sous forme de chaîne)
        public string time { get; set; }

        // Abréviation du canton ou du Liechtenstein
        public string abbreviation_canton_and_fl { get; set; }

        // Nombre cumulé de tests effectués (peut être null)
        public int? ncumul_tested { get; set; }

        // Nombre cumulé de cas confirmés (peut être null)
        public int? ncumul_conf { get; set; }

        // Nombre de nouvelles hospitalisations (peut être null)
        public int? new_hosp { get; set; }

        // Nombre actuel de patients hospitalisés (peut être null)
        public int? current_hosp { get; set; }

        // Nombre actuel de patients sous ventilation (peut être null)
        public int? current_vent { get; set; }

        // Nombre actuel de patients en soins intensifs (peut être null)
        public int? current_icu { get; set; }

        // Nombre cumulé de patients guéris (peut être null)
        public int? ncumul_released { get; set; }

        // Nombre cumulé de décès (peut être null)
        public int? ncumul_deceased { get; set; }

        // Source des données (sous forme de chaîne)
        public string source { get; set; }

        // Nombre actuel de personnes isolées (peut être null)
        public int? current_isolated { get; set; }

        // Nombre actuel de personnes en quarantaine (peut être null)
        public int? current_quarantined { get; set; }

        // Nombre actuel de personnes en quarantaine suite à un voyage en zone à risque (peut être null)
        public int? current_quarantined_riskareatravel { get; set; }

        // Nombre total actuel de personnes en quarantaine (peut être null)
        public int? current_quarantined_total { get; set; }
    }
}
