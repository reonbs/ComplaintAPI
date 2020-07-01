using System;
using Bankly.Complaint.Respository.Models;
using Bankly.Complaint.Service.Dto;

namespace Bankly.Complaint.Service.Mappings
{
    public static class ProductComplaintMapping
    {
        public static ProductComplaint GetEntity(ProductComplaintReqDto productComplaintReqDto)
        {
            return new ProductComplaint
            {
                 Comment = productComplaintReqDto.Comment,
                 ProductName = productComplaintReqDto.ProductName
            };
        }

        public static ProductComplaintDto GetDto(ProductComplaint productComplaint)
        {
            return new ProductComplaintDto
            {
                Comment = productComplaint.Comment,
                ProductName = productComplaint.ProductName
            };
        }
    }
}
