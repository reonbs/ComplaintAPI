using System;
namespace Bankly.Complaint.Service.Dto
{
    public class IDServerResponseDto
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refreshtoken { get; set; }
    }
}
