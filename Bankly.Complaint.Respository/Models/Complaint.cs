using System;
namespace Bankly.Complaint.Respository.Models
{
    public class ProductComplaint: BaseEntity
    {
        public string ProductName { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
