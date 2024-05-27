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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string KeyCredential { get; set; }

        public URole Level { get; set; }
        public string UserIp { get; set; }

        public WishlistTable Wishlist { get; set; }


        public UserDataModel() {
            userApi = new UserApi();
        }

        public List<UserDTO> dataForTable()
        {
            return userApi.getUsersFromDatabase();
        }

        //public UserDTO moveDataFromModelToDTO()
        //{
        //    UserDTO userDTO = new UserDTO
        //    {

        //    }

        //    return userDTO;
        //}

        //public UserDataModel moveDataFromDTOToModel()
        //{
        //    UserDTO userDTO = new UserDTO
        //    {

        //    }

        //    return userDTO;
        //}

    }
}


