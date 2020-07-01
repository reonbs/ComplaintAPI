using System;
using System.Net.Http;
using System.Threading.Tasks;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Factory;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bankly.Complaint.Service.Services
{
    public interface IAuthService
    {
        Task<ExecutionResponse<IDServerResponseDto>> Login(LoginReqDto loginReqDto)
    }

    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IResponseService _responseService;
        private readonly AppSettings _appSettings;

        public AuthService(IHttpClientFactory clientFactory,
            IResponseService responseService,
            IOptions<AppSettings> appSettings)
        {
            _clientFactory = clientFactory;
            _responseService = responseService;
            _appSettings = appSettings.Value;
        }

        public async Task<ExecutionResponse<IDServerResponseDto>> Login(LoginReqDto loginReqDto)
        {
            PasswordTokenRequest passwordTokenRequest = null;

            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri(_appSettings.IdentityUrl);

                passwordTokenRequest = new PasswordTokenRequest
                {
                    Address = _appSettings.IdentityUrl + "/connect/token",
                    ClientId = _appSettings.ClientId,
                    ClientSecret = _appSettings.ClientSecret,
                    Scope = $"{_appSettings.APIScope} profile openid",
                    UserName = loginReqDto.UserName,
                    Password = loginReqDto.Password,
                    GrantType = "password"
                };

                var response = await client.RequestPasswordTokenAsync(passwordTokenRequest);
                if (!response.IsError)
                {
                    var responseObj = JsonConvert.DeserializeObject<IDServerResponseDto>(response.Raw);

                    return _responseService.ExecutionResponse<IDServerResponseDto>("login successful", responseObj, true);
                }

                return _responseService.ExecutionResponse<IDServerResponseDto>(response.ErrorDescription);
            }
        }

    }
}
