using SimplePatientWebAPI.Domain;
using SimplePatientWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePatientWebAPI.Repositories
{
    interface IPatientRepository
    {

        List<PatientViewModel> getAllPatients();

        PatientViewModel getPatientById(int id);

        Boolean registerPatient(Patient patient);

        Boolean updatePatient(int patientID, Patient patient);

    }
}
