using System.ComponentModel.DataAnnotations;

namespace BlazorTestProject.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Identifier too long")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }

    }
}
