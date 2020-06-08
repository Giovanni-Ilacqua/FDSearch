using System;
using System.Collections.Generic;
using System.Linq;
using FDSearch.Models;
using FDSearch.ViewModels;

using Xamarin.Forms;

namespace FDSearch.Views
{
    public partial class DeptListPage : ContentPage
    {
        public DeptListPage()
        {
            InitializeComponent();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as FireDept;
            await Navigation.PushAsync(
                new DeptListPageDetail(details));
                
        }


        private void Handle_TextChanged (Object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as DeptListPageViewModel;
            DeptListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                DeptListView.ItemsSource = _container.FireDeptList;
            else
                DeptListView.ItemsSource = _container.FireDeptList
                    .Where(i => i.DeptName.ToLower().Contains(e.NewTextValue.ToLower())
                                || i.FdId.Contains(e.NewTextValue)
                                || i.County.Contains(e.NewTextValue.ToUpper())
                                || i.Address.City.ToLower().Contains(e.NewTextValue.ToLower())
                                || i.Address.State.ToLower().Contains(e.NewTextValue.ToLower())
                           );
            DeptListView.EndRefresh();
        }

    }
}
