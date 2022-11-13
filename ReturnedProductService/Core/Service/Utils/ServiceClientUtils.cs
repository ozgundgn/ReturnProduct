using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public class ServiceClientUtils
    {
        public static string Url(ServiceTypeEnum serviceType = ServiceTypeEnum.MarsTechProductService)
        {
            switch (serviceType)
            {
                case ServiceTypeEnum.SpecificCargoService:
                    return "https://dummyjson.com/carts/1"; //RMA kodunun geldiğini farzedeceğimiz dummyjson linki
                case ServiceTypeEnum.MarsTechProductService:
                    return "https://dummyjson.com/products/1"; //RMA kodu ile kendi servisimizden çekeceğimiz order verisinin dummyjson linki
                default:
                    throw new ArgumentOutOfRangeException("serviceType");
            }
        }
    }
}
