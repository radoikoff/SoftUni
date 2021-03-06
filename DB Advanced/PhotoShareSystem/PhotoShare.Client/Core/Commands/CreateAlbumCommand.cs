﻿namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models.Enums;
    using Services.Contracts;


    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string color = data[2];
            string[] tags = data.Skip(3).ToArray();

            bool userExsits = this.userService.Exists(username);

            if (!userExsits)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            bool albumExists = this.albumService.Exists(albumTitle);

            if (albumExists)
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            var isValidColor = Enum.TryParse<Color>(color, out Color result);

            if (!isValidColor)
            {
                throw new ArgumentException($"Color {color} not found!");
            }

            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].ValidateOrTransform();

                bool currentTagExists = this.tagService.Exists(tags[i]);

                if (!currentTagExists)
                {
                    throw new ArgumentException($"Invalid tags!");
                }
            }


            this.albumService.Create(userId, albumTitle, color, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}
