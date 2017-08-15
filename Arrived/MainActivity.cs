using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Telephony;
using Android.Content;

namespace Arrived
{
    [Activity(Label = "Arrived", MainLauncher = true, Icon = "@drawable/Car")]
    public class MainActivity : Activity
    {
        ImageButton ButtonSend { get; set; }
        RadioButton ButtonDN { get; set; }
        RadioButton ButtonRAIFF { get; set; }
        TextView TxtInfo { get; set; }

        SmsManager smsManager;
        BroadcastReceiver smsSentBroadcastReceiver, smsDeliveredBroadcastReceiver;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            smsManager = SmsManager.Default;

            InitUI();
        }

        protected override void OnResume()
        {
            base.OnResume();

            smsSentBroadcastReceiver = new SMSSentReceiver();
            smsDeliveredBroadcastReceiver = new SMSDeliveredReceiver();

            RegisterReceiver(smsSentBroadcastReceiver, new IntentFilter("SMS_SENT"));
            RegisterReceiver(smsDeliveredBroadcastReceiver, new IntentFilter("SMS_DELIVERED"));
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterReceiver(smsSentBroadcastReceiver);
            UnregisterReceiver(smsDeliveredBroadcastReceiver);
        }

        protected void InitUI()
        {
            TxtInfo = FindViewById<TextView>(Resource.Id.txtInfo);
            ButtonDN = FindViewById<RadioButton>(Resource.Id.radioArrToDn);
            ButtonRAIFF = FindViewById<RadioButton>(Resource.Id.radioArrToRaiff);
            ButtonSend = FindViewById<ImageButton>(Resource.Id.btnSend);
            ButtonSend.Click += ButtonSendClicked;

            SetRadios();
        }

        protected void SetRadios()
        {
            if (DateTime.Now.Hour >= 11)
            {
                ButtonRAIFF.Checked = true;
            }
            else
            {
                ButtonDN.Checked = true;
            }
        }

        private void ButtonSendClicked(object sender, EventArgs e)
        {
            using (var msgBuilder = new MessageBuilder(this))
            {
                var piSent = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_SENT"), 0);
                var piDelivered = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_DELIVERED"), 0);

                smsManager.SendTextMessage(GetString(Resource.String.phone_nmbr), 
                    null, 
                    ButtonDN.Checked ? msgBuilder.GetMsgArriveToDN() : msgBuilder.GetMsgArriveToRAIFF(), 
                    piSent, 
                    piDelivered);

                TxtInfo.Text = ButtonDN.Checked ? msgBuilder.GetMsgArriveToDN() : msgBuilder.GetMsgArriveToRAIFF();
            }
        }
    }
}

