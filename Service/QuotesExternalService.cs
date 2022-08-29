using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PolicyAPI.Service
{
    public class QuotesExternalService
    {
        private readonly IConfiguration _configuration;
        public QuotesExternalService( IConfiguration configuration)
        {
           // _policyRepo = policyrepo;
            _configuration = configuration;
        }
        
        public int GetQuote(int BusinessValue, int PropertyValue, string authtoken)
        {
            var client = new HttpClient();
            string url = _configuration.GetSection("PolicyApi:Consumerapi").Value;
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", authtoken);
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var Res = client.GetAsync(url).Result;
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = client.GetAsync(url).Result;

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var quoteResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                int quoteInfo = JsonConvert.DeserializeObject<int>(quoteResponse);
                return quoteInfo;
            }
            else
            {
                return 0;
            }
        }
    }
}
