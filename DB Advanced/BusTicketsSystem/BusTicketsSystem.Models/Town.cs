using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusTicketsSystem.Models
{
    public class Town
    {
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public ICollection<BusStation> BusStations { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
