using Models.BaseReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GetOrderDataRequest : IReturn<OrderDataModel>
    {
        public string RMACode { get; set; }
    }
}
