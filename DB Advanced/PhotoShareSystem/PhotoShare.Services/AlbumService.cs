﻿namespace PhotoShare.Services
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext context;

        public AlbumService(PhotoShareContext context)
        {
            this.context = context;
        }


        public TModel ById<TModel>(int id)
            => By<TModel>(a => a.Id == id).SingleOrDefault();

        public TModel ByName<TModel>(string name)
            => By<TModel>(a => a.Name == name).SingleOrDefault();

        public bool Exists(int id)
            => ById<Album>(id) != null;

        public bool Exists(string name)
            => ByName<Album>(name) != null;


        public Album Create(int userId, string albumTitle, string bgColor, string[] tags)
        {
            var album = new Album
            {
                Name = albumTitle,
                BackgroundColor = Enum.Parse<Color>(bgColor, true)
            };


            this.context.Albums.Add(album);
            context.SaveChanges();

            var albumRole = new AlbumRole
            {
                UserId = userId,
                Album = album
            };

            this.context.AlbumRoles.Add(albumRole);
            context.SaveChanges();

            foreach (var tag in tags)
            {
                var currentTagId = this.context.Tags.FirstOrDefault(t => t.Name == tag).Id;

                var albumTag = new AlbumTag
                {
                    Album = album,
                    TagId = currentTagId
                };
                this.context.AlbumTags.Add(albumTag);
            }

            context.SaveChanges();

            return album;
        }


        private IEnumerable<TModel> By<TModel>(Func<Album, bool> predicate)
            => this.context.Albums
                           .Include(a=>a.AlbumRoles)
                           .Include(a=>a.AlbumTags)
                           .Include(a=>a.Pictures)
                           .Where(predicate)
                           .AsQueryable()
                           .ProjectTo<TModel>();
    }
}
