﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.User;

using AutoMapper;
using WebApplication.Domain.Entities.Enums;
using System.Security.AccessControl;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.BL
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, UDbTable>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Level))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.ConfirmPassword))
            
            .ForMember(dest => dest.UserIp, opt => opt.MapFrom(src => src.UserIp))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));


            CreateMap<ArticleTable, ArticleDTO>().ReverseMap();



        }
    } 
}