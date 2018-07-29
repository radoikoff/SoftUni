namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using PhotoShare.Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IAlbumRoleService albumRoleService;
        private readonly IUserService userService;
        private readonly ISessionService sessionService;

        public ShareAlbumCommand(IAlbumService albumService, IAlbumRoleService albumRoleService, IUserService userService, ISessionService sessionService)
        {
            this.albumService = albumService;
            this.albumRoleService = albumRoleService;
            this.userService = userService;
            this.sessionService = sessionService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            bool albumExists = this.albumService.Exists(albumId);

            if (!albumExists)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            var album = this.albumService.ById<Album>(albumId);
            var albumOwnerId = album.AlbumRoles.FirstOrDefault(r => r.Role == Role.Owner).UserId;

            if (!this.sessionService.IsLoggedIn(albumOwnerId))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            bool userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            bool isValidPermission = Enum.TryParse(permission, out Role result);

            if (!isValidPermission)
            {
                throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
            }

            //Check is requested albumRole entity already exisits.
            bool exisits = this.albumRoleService.IsExists(albumId, userId, permission);
            if (exisits)
            {
                throw new ArgumentException($"{username} already has {permission} access to album with Id {albumId}");
            }

            var albumRole = this.albumRoleService.PublishAlbumRole(albumId, userId, permission);

            return $"Username {username} added to album {album.Name} ({permission})";

        }
    }
}
