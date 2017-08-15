using Android.App;
using Android.Content;
using Android.Media;
using Android.Widget;
using System;

namespace Arrived
{
    [BroadcastReceiver(Exported = true)]
    public class SMSDeliveredReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            switch (ResultCode)
            {
                case Result.Ok:
                    {
                        try
                        {
                            Android.Net.Uri notification = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                            Ringtone r = RingtoneManager.GetRingtone(context, notification);
                            r.Play();
                        }
                        catch (Exception e)
                        {

                        }

                        Toast.MakeText(Application.Context, "SMS delivered", ToastLength.Long).Show();
                        break;
                    }
                case Result.Canceled:
                    {
                        Toast.MakeText(Application.Context, "SMS not delivered", ToastLength.Long).Show();
                        break;
                    }
            }
        }
    }
}