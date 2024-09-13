using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Fun_Chart
{
    public class CovidData
    {
        public DateTime date { get; set; }
        public string time { get; set; }
        public string abbreviation_canton_and_fl { get; set; }
        public int? ncumul_tested { get; set; }
        public int? ncumul_conf { get; set; }
        public int? new_hosp { get; set; }
        public int? current_hosp { get; set; }
        public int? current_vent { get; set; }
        public int? current_icu { get; set; }
        public int? ncumul_released { get; set; }
        public int? ncumul_deceased { get; set; }
        public string source { get; set; }
        public int? current_isolated { get; set; }
        public int? current_quarantined { get; set; }
        public int? current_quarantined_riskareatravel { get; set; }
        public int? current_quarantined_total { get; set; }
    }

}


