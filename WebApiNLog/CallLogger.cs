using Autofac.Extras.NLog;
using Castle.DynamicProxy;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiNLog
{
    public class CallLogger : IInterceptor
    {
        private NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        public void Intercept(IInvocation invocation)
        {
            _logger.Info("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            _logger.Info("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}
