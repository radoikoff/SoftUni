namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class ListFriendsCommand : ICommand
    {
        private readonly IUserService userService;

        public ListFriendsCommand(IUserService userService)
        {
            this.userService = userService;
        }


        public string Execute(string[] data)
        {
            string username = data[0];

            bool userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"{username} not found!");
            }


            var user = this.userService.ByUsername<UserFriendsDto>(username);
            StringBuilder sb = new StringBuilder();

            if (user.Friends.Any())
            {
                sb.AppendLine("Friends:");

                foreach (var friend in user.Friends)
                {
                    sb.AppendLine($"-{friend.Username}");
                }
            }
            else
            {
                sb.AppendLine("No friends for this user. :(");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
