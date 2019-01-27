using PriceCalculator.Server.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Server.BusinessLogic
{
    public static class DiscountCal
    {
        public static DiscountMaching Cal(double TotalPrice, int customerCount,string discountCode, Discount discountItem)
        {
            if((discountItem.CouponCode.Equals(discountCode) && (discountItem.CustomerCount == 0 || discountItem.CustomerCount.Equals(customerCount))) || (discountItem.TotalPrice > 0 && discountItem.TotalPrice <= TotalPrice))
            {
                return new DiscountMaching() { TotalPrice = TotalPrice * discountItem.DiscountPrice, Reason = discountItem.MatchReson };

            }
            return new DiscountMaching() { TotalPrice = TotalPrice, Reason = string.Empty };
        }
    }
}
