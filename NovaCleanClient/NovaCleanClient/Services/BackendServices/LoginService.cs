using Newtonsoft.Json;
using NovaCleanClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NovaCleanClient.Services.BackendServices
{
    public class LoginService : BackendServicesBase, ILoginService
    {
        
        private IUserCredentialsProvider _userCredentialsProvider;
        public LoginService(IUserCredentialsProvider ucp)
        {
            _userCredentialsProvider = ucp;
        }
        public async Task<bool> LogIn(string email, string password)
        {



            try
            {
                var formData = new FormUrlEncodedContent(new Dictionary<string, string> { { "email", email },{"password",password } });

                var data = await PostFormAnon<LoginResponse>(
                    BASE_URL + "login",
                    formData
                );
                if (data != null)
                {
                    _userCredentialsProvider.CurrentUser = data.data;
                    SetAuthToken(data.data.api_token);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                DebugLogger.Log(ex.ToString(), "LogIn");
                return false;
            }
            
        }
        class LoginResponse
        {
            public User data { get; set; }
        }
    
    }
    
}
