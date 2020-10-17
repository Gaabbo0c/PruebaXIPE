using System;
using Test007.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test007
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MessageView();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
