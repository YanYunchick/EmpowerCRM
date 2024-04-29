namespace EmpowerCRMv2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Opportunity> Opportunities { get; set; }
        public List<OpportunityProduct> OpportunityProducts { get; set; }
    }
}
