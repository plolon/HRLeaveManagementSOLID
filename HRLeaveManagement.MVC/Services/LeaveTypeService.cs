using AutoMapper;
using HRLeaveManagement.MVC.Contracts;
using HRLeaveManagement.MVC.Models;
using HRLeaveManagement.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper mapper;
        private readonly IClient httpclient;
        private readonly ILocalStorageService localStorage;

        public LeaveTypeService(IMapper mapper, IClient httpclient, ILocalStorageService localStorage) : base(httpclient, localStorage)
        {
            this.mapper = mapper;
            this.httpclient = httpclient;
            this.localStorage = localStorage;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var apiResponse = await client.LeaveTypesPOSTAsync(mapper.Map<CreateLeaveTypeDto>(leaveType));
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.Success = false;
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                await client.LeaveTypesDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveType = await client.LeaveTypesGETAsync(id);
            return mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await client.LeaveTypesAllAsync();
            return mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var apiResponse = await client.LeaveTypesPUTAsync(mapper.Map<LeaveTypeDto>(leaveType));
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.Success = false;
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
