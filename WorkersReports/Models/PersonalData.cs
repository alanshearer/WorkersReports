using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorkersReports.Models
{
    public class PersonalData
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "MAC Address")]
        public String MACAddress { get; set; }
        [Required]
        [Display(Name="Nome")]
        public String FirstName { get; set; }
        [Required]
        [Display(Name = "Cognome")]
        public String LastName { get; set; }
        [Display(Name = "Codice Fiscale")]
        public String FiscalCode { get; set; }
        [Display(Name = "Matricola")]
        public String SerialNumber { get; set; }


        public ICollection<WorkerData> WorkerDatas { get; set; }

    }
}