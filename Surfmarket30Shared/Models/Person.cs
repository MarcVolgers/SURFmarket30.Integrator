using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.Shared.Models
{
    public class Person : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonRole> Roles { get; set; }
    }
}
