using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test007.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test007.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageView : ContentPage
    {
        public MessageView()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel ModelData = new ViewModel(); 
           

        }
        
    }
}