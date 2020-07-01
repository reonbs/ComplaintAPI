using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Bankly.Complaint.Service.Services
{
    public abstract class BaseService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId()
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
                return (userId == null) ? "system" : userId.Value;
            }
            catch (Exception ex)
            {
                return "system";
            }
        }

        public string UserName()
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email);
                return (userId == null) ? "system" : userId.Value;
            }
            catch (Exception ex)
            {
                return "system";
            }
        }

    }
}
