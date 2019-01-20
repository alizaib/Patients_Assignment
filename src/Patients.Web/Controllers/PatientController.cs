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
        
        [HttpPost("CreatePatient")]
        public Task<PatientRes> CreatePatient(PatientReq req) {
            return SendAsync<CreatePatientCommand, PatientReq, PatientRes>(req);
            
        }
        [HttpPost("UpdatePatient/{PatientId:int}")]
        public Task<PatientRes> CreatePatient(UpdatePatientReq req) {
            int Id = System.Int32.Parse(this.ControllerContext.RouteData.Values["PatientId"].ToString());
            req.Id = Id;
            return SendAsync<UpdatePatientCommand, UpdatePatientReq, PatientRes>(req);

        }
        [HttpPost("FindPatient")]
        public Task<IEnumerable<PatientRes>> FindPatient(PatientCriteria req) {
            return SendAsync<FindPatientQuery, PatientCriteria, IEnumerable<PatientRes>>(req);

        }
        [HttpPost("GetAll")]
        public Task<IEnumerable<PatientRes>> GetAll() {
            return FindPatient(null);

        }
        [HttpDelete("Delete/{PatientId:int}")]
        public Task<bool> DeletePatient() {
            int Id = System.Int32.Parse(this.ControllerContext.RouteData.Values["PatientId"].ToString());
            return SendAsync<DeletePatientCommand, int, bool>(Id);
        }
    }
}
