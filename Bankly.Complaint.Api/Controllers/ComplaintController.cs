using System;
using System.Threading.Tasks;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bankly.Complaint.Api.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class ComplaintController:ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductComplaintReqDto productComplaintReqDto)
        {
            try
            {
                var complaint = await _complaintService.CreateComplaint(productComplaintReqDto);
                return Ok(complaint);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductComplaintUpdateDto productComplaintUpdateDto)
        {
            try
            {
                var complaint = await _complaintService.UpdateComplaintStatus(productComplaintUpdateDto);
                return Ok(complaint);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long Id)
        {
            try
            {
                var complaint = await _complaintService.GetComplaint(Id);
                return Ok(complaint);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var complaint =  _complaintService.GetComplaints(pageNumber, pageSize);
                return Ok(complaint);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
