using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimplePatientWebAPI.Domain;


namespace SimplePatientWebAPI.ViewModel
{
    public class PatientViewModel
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string phone { get; set; }

        public string Hospitalname { get; set; }

        public PatientViewModel()
        {
            
        }
    }
}