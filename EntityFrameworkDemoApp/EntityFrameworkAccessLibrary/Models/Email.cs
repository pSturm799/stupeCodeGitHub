using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkAccessLibrary.Models
{
    public class Email
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
    }
}
