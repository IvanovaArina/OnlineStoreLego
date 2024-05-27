using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using AutoMapper;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;
using WebApplication.Models;

namespace WebApplication
{
    public class AutoMapperProfile:Profile
    {
        

            public AutoMapperProfile()
        {
            CreateMap<UserSignIn, USignInData>()
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
    
    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
    .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.ConfirmPassword))
    .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
    .ForMember(dest => dest.UserIp, opt => opt.MapFrom(src => src.UserIp));


            CreateMap<UserDataModel, UserDTO>().ReverseMap();
        }
    }

}