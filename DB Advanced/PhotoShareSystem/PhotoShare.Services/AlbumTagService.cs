namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AlbumTagService : IAlbumTagService
    {
        private readonly PhotoShareContext context;

        public AlbumTagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public AlbumTag AddTagTo(int albumId, int tagId)
        {
            var albumTag = new AlbumTag
            {
                AlbumId = albumId,
                TagId = tagId
            };

            context.AlbumTags.Add(albumTag);
            context.SaveChanges();

            return albumTag;
        }
    }
}
