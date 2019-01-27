using Microsoft.AspNetCore.Mvc;
using PriceCalculator.Model;
using PriceCalculator.Server.BusinessLogic;

namespace PriceCalculator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        [HttpPost,Route("TotalPrice")]
        public ActionResult<PriceResponse> TotalPrice(PriceRequest model)
        {
            var priceCal = new PriceCalculate();
            return priceCal.Calculate(model.CustomerCount,model.PricePerCustomer,model.DiscountCode);
        }
    }
}
