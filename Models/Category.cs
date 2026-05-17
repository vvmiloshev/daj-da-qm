namespace VSP__559ir_MyProject.Models
{
    internal sealed class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public override string ToString() => Name;
    }
}
