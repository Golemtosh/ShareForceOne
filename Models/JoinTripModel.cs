using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareForceOne.Models
{
    public class JoinTripModel
    {
        [Key]
        public int joinTripId { get; set; }
        [DisplayName("Trip Number: ")]
        public int TripId { get; set; }
        public string UserId { get; set; }
        [DisplayName("Notes")]
        public string JoinTripNotes { get; set; }

    }
}
