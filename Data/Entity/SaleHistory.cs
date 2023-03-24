namespace Data.Entity
{
    public class SaleHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }        
        public Product? Product { get; set; }

        public int MyProperty { get; set; }
    }
}