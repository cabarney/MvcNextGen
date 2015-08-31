using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Models
{
    public class Meeting : Entity
    {
        [MaxLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string Speaker { get; set; }
        public string SpeakerBio { get; set; }
        public DateTime MeetingDate { get; set; }
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}