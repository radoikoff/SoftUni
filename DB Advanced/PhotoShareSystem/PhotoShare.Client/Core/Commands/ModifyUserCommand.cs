namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;

        public ModifyUserCommand(IUserService userService, ITownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string newValue = data[2];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            if (property.ToLower() == "password")
            {
                SetPassword(userId, newValue);
            }
            else if (property.ToLower() == "borntown")
            {
                SetBorntown(userId, newValue);
            }
            else if (property.ToLower() == "currenttown")
            {
                SetCurrenttown(userId, newValue);
            }
            else
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            return $"User {username} {property} is {newValue}.";

        }

        private void SetCurrenttown(int userId, string name)
        {
            var townExisits = this.townService.Exists(name);

            if (!townExisits)
            {
                throw new ArgumentException($"Value {name} not valid. Town {name} not found!");
            }

            var townId = this.townService.ByName<TownDto>(name).Id;

            this.userService.SetCurrentTown(userId, townId);
        }

        private void SetBorntown(int userId, string name)
        {
            var townExisits = this.townService.Exists(name);

            if (!townExisits)
            {
                throw new ArgumentException($"Value {name} not valid. Town {name} not found!");
            }

            var townId = this.townService.ByName<TownDto>(name).Id;

            this.userService.SetBornTown(userId, townId);
        }

        private void SetPassword(int userId, string password)
        {
            var isLower = password.Any(x => char.IsLower(x));
            var isDigit = password.Any(x => char.IsDigit(x));

            if (!isLower || !isDigit)
            {
                throw new ArgumentException($"Value {password} not valid. Invalid Password");
            }

            this.userService.ChangePassword(userId, password);
        }
    }
}
