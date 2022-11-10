using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DataModels
{
    public class ServiceRequestAssignDto
    {
        public int assignId { get; set; }
        public string assignname { get; set; }
        public int srcId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
