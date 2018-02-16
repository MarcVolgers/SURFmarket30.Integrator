using SURF.Surfmarket30.MockupData;
using SURF.Surfmarket30.Shared;
using SURF.Surfmarket30.Shared.Enums;
using SURF.Surfmarket30.Shared.Models;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SURF.Surfmarket30.Integrator.Controllers
{
    /// <summary>
    /// Controller for contract api calls.
    /// </summary>
    public class ContractController : ApiController
    {
        private IContractRepository _contractRepository;

        /// <summary>
        /// Instance
        /// </summary>
        public ContractController()
        {
            _contractRepository = new ContractRepository();
        }

        /// <summary>
        /// Get contracts by request.
        /// </summary>
        /// <param name="request">The requestobject,  a value for 'Role' is requiered.</param>
        /// <returns></returns>
        // POST: api/Contract/Get
        [HttpPost]
        [ResponseType(typeof(List<Contract>))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Contract>))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ContractRequestExamples))]
        //[SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ErrorResource>))]
        public HttpResponseMessage Get([FromBody]ContractRequest request)
        {
            try
            {
                ValidateRequest(request);
                var contracts = _contractRepository.GetContracts(request.Id, request.InstituteId, request.ContractStatuses, request.ContractTypes, request.DocumentTypes, request.Or);
                return Request.CreateResponse(HttpStatusCode.OK, contracts);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get an example contract request.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ContractRequest GetExampleContractRequest()
        {
            return new ContractRequest()
            {
                Id = 1,
                InstituteId = 2,
                Role = PersonRoleFunction.LicentieContactPersoon,
                ContractStatuses = new List<ContractStatus>() { ContractStatus.Aanbesteding, ContractStatus.Actief },
                ContractTypes = new List<ContractType>() { ContractType.DienstverleningsOvereenkomst, ContractType.Lidmaatschap },
                DocumentTypes = new List<DocumentType>() { DocumentType.Bijlage }
            };
        }

        private bool ValidateRequest(ContractRequest request)
        {
            var validRole = new[] { PersonRoleFunction.LicentieContactPersoon }.Any(r => r == request.Role);

            if (!validRole)
            {
                throw new Exception("Invalid role");
            }

            return validRole;
        }
    }

    public class ContractRequestExamples : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ContractRequest()
            {
                Id = 1,
                Role = PersonRoleFunction.LicentieContactPersoon
            };
        }
    }
}
