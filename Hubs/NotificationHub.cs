using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using NotificationExample.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationExample.Hubs
{
    [HubName("NotiHub")]
    public class NotificationHub : Hub
    {
        public static void BroadcastData(NotificationMaster model)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.refreshNotificationData(model.Notify_To, model.Notification_Id);
        }
    }
}