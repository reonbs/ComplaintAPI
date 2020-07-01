using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bankly.Complaint.Respository.IRepository;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Factory;
using Bankly.Complaint.Service.Interfaces;
using Bankly.Complaint.Service.Mappings;
using Microsoft.AspNetCore.Http;

namespace Bankly.Complaint.Service.Services
{
    
    public class ComplaintService:BaseService, IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IResponseService _responseService;

        public ComplaintService(
            IComplaintRepository complaintRepository,
            IResponseService responseService,
            IHttpContextAccessor httpContextAccessor
            ):base(httpContextAccessor)
        {
            _complaintRepository = complaintRepository;
            _responseService = responseService;
        }

        public async Task<ExecutionResponse<ProductComplaintDto>> CreateComplaint(ProductComplaintReqDto productComplaintReqDto)
        {
            if (productComplaintReqDto == null)
                return _responseService.ExecutionResponse<ProductComplaintDto>("invalid request");

            if(string.IsNullOrWhiteSpace(productComplaintReqDto.ProductName) || string.IsNullOrWhiteSpace(productComplaintReqDto.Comment))
                return _responseService.ExecutionResponse<ProductComplaintDto>("product name , comment are required");


            var productComplaint = ProductComplaintMapping.GetEntity(productComplaintReqDto);
            productComplaint.CreatedBy = UserName();
            productComplaint.CreatedDate = DateTime.Now;

            await _complaintRepository.Add(productComplaint);
            await _complaintRepository.SaveChangesAsync();

            return _responseService.ExecutionResponse<ProductComplaintDto>("complaint created successfully",null, true);

        }

        public async Task<ExecutionResponse<ProductComplaintDto>> UpdateComplaintStatus(ProductComplaintUpdateDto productComplaintUpdateDto)
        {
            if (productComplaintUpdateDto == null)
                return _responseService.ExecutionResponse<ProductComplaintDto>("invalid request");

            if(productComplaintUpdateDto.Id <= 0)
                return _responseService.ExecutionResponse<ProductComplaintDto>("complaint not found");

            var productComplaint = await _complaintRepository.GetById(productComplaintUpdateDto.Id);

            if(productComplaint == null)
                return _responseService.ExecutionResponse<ProductComplaintDto>("complaint not found");


            productComplaint.Status = productComplaintUpdateDto.Status;
            productComplaint.ModifiedBy = UserName();
            productComplaint.ModifiedDate = DateTime.Now;

            await _complaintRepository.SaveChangesAsync();

            return _responseService.ExecutionResponse<ProductComplaintDto>("complaint status updated successfully", null, true);

        }

        public async Task<ExecutionResponse<ProductComplaintDto>> GetComplaint(long Id)
        {
            if (Id <= 0)
                return _responseService.ExecutionResponse<ProductComplaintDto>("invalid complaint");

            var productComplaint = await _complaintRepository.GetByIdAsnotracking(Id);

            if(productComplaint == null)
                return _responseService.ExecutionResponse<ProductComplaintDto>("complaint not found");


            return _responseService.ExecutionResponse<ProductComplaintDto>("complaint retreived successfully", ProductComplaintMapping.GetDto(productComplaint), true);
        }

        public ExecutionResponse<List<ProductComplaintDto>> GetComplaints(int pageNumber = 1, int pageSize = 10)
        {
            var productComplaints = _complaintRepository.GetAllAsQueryable();

            var pagedProductComplaints = productComplaints.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return _responseService
                .ExecutionResponse<List<ProductComplaintDto>>("complaint retreived successfully",
                pagedProductComplaints.Select(ProductComplaintMapping.GetDto).ToList(), true);
        }
    }
}
