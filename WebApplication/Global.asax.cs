using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using AutoMapper;
using WebApplication.BL;
using WebApplication.BL.Core;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Инициализация AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<WebApplication.BL.AutoMapperProfile>();
            });

            // Здесь вызываем метод для создания учетной записи администратора
            var userApi = new UserApi();
            userApi.CreateAdminAccount();
        }
            
    }
}