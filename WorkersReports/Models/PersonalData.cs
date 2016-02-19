using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WorkersReports.Models
{
    [DataContract]
    public class PersonalData
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [Required]
        [DataMember]
        [Display(Name = "MAC Address")]
        public String MACAddress { get; set; }
        [Required]
        [DataMember]
        [Display(Name="Nome")]
        public String FirstName { get; set; }
        [Required]
        [DataMember]
        [Display(Name = "Cognome")]
        public String LastName { get; set; }
        [DataMember]
        [Display(Name = "Codice Fiscale")]
        public String FiscalCode { get; set; }
        [DataMember]
        [Display(Name = "Matricola")]
        public String SerialNumber { get; set; }

        [DataMember]
        public ICollection<WorkerData> WorkerDatas { get; set; }

    }
}