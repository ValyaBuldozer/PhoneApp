using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomingCallPAge : ContentPage
    {
        public IncomingCallPAge()
        {
            InitializeComponent();

            var callReciever = DependencyService.Get<ICallHandler>();

            callReciever.CallEvent += (s, e) => {
                telephone_Label.BackgroundColor = Color.Red;
                telephone_Label.Text = callReciever.CallInfo;
            };

        }
    }
}