namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;

    public interface ISessionService
    {
        User User { get; }
        void Login(int userId);
        void Logout();
        bool IsLoggedIn();
    }
}
