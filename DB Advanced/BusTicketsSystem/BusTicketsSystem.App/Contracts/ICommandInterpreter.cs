namespace BusTicketsSystem.App.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}
