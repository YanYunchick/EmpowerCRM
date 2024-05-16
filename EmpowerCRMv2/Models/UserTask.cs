using EmpowerCRMv2.Data;
using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        [Required]
        public string Subject { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StatusId { get; set; }
        public UserTaskStatus? Status { get; set; }
        public int? PriorityId { get; set; }
        public UserTaskPriority? Priority { get; set; }
        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }
    }
}
