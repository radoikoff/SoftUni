namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;

        public AcceptFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AcceptFriend <username1> <username2>

        public string Execute(string[] data)
        {
            string username = data[0];
            string friendName = data[1];

            bool userExists = this.userService.Exists(username);
            bool friendExists = this.userService.Exists(friendName);

            if (!userExists)
            {
                throw new ArgumentException($"{username} not found!");
            }

            if (!friendExists)
            {
                throw new ArgumentException($"{friendName} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendName);

            bool isSendRequestFromUser = user.Friends.Any(x => x.Username == friend.Username);
            bool isSendRequestFromFriend = friend.Friends.Any(x => x.Username == user.Username);

            if (isSendRequestFromUser && isSendRequestFromFriend)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }
            else if (!isSendRequestFromFriend)
            {
                throw new InvalidOperationException($"{friend.Username} has not added {user.Username} as a friend");
            }

            this.userService.AcceptFriend(user.Id, friend.Id);

            return $"{user.Username} accepted {friend.Username} as a friend";
        }
    }
}
