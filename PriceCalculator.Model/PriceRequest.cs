namespace PriceCalculator.Model
{
    public class PriceRequest
    {
        public int CustomerCount { get; set; }
        public double PricePerCustomer { get; set; }
        public string DiscountCode { get; set; } = string.Empty;
    }
}
