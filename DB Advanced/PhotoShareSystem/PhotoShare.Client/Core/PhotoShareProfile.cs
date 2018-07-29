namespace PhotoShare.Client.Core
{
    using AutoMapper;
    using Commands;
    using Models;
    using Dtos;
    using System.Linq;
    using PhotoShare.Models.Enums;

    public class PhotoShareProfile : Profile
    {
        public PhotoShareProfile()
        {
            CreateMap<User, User>();
            CreateMap<Town, Town>();
            CreateMap<Tag, Tag>();
            CreateMap<Album, Album>();

            CreateMap<Town, TownDto>().ReverseMap();

            CreateMap<Album, AlbumDto>()
                .ForMember(dest=>dest.AlbumOwnerId, opt=>opt.MapFrom(x=>x.AlbumRoles.FirstOrDefault(r => r.Role == Role.Owner).UserId))
                .ReverseMap();

            CreateMap<Tag, TagDto>().ReverseMap();

            CreateMap<AlbumRole, AlbumRoleDto>()
                    .ForMember(dest => dest.AlbumName, from => from.MapFrom(p => p.Album.Name))
                    .ForMember(dest => dest.Username, from => from.MapFrom(p => p.User.Username))
                    .ReverseMap();

	        CreateMap<User, UserFriendsDto>()
		        .ForMember(dto => dto.Friends,
			        opt => opt.MapFrom(u => u.FriendsAdded));

	        CreateMap<Friendship, FriendDto>()
		        .ForMember(dto => dto.Username,
			        opt => opt.MapFrom(f => f.Friend.Username));
        }
    }
}
