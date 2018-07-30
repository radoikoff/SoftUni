using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusTicketsSystem.Models
{
    public class BusCompany
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Nationality { get; set; }

        public int Rating { get; set; }


        public ICollection<Trip> Trips { get; set; }

        public ICollection<BusCompanyReview> BusCompanyReviews { get; set; }
    }
}
