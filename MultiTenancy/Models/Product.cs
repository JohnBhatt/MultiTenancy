namespace MultiTenancy.Models
{
    public class Product : IMustHaveTenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
