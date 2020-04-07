using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeWhoisAPIv2.Models
{
    public class DomainViewModel
    {
        public DomainModel DomainAPI { get; set; }
        public IEnumerable<DomainModel> DomainDB { get; set; }
    }
}
