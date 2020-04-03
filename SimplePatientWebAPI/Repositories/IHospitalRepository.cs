using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePatientWebAPI.Domain;

namespace SimplePatientWebAPI.Repositories
{
    interface IHospitalRepository
    {
        IEnumerable<Hospital> getHospitallist();

        Hospital getHospitalByID(int id);

        Boolean registerHospital(Hospital  patient);

        Boolean updateHospitalInfo(int hosipitalID, Hospital  hospital);

    }
}
