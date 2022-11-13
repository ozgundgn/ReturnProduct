using Models.BaseReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GetRMAByCargoBarcodeRequest : IReturn<RMACodeModel> //Servislerde success ve message içeriği döndüğü farzedilerek, harici olarak döneceği bilinen object model oluşturulur
    {
        public string? CargoBarcode { get; set; }
    }
}
