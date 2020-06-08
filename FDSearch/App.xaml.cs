using System;
using FDSearch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FDSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DeptListPage());
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
