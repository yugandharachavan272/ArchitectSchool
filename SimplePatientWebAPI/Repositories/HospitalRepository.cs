using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimplePatientWebAPI.Domain;
using SimplePatientWebAPI.Data.Context;
using System.Data.Entity;

namespace SimplePatientWebAPI.Repositories
{
    public class HospitalRepository:IHospitalRepository
    {
        private HospitalDBContext _ctx;


        public HospitalRepository()
        {
            _ctx = new HospitalDBContext();
        }

        public IEnumerable<Hospital> getHospitallist()
        {
            return _ctx.Hospitals;
        }

        public Hospital getHospitalByID(int id)
        { 
            return _ctx.Hospitals.Find(id);
        }

        public bool registerHospital(Hospital hospital)
        {
            _ctx.Hospitals.Add(hospital);

            return Convert.ToBoolean(_ctx.SaveChanges());
        }

        public bool updateHospitalInfo(int hosipitalID, Hospital hospital)
        {
            hospital.ID = hosipitalID;
            _ctx.Entry(hospital).State = hosipitalID == 0 ? EntityState.Added : EntityState.Modified;

            return Convert.ToBoolean(_ctx.SaveChanges());
        }
    }
}