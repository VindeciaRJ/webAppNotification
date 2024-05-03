namespace NotificationExample.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NotificationMaster")]
    public partial class NotificationMaster
    {
        [Key]
        public int Notification_Id { get; set; }

        [StringLength(128)]
        public string Notify_From { get; set; }

        [StringLength(128)]
        public string Notify_To { get; set; }

        [StringLength(50)]
        public string Notification_Title { get; set; }

        public string Notification_Message { get; set; }
    }
}
