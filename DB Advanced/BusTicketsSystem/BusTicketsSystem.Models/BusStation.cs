namespace BusTicketsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BusStation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }


        public ICollection<Trip> TripsFrom { get; set; }

        public ICollection<Trip> TripsTo { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
