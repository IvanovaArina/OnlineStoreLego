/*using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WebApplication.BL.Core;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Models
{
    public class ArticleDataModelWithActions
    {

        public Tuple<int, string, string, string>  getDataFromDatabase()
        {
            



            return new Tuple<int, string, string, string>();
        }

        internal BaseResponces RegisterNewUserAccaunt(USignInData ulData)
        {

            UserDTO local = null;
            using (var db = new UserContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.Email == ulData.Email);
                if (dbUser != null)
                {
                    local = new UserDTO
                    {
                        UserId = dbUser.Id,   // Assuming you want to map 'Id' from UDbTable to 'UserId' in UserDTO
                        Name = dbUser.Username,
                        Email = dbUser.Email,
                        Password = dbUser.Password,
                        // Map other properties as necessary
                    };
                }
            }

            if (local != null)
            {
                return new BaseResponces { Status = false, StatusMessage = "This UserName already redistered" };
            }

            var user = new UserDTO
            {
                Password = ulData.Password,//зашифровать 
                Email = ulData.Email,
                Name = ulData.FullName,
                UserIp = ulData.UserIp,
                Country = ulData.Country,
                ConfirmPassword = ulData.ConfirmPassword,
                City = ulData.City,
                Phone = ulData.PhoneNumber,

                Level = URole.User


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



            return new BaseResponces { Status = true };
        }



        public List<Tuple<int, string, string, string>> dataForTable()
        {
            List<Tuple<int, string, string, string>> tupelsWithArticlesData = new List<Tuple<int, string, string, string>>();


            tupelsWithArticlesData.Add(Tuple.Create(1, "Title1", "Author1", "Category1"));
            tupelsWithArticlesData.Add(Tuple.Create(1, "Title eva", "Author eva", "Category eva"));


            return tupelsWithArticlesData;
        }

    }
}
*/