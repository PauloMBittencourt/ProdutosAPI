using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Produtos.Service.Helpers
{
    public class ResponseService
    {
        public HttpStatusCode  StatusCode{ get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
    public class ResponseService<T> : ResponseService
    {
        public T Value { get; set; }
    }
}
