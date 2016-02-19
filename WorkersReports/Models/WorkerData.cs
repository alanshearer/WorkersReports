using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace WorkersReports.Models
{
    [Serializable]
    [DataContract]
    public enum WorkerDataTipology
    {
        [EnumMember]
        [XmlEnum("0")]
        Entry = 0,
        [EnumMember]
        [XmlEnum("1")]
        Exit = 1
    };

    [DataContract]
    public class WorkerData
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public String Latitude { get; set; }
        [DataMember]
        public String Longitude { get; set; }
        [DataMember]
        public WorkerDataTipology Tipology { get; set; }
        [DataMember]
        public int PersonalDataId { get; set; }
        [DataMember]
        public PersonalData PersonalData { get; set; }


        public WorkerData()
        {
            PersonalData = new PersonalData();
        }

    }
}