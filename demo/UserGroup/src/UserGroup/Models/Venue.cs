using System.ComponentModel.DataAnnotations;

namespace UserGroup.Models
{
    public class Venue : Entity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string StreetAddress { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(5)]
        public string Zip { get; set; }
        public string Directions { get; set; }
    }
}