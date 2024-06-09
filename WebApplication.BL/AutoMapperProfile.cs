using System;
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
using WebApplication.BL.Core.DTOs;

namespace WebApplication.BL
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<UserDTO, UDbTable>()
            //.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Level))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            //.ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.ConfirmPassword))
            
            //.ForMember(dest => dest.UserIp, opt => opt.MapFrom(src => src.UserIp))
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));


            CreateMap<UDbTable, UserDTO>().ReverseMap();

            CreateMap<ArticleTable, ArticleDTO>().ReverseMap();
            CreateMap<ProductTable, ProductDTO>().ReverseMap();
            CreateMap<OrderTable, OrderDTO>().ReverseMap();
            CreateMap<MyIntOrder, MyIntOrderDTO>().ReverseMap();
            CreateMap<ReviewTable, ReviewDTO>().ReverseMap();

            CreateMap<WishlistTable, WishlistDTO>().ReverseMap();



        }
    } 
}
