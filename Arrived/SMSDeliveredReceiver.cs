using Android.App;
using Android.Content;
using Android.Widget;

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
                    Toast.MakeText(Application.Context, "SMS delivered", ToastLength.Long).Show();
                    break;
                case Result.Canceled:
                    Toast.MakeText(Application.Context, "SMS not delivered", ToastLength.Long).Show();
                    break;
            }
        }
    }
}