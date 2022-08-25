﻿using HRLeaveManagement.Application.Models.Identity;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
