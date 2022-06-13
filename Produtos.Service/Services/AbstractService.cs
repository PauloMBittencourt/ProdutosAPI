using FluentValidation.Results;
using Produtos.Service.Helpers;
using Produtos.Service.Interfaces;
using System.Net;

namespace Produtos.Service.Services
{
    public abstract class AbstractService : IService
    {
        public ResponseService GenerateBadRequestServiceResponse(string message, HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new()
            {
                Message = message,
                StatusCode = status,
                Success = false
            };

        public ResponseService<T> GenerateBadRequestServiceResponse<T>(string message, HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new()
            {
                Message = message,
                StatusCode = status,
                Success = false,
                Value = default
            };

        public ResponseService GenerateSuccessServiceResponse(HttpStatusCode status = HttpStatusCode.OK) => 
            new()
            {
                StatusCode = status,
                Success = true
            };

        public ResponseService<T> GenerateSuccessServiceResponse<T>(T value, HttpStatusCode status = HttpStatusCode.OK) =>
            new()
            {
                StatusCode = status,
                Success = true,
                Value = value
            };

        public ResponseService GeneratePreconditionFailedServiceResponse(string message, HttpStatusCode status = HttpStatusCode.PreconditionFailed) =>
            new()
            {
                StatusCode = status,
                Message = message,
                Success = false
            };

        public ResponseService<T> GeneratePreconditionFailedServiceResponse<T>(string message, HttpStatusCode status = HttpStatusCode.PreconditionFailed) =>
            new()
            {
                StatusCode = status,
                Message = message,
                Success = false,
                Value = default
            };

        private readonly List<string> _notificador;

        protected AbstractService()
        {
            _notificador = new List<string>();
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
        protected void Notificar(string mensagem)
        {
            _notificador.Add(new string(mensagem));
        }

        public List<string> ObterNotificacoes()
        {
            return _notificador;
        }

    }
}
