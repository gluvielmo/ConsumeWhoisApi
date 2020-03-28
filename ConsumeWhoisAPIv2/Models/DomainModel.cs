using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWhoisAPIv2.Models
{
    public class DomainModel
    {
        public int Id { get; set; }

        // Claro
        public string Name { get; set; }
        public string Status { get; set; }
        public string RegisterDate { get; set; }
        public string LastUpdate { get; set; }
        public string Expires { get; set; }
        public string[] NameServers { get; set; }   

    }
}
