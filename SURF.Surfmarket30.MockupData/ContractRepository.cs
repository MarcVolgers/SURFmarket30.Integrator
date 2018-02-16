using SURF.Surfmarket30.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SURF.Surfmarket30.Shared.Models;
using SURF.Surfmarket30.Shared.Enums;

namespace SURF.Surfmarket30.MockupData
{
    public class ContractRepository : IContractRepository
    {
        public List<Contract> GetContracts(int? id, int? instellingId, List<ContractStatus> status = null, List<ContractType> contractType = null, List<DocumentType> documentType = null, bool or = false)
        {
            return MockupData.Instance.Contracts.Where(c => FilterContract(c, id, instellingId, status, contractType, documentType, or)).ToList();
        }

        private bool FilterContract(Contract contract, int? id, int? instellingId, List<ContractStatus> status, List<ContractType> contractType, List<DocumentType> documentType, bool or)
        {
            var validId = !id.HasValue || contract.Id == id.Value;
            var validInstelling = !instellingId.HasValue || contract.AllowedOrganizations.Any(o => o.Id == instellingId.Value);
            var validStatus = status == null || status.Any(s => s == contract.Status);
            var validContractType = contractType == null || contractType.Any(t => t == contract.ContractType);
            var validDocumentType = documentType == null || documentType.Any(d => d == contract.DocumentType);

            if (or)
            {
                return validId || validInstelling || validStatus || validContractType || validDocumentType;
            }
            else
            {
                return validId && validInstelling && validStatus && validContractType && validDocumentType;
            }

        }
    }
}
