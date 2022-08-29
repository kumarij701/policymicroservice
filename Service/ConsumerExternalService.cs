﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PolicyAPI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PolicyAPI.Service
{
    public class ConsumerExternalService 
    {

        private readonly IConfiguration _configuration;
        public ConsumerExternalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Business GetBusinessById(int id, string authtoken)
        {
            var client = new HttpClient();
            string url = _configuration.GetSection("PolicyApi:Businessapi").Value;
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var Res = client.GetAsync(url).Result;
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = client.GetAsync(url).Result;

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var BusinessResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                var BusinessInfo = JsonConvert.DeserializeObject<Business>(BusinessResponse);
                return BusinessInfo;
            }
            else
            {
                return null;
            }
        }


        public Property GetPropertiesById(int id, string authtoken)
        {
            var client = new HttpClient();
            string url = _configuration.GetSection("PolicyApi:Propertyapi").Value;
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var Res = client.GetAsync(url).Result;
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = client.GetAsync(url).Result;

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var PropertyResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                var PropertyInfo = JsonConvert.DeserializeObject<Property>(PropertyResponse);
                return PropertyInfo;
            }
            else
            {
                return null;
            }
        }


    }
}
