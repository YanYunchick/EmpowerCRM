using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Manufacturer { get; set; }
        public List<Opportunity> Opportunities { get; set; }
        public List<OpportunityProduct> OpportunityProducts { get; set; }
    }
}
