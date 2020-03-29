using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWhoisAPIv2.Models
{
    public class RequestApiModel
    {
        private readonly RestClient client;

        public RequestApiModel() => client = new RestClient("https://jsonwhoisapi.com/");

        public DomainModel DomainSearch(string domain)
        {
            var request = new RestRequest($"api/v1/whois?identifier={domain}", Method.GET);
            request.AddHeader("Authorization", "Vr-RsVJg4sDGOLndN5_eJw");

            var response = client.Execute(request);

            var domainResponse = JsonConvert.DeserializeObject<DomainModel>(response.Content);

            return domainResponse;
        }

    }
}
