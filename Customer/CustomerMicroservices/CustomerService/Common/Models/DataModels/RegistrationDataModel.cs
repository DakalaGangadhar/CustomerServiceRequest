using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DataModels
{
    public class RegistrationDataModel
    {
        public int registrationId { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerPanCard { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerDOB { get; set; }
        public string CustomerState { get; set; }
    }
}
