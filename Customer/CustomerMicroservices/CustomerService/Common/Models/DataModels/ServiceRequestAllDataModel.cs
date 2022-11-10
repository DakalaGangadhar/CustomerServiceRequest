using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DataModels
{
    public class ServiceRequestAllDataModel
    {
        public int srId { get; set; }
        public string cusromername { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string pancard { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string category { get; set; }
        public string assignto { get; set; }
        public string date { get; set; }
        
    }
}
