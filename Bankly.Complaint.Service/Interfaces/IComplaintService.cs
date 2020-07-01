using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Factory;

namespace Bankly.Complaint.Service.Interfaces
{
    public interface IComplaintService
    {
        Task<ExecutionResponse<ProductComplaintDto>> CreateComplaint(ProductComplaintReqDto productComplaintReqDto);
        Task<ExecutionResponse<ProductComplaintDto>> UpdateComplaintStatus(ProductComplaintUpdateDto productComplaintUpdateDto);
        Task<ExecutionResponse<ProductComplaintDto>> GetComplaint(long Id);
        ExecutionResponse<List<ProductComplaintDto>> GetComplaints(int pageNumber = 1, int pageSize = 10);

    }
}
