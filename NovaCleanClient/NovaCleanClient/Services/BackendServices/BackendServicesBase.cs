using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using NovaCleanClient.Exceptions;
using System.Threading.Tasks;

namespace NovaCleanClient.Services.BackendServices
{
    public class BackendServicesBase
    {
        protected const string BASE_URL = "https://www.novaclean.com.ar/api/";

        private HttpClient _client
        {
            get => __client ?? (__client = new HttpClient());
        }
        private static HttpClient __client;
      

        
        protected async Task<T> PostFormAnon<T>(string url, FormUrlEncodedContent data)
        {
            
            try
            {
                var response = await _client.PostAsync(url, data);
                T result = await ProcessResponse<T>(response);
                return result;
            }catch(HttpRequestException ex)
            {
                throw ex;
            }
        }
        protected async Task<T> GetJson<T>(Uri uri)
        {
            try
            {
                
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                T result = await ProcessResponse<T>(response);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        protected async Task<T> PostJson<T>(Uri uri, object data)
        {

            HttpResponseMessage response = await Post(uri, data);
            T result = await ProcessResponse<T>(response);

            return result;


        }
        protected async Task Delete(Uri uri)
        {

            HttpResponseMessage response = await _client.DeleteAsync(uri);

            await ProcessResponse(response);
        }

        protected async Task PostJson(Uri uri, object data)
        {

            HttpResponseMessage response = await Post(uri, data);

            await ProcessResponse(response);
        }

        private async Task<HttpResponseMessage> Post(Uri uri, object data)
        {

            StringContent content = Serialize(data);

            var response = await _client.PostAsync(uri, content);
            return response;
      

        }

        protected async Task<T> PutJson<T>(Uri uri, object data)
        {

            HttpResponseMessage response = await Put(uri, data);

            T result = await ProcessResponse<T>(response);

            return result;
        }

        protected async Task PutJson(Uri uri, object data)
        {

            HttpResponseMessage response = await Put(uri, data);

            await ProcessResponse(response);
        }

        private async Task<HttpResponseMessage> Put(Uri uri, object data)
        {

            StringContent content = Serialize(data);

            var response = await _client.PutAsync(uri, content);

            return response;
        }

        private static StringContent Serialize(object data)
        {
            var s = JsonConvert.SerializeObject(data,Formatting.None,new JsonSerializerSettings { 
                NullValueHandling = NullValueHandling.Ignore
            });;
            return new StringContent(s, Encoding.UTF8, "application/json");
        }

        protected async Task ProcessResponse(HttpResponseMessage response)
        {
            await CheckBadRequest(response);
            CheckOkRequest(response);
        }

        private static async Task CheckBadRequest(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var exContent = await response.Content.ReadAsStringAsync();

                var exData = JObject.Parse(exContent);

                var backendResult = 999999;
                var backendResultString = exData["result"]?.Value<string>();

                int.TryParse(backendResultString, out backendResult);

                var errorCode = exData["code"]?.Value<string>();

                var errorMessage = exData["userMessage"] != null ? exData["userMessage"].Value<string>()
                    : exData["errorMessage"]?.Value<string>();

                var backendException = new BackendServiceBusinessException(response.StatusCode, backendResult, errorCode, errorMessage);

                if (exData["extraData"] != null)
                {
                    var extraData = JsonConvert.DeserializeObject<Dictionary<string, string>>(exData["extraData"].ToString());
                    foreach (var item in extraData)
                    {
                        backendException.ExtraData[item.Key] = item.Value;
                    }
                }

                throw backendException;
            }
        }

        private void CheckOkRequest(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(); //throw new BackendServiceException(response.StatusCode, 0, string.Empty, string.Empty);
            }
        }

        protected async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            await CheckBadRequest(response);
            CheckOkRequest(response);

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(responseContent);
            return result;
        }
        protected void SetAuthToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
