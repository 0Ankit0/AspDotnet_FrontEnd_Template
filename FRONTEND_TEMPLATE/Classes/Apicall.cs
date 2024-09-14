using Newtonsoft.Json; //install the package Newtonsoft.Json
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FRONTEND_TEMPLATE.Classes
{
    public interface IApiCall
    {
        Task<string> GetAsync(string endpoint);
        Task<string> PostAsync(string endpoint, string content);
        Task<string> PostFileAsync(string endpoint, IFormFile file);
    }
    public class Apicall : IApiCall
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public Apicall(IConfiguration configuration)
        {
            _baseAddress = configuration.GetConnectionString("BaseAddress");
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseAddress) };
        }

        public async Task<string> GetAsync(string endpoint)
        {
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                var ExceptionSubstring = Exception.Substring(0, 1500);
                // You can't use RedirectToAction in this context, you should handle the exception appropriately
                throw new Exception(ExceptionSubstring);
            }
        }

        public async Task<string> PostAsync(string endpoint, string content)
        {
            try
            {

                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                var ExceptionSubstring = Exception.Substring(0, 1500);
                // You can't use RedirectToAction in this context, you should handle the exception appropriately
                throw new Exception(ExceptionSubstring);
            }
        }
        public async Task<string> PostAsync(string endpoint, object data)
        {
            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(endpoint, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                var ExceptionSubstring = Exception.Substring(0, 1500);
                // You can't use RedirectToAction in this context, you should handle the exception appropriately
                throw new Exception(ExceptionSubstring);
            }
        }

        public async Task<string> PostFileAsync(string endpoint, IFormFile file)
        {
            try
            {
                var multipartContent = new MultipartFormDataContent();
                var streamContent = new StreamContent(file.OpenReadStream());

                multipartContent.Add(streamContent, "file", file.FileName);

                HttpResponseMessage res = await _httpClient.PostAsync(endpoint, multipartContent);

                if (res.IsSuccessStatusCode)
                {
                    string result = await res.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    string result = await res.Content.ReadAsStringAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                var ExceptionSubstring = Exception.Substring(0, 1500);
                // You can't use RedirectToAction in this context, you should handle the exception appropriately
                throw new Exception(ExceptionSubstring);
            }
        }
    }
}