using Models.BaseReponseModel;
using Models.Enums;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace ReturnedProductService.Core.Service
{
    public static class ServiceConnect
    {
        public static ServiceConnectModel New(ServiceTypeEnum serviceType)
        {
            return new ServiceConnectModel(serviceType);
        }
    }
}
