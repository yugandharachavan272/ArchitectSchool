using SimplePatientWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimplePatientWebAPI.ViewModel;
using SimplePatientWebAPI.Data.Context;

namespace SimplePatientWebAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private HospitalDBContext _ctx;

        public PatientRepository()
        {
            _ctx = new HospitalDBContext();
        }

        public List<PatientViewModel> getAllPatients()
        {
            
            List<PatientViewModel> patientVMlist = new List<PatientViewModel>();

            var patientList = (from tblPatient in _ctx.Patients
                               join tblHospital in _ctx.Hospitals on tblPatient.hospitalID equals tblHospital.ID
                               select new { tblPatient.Name, tblPatient.DateOfBirth, tblPatient.Address, tblPatient.phone, tblHospital.HospitalName }).ToList();
           

            foreach (var patientData in patientList)
            {
                PatientViewModel model = new PatientViewModel();
                model.Name = patientData.Name;
                model.DateOfBirth = patientData.DateOfBirth;
                model.Address = patientData.Address;
                model.phone = patientData.phone;
                model.Hospitalname = patientData.HospitalName;
                patientVMlist.Add(model);
            }

            return patientVMlist;

        }

        public PatientViewModel getPatientById(int id)
        {

            var patientData = (from tblPatient in _ctx.Patients
                               join tblHospital in _ctx.Hospitals on tblPatient.hospitalID equals tblHospital.ID
                               where tblPatient.ID == id
                               select new { tblPatient.Name, tblPatient.DateOfBirth, tblPatient.Address, tblPatient.phone, tblHospital.HospitalName }).FirstOrDefault();


            PatientViewModel model = new PatientViewModel
            {
                Name = patientData.Name,
                DateOfBirth = patientData.DateOfBirth,
                Address = patientData.Address,
                phone = patientData.phone,
                Hospitalname = patientData.HospitalName
            };

            return model ;
        }

        public bool registerPatient(Patient patient)
        {
            _ctx.Patients.Add(patient);

            return Convert.ToBoolean(_ctx.SaveChanges());
        }

        public bool updatePatient(int patientID, Patient patient)
        {
            patient.ID = patientID;
            _ctx.Entry(patient).State = patientID == 0 ? EntityState.Added : EntityState.Modified;

            return Convert.ToBoolean(_ctx.SaveChanges());
        }
        
        
    }
}