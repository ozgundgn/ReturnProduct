using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BaseReponseModel
{
    public class GeneralResponse : BaseResponseModel
    {
    }
    public class GeneralResponse<T> : BaseResponseModel
    {
        public T Object { get; set; }
    }
}
