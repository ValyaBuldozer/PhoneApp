using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomingCallPAge : ContentPage
    {
        ICallHandler callReciever = DependencyService.Get<ICallHandler>();

        public IncomingCallPAge()
        {
            DependencyService.Get<ICallHandler>().CallEvent += CallEventHandler;
            InitializeComponent();

        }

        private void CallEventHandler (object sender,EventArgs e)
        {
            telephone_Label.BackgroundColor = Color.Red;
            telephone_Label.Text = DependencyService.Get<ICallHandler>().CallInfo;
        }

        private void but_test_Clicked(object sender, EventArgs e)
        {
            telephone_Label.Text = DependencyService.Get<ICallHandler>().CallInfo;
        }
    }
}