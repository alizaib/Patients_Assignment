using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Domain {
    public class UpdatePatientCommand : BaseDBRequest<Patient, UpdatePatientReq, PatientRes> {
    }
}
