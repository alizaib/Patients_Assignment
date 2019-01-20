using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Domain {
    public class FindPatientQuery : BaseDBRequest<Patient, PatientCriteria, IEnumerable<PatientRes>> {
    }
}
