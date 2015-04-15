using DataLayer;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class TrainingController : Controller
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=johngorterstorage;AccountKey=xdhjkxTF/41XKK32cgsdxBKx7rbsICPCgo/IVMdkTyPNaZ1fH8OA8Mmz60G7KPF70XqHBUpObT5paAYTyXE79Q==");

        // GET: Training
        public ActionResult Index()
        {
            return View(new TrainingDatabase().Trainings.ToList());
        }

        public ActionResult Subscribe() {

            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(int id, string name)
        {
           CloudTableClient tableclient = storageAccount.CreateCloudTableClient();
           CloudTable table = tableclient.GetTableReference("registrations");

           table.Execute(TableOperation.Insert(new RegistrationEntity("registrations", Guid.NewGuid().ToString()) { student = name, training = id.ToString() }));

            //var db = new TrainingDatabase();
            //Training training = db.Trainings.Where(t => t.id == id).FirstOrDefault();
            //if (training != null)
            //{
            //    var regis = new Registration { StudentName = name, training = training };
            //    db.Registrations.Add(regis);
            //    training.registrations.Add(regis);
            //    db.SaveChanges();
            //}
            return RedirectToAction("/");
        }

    }
}