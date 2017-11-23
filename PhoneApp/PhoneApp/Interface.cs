using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin;
using Xamarin.Forms;

namespace PhoneApp
{
    public interface ICallHandler
    {
         event EventHandler CallEvent;
         string CallInfo { get; set; }
    }
       
}
