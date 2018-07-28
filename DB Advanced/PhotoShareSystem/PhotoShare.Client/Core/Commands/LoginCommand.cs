namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;

    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ISessionService sessionService;

        public LoginCommand(IUserService userService, ISessionService sessionService)
        {
            this.userService = userService;
            this.sessionService = sessionService;
        }

        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];

            bool userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            User user = this.userService.ByUsername<User>(username);

            bool passwordValid = user.Password == password;

            if (!passwordValid)
            {
                throw new ArgumentException("Invalid username or password!");
            }
            
            if (this.sessionService.IsLoggedIn())
            {
                throw new ArgumentException($"You should logout first!");
            }

            this.sessionService.Login(user.Id);

            return $"User {username} successfully logged in!";
        }
    }
}
