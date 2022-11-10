using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DataModels
{
    public class UpdateRequestDataModel
    {
        public int SrId { get; set; }
        public string Categoty { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
