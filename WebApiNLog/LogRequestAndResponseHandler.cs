using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiNLog
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {

        private ILogger _logger = LogManager.GetCurrentClassLogger();


        protected override async Task<HttpResponseMessage> SendAsync(
                    HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            string requestBody = await request.Content.ReadAsStringAsync();
            //Trace.WriteLine(requestBody);
            _logger.Info($"{request.Method.ToString()} {request.RequestUri.ToString()}");

            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                // once response body is ready, log it
                var responseBody = await result.Content.ReadAsStringAsync();
                //Trace.WriteLine(responseBody);
                _logger.Info($"{result.StatusCode.ToString()}");
            }

            return result;
        }
    }
}
