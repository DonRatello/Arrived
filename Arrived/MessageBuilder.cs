using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Arrived
{
    public class MessageBuilder : IDisposable
    {
        Activity activity;

        public MessageBuilder(Activity activity)
        {
            this.activity = activity;
        }

        string GetHeader()
        {
            return $"{activity.GetString(Resource.String.app_name)} {DateTime.Now.ToString("HH:mm:ss")}\n\n";
        }

        public string GetMsgArriveToDN()
        {
            return $"{GetHeader()}{activity.GetString(Resource.String.msg_dn)}";
        }

        public string GetMsgArriveToRAIFF()
        {
            return $"{GetHeader()}{activity.GetString(Resource.String.msg_raiff)}";
        }

        public void Dispose()
        {}
    }
}