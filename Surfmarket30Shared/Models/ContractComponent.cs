using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.Shared.Models
{
    public class ContractComponent : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Labels { get; set; }
    }
}
