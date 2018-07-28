namespace PhotoShare.Services
{
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SessionService : ISessionService
    {
        private readonly IUserService userService;

        public SessionService(IUserService userService)
        {
            this.userService = userService;
        }

        public User User { get; private set; }


        public void Login(int userId)
        {
            this.User = this.userService.ById<User>(userId);
        }

        public void Logout()
        {
            this.User = null;
        }

        public bool IsLoggedIn()
        {
            return this.User != null;
        }
    }
}
