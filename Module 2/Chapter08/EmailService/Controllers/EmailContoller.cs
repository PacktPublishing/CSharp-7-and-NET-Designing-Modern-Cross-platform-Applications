using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    public class EmailContoller : Controller
    {
      
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string message)
        {

            try
            {
                var result = SendEmail(message);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
        }


        [HttpGet]
        public String Get()
        {
            return "hello world!";
        }

        private bool SendEmail(string message)
        {
            throw new NotImplementedException();
        }
    }
}
