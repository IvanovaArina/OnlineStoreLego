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
using WebApplication.BL.Migrations;

namespace WebApplication.BL.Core
{
    public class UserApi
    {

        public bool UsersExist()
        {
            using (var db = new UserContext())
            {
                return db.Users.Any();
            }
        }
        internal BaseResponces CheckUserCredential(ULoginData ulData)
        {
            UserDTO local=null;

            using(var db =new UserContext())
            {
                
                var dbUser = db.Users.FirstOrDefault(x => x.Email == ulData.Email);

                if (dbUser != null)
                {
                    // Если роль администратора, не хешировать пароль
                    if (dbUser.Role == URole.Admin)
                    {
                        if (dbUser.Password == ulData.Password)
                        {
                            local = new UserDTO
                            {
                                UserId = dbUser.Id,
                                Email = dbUser.Email,
                                Password = dbUser.Password,
                                Level = dbUser.Role,
                                Wishlist = dbUser.Wishlist
                            };
                        }
                    }
                    else
                    {
                        // Хэширование пароля для других пользователей
                        string hashedPassword = HashPassword(ulData.Password);
                        if (dbUser.Password == hashedPassword)
                        {
                            local = new UserDTO
                            {
                                UserId = dbUser.Id,
                                Email = dbUser.Email,
                                Password = dbUser.Password,
                                Level = dbUser.Role,
                                Wishlist = dbUser.Wishlist
                            };
                        }
                        else
                        {
                            return new BaseResponces { Status = false, StatusMessage = "Incorrect password." };
                        }
                    }
                }
                else
                {
                    return new BaseResponces { Status = false, StatusMessage = "No user with this email exists." };
                }
            }

            if (local!=null)
            {
                

                return new BaseResponces { Status = true, Role = local.Level };
            }
            return new BaseResponces { Status = false ,StatusMessage="No user with this credential types"};
        }


        internal BaseResponces GenerateUserSession(ULoginData ulData)
        {
            UserDTO local = null;

            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.Email == ulData.Email);
                if (dbUser != null)
                {
                    local = new UserDTO
                    {
                        UserIp = dbUser.UserIp,   // Assuming you want to map 'Id' from UDbTable to 'UserId' in UserDTO
                        Name = dbUser.Username,
                        Email = dbUser.Email,
                        Password = dbUser.Password,
                        Level = dbUser.Role,
                        Wishlist = dbUser.Wishlist
                        // Map other properties as necessary
                    };
                }
            }


            if(local==null)
            {
                return new BaseResponces { Status = false, StatusMessage ="WRONG USERNAME OR PASSWORD"};
            }
            return new BaseResponces { Status=true};
        }


        

        internal BaseResponces RegisterNewUserAccaunt(USignInData ulData) 
        {
            if (ulData.Password != ulData.ConfirmPassword)
            {
                return new BaseResponces { Status = false, StatusMessage = "Пароль и подтверждение пароля не совпадают." };
            }

            UserDTO local = null ;
            using (var db = new UserContext())
            {
                
                var dbUser = db.Users.FirstOrDefault(x => x.Email == ulData.Email);
                if (dbUser != null)
                {
                    return new BaseResponces { Status = false, StatusMessage = "Этот адрес электронной почты уже зарегистрирован." };
                }
                if (dbUser != null)
                {
                    local = new UserDTO
                    {
                        UserId = dbUser.Id,   // Assuming you want to map 'Id' from UDbTable to 'UserId' in UserDTO
                        Name = dbUser.Username,
                        Email = dbUser.Email,
                        Password = dbUser.Password,
                        Wishlist = dbUser.Wishlist
                        // Map other properties as necessary
                    };
                }
            }

            if (local!=null)
            {
                return new BaseResponces { Status=false,StatusMessage="This UserName already redistered"};
            }
            string hashedPassword = HashPassword(ulData.Password);

            var user = new UserDTO
            {
                Password = hashedPassword,
                Email = ulData.Email,
                Name = ulData.FullName,
                UserIp = ulData.UserIp,

                ConfirmPassword = hashedPassword,



                Level = URole.User,
                Wishlist = new WishlistTable
                {
                    test = 2,
                    wishlistEntity = new List<int>()
                }


            };



            var userDb = Mapper.Map<UDbTable>(user); // Используем AutoMapper для преобразования

            using (var db = new UserContext())
            {
                db.Users.Add(userDb);
                //db.SaveChanges();
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



            return new BaseResponces {Status=true };
        }


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


        public BaseResponces CreateAdminAccount()
        {
            using (var db = new UserContext())
            {
                // Проверяем, существует ли уже администратор
                var adminExists = db.Users.Any(u => u.Email == "admin@example.com");
                if (!adminExists)
                {
                    // Создаем учетную запись администратора
                    var adminUser = new UDbTable
                    {
                        Username = "Admin",
                        Email = "admin@example.com",
                        Password = "cisco1234",
                        
                        Role = URole.Admin,
                        Wishlist = new WishlistTable()
                    };

                    db.Users.Add(adminUser);
                    try
                    {
                        db.SaveChanges();
                        return new BaseResponces { Status = true, StatusMessage = "Admin account created successfully" };
                    }
                    catch (Exception ex)
                    {
                        // Обработка ошибок
                        return new BaseResponces { Status = false, StatusMessage = ex.Message };
                    }
                }
                else
                {
                    // Администратор уже существует
                    return new BaseResponces { Status = false, StatusMessage = "Admin account already exists" };
                }
            }
        }

    }
}
