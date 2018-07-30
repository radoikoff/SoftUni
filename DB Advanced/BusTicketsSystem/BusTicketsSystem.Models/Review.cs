namespace BusTicketsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1.0, 10.0)]
        public double Grade { get; set; }

        public int BusStationId { get; set; }
        public BusStation BusStation { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime PublishedDate { get; set; }

        public ICollection<BusCompanyReview> BusCompanyReviews { get; set; }
    }
}
