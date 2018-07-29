namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using PhotoShare.Services.Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IAlbumService albumService;
        private readonly IAlbumTagService albumTagService;
        private readonly ISessionService sessionService;

        public AddTagToCommand(ITagService tagService, IAlbumService albumService, IAlbumTagService albumTagService, ISessionService sessionService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
            this.albumTagService = albumTagService;
            this.sessionService = sessionService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string tagName = data[1];

            var newTagName = tagName.ValidateOrTransform();

            bool albumExists = this.albumService.Exists(albumName);
            bool tagExists = this.tagService.Exists(newTagName);

            if (!albumExists || !tagExists)
            {
                throw new ArgumentException($"Either tag or album do not exist!");
            }

            var album = this.albumService.ByName<AlbumDto>(albumName);

            if (!this.sessionService.IsLoggedIn(album.AlbumOwnerId))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var albumId = album.Id;
            var tagId = this.tagService.ByName<AlbumDto>(newTagName).Id;

            this.albumTagService.AddTagTo(albumId, tagId);

            return $"Tag {newTagName} added to {albumName}!";

        }
    }
}
