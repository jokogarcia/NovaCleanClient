﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaCleanClient.Services.BackendServices
{
    public interface ILoginService
    {
        Task<bool> LogIn(string email, string password);
    }
}
