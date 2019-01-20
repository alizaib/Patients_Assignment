using AutoMapper;
using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patients.Domain.Commands.UpdatePatient {
    public class UpdatePatientHandler : ADBRequestHandler<Patient, UpdatePatientCommand, PatientRes> {
        public override Task<PatientRes> HandleAsync(UpdatePatientCommand req, CancellationToken cancellationToken) {

            var patient = Mapper.Map<Patient>(req.Data);
            req.Context.UpdateEntity(patient);
            req.Context.SaveContextChanges();
            var result = Mapper.Map<PatientRes>(patient);
            return Task.FromResult(result);
        }
    }
}
