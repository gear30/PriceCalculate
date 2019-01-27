namespace PriceCalculator.Server.BusinessLogic.Model
{
    public class Discount
    {
        public string CouponCode { get; set; }
        public double TotalPrice { get; set; }
        public int CustomerCount { get; set; }
        public double DiscountPrice { get; set; }
        public string MatchReson { get; set; }
    }
}
