namespace BusTicketsSystem.App.Core.DTOs
{
    public class CustomerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Balance { get; set; }

        public string AccountNumber { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
