using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProgiV2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CarPricesController : ControllerBase
    {

        private readonly ILogger<CarPricesController> _logger;

        public CarPricesController(ILogger<CarPricesController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "carprices")]
        public CarPrices Post()
        {
            CarInfo carInfo = null;
            using (var reader = new StreamReader(HttpContext.Request.Body))
            {
                // lecture du body de la requête recue
                var postData = reader.ReadToEndAsync();
                // essai de tranformation en CarInfo
                if (postData != null)
                {

                try
                {
                    carInfo = JsonSerializer.Deserialize<CarInfo>(postData.Result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // si la transformation ne fonctionne pas, on renvoie un object factice
                    carInfo = new CarInfo() { price = 0.00, type = "Invalid" };
                }
            }
            //
            CarPrices myCar = new CarPrices { Price = carInfo.price, Type = carInfo.type };
            return myCar;
                }
        }
    }
}
