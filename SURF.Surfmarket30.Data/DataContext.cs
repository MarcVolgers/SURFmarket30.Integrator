using SURF.SurfMarket30.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> ContactSet { get; set; }
        public DbSet<Contract> ContractSet { get; set; }
        public DbSet<ContractBijlage> ContractBijlageSet { get; set; }
        public DbSet<ContractComponent> ContractComponentSet { get; set; }
        public DbSet<Organization> OrganizationSet { get; set; }
        public DbSet<User> UserSet { get; set; }
    }
}
