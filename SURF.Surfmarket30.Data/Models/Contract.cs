using SURF.SurfMarket30.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.SurfMarket30.Data.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Titel​ { get; set; }
        public ContractStatus Status​ { get; set; }
        public string Revisie​ { get; set; }
        public DateTime DatumStart​ { get; set; }
        public DateTime DatumEind​ { get; set; }
        public DateTime DatumGetekend { get; set; }
        public int LeverancierId​ { get; set; }
        public int FabrikantId​ { get; set; }
        public ContractType ContractType { get; set; }
        public DocumentType Document​ { get; set; }
        public decimal ContractWaarde { get; set; }
        public int ContactOndertekenaarId { get; set; }
        public virtual Contact ContactOndertekenaar { get; set; }
        public int ContactBeheerderId { get; set; }
        public virtual Contact ContactBeheerder { get; set; }
        public int UserBeheerderId { get; set; }
        public virtual User UserBeheerder { get; set; }
        public int UserAuteurId { get; set; }
        public virtual User UserAuteur { get; set; }
        public string DocumentUrl { get; set; }
        public virtual List<ContractBijlage> Bijlagen { get; set; }
        public virtual List<ContractComponent> Componenten { get; set; }
    }
}

