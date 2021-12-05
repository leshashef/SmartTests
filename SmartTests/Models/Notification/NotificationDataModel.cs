using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models.Notification
{
    public class NotificationDataModel
    {
        public int Id { get; set; }

        public int UserModelId { get; set; }

        public string Auth { get; set; }
        public string P256DH { get; set; }
        public string Endpoint { get; set; }


        public virtual UserModel User { get; set; }
    }
}
