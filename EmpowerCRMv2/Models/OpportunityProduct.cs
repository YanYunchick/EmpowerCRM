namespace EmpowerCRMv2.Models
{
    public class OpportunityProduct
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
