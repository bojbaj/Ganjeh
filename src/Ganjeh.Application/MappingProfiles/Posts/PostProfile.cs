using System;
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
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)))
                .ReverseMap();

            CreateMap<InsertPost, Post>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => string.Join(",", src.PhoneNumbers)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => string.Join(",", src.OtherImages)))
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

            CreateMap<UpdatePost, Post>()
                .IncludeBase<InsertPost, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .AfterMap(UpdateExistsData)
                .ReverseMap();
        }

        private void UpdateExistsData(InsertPost src, Post dest)
        {
            dest.Address = new Address()
            {
                Id = dest.AddressId,
                RegionCityId = src.RegionCityId,
                AddressLine = src.AddressLine,
                ZipCode = src.ZipCode,
                Lat = src.Lat,
                Lng = src.Lng
            };
        }
    }
}