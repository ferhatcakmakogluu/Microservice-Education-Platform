﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _contextAccessor;

        public SharedIdentityService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
