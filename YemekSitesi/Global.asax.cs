using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YemekSitesi.Models;



namespace YemekSitesi

{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Database.CreateIfNotExists();
            }

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
