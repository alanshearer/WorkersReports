using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkersReports.Models
{
    public class WorkerDataSearchParameter
    {
        public String cognome { get; set; }
        public DateTime data { get; set; }
        public WorkerDataTipology tipology { get; set; }
    }
}