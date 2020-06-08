using System;
using System.Collections.Generic;
using FDSearch.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FDSearch.Views
{
   
    public partial class DeptListPageDetail : ContentPage
    {
        Address DetailAddress = new Address();
        public DeptListPageDetail(FireDept fireDept)
        {
            InitializeComponent();

            DetailAddress = fireDept.Address;

            DeptNameShow.Text = fireDept.DeptName;
            FdIdShow.Text = fireDept.FdId;
            PhoneShow.Text = fireDept.Phone;
            CountyShow.Text = fireDept.County;
            AddressShow.Text = DetailAddress.Street + "\n" +
                               DetailAddress.City + "\n" +
                               DetailAddress.State + "\n" +
                               DetailAddress.Zip;
            DeptTypeShow.Text = fireDept.DeptType;
            if(fireDept.Website != "")
            {
                WebsiteShow.Text = fireDept.Website;
            }
            else
            {
                WebsiteShow.Text = "Not available";
            }
            

        }

        private async void Phone_Tapped(Object sender, EventArgs e)
        {
            string phoneNumber = PhoneShow.Text;

            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Unable to dial", "Phone dialing failed", "OK");
            }
        }



        public async void Website_Tapped(System.Object sender, System.EventArgs e)
        {
            if(WebsiteShow.Text != "Not available")
            {
                await Browser.OpenAsync(WebsiteShow.Text, BrowserLaunchMode.SystemPreferred);
            }
        }

        public async void Address_Tapped(System.Object sender, System.EventArgs e)
        {
            var placemark = new Placemark
            {
                CountryName = "United States",
                AdminArea = DetailAddress.State,
                Thoroughfare = DetailAddress.Street,
                Locality = DetailAddress.City
            };
            var options = new MapLaunchOptions { Name = DetailAddress.Street };

            try
            {
                await Map.OpenAsync(placemark, options);
            }
            catch (Exception)
            {
                await DisplayAlert("Unable to show address on map", "Address not found", "OK");
            }
        }


    }
}
