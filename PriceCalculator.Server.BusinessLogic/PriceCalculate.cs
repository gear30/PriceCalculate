using Newtonsoft.Json;
using PriceCalculator.Model;
using PriceCalculator.Server.BusinessLogic.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PriceCalculator.Server.BusinessLogic
{
    public class PriceCalculate
    {
        public PriceResponse Calculate(int customerCount,double price,string discountCode)
        {
            var totalPrice = price * customerCount;
            var payPrice = totalPrice;
            var discountList = JsonConvert.DeserializeObject<List<Discount>>(File.ReadAllText("DiscountList.json"));
            var raesonBuilder = new StringBuilder();
            DiscountMaching discountsMatch;
            foreach(var discountItem in discountList)
            {
                discountsMatch = DiscountCal.Cal(totalPrice, customerCount, discountCode, discountItem);
                if(discountsMatch.TotalPrice < totalPrice)
                {
                    payPrice = discountsMatch.TotalPrice >= payPrice ? payPrice : discountsMatch.TotalPrice;
                    raesonBuilder.Append(discountsMatch.Reason);
                    raesonBuilder.Append(" ");
                }
            }

            return new PriceResponse() { TotalPrice = payPrice,Reason = raesonBuilder.ToString() };
        }
    }
}
