using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.NetworkInformation;

namespace App2
{
    [Activity(Label = "Invia la tua posizione", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button EntrySendButton = FindViewById<Button>(Resource.Id.EntrySendButton);

            EntrySendButton.Click += delegate { EntrySendButton.Text = string.Format("{0} clicks!", count++); };

            // Get our button from the layout resource,
            // and attach an event to it
            Button ExitSendButton = FindViewById<Button>(Resource.Id.ExitSendButton);

            ExitSendButton.Click += delegate { ExitSendButton.Text = string.Format("{0} clicks!", count++); };

            // Get our button from the layout resource,
            // and attach an event to it
            Button InfoSendButton = FindViewById<Button>(Resource.Id.InfoSendButton);

            InfoSendButton.Click += delegate { InfoSendButton.Text = string.Format("{0} clicks!", count++); };


            TextView textview1 = FindViewById<TextView>(Resource.Id.textView1);
            textview1.Text = GetDeviceMacAddress();
        }

        private static string GetDeviceMacAddress()
        {
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    var address = netInterface.GetPhysicalAddress();
                    return BitConverter.ToString(address.GetAddressBytes());

                }
            }

            return "NoMac";
        }
    }
}

