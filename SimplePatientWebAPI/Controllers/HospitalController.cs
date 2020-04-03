using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimplePatientWebAPI.Domain;
using SimplePatientWebAPI.Repositories;


namespace SimplePatientWebAPI.Controllers
{
    public class HospitalController : ApiController
    {

        IHospitalRepository _hospitalRepository;


        public HospitalController()
        {
            _hospitalRepository = new HospitalRepository();
        }     

        // GET: api/Hospital
        public IEnumerable<Hospital> Get()
        {
            return _hospitalRepository.getHospitallist();
        }

        // GET: api/Hospital/5
        public Hospital Get(int id)
        {
            //return _patientRepository.getPatientById(id);

            return _hospitalRepository.getHospitalByID(id);
        }

        // POST: api/Hospital
        public IHttpActionResult Post([FromBody]Hospital hospital)
        {
            if (hospital != null)
            {
                if (!string.IsNullOrEmpty(hospital.HospitalName))
                {
                    return Ok("data:" + _hospitalRepository.registerHospital(hospital));
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

        // PUT: api/Hospital/5
        public IHttpActionResult Put(int id, [FromBody]Hospital hospital)
        {
            if (hospital != null)
            {
                if (!string.IsNullOrEmpty(hospital.HospitalName) && id > 0)
                {
                    return Ok("data:" + _hospitalRepository.updateHospitalInfo(id, hospital));
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
