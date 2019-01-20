using Patients.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace Patients.Domain {
    public class FindPatientHandler : ADBRequestHandler<Patient, FindPatientQuery, IEnumerable<PatientRes>> {
        public override Task<IEnumerable<PatientRes>> HandleAsync(FindPatientQuery req, CancellationToken cancellationToken) {
            var predicate = PredicateBuilder.True<Patient>();
            if (req.Data?.GivenName != null)
                predicate = predicate.And(p => p.GivenName.Contains(req.Data.GivenName));
            if (req.Data?.FamilyName != null)
                predicate = predicate.And(p => p.FamilyName.Contains(req.Data.FamilyName));
            if (req.Data?.NextOfKin?.Name != null)
                predicate = predicate.And(k => k.NextOfKin.Name.Contains(req.Data.NextOfKin.Name));

            var result = req.Context.FindBy(predicate).AsEnumerable().Select(patient => Mapper.Map<PatientRes>(patient));

            return Task.FromResult(result);
        }
    }
}
