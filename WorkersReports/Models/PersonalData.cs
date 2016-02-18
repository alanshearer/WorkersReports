using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkersReports.Models
{
    public class PersonalData
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "MAC Address")]
        public String MACAddress { get; set; }
        [Display(Name="Nome")]
        public String FirstName { get; set; }
        [Display(Name = "Cognome")]
        public String LastName { get; set; }
        [Display(Name = "Codice Fiscale")]
        public String FiscalCode { get; set; }
        [Display(Name = "Matricola")]
        public String SerialNumber { get; set; }
    }
}