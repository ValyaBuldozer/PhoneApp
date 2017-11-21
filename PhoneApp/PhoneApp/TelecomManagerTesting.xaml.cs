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
    public partial class TelecomManagerTesting : ContentPage
    {
        Button button;
        public TelecomManagerTesting()
        {
            button = new Button()
            {
                Text = "call",
                BackgroundColor = Color.Red
            };

            
            while (true)
            {
                
            }
        }
    }
}