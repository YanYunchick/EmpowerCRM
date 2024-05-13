using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StageId { get; set; }
        public int ContactId { get; set; }
        public OpportunityStage? Stage { get; set; }
        public Contact Contact { get; set; }
        public List<Product> Products { get; set; }
        public List<OpportunityProduct> OpportunityProducts { get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
