namespace BusTicketsSystem.Services.Contracts
{
    public interface ITicketService
    {
        void CreateTicket(int customerId, int tripId, decimal price, string seat);
    }
}
