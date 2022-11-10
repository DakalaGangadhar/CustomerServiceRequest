using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DataModels
{
    public class RegistrationDto
    {
        public int registrationId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string customername { get; set; }
        public string address { get; set; }
        public string pancard { get; set; }
        public string contactnumber { get; set; }
        public DateTime dob { get; set; }
        public int cId { get; set; }
        public int stateId { get; set; }
        public int districtId { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
