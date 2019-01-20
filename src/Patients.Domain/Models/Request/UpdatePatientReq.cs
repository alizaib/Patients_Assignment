using FluentValidation;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Domain {
    public class UpdatePatientReq {
        public int Id { get; set; }
        public string PasNumber { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DoB { get; set; }
        public string SexCode { get; set; }
        public string ContactNumber { get; set; }
        public Kin NextOfKin { get; set; }
    }
    public class UpdatePatientReqValidator : AbstractValidator<UpdatePatientReq> {
        public UpdatePatientReqValidator() {
            RuleFor(m => m.GivenName).NotEmpty().NotNull().WithMessage("Given name of the patient is required");
        }
    }

    public class UpdatePatientReqExample : IExamplesProvider<UpdatePatientReq> {
        public UpdatePatientReq GetExamples() {
            return new UpdatePatientReq {
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
