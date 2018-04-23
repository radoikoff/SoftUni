namespace FestivalManager.Core.IO
{
    using Contracts;
    public class Writer : IWriter
    {
        public void Write(string contents)
        {
            System.Console.Write(contents);
        }

        public void WriteLine(string contents)
        {
            System.Console.WriteLine(contents);
        }
    }
}
