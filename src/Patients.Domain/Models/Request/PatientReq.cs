using FluentValidation;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Domain {
    public class PatientReq {
        public string PasNumber { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DoB { get; set; }
        public string SexCode { get; set; }
        public string ContactNumber { get; set; }
        public Kin NextOfKin { get; set; }
    }
    public class PatientReqValidator : AbstractValidator<PatientReq> {
        public PatientReqValidator() {
            RuleFor(m => m.GivenName).NotEmpty().NotNull().WithMessage("Given name of the patient is required");
        }
    }
    public class PatientReqExample : IExamplesProvider<PatientReq> {
        public PatientReq GetExamples() {
            return new PatientReq {
                GivenName = "Ali",
                FamilyName = "Zaib",
                ContactNumber = "334512xxxx",
                DoB = new DateTime(1984, 3, 24),
                PasNumber = "1",
                SexCode = "M",
                NextOfKin = new Kin { Name = "Amir Zaib", RelationshopCode = "Brother", Address = "Full Address here" }
            };
        }
    }
}
