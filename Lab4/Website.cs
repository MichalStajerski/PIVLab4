using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Website
    {
        public static async Task<IRestResponse> Download(string domain, string path, Method method = Method.GET)
        {
            var client = new RestClient(domain);
            return await client.ExecuteAsync(new RestRequest(path), method);
        }
    }
}
