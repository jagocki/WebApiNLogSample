using System;
using System.Collections.Generic;
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

            var result = this.testClass.Test("hej hej");
            return new string[] { "value1", "value2" };
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
