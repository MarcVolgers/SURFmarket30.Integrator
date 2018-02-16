using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.Shared.Models
{
    public class Organization : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OrganizationType OrganizationType { get; set; }
    }

    public enum OrganizationType
    {
        Supplier,
        Manufacturer,
        Institution
    }
}
