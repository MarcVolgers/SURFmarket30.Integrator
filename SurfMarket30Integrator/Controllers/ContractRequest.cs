using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SURF.Surfmarket30.Shared.Enums;
using System.Collections.Generic;

namespace SURF.Surfmarket30.Integrator.Controllers
{
    /// <summary>
    /// The request model for a contract
    /// </summary>
    public class ContractRequest
    {
        /// <summary>
        /// The id of a contract
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// The id of an institute
        /// </summary>
        public int? InstituteId { get; set; }
        /// <summary>
        /// The role of the requester
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public PersonRoleFunction Role { get; set; }
        /// <summary>
        /// List of statuses
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<ContractStatus> ContractStatuses { get; set; }
        /// <summary>
        /// List of contract types
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<ContractType> ContractTypes { get; set; }
        /// <summary>
        /// List of document types
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<DocumentType> DocumentTypes { get; set; }
        /// <summary>
        /// By default false, if true then any of the properties that are not null apply. If false then all of the properties that are not null apply
        /// </summary>
        public bool Or { get; set; }
    }
}