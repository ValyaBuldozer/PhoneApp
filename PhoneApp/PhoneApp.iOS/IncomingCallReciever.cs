using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin;
using Xamarin.Forms;
using PhoneApp.iOS;

[assembly: Dependency(typeof(IncomingCallReceiver))]   
namespace PhoneApp.iOS
{
        public class IncomingCallReceiver :  ICallHandler
        {
           
            public event EventHandler CallEvent;

            public void CallEventRun()
            {
                EventHandler handler = CallEvent;
                handler(this, null);
            }

            public string CallInfo { get; set; }
        }
    
}