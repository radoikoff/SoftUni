namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Models.Enums;
    using PhotoShare.Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IAlbumRoleService albumRoleService;
        private readonly IUserService userService;

        public ShareAlbumCommand(IAlbumService albumService, IAlbumRoleService albumRoleService, IUserService userService)
        {
            this.albumService = albumService;
            this.albumRoleService = albumRoleService;
            this.userService = userService;
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

            var album = this.albumService.ById<AlbumDto>(albumId);

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

            var albumRole = this.albumRoleService.PublishAlbumRole(albumId, userId, permission);

            return $"Username {username} added to album {album.Name} ({permission})";

        }
    }
}
