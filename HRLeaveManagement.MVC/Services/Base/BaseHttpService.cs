using HRLeaveManagement.MVC.Contracts;
using System;
using System.Net.Http.Headers;

namespace HRLeaveManagement.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>
                {
                    Message = "Validation errors have occured.",
                    ValidationErrors = ex.Response,
                    Success = false
                };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>
                {
                    Message = "The requested item could not be found.",
                    Success = false
                };
            }
            else
            {
                return new Response<Guid>
                {
                    Message = "Something went wrong, pleace try again. If this problem persist, please contact your administrator. ",
                    Success = false
                };
            }
        }

        protected void AddBearerToken()
        {
            if (localStorage.Exists("token"))
                client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", localStorage.GetStorageValue<string>("token"));
        }
    }
}