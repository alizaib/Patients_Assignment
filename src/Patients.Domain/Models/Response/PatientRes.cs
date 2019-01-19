using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Domain {
    public class PatientRes {
        public int Id { get; set; }
        public string PasNumber { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DoB { get; set; }
        public string SexCode { get; set; }
        public string ContactNumber { get; set; }
        public Kin NextOfKin { get; set; }
    }
}
