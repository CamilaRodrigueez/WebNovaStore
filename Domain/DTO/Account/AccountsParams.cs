using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO.Account
{
    public class AccountsParams
    {
        [JsonProperty("codCli")]
        [MaxLength(15)]
        [Required]
        public string CodCli { get; set; }
        [JsonProperty("tipIde")]
        [MaxLength(2)]
        [Required]
        public string TipIde { get; set; }
        [JsonProperty("nitCli")]
        [MaxLength(15)]
        [Required]
        public string NitCli { get; set; }
        [JsonProperty("nomCli")]
        [MaxLength(200)]
        [Required]
        public string NomCli { get; set; }
        [JsonProperty("ap1Cli")]
        [MaxLength(50)]
        [AllowNull]
        public string Ap1Cli { get; set; }
        [JsonProperty("nom1Cli")]
        [MaxLength(50)]
        [AllowNull]
        public string Nom1Cli { get; set; }
        [JsonProperty("eMail")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EMail { get; set; }
        [JsonProperty("tipPer")]
        [Range(1,2,ErrorMessage ="Debe ser el número 1 o 2.")]
        [Required]
        public int TipPer { get; set; }
        [JsonProperty("codCiu")]
        [MaxLength(5)]
        [Required]
        public string CodCiu { get; set; }
        [JsonProperty("codDep")]
        [MaxLength(2)]
        [Required]
        public string CodDep { get; set; }
        [JsonProperty("codPai")]
        [MaxLength(3)]
        [Required]
        public string CodPai { get; set; }
        [JsonProperty("di1Cli")]
        [MaxLength(100)]
        [AllowNull]
        public string Di1Cli { get; set; }
        [JsonProperty("di2Cli")]
        [MaxLength(100)]
        [AllowNull]
        public string Di2Cli { get; set; }
        [JsonProperty("te1Cli")]
        [MaxLength(15)]
        [AllowNull]
        public string Te1Cli { get; set; }
        [JsonProperty("tipCli")]
        [Range(1, 5,ErrorMessage ="Debe ser un número entre 1 y 5")]
        [Required]
        public int TipCli { get; set; }
        [JsonProperty("pagWeb")]
        [AllowNull]
        public string PagWeb { get; set; }
        [JsonProperty("fecIng")]
        [Required]
        public DateTime FecIng { get; set; }
        [JsonProperty("codCliExtr")]
        [AllowNull]
        public string CodCliExtr { get; set; }
    }

}
