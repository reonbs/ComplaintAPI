using System;
namespace Bankly.Complaint.Respository.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
