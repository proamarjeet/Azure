using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using CIP_1.ServiceAgentInterfaces;
using CIP_1.ServiceLocatorInterfaces;
using CIP_1.DataModel;

namespace CIP_1.Facade
{
    public class SubscriptionFacade
    {
        public const string KPM_NUMBER_PARAMCODE = "PA_INTERNET_NO";
        public const string MOBILE_NUMBER_LID_PARAMCODE = "PA_LID";
        public const string MOBILE_NUMBER_MSISDN_PARAMCODE = "MSISDN";

        public const string EMAILSTATUS_MAX_EMAIL_SIZE = "1.2GB";
        public const int EMAILSTATUS_MAX_EMAILS_IN_INBOX = 1000;

        private readonly ISubscriptionAgent _subscriptionAgent;

        public SubscriptionFacade()
        { }

        public async Task<List<Subscription>> SubscriptionFacade1()//IServiceLocator serviceLocator
        {
            //customerFacade = new CustomerFacade(serviceLocator);
           //_subscriptionAgent = serviceLocator.GetService<ISubscriptionAgent>();

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://bc13-new.test.tdc.dk");

                    // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                   client.DefaultRequestHeaders.Add("x-tdc-user-roles", "CIP_PORTAL");
                    client.DefaultRequestHeaders.Add("x-tdc-username", "m32321");
                    client.DefaultRequestHeaders.Add("x-tdc-has-migrated-to-yspro", "true");
                    client.DefaultRequestHeaders.Add("SSOID", "m32321");
                    client.DefaultRequestHeaders.Add("Authorization", "Basic Y2lwX3Rlc3QwMDE6YWJjMTIz");

                    //client.DefaultRequestHeaders.Add("", "");

                    // var response = await client.GetAsync($"");

                   // var serializer = new DataContractJsonSerializer(typeof(List<Subscription>));

                    var response = await client.GetAsync($"/bc/secure/subscription?subscriptionId=87341127");
                    response.EnsureSuccessStatusCode();

                    //serializer.ReadObject(await response.Content.ReadAsStringAsync()) as List<repo>

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<List<Subscription>>(stringResult);
                    //return Ok(new
                    //{
                    //    Temp = rawWeather.Main.Temp,
                    //    Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                    //    City = rawWeather.Name
                    //});
                    return rawWeather;
                    
                }
                catch (HttpRequestException httpRequestException)
                {
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

public async Task<List<CustomerNote>> ActiveUserGuideFacade()//IServiceLocator serviceLocator
        {
            //customerFacade = new CustomerFacade(serviceLocator);
           //_subscriptionAgent = serviceLocator.GetService<ISubscriptionAgent>();

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://bc13-new.test.tdc.dk");

                    // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                   client.DefaultRequestHeaders.Add("x-tdc-user-roles", "CIP_PORTAL");
                    client.DefaultRequestHeaders.Add("x-tdc-username", "m32321");
                    client.DefaultRequestHeaders.Add("x-tdc-has-migrated-to-yspro", "true");
                    client.DefaultRequestHeaders.Add("SSOID", "m32321");
                    client.DefaultRequestHeaders.Add("Authorization", "Basic Y2lwX3Rlc3QwMDE6YWJjMTIz");

                    //client.DefaultRequestHeaders.Add("", "");

                    // var response = await client.GetAsync($"");

                   // var serializer = new DataContractJsonSerializer(typeof(List<Subscription>));

                    var response = await client.GetAsync($"/bc/secure/customer/notes/userid/m32321?pageSize=45&page=0&status=Active");
                    response.EnsureSuccessStatusCode();

                    //serializer.ReadObject(await response.Content.ReadAsStringAsync()) as List<repo>

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<List<CustomerNote>>(stringResult);
                    //return Ok(new
                    //{
                    //    Temp = rawWeather.Main.Temp,
                    //    Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                    //    City = rawWeather.Name
                    //});
                    return rawWeather;
                    
                }
                catch (HttpRequestException httpRequestException)
                {
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public List<Subscription> searchSubscriptions(string subscriptionId)
        {
            var subscriptions = _subscriptionAgent.searchSubscriptions(subscriptionId);
            return subscriptions;
        }
    }
}
