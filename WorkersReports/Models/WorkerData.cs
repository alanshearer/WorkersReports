using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkersReports.Models
{
    public class WorkerData
    {
        public String MACAddress { get; set; }
        public DateTime Time { get; set; }

        public String Latitude { get; set; }
        public String Longitude { get; set; }

    }
}