using Patients.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.Web {
    public static class DbInitializer {
        public static void Initialize(PatientContext context) {
            context.Database.EnsureCreated();

            if (context.Patients.Any()) { return; }

            var patients = new Patient[] {
                new Patient { GivenName = "Ali", FamilyName = "Zaib", ContactNumber = "334512xxxx", DoB = new DateTime(1984, 3, 24), PasNumber = "1", SexCode = "M",
                    NextOfKin = new Kin { Name = "Amir Zaib", RelationshopCode = "Brother", Address = "Full Address here" }
                },
                new Patient { GivenName = "Imran", FamilyName = "Zaib", ContactNumber = "334512xxxx", DoB = new DateTime(1992, 3, 24), PasNumber = "2", SexCode = "M",
                    NextOfKin = new Kin { Name = "Jehan Zaib", RelationshopCode = "Brother", Address = "Full Address here" }
                },
                new Patient { GivenName = "Diya", FamilyName = "Ali", ContactNumber = "334512xxxx", DoB = new DateTime(1984, 3, 24), PasNumber = "1", SexCode = "F",
                    NextOfKin = new Kin { Name = "Ali Zaib", RelationshopCode = "Husband", Address = "Full Address here" }
                },
            };

            context.Patients.AddRange(patients);

            context.SaveChanges();
        }
    }
}
