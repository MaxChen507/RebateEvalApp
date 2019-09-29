using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateEvalApp.Domain
{
    class AnalysisInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Backspaces { get; set; }

        public AnalysisInfo()
        {

        }
    }
}
