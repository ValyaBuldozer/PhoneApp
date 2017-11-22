﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin;
using Android.Telephony;
using Xamarin.Forms;
using PhoneApp.Droid;
using PhoneApp;

[assembly: Dependency(typeof(IncomingCallReceiver))]
namespace PhoneApp.Droid
{
    [BroadcastReceiver()]
    [IntentFilter(new[] { "android.intent.action.PHONE_STATE" })]
    public class IncomingCallReceiver : BroadcastReceiver, ICallHandler
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //ensure there is information
            if (intent.Extras != null)
            {
                // get the incoming call state
                string state = intent.GetStringExtra(TelephonyManager.ExtraState);

                // check the current state
                if (state == TelephonyManager.ExtraStateRinging)
                {
                    // read the incoming call telephone number...
                    string telephone = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    // check the reade telephone
                    if (string.IsNullOrEmpty(telephone))
                        telephone = string.Empty;

                    CallInfo = telephone;
                    CallEventRun(new EventArgs());
                }
                else if (state == TelephonyManager.ExtraStateOffhook)
                {
                    // incoming call answer
                }
                else if (state == TelephonyManager.ExtraStateIdle)
                {
                    // incoming call end
                }
            }
        }

        public event EventHandler<EventArgs> CallEvent;

        public void CallEventRun(EventArgs e)
        {
            EventHandler<EventArgs> handler = CallEvent;
            handler(this, e);
        }

        public string CallInfo { get; set; }
    }
}
