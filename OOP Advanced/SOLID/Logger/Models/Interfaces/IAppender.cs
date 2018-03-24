namespace Logger.Models.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel Level { get; }

        void Append(IError error);
    }
}
