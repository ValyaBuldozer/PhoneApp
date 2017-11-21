using Xamarin.Forms;
using System;

namespace PhoneApp
{
    public partial class PhonePage : ContentPage
    {
        Entry phoneNumberEntry;
        Button callButton;
        public PhonePage()
        {
            try
            {
                Title = "Телефон";
                phoneNumberEntry = new Entry { Placeholder = "Введите номер" };
                callButton = new Button { Text = "Call" };
                callButton.Clicked += async (o, e) =>
                {
                    await DependencyService.Get<IPhone>()?.Call(phoneNumberEntry.Text);
                    
                };

                Content = new StackLayout
                {
                    Children = { phoneNumberEntry, callButton }
                };
            }
            catch(Exception ex)
            {
                Label exceptionLabel = new Label { Text = ex.Message };
            }
        }
    }
}