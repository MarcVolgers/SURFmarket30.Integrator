using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.SurfMarket30.Data.Models
{
    public class ContractComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Labels { get; set; }
    }
}
