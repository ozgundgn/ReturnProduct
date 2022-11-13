# ReturnProduct

Proje Core, Models, Web Api katmanlarından oluşmaktadır.

## Core Katmanı

- Extensions klasöründe projede api controllerda alınan exceptionlar için, IApplicationBuilder a eklenbilmesi ExceptionMiddlewareExtensions classı bulunur.

- Filters klsöründe, basic authentication için authorize ve allowanonymus attributeleri bulunur. Her controllerda authentication kontrolü için AddControllers filters özelliğine eklenmiştir. Allowanonymous attributesi bulunanlar hariç diğer tüm metodlar için yetki kontrolü yapar.

- Middlewares klasörü projeye eklenebilecek middlewarelerin bulunması için oluşturuldu. Burada ExceptionMiddeleware classı bulunur ve ExceptionMiddlewareExtensions classında UseMiddleare kullanılarak eklenilen projeye dahil edilebilmesini sağlar.

## Models Katmanı

- Enums klasöründe servis tiplerini tutması için ServiceTypeEnum classı bulunur.

- BaseResponseModel klasöründe servislere yapılan isteklerin standart bir geri dönüşü olması durumunda (status,message) dönüş modellerinde kullanılması için BaseResponseModel,GeneralResponse ve servisten alınan bir model olma özelliğini tutması için IReturn interfacesi bulunur.

- Servise gönderilecek olan request ve reponse classları bulunur.

##  WEB API Katmanı (ReturnedProductService)


Core klasöründe;
- Servicetypenenum değerine göre servislerin base adreslerinin tutulduğu bir ServiceClientUtils classı bulunur. 
- Servisleri simüle edebilmek ve cevap alabilmek için https://dummyjson.com/ adresindeki products ve carts metodları kullanıldı. Servislere erişimin yapıldığı ServiceConnetModel classı bulunur. ServiceConnectModel classının oluşturulması static olan ServiceConnect sınıfından yapılmıştır. Bunun nedeni başka bir serviceconnectmodel sınıfı kullanılmak istendiğinde yada herhangi bir değişiklik olduğunda sadece bu ServiceConnect static classı içindeki static metodu değiştirmemiz yeterli olacağındandır.

Controller klasöründe;
- ApiControllerBase classı bulunur. Bu sınıfta ServiceConnetModel tipindeki servislerin instanceleri bulunur. Oluşturulan her bir api controller bu sınıfı miras alarak oluşturulur ve erişilebilecek servisler default olarak controllerda bulunmuş olur.

- ReturnProductController da GetRMADataByRMACodeAsync metodu vardır. GetRMAByCargoBarcodeRequest  modeli ile gelen istekteki CargoBarcode ile istenilen kargo şirketi servisinden ilgili metod ile RMA kodu alınması için istek atılır. Dönen değer boş ya da null değilse RMA kodu ile Mars şirketi servisinde order sorgulaması yapılıp OrderDataModel i temsilen https://dummyjson.com/producs/1 deki ürün bilgisi gösterildi.












