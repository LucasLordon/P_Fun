using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Fun_Chart
{
    public class CovidData
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string AbbreviationCantonAndFl { get; set; }
        public int? NcumulTested { get; set; }
        public int? NcumulConf { get; set; }
        public int? NewHosp { get; set; }
        public int? CurrentHosp { get; set; }
        public int? CurrentIcu { get; set; }
        public int? CurrentVent { get; set; }
        public int? NcumulReleased { get; set; }
        public int? NcumulDeceased { get; set; }
        public string Source { get; set; }
        public int? CurrentIsolated { get; set; }
        public int? CurrentQuarantined { get; set; }
        public int? CurrentQuarantinedRiskAreaTravel { get; set; }
        public int? CurrentQuarantinedTotal { get; set; }
    }

}


