﻿using System.Threading.Tasks;

namespace OnlineCourse.Web.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
