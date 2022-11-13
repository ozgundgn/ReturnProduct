
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using ReturnedProductService.Core.Service;

namespace ReturnedProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase // controllerlarda ortak kullanılabilecek işlemler için oluşturuldu.
    {
        /// <summary>
        /// İlişkili olunan kargo şirketi servisi
        /// </summary>

        private ServiceConnectModel? serviceSpecificCargo;

        /// <summary>
        /// Mars teknoloji içinden ürün bilgisini çekecegimiz servis
        /// </summary>
        private ServiceConnectModel? serviceMarsTechProducts;

        protected ServiceConnectModel ServiceSpecificCargo => serviceSpecificCargo ??= ServiceConnect.New(ServiceTypeEnum.SpecificCargoService);

        protected ServiceConnectModel ServiceMarsProducts => serviceMarsTechProducts ??= ServiceConnect.New(ServiceTypeEnum.MarsTechProductService);
    }
}
