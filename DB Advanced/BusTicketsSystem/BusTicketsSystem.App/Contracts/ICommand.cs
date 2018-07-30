namespace BusTicketsSystem.App.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
