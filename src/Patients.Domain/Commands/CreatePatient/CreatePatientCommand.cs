using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Domain {
    public class CreatePatientCommand : BaseDBRequest<Patient, PatientReq,  PatientRes> {
    }
}
