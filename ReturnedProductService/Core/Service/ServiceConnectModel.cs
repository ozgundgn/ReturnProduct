using Core.Utils;
using Models.BaseReponseModel;
using Models.Enums;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace ReturnedProductService.Core.Service
{
    public class ServiceConnectModel
    {
        private ServiceTypeEnum _serviceType;
        public ServiceConnectModel(ServiceTypeEnum serviceType)
        {
            _serviceType = serviceType;
        }

        public TResponse Get<TResponse>(string methodName, IReturn<TResponse> request, HttpMethod method)
        {
            string baseUrl = ServiceClientUtils.Url(_serviceType);

            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(60) })
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = new Uri(baseUrl) //baseurle gerçek ortamda yukarıda verilen methodname eklenir. -> string.Concat(baseUrl, "/", methodName);
                };
                if (request != null)
                {
                    var jsonRequest = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);
                    requestMessage.Content = stringContent;
                }

                HttpResponseMessage response = new HttpResponseMessage();
                HttpContent content;
                string x = string.Empty;
                try
                {
                    response = client.SendAsync(requestMessage).Result;
                    content = response.Content;
                    x = content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    throw new Exception("Connection service is not accessible. Message: " + e.Message);
                }

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<TResponse>(x);
                    }
                    catch (Exception e)
                    {

                        throw new Exception(e.Message);
                    }
                }
                throw new Exception(string.Concat(response.StatusCode.ToString(), ": Request - ", methodName
                    , ", ", x));
            }
        }
    }
}
