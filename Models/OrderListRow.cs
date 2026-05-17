namespace VSP__559ir_MyProject.Models
{
    public sealed class OrderListRow
    {
        public long OrderId { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string DeliveryAddress { get; set; } = "";
        public decimal TotalEur { get; set; }
        public string CourierName { get; set; } = "";
        public string CreatedAt { get; set; } = "";
        public string DeliverAt { get; set; } = "";
        public int Status { get; set; }
    }
}
