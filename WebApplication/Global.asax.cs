using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using AutoMapper;
using WebApplication.App_Start;
using WebApplication.BL;
using WebApplication.BL.Core;
using WebApplication.BL.DBModel;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProductContext>());

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Инициализация AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BL.AutoMapperProfile>();
            });

            //TODO: Добавить проверку на наличие пользователей в бд и создавать админа только если нет ниодного пользователя в бд
            // Здесь вызываем метод для создания учетной записи администратора
            var userApi = new UserApi();
            //if (!userApi.UsersExist())
            //{
            //    userApi.CreateAdminAccount();
            //}
        }
            
    }
}