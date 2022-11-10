using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DataModels
{
    public class ServiceRequestDto
    {
        public int srId { get; set; }
        public string description { get; set; }
        public int registrationId { get; set; }
        public int srcId { get; set; }
        public int assignId { get; set; }
        public int statusId { get; set; }
        public DateTime createrequestdate { get; set; }
    }
}
