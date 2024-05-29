using AutoMapper;
using Microsoft.SqlServer.Server;
using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;
using WebApplication.Helper;
using System.Security.Policy;
using System.Diagnostics;
using System.Security.Cryptography;
using WebApplication.Domain.Entities.Admin;
using ProductTable = WebApplication.Domain.Entities.Admin.ProductTable;
using System.Web.UI.WebControls.WebParts;
//using WebApplication.BL.Migrations;

namespace WebApplication.BL.Core
{
    public class UserApi
    {
        //----------------------
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal BaseResponces GenerateUserSession(UserDTO userDTO)
        {
            UserDTO local = null;

            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.Email == userDTO.Email);
                if (dbUser != null)
                {
                    local = new UserDTO
                    {
                        //UserIp = dbUser.UserIp,   // Assuming you want to map 'Id' from UDbTable to 'UserId' in UserDTO
                        Username = dbUser.Username,
                        Email = dbUser.Email,
                        Password = dbUser.Password,
                        Role = dbUser.Role,
                        Wishlist = dbUser.Wishlist
                        // Map other properties as necessary
                    };
                }
            }


            if (local == null)
            {
                return new BaseResponces { Status = false, StatusMessage = "WRONG USERNAME OR PASSWORD" };
            }
            return new BaseResponces { Status = true };
        }

        public URole defineRole(UDbTable DbUser)
        {
            URole role = new URole();
            if (DbUser.Role == 0)
            {
                role = URole.User;
            }
            else
            {
                role = URole.Admin;
            }

            return role;
        }

        //public URole defineRoleByKeyCredential(string KeyCredential)
        //{
        //    URole role = new URole();
        //    if (KeyCredential == "cisco1234")
        //    {
        //        role = URole.Admin;
        //    }
        //    else
        //    {
        //        role = URole.User;
        //    }

        //    return role;
        //}

        public List<UserDTO> getUsersFromDatabase()
        {
            List<UserDTO> listOfUserDTO = new List<UserDTO>();

            List<int> usersIds = new List<int>();

            using (var db = new UserContext())
            {
                usersIds = db.Users.Select(w => w.UserId).ToList();
            }

            foreach (var i in usersIds)
            {

                listOfUserDTO.Add(getUserDTObyId(i));

            }
            return listOfUserDTO;
        }

        public UserDTO getUserDTObyId(int id)
        {
            UserDTO local = null;
            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.UserId == id);
                if (dbUser != null)
                {
                    local = new UserDTO
                    {
                        UserId = dbUser.UserId,
                        Username = dbUser.Username,
                        Email = dbUser.Email,
                        Password = dbUser.Password,
                        ConfirmPassword = dbUser.ConfirmPassword,
                        //KeyCredential
                        Role = defineRole(dbUser),
                        //UserIp = dbUser.UserIp,
                        //Wishlist 
                    };
                }
            }
            return local;
        }

        public bool checkIfEmailExists(string email)
        {
            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.Email == email);

                if (dbUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool checkIfUserIdExists (int id)
        {
            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.UserId == id);

                if (dbUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //private void saveChanges(UDbTable userDb)
        //{
        //    using (var db = new UserContext())
        //    {
        //        db.Users.Add(userDb);
        //        try
        //        {
        //            // Попытка сохранить изменения в базе данных
        //            db.SaveChanges();
        //        }
        //        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        //        {
        //            foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            {
        //                foreach (var validationError in validationErrors.ValidationErrors)
        //                {
        //                    Trace.TraceInformation("Property: {0} Error: {1}",
        //                                            validationError.PropertyName,
        //                                            validationError.ErrorMessage);
        //                }
        //            }
        //            // Здесь можно выбросить более общее исключение или обработать ошибку
        //            throw; // Перебрасывает исключение дальше
        //        }
        //    }
        //}

        public BaseResponces addUserToDb(UDbTable userDb)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(userDb);
                try
                {
                    // Попытка сохранить изменения в базе данных
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                    // Здесь можно выбросить более общее исключение или обработать ошибку
                    throw; // Перебрасывает исключение дальше
                }
            }

            return new BaseResponces { Status = true };
        }

        public CartTable createCartTable()
        {
            var prod1 = new ProductTable
            {
                ProductNumber = 33,
                ProductName = "ProductName",
                Price = 20,
                CategoryByAge = "CategoryByAge",
                Category = "Category",
                SellCategory = "SellCategory",
                Quantity = 500,
                isActive = true
            };

            var prod2 = new ProductTable
            {
                ProductNumber = 44,
                ProductName = "ProductName2",
                Price = 202,
                CategoryByAge = "CategoryByAge2",
                Category = "Category2",
                SellCategory = "SellCategory2",
                Quantity = 5002,
                isActive = false
            };

            CartTable Cart = new CartTable
            {
                testCart = 55,

                Products = new Dictionary<ProductTable, int>
                    {
                        { prod1 , 35 },
                        {prod2 , 85 },
                }
            };

            return Cart;
        }

        public WishlistTable createWishlistTable()
        {
            WishlistTable Wishlist = new WishlistTable
            {
                test = 2,
                //wishlistEntity = new List<int>()
                Products = new List<ProductTable>
                    {
                        new ProductTable { ProductNumber = 1,
                        ProductName = "ProductName",
                        Price = 20,
                        CategoryByAge = "CategoryByAge",
                        Category = "Category",
                        SellCategory = "SellCategory",
                        Quantity = 500,
                        isActive = true
                        },
                        new ProductTable { ProductNumber = 2,
                        ProductName = "ProductName2",
                        Price = 202,
                        CategoryByAge = "CategoryByAge2",
                        Category = "Category2",
                        SellCategory = "SellCategory2",
                        Quantity = 5002,
                        isActive = false
                        },

                    }
            };
            return Wishlist;    
        }

        public UserDTO createNewUserWithHash(UserDTO userDTO)
        {
            string hashedPassword = HashPassword(userDTO.Password);

            var user = new UserDTO
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = hashedPassword,
                ConfirmPassword = hashedPassword,
                //UserIp = userDTO.UserIp,
                KeyCredential = userDTO.KeyCredential,
                Role = userDTO.Role,

                Wishlist = createWishlistTable(),

                Cart = createCartTable()

            };


        

            return user;
        }

        
        //----------------------


        //public bool UsersExist()
        //{
        //    using (var db = new UserContext())
        //    {
        //        return db.Users.Any();
        //    }
        //}

        internal BaseResponces CheckUserCredential(UserDTO userDTO)
        {
            UserDTO local = null;

            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.Email == userDTO.Email);

                if (dbUser != null)
                {
                    string hashedPassword = HashPassword(userDTO.Password);
                    if (dbUser.Password == hashedPassword)
                    {
                        local = new UserDTO
                        {
                            UserId = dbUser.UserId,
                            Email = dbUser.Email,
                            Password = dbUser.Password,
                            Role = dbUser.Role,
                            Wishlist = dbUser.Wishlist
                        };
                    }
                    else
                    {
                        return new BaseResponces { Status = false, StatusMessage = "Incorrect password." };
                    }
                }

                else
                {
                    return new BaseResponces { Status = false, StatusMessage = "No user with this email exists." };
                }
            }

            if (local != null)
            {


                return new BaseResponces { Status = true, Role = local.Role };
            }
            return new BaseResponces { Status = false, StatusMessage = "No user with this credential types" };
        }


       


        public BaseResponces RegisterNewUserAccount(UserDTO userDTO)
        {
            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                return new BaseResponces { Status = false, StatusMessage = "Пароль и подтверждение пароля не совпадают." };
            }

            if (checkIfEmailExists(userDTO.Email))
            {
                return new BaseResponces { Status = false, StatusMessage = "This UserName already registered" };
            }

            var user = createNewUserWithHash(userDTO);
            var userDb = Mapper.Map<UDbTable>(user); // Используем AutoMapper для преобразования
            //userDb.Wishlist.User = userDb;
            //userDb.Cart.User = userDb;

            return addUserToDb(userDb);
        }





        private void saveChanges(UDbTable userDb)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(userDb);
                try
                {
                    // Попытка сохранить изменения в базе данных
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                    // Здесь можно выбросить более общее исключение или обработать ошибку
                    throw; // Перебрасывает исключение дальше
                }
            }
        }




        public BaseResponces addUserToDb(UserDTO userDTO)
        {
            if (checkIfEmailExists(userDTO.Email))
            {
                return new BaseResponces { Status = false, StatusMessage = "This Article Number already exists" };
            }

            var userDb = Mapper.Map<UDbTable>(userDTO);

            saveChanges(userDb);

            return new BaseResponces { Status = true };
        }


        public void editUserInDb (UserDTO userDTO)
        {
            using (var context = new UserContext())
            {
                 //var userDb = Mapper.Map<UDbTable>(userDTO);


                // Находим продукт по его идентификатору (ID)
                var userDb = context.Users.FirstOrDefault(p => p.UserId == userDTO.UserId);

                if (userDb != null)
                {


                    // Меняем свойства продукта, которые могли поменяться
                    userDb.Username = userDTO.Username;
                    userDb.Email = userDTO.Email;
                    userDb.Password = HashPassword(userDTO.Password);
                    userDb.ConfirmPassword = userDb.Password;



                    //Role = userDTO.Role,
                    ////UserIp = userDTO.UserIp,
                    //Wishlist = userDTO.Wishlist,
                    //Cart = userDTO.Cart



                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }

            }
        }


        public void deleteUser(int id)
        {
            using (var context = new UserContext())
            {
                // Найти продукт по его идентификатору 
                var articleDb = context.Users.FirstOrDefault(p => p.UserId == id);

                if (articleDb != null)
                {
                    // Удаляем продукт из контекста данных
                    context.Users.Remove(articleDb);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
            }
        }

    }
}
