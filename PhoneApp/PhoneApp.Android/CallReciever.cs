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
                    CallEvent = (s, e) => { };
                    CallEvent(this, new EventArgs());
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

        public event EventHandler CallEvent;

        public void CallEventRun()
        {
            EventHandler handler = CallEvent;
            handler(this,null);
        }

        public string CallInfo { get; set; }
    }
}
