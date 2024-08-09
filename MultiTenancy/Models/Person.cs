namespace MultiTenancy.Models
{
    public class Person:IMustHaveTenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
