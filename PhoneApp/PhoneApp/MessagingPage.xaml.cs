using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace PhoneApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingPage : ContentPage
    {
        public MessagingPage()
        {
            InitializeComponent();
        }

        private void MakeCall_Clicked(object sender, EventArgs e)
        {
            try
            { 
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+79051501020");
            }
            catch (Exception ex)
            {
                Label exceptionLabel = new Label { Text = ex.Message };
            }
        }
    }
}