namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ISessionService sessionService;

        public DeleteUserCommand(IUserService userService, ISessionService sessionService)
        {
            this.userService = userService;
            this.sessionService = sessionService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            if (!this.sessionService.IsLoggedIn(userId))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.userService.Delete(userId);


            return $"User {username} was deleted from the database!";
        }
    }
}
