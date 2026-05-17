namespace SDA_559ir.Models
{
    internal sealed class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public override string ToString() => Name;
    }
}
