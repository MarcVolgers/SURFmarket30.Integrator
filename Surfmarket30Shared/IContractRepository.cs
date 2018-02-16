using SURF.Surfmarket30.Shared.Enums;
using SURF.Surfmarket30.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.Shared
{
    public interface IContractRepository
    {
        List<Contract> GetContracts(int? id, int? instellingId, List<ContractStatus> status = null, List<ContractType> contractType = null, List<DocumentType> documentType = null, bool or = false);
    }
}
