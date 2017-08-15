using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Arrived
{
    [Activity(Label = "Arrived", MainLauncher = true, Icon = "@drawable/Car")]
    public class MainActivity : Activity
    {
        ImageButton ButtonSend { get; set; }
        RadioButton ButtonDN { get; set; }
        RadioButton ButtonRAIFF { get; set; }
        TextView TxtInfo { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            InitUI();
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
                TxtInfo.Text = ButtonDN.Checked ? msgBuilder.GetMsgArriveToDN() : msgBuilder.GetMsgArriveToRAIFF();
            }
        }
    }
}

