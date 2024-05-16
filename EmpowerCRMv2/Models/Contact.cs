using EmpowerCRMv2.Data;
using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }
        [MaxLength(255)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        [MaxLength(255)]
        public string? Company { get; set; }
        public string? OwnerId { get; set; }
        public ApplicationUser? Owner { get; set; }
        public List<Opportunity> Opportunities { get; set; }
    }
}
