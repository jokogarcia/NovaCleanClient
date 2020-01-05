using System;
using System.Collections.Generic;
using System.Text;
using NovaCleanClient.Models;

namespace NovaCleanClient.Services.BackendServices
{
    class UserCredentialsProvider : IUserCredentialsProvider
    {
        public User CurrentUser { get; set; }
    }
}
