using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using AutoMapper;
using WebApplication.BL.Core;
using WebApplication.BL.Core.DTOs;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;
using WebApplication.Models;

namespace WebApplication
{
    public class AutoMapperProfile:Profile
    {
        

            public AutoMapperProfile()
        {
            //CreateMap<UDbTable, UserDataModel>()
            //  .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //  .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            //  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //  .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            //  .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
            //  .ForMember(dest => dest.WishlistId, opt => opt.MapFrom(src => src.WishlistId))
            //  .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId));

            CreateMap<UDbTable, UserDataModel>().ReverseMap();


    

    }



    }

}