using System;
namespace Bankly.Complaint.Service.Dto
{
    public class AppSettings
    {
        public string IdentityUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string APIScope { get; set; }
    }
}
