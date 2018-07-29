namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Dtos;
    using Contracts;
    using Services.Contracts;

    public class UploadPictureCommand : ICommand
    {
        private readonly IPictureService pictureService;
        private readonly IAlbumService albumService;
        private readonly ISessionService sessionService;

        public UploadPictureCommand(IPictureService pictureService, IAlbumService albumService, ISessionService sessionService)
        {
            this.pictureService = pictureService;
            this.albumService = albumService;
            this.sessionService = sessionService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string pictureTitle = data[1];
            string path = data[2];

            var albumExists = this.albumService.Exists(albumName);

            if (!albumExists)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            var album = this.albumService.ByName<AlbumDto>(albumName);

            if (!this.sessionService.IsLoggedIn(album.AlbumOwnerId))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }


            var picture = this.pictureService.Create(album.Id, pictureTitle, path);

            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
