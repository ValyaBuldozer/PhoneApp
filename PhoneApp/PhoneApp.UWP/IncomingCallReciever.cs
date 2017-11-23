using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using PhoneApp.UWP;

[assembly: Dependency(typeof(IncomingCallReceiver))]
namespace PhoneApp.UWP
{
    public class IncomingCallReceiver : ICallHandler
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
