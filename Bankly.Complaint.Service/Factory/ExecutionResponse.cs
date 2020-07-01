using System;
namespace Bankly.Complaint.Service.Factory
{
    public class ExecutionResponse<T> where T : class
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
