using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO.Account
{
    public  class GenericResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("traceId")]
        public string TraceId { get; set; }
        [JsonProperty("errors")]
        public Erros[] Erros { get; set; }
    }

    public class Erros
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }
        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }
    }
}
