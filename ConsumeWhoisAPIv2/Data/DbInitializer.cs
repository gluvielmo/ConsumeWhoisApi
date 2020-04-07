using System;
using System.Collections.Generic;
using ConsumeWhoisAPIv2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeWhoisAPIv2.Data
{
    public class DbInitializer
    {
        public static void Initialize(DomainContext context)
        {
            context.Database.EnsureCreated();

            if (context.Domains.Any())
            {
                return;
            }

            string[] Ns = { "teste1.com", "teste2.com" };

            var domains = new DomainModel[]
            {
                new DomainModel{Name="teste.com",Registered=true,RegisterDate="04/09/2019",LastUpdate="04/04/2020",ExpiresAt="25/12/2021", NameServers=Ns}
            };
            foreach (DomainModel domain in domains)
            {
                context.Domains.Add(domain);
            }
            context.SaveChanges();
        }
    }
}
