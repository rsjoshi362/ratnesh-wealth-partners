using System.ComponentModel.DataAnnotations;

namespace asp_dot_net_core_first_app.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string? Subject { get; set; }

        public string? Message { get; set; }
    }
}