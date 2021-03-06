﻿namespace PhotoShare.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly PhotoShareContext context;
        private readonly IMapper mapper;

        public UserService(PhotoShareContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel ById<TModel>(int id)
            => By<TModel>(u => u.Id == id).SingleOrDefault();

        public TModel ByUsername<TModel>(string username)
            => By<TModel>(u => u.Username == username).SingleOrDefault();

        public bool Exists(int id)
            => ById<User>(id) != null;

        public bool Exists(string name)
            => ByUsername<User>(name) != null;


        public Friendship AcceptFriend(int userId, int friendId)
        {
            var friendship = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };

            this.context.Friendships.Add(friendship);
            this.context.SaveChanges();

            return friendship;
        }

        public Friendship AddFriend(int userId, int friendId)
        {
            var friendship = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };

            this.context.Friendships.Add(friendship);
            this.context.SaveChanges();

            return friendship;
        }



        public void ChangePassword(int userId, string password)
        {
            var user = this.context.Users.Find(userId);

            user.Password = password;

            this.context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = this.context.Users.Find(userId);

            user.IsDeleted = true;
            this.context.SaveChanges();
        }

        public User Register(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user;
        }

        public void SetBornTown(int userId, int townId)
        {
            var user = this.context.Users.Find(userId);

            user.BornTownId = townId;

            this.context.SaveChanges();
        }

        public void SetCurrentTown(int userId, int townId)
        {
            var user = this.context.Users.Find(userId);

            user.CurrentTownId = townId;

            this.context.SaveChanges();
        }

        private IEnumerable<TModel> By<TModel>(Func<User, bool> predicate)
            => this.context.Users
                           .Include(u => u.FriendsAdded)
                           .Include(u => u.AlbumRoles)
                           .Where(predicate)
                           .AsQueryable()
                           .ProjectTo<TModel>(this.mapper.ConfigurationProvider);

    }
}