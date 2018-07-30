namespace BusTicketsSystem.Models
{
    public class BusCompanyReview
    {
        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
