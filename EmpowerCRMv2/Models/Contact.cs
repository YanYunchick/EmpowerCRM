using EmpowerCRMv2.Data;
using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        [MaxLength(15)]
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public List<Opportunity> Opportunities { get; set; }
    }
}
