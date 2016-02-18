using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkersReports.Models
{
    public class WorkerData
    {
        [Key]
        public int ID { get; set; }
        public String MACAddress { get; set; }
        public DateTime Time { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }

    }
}