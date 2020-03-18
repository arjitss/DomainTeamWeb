using System.ComponentModel.DataAnnotations;

namespace DomainTeamWebsite.Models {
    public class Employee 
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name should be 50 chars or less")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-.]+$",ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        public string  CoreSkills { get; set; }
    }
}