using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Produtos.Service.Services
{
    public class ResponseService : IHttpActionResult
    {
        public HttpStatusCode  StatusCode{ get; set; }
        public string? Message { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
