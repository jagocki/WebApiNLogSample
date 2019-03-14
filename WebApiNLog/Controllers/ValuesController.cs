using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiNLog.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ITestClass testClass;
    
        public ValuesController(ITestClass testClass)
        {
            this.testClass = testClass;
        }
        
        // GET api/values
        public virtual IEnumerable<string> Get()
        {
            List<string> connStrings = new List<string>();
            foreach (var item in ConfigurationManager.ConnectionStrings)
            {
                connStrings.Add(item.ToString());
            }

            var result = this.testClass.Test("hej hej");
            return connStrings;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
