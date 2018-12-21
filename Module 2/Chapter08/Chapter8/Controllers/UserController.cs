using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly;
using Polly.Caching;
using Polly.CircuitBreaker;
using Polly.Registry;
using UserRegService.Resilient;

namespace Chapter8.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        IResilientHttpClient _resilientClient;
        CachePolicy<HttpResponseMessage> _cachePolicy;

        HttpClient _client;
        CircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy;
        public UserController(HttpClient client, IResilientHttpClient resilientClient, IPolicyRegistry<string> registry)
        {
            _client = client;
           // _circuitBreakerPolicy = circuitBreakerPolicy;
            _resilientClient = resilientClient;

            _cachePolicy = registry.Get<CachePolicy<HttpResponseMessage>>("cache");
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {

            //Email service URL
            string emailService = "http://localhost:80/api/Email";

            var response = _resilientClient.Post(emailService, user);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                return Ok(result);
            }

            return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync());
           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            // HttpClient clnt = new HttpClient();
            // var response = clnt.GetAsync("http://localhost:7637/api/values").Result;
            
            //Specify the name of the Response. If the method is taking parameter, we can append the actual parameter to cache unique responses separately
            Context policyExecutionContext = new Context($"GetUsers");

            var response = _cachePolicy.Execute(()=> _resilientClient.Get("http://localhost:7637/api/values"), policyExecutionContext);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                return Ok(result);
            }

            return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync());
        }
       
      
        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]User user)
        //{

        //    //Email service URL
        //    string emailService = "http://localhost:80/api/Email";

        //    //Serialize user object into JSON string
        //    HttpContent content = new StringContent(JsonConvert.SerializeObject(user));

        //    //Setting Content-Type to application/json
        //    _client.DefaultRequestHeaders
        //    .Accept
        //    .Add(new MediaTypeWithQualityHeaderValue("application/json"));


        //    int maxRetries = 3;

        //    //Define Retry policy and set max retries limit and duration between each retry to 3 seconds
        //    var retryPolicy = Policy.Handle<HttpRequestException>().WaitAndRetryAsync(maxRetries, sleepDuration=> TimeSpan.FromSeconds(3));


        //    //Call service and wrap HttpClient PostAsync into retry policy
        //    retryPolicy.ExecuteAsync(async () => {
        //        var response =  _client.PostAsync(emailService, content).Result;
        //        response.EnsureSuccessStatusCode();
        //    });

        //}


    }
}
