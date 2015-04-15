using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebRole1.Models;

namespace WebRole1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //// insert some trainings
            //TrainingDatabase db = new TrainingDatabase();
            //if (db.Trainings.Where(t => t.name.Equals("c#")).FirstOrDefault() == null) {
            //    db.Trainings.Add(new Training { id=0, name="c#", description="programming c#", location="Veenendaal", startDate = DateTime.Now});
            //    db.SaveChanges();
            //}
            //if (db.Trainings.Where(t => t.name.Equals("c# 2")).FirstOrDefault() == null) {
            //    db.Trainings.Add(new Training { id = 1, name = "c# 2", description = "programming c# 2", location = "Veenendaal", startDate = DateTime.Now });
            //    db.SaveChanges();
            //}

        }
    }
}
