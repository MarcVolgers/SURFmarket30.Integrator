using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SURF.Surfmarket30.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.Shared.Models
{    
    public class Contract : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ContractStatus Status​ { get; set; }
        public string Revisie​ { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatumStart​ { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatumEind​ { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatumGetekend { get; set; }
        public int LeverancierId​ { get; set; }
        public Organization Leverancier { get; set; }
        public int FabrikantId​ { get; set; }
        public Organization Fabrikant { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ContractType ContractType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType DocumentType​ { get; set; }
        [DataType(DataType.Currency)]
        public decimal ContractWaarde { get; set; }
        public int ContactOndertekenaarId { get; set; }
        public Person ContactOndertekenaar { get; set; }
        public int ContactBeheerderId { get; set; }
        public Person ContactBeheerder { get; set; }
        public int UserBeheerderId { get; set; }
        public Person UserBeheerder { get; set; }
        public int UserAuteurId { get; set; }
        public Person UserAuteur { get; set; }
        public string DocumentUrl { get; set; }
        public List<ContractBijlage> Bijlagen { get; set; }
        public List<ContractComponent> Componenten { get; set; }
        public List<Organization> AllowedOrganizations { get; set; }
    }
}

