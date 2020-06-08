using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FDSearch.Models;
using FDSearch.Views;
using Xamarin.Forms;
using Xamarin.Essentials;
using FDSearch.Services;

namespace FDSearch.ViewModels
{
    public class DeptListPageViewModel
    {


        //public FireDept _selectedFireDept { get; set; }
        //public FireDept SelectedFireDept
        //{
        //    get
        //    {
        //        return _selectedFireDept;
        //    }
        //    set
        //    {
        //        if (_selectedFireDept != value)
        //        {
        //            _selectedFireDept = value;
        //            OnItemSelected();
        //            _selectedFireDept = null;
        //        }
        //    }
        //}

        public ObservableCollection<FireDept> FireDeptList { get; set; }

        public DeptListPageViewModel()
        {
            FireDeptList = new ObservableCollection<FireDept>();
            
            ReadData();
        }

        //public void OnItemSelected()
        //{
        //    var details = SelectedFireDept;
        //    App.Current.MainPage.Navigation.PushAsync(
        //        new DeptListPageDetail(details.DeptName, details.FdId, details.Phone, details.County, details.Address));

        //}

        private async void ReadData()
        {
            using(var stream = await FileSystem.OpenAppPackageFileAsync("usfa-registry-ny.csv"))
            {
                using (CsvFileReader reader = new CsvFileReader(stream))
                {
                    CsvRow row = new CsvRow();
                    while (reader.ReadRow(row))
                    {
                        FireDept myFireDept = new FireDept();
                        Address myAddress = new Address();

                        myFireDept.FdId = row[0];
                        myFireDept.DeptName = row[1];
                        myAddress.Street = row[2];
                        myAddress.City = row[4];
                        myAddress.State = row[5];
                        myAddress.Zip = row[6];
                        myFireDept.Address = myAddress;
                        myFireDept.Phone = row[13];
                        myFireDept.County = row[15];
                        myFireDept.DeptType = row[16];
                        myFireDept.Website = row[18];

                        FireDeptList.Add(myFireDept);

                    }

                }


            }
            
        }
        

    }
}
