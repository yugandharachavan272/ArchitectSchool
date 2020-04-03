using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace SimplePatientWebAPI.Domain
{
    public class Hospital
    { 
        [Key]
        public int ID { get; set; }

        public string HospitalName { get; set; }

        public ICollection<Patient> patients { get; set; }
    }
}