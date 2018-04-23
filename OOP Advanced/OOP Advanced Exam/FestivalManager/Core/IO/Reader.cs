namespace FestivalManager.Core.IO
{
    using Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
