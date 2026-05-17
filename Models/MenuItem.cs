namespace SDA_559ir.Models
{
    public class MenuItem
    {
        public long Id { get; set; }
        public string ProductName { get; set; } = "";
        public long CategoryId { get; set; }
        public string Description { get; set; } = "";
        public double WeightGrams { get; set; }
        public double PriceEur { get; set; }
        public string ImagePath { get; set; } = "";
        public string CategoryName { get; set; } = "";
    }
}
