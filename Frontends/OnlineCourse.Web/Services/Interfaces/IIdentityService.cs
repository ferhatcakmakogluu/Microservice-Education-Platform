using Microsoft.AspNetCore.Authentication.OAuth;
using OnlineCourse.Shared.Dtos;
using System.Threading.Tasks;
using IdentityModel.Client;
using OnlineCourse.Web.Models;

namespace OnlineCourse.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
