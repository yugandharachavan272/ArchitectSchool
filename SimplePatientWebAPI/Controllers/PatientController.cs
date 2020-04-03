using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SimplePatientWebAPI.Domain;
using SimplePatientWebAPI.Repositories;
using SimplePatientWebAPI.ViewModel;


namespace SimplePatientWebAPI.Controllers
{
    public class PatientController : ApiController
    {
        IPatientRepository _patientRepository;

        public PatientController()
        {
            _patientRepository = new PatientRepository();
        }       

        // GET: api/Patient
        public List<PatientViewModel> Get()
        {
           return _patientRepository.getAllPatients();
        }

        // GET: api/Patient/5
        public PatientViewModel Get(int id)
        {
            return _patientRepository.getPatientById(id);
        }

        // POST: api/Patient
        public IHttpActionResult Post(Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrEmpty(patient.Name))
                {
                    return Ok("data:" + _patientRepository.registerPatient(patient));
                }
                else
                {
                    return Ok("data:False");
                }
            }
            else
            {
                return BadRequest("request can not be null");
            }

        }

        // PUT: api/Patient/5
        public IHttpActionResult Put(int id,Patient patient)
        {
            if (patient != null)
            {
                
                if (!string.IsNullOrEmpty(patient.Name) && id > 0)
                {
                    return Ok("data:" + _patientRepository.updatePatient(id, patient));
                }
                else
                {
                    return Ok("data:False");
                }
            }
            else
            {
                return BadRequest("request can not be null");
            }
        }

    }
}
