using System.Collections.Generic;
using System.Linq;
using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Post;
using Ganjeh.Domain.Models.Posts;

namespace Ganjeh.Application.MappingProfiles.Regions
{
    public class PostProfile : BaseProfile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.PostCategory))
                .ReverseMap();

            CreateMap<InsertPost, Post>()
                .ForMember(dest => dest.Video,
                    opt => opt.MapFrom(src =>
                    new File()
                    {
                        Source = src.Video,
                        FileType = Domain.Enums.FileTypeEnum.VIDEO,
                        RecordType = Domain.Enums.RecordTypeEnum.MAIN,
                        Title = string.Empty
                    })
                )
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(src =>
                        src.OtherImages.Where(img => !string.IsNullOrEmpty(img))
                        .Select(img => new File()
                        {
                            Source = img,
                            FileType = Domain.Enums.FileTypeEnum.IMAGE,
                            RecordType = Domain.Enums.RecordTypeEnum.OTHER,
                            Title = string.Empty
                        }).Append(new File()
                        {
                            Source = src.Image,
                            FileType = Domain.Enums.FileTypeEnum.IMAGE,
                            RecordType = Domain.Enums.RecordTypeEnum.MAIN,
                            Title = string.Empty
                        })
                    )
                )
                .ForMember(dest => dest.PhoneNumbers,
                    opt => opt.MapFrom(src =>
                        src.PhoneNumbers
                        .Select(phone => new Phone()
                        {
                            Number = phone,
                            RecordType = Domain.Enums.RecordTypeEnum.OTHER,
                        })
                    )
                )
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => new Address()
                    {
                        RegionCityId = src.RegionCityId,
                        AddressLine = src.AddressLine,
                        ZipCode = src.ZipCode,
                        Lat = src.Lat,
                        Lng = src.Lng
                    })
                )
                .ReverseMap();
            ;
        }
    }
}