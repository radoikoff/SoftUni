namespace PhotoShare.Services
{
    using System;

    using Models;
    using Models.Enums;
    using Data;
    using Contracts;
    using System.Linq;

    public class AlbumRoleService : IAlbumRoleService
    {
        private readonly PhotoShareContext context;

        public AlbumRoleService(PhotoShareContext context)
        {
            this.context = context;
        }

        public AlbumRole PublishAlbumRole(int albumId, int userId, string role)
        {
            var roleAsEnum = Enum.Parse<Role>(role);

            var albumRole = new AlbumRole()
            {
                AlbumId = albumId,
                UserId = userId,
                Role = roleAsEnum
            };

            this.context.AlbumRoles.Add(albumRole);

            this.context.SaveChanges();

            return albumRole;
        }

        public bool IsExists(int albumId, int userId, string permission)
        {
            var roleAsEnum = Enum.Parse<Role>(permission);

            var entity = this.context.AlbumRoles.FirstOrDefault(x => x.AlbumId == albumId && x.UserId == userId && x.Role == roleAsEnum);

            return entity != null;
        }
    }
}
