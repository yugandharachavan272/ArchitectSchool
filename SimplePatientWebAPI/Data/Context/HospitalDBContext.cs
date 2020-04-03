using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimplePatientWebAPI.Domain;
using System.ComponentModel.DataAnnotations.Schema;


namespace SimplePatientWebAPI.Data.Context
{
    public class HospitalDBContext: DbContext
    {

        public HospitalDBContext() :base("Data Source=SCS-ME16;Initial Catalog=HospitalDB;Integrated Security=true")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasRequired<Hospital>(b => b.objHospital).WithMany(a => a.patients).HasForeignKey<int>(b => b.hospitalID);
        }
        
    }
}