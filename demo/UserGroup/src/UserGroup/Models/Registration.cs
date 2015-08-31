using System.ComponentModel.DataAnnotations;

namespace UserGroup.Models
{
    public class Registration : Entity
    {
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}