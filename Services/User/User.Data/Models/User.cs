using System;
using System.ComponentModel.DataAnnotations;

namespace User.Data.Models
{
    public class User
    {
        [Required]
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
