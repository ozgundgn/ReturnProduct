using Core.Filters.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.BaseReponseModel;

namespace ReturnedProductService.Controllers
{

    public class ReturnProductController : ApiControllerBase
    {
        private readonly ILogger<ReturnProductController> _logger;

        public ReturnProductController(ILogger<ReturnProductController> logger)
        {
            _logger = logger;
        }
        //[AllowAnonymous]
        [HttpGet("getRMAData")]
        public async Task<OrderDataModel> GetRMADataByRMACodeAsync(GetRMAByCargoBarcodeRequest request)
        {
            var rmaCode = ServiceSpecificCargo.Get("getRMAByCargoBarcode", request, HttpMethod.Get);

            if (rmaCode != null)
            {
                var orderData = ServiceMarsProducts.Get("getOrderDataModel", new GetOrderDataRequest
                {
                    RMACode = rmaCode.RMACode
                }, HttpMethod.Get);

                if (orderData != null)
                    return orderData;

                return await Task.FromResult<OrderDataModel>(new OrderDataModel());
            }
            else
            {
                throw new Exception("Ýlgili iade koduna ait bir sipariþ bulunamadý");
            }
        }
    }
}