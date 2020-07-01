using System;
using Bankly.Complaint.Service.Factory;

namespace Bankly.Complaint.Service.Services
{

    public interface IResponseService
    {
        ExecutionResponse<T> ExecutionResponse<T>(string message, T data = null, bool status = false) where T : class;
    }

    public class ResponseService : IResponseService
    {
        public ExecutionResponse<T>
           ExecutionResponse<T>(string message, T data = null, bool status = false) where T : class
        {
            return new ExecutionResponse<T>
            {
                Status = status,
                Message = message,
                Data = data

            };
        }
    }
}
