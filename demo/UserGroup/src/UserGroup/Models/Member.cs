using System.ComponentModel.DataAnnotations;

namespace UserGroup.Models
{
    public class Member : Entity
    {

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}