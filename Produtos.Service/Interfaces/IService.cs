using Produtos.Service.Helpers;
using System.Net;

namespace Produtos.Service.Interfaces
{
    public interface IService
    {
        ResponseService GenerateBadRequestServiceResponse
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService<T> GenerateBadRequestServiceResponse<T>
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService GenerateSuccessServiceResponse
            (HttpStatusCode status = HttpStatusCode.OK);
        ResponseService<T> GenerateSuccessServiceResponse<T>
            (T value, HttpStatusCode status = HttpStatusCode.OK);
        ResponseService GeneratePreconditionFailedServiceResponse
            (string message, HttpStatusCode status = HttpStatusCode.PreconditionFailed);
        ResponseService<T> GeneratePreconditionFailedServiceResponse<T>
            (string message, HttpStatusCode status = HttpStatusCode.PreconditionFailed);
    }
}
