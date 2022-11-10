using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class District
    {
        [Key]
        public int districtId { get; set; }
        [Required]
        [MaxLength(50)]
        public string districtname { get; set; }
        public int stateId { get; set; }
    }
}
