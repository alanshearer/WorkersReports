using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkersReports.Models
{
    public enum WorkerDataTipology
    {
        Entry = 0,
        Exit = 1
    };
    public class WorkerData
    {
        [Key]
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public WorkerDataTipology Tipology { get; set; }

        public int PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

    }
}