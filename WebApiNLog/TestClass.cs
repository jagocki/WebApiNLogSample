using Autofac.Extras.DynamicProxy;
using Autofac.Extras.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiNLog
{
    [Intercept("log-calls")]
    public interface ITestClass
    {
        string Test(string par);
    }


    public class TestClass : ITestClass
    {
        private readonly ILogger _logger;

        public TestClass(ILogger logger)
        {
            _logger = logger;
        }


        public string Test(string parametr)
        {
            _logger.Info("My Info: {myinfo}", new { Id = 6, Name = "Coco Jumbo", Color = "Orange" });
            return parametr.ToUpper();
        }
    }
}
