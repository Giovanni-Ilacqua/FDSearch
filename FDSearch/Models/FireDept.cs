using System;
namespace FDSearch.Models
{
    public class FireDept
    {
        public string FdId { get; set; }
        public string DeptName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string County { get; set; }
        public string DeptType { get; set; }
        public string Website { get; set; }


        public FireDept()
        {
        }

        public FireDept(string fdId, string deptName, Address address, string phone,
            string county, string deptType, string website)
        {
            FdId = fdId;
            DeptName = deptName;
            Address = address;
            Phone = phone;
            County = county;
            DeptType = deptType;
            Website = website;
        }


    }

    
}
