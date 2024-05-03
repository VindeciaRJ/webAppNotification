using NotificationExample.Hubs;
using NotificationExample.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationExample.Controllers
{
    public class HomeController : Controller
    {
        AddDataModel db = new AddDataModel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNewMessage(NotificationMaster model)
        {
            var rawQuery = db.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.Notification_Seq;");
            var task = rawQuery.SingleAsync();
            int nextVal = task.Result;

            model.Notification_Id = nextVal;
            db.NotificationMaster.Add(model);
            db.SaveChanges();

            NotificationHub.BroadcastData(model);
            return Json(new { status = true });
        }

        public ActionResult GetNotification(NotificationMaster model)
        {
            var noti = (from m in db.NotificationMaster
                        where m.Notification_Id == model.Notification_Id
                        select m).FirstOrDefault();

            var num = (from m in db.NotificationMaster
                       where m.Notify_To == model.Notify_From
                       select m).ToList().Count();

            return Json(new { number = num, title = noti.Notification_Title, message = noti.Notification_Message });
        }
    }
}