using NaControl.App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NaControl.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NaControlMaps();
            MainPage = new MasterPage();
            //MainPage = new NavigationPage(new MasterPage());
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout()
            //    {
            //        Children = { map }
            //    }
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
