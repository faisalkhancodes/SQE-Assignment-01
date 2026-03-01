namespace SearchLibrary.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double TotalAmount { get; set; }
        public bool IsProcessed { get; set; }

        // Logic for MC/DC Testing: (A && B) || (!A && C)
        // A = IsProcessed, B = Amount > 1000, C = Amount < 0
        public string GetOrderStatus()
        {
            if (IsProcessed)
            {
                if (TotalAmount > 1000)
                {
                    return "Processed High Value";
                }
                return "Processed";
            }
            else
            {
                if (TotalAmount < 0)
                {
                    return "Invalid Amount";
                }
                return "Pending";
            }
        }
    }
}
