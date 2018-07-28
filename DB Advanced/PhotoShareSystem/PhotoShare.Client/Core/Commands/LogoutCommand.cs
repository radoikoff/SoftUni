namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Services.Contracts;

    public class LogoutCommand : ICommand
    {
        private readonly ISessionService sessionService;

        public LogoutCommand(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public string Execute(string[] args)
        {
            if (!this.sessionService.IsLoggedIn())
            {
                throw new ArgumentException("You should log in first in order to logout.");
            }

            string loggedUsername = this.sessionService.User.Username;

            this.sessionService.Logout();

            return $"User {loggedUsername} successfully logged out!";
        }
    }
}
