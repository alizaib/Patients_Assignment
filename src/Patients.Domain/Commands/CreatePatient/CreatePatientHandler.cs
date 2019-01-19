using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Patients.Domain {
    public class CreatePatientHandler : ADBRequestHandler<Patient, CreatePatientCommand, PatientRes> {

        public override Task<PatientRes> HandleAsync(CreatePatientCommand req, CancellationToken cancellationToken) {

            var patient = Mapper.Map<Patient>(req.Data);
            req.Context.AddEntity(patient);
            req.Context.SaveContextChanges();
            var result = Mapper.Map<PatientRes>(patient);
            return Task.FromResult(result);
        }
    }
}
