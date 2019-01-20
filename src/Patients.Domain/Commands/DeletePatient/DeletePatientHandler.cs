using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patients.Domain {
    public class DeletePatientHandler : ADBRequestHandler<Patient, DeletePatientCommand, bool> {
        public override Task<bool> HandleAsync(DeletePatientCommand req, CancellationToken cancellationToken) {
            var patient = new Patient { Id = req.Data };
            req.Context.RemoveEntity(patient);
            req.Context.SaveContextChanges();
            return Task.FromResult(true);
        }
    }
}
