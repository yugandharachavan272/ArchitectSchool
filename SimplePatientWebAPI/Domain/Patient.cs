using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SimplePatientWebAPI.Domain
{    
    public class Patient
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string  phone { get; set; }
       
        public int hospitalID { get; set; }

        public Hospital objHospital { get; set; }

    }
}