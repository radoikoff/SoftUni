namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services.Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IAlbumService albumeService;
        private readonly IAlbumTagService albumTagService;

        public AddTagToCommand(ITagService tagService, IAlbumService albumeService, IAlbumTagService albumTagService)
        {
            this.tagService = tagService;
            this.albumeService = albumeService;
            this.albumTagService = albumTagService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string tagName = data[1];

            var newTagName = tagName.ValidateOrTransform();

            bool albumExists = this.albumeService.Exists(albumName);
            bool tagExists = this.tagService.Exists(newTagName);

            if (!albumExists || !tagExists)
            {
                throw new ArgumentException($"Either tag or album do not exist!");
            }

            var albumId = this.albumeService.ByName<AlbumDto>(albumName).Id;
            var tagId = this.tagService.ByName<AlbumDto>(newTagName).Id;

            this.albumTagService.AddTagTo(albumId, tagId);

            return $"Tag {newTagName} added to {albumName}!";

        }
    }
}
