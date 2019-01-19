using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patients.Core;
using Patients.Domain;

namespace Patients.Web.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController<Patient> {
        public PatientController(IContext<Patient> context, IMediator mediator) : base(context, mediator) {
        }
        
        [HttpPost]
        public Task<PatientRes> Post(PatientReq req) {
            return SendAsync<CreatePatientCommand, PatientReq, PatientRes>(req);
            
        }
    }
}
