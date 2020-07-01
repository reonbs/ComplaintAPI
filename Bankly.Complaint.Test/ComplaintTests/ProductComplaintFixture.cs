using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bankly.Complaint.Respository.IRepository;
using Bankly.Complaint.Respository.Models;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Factory;
using Bankly.Complaint.Service.Interfaces;
using Bankly.Complaint.Service.Services;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Bankly.Complaint.Test.ComplaintTests
{
    public class ProductComplaintFixture
    {
        private readonly Mock<IComplaintRepository> _complaintRepository;

        private readonly IComplaintService _complaintService;

        private readonly IResponseService _responseService;

        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;

        public ProductComplaintFixture()
        {
            _complaintRepository = new Mock<IComplaintRepository>();

            _responseService = new ResponseService();

            

            _httpContextAccessor = new Mock<IHttpContextAccessor>();


            _complaintService = new ComplaintService(_complaintRepository.Object, _responseService, _httpContextAccessor.Object);
        }

        public async Task<ExecutionResponse<ProductComplaintDto>> CreateComplaint(ProductComplaintReqDto productComplaintReqDto)
        {
            return await _complaintService.CreateComplaint(productComplaintReqDto);
        }

        public async Task<ExecutionResponse<ProductComplaintDto>> UpdateComplaintStatus(ProductComplaintUpdateDto productComplaintUpdateDto)
        {
            return await _complaintService.UpdateComplaintStatus(productComplaintUpdateDto);
        }

        public async Task<ExecutionResponse<ProductComplaintDto>> GetComplaint(long Id)
        {
            return await _complaintService.GetComplaint(Id);
        }

        public ExecutionResponse<List<ProductComplaintDto>> GetComplaints(int pageNumber = 1, int pageSize = 10)
        {
            return  _complaintService.GetComplaints(pageNumber, pageSize);
        }

        public void ExistSetup(bool res)
        {
            _complaintRepository.Setup(x => x.Exist(It.IsAny<Expression<Func<ProductComplaint, bool>>>())).Returns(res);
        }

        public void GetByIdSetup(ProductComplaint ProductComplaintRes)
        {
            _complaintRepository.Setup(x => x.GetById(1)).ReturnsAsync(ProductComplaintRes);

        }

        public void GetByIdAsNotrackingSetup(ProductComplaint ProductComplaintRes)
        {
            _complaintRepository.Setup(x => x.GetByIdAsnotracking(1)).ReturnsAsync(ProductComplaintRes);

        }

    }
}
