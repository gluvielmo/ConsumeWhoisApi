using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumeWhoisAPIv2.Models
{
    public class DomainModel
    {
        [Key]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("registered")]
        public Boolean Registered { get; set; }

        [JsonProperty("created")]
        public string RegisterDate { get; set; }

        [JsonProperty("changed")]
        public string LastUpdate { get; set; }

        [JsonProperty("expires")]
        public string ExpiresAt { get; set; }

        [JsonProperty("nameservers")]
        public string[] NameServers { get; set; }

    }
}
