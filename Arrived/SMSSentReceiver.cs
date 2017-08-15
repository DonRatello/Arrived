using Android.App;
using Android.Content;
using Android.Telephony;
using Android.Widget;

namespace Arrived
{
    [BroadcastReceiver(Exported = true)]
    public class SMSSentReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            switch ((int)ResultCode)
            {
                case (int)Result.Ok:
                    Toast.MakeText(Application.Context, "SMS has been sent", ToastLength.Long).Show();
                    break;
                case (int)SmsResultError.GenericFailure:
                    Toast.MakeText(Application.Context, "Generic Failure", ToastLength.Long).Show();
                    break;
                case (int)SmsResultError.NoService:
                    Toast.MakeText(Application.Context, "No Service", ToastLength.Long).Show();
                    break;
                case (int)SmsResultError.NullPdu:
                    Toast.MakeText(Application.Context, "Null PDU", ToastLength.Long).Show();
                    break;
                case (int)SmsResultError.RadioOff:
                    Toast.MakeText(Application.Context, "Radio Off", ToastLength.Long).Show();
                    break;
            }
        }
    }
}