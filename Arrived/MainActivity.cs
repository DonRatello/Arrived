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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            //ButtonSend = FindViewById<ImageButton>(Resource.Id.btnSend);
            //ButtonSend.Click += delegate { ButtonClicked(); }; 
        }

        protected void ButtonClicked()
        {
           
        }
    }
}

