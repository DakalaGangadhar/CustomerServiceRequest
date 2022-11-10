using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Registration
    {
        [Key]
        public int registrationId { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }
        [Required]
        [MaxLength(20)]
        public string password { get; set; }
        [Required]
        [MaxLength(20)]
        public string customername { get; set; }
        [Required]
        [MaxLength(50)]
        public string address { get; set; }
        [Required]
        [MaxLength(10)]
        public string pancard { get; set; }
        [Required]
        [MaxLength(15)]
        public string contactnumber { get; set; }
        public DateTime dob { get; set; }
        public int cId { get; set; }
        public int stateId { get; set; }        
        public int districtId { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
