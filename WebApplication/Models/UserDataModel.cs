using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Models
{
    public class UserDataModel
    {
        public UserApi userApi;

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string KeyCredential { get; set; }

        public URole Role { get; set; }
        public string UserIp { get; set; }

        public WishlistTable Wishlist { get; set; }


        public UserDataModel() {
            userApi = new UserApi();
        }

        public List<UserDTO> dataForTable()
        {
            return userApi.getUsersFromDatabase();
        }

        public UserDTO moveDataFromModelToDTO()
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = this.UserId,
                Username = this.Username,
                Email = this.Email,
                Password = this.Password,
                ConfirmPassword = this.ConfirmPassword,
                KeyCredential = this.KeyCredential,
                Role = this.Role,
                UserIp = this.UserIp,
                Wishlist = this.Wishlist
            };

            return userDTO;
        }

        //public UserDataModel moveDataFromDTOToModel()
        //{
        //    UserDTO userDTO = new UserDTO
        //    {

        //    }

        //    return userDTO;
        //}

    }
}


