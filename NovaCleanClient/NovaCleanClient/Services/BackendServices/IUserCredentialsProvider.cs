using NovaCleanClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Services.BackendServices
{
    public interface IUserCredentialsProvider
    {
        User CurrentUser { get; set; }
    }
}
