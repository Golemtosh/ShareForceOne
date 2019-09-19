using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareForceOne.Models
{
    public class TripModel
    {
        [Key]
        public int TripId { get; set; }

        [DisplayName("Car to use")]
        public int TripCarId { get; set; }

        [DisplayName("Start position")]
        public string TripStartCoord { get; set; }

        [DisplayName("End position")]
        public string TripStopCoord { get; set; }

        [DisplayName("Start position name")]
        public string TripStartName { get; set; }

        [DisplayName("End position name")]
        public string TripStopName { get; set; }

        [DisplayName("Creator")]
        public string TripCreator { get; set; }

        [DisplayName("Cost per KM")]
        public decimal TripKMCost { get; set; }

        [DisplayName("Date and start time")]
        public DateTime TripDateTime { get; set; }

        [DisplayName("Available seats")]
        public int TripCarSeats { get; set; }

        [DisplayName("Allergy info")]
        public int TripAnimals { get; set; }

        [DisplayName("Trip comments / important info")]
        public string TripInfoText { get; set; }
    }
}
