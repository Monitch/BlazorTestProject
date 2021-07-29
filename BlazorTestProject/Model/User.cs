using System.ComponentModel.DataAnnotations;

namespace BlazorTestProject.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name too long")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }

    }
}
