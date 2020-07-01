using System;
using System.ComponentModel.DataAnnotations;

namespace Bankly.Complaint.Service.Dto
{
    public class ProductComplaintReqDto
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Comment { get; set; }
        public bool Status { get; set; }
    }

    public class ProductComplaintDto : ProductComplaintReqDto
    {
        public long Id { get; set; }
    }

    public class ProductComplaintUpdateDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
    }
}
