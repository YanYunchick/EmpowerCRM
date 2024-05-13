using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class UserTaskStatus
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
