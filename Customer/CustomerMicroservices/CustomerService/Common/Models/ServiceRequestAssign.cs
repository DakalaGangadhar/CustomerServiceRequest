using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class ServiceRequestAssign
    {
        [Key]
        public int assignId { get; set; }
        [Required]
        [MaxLength(20)]
        public string assignname { get; set; }
        public int srcId { get; set; }
        [Required]
        [MaxLength(20)]
        public string email { get; set; }
        [Required]
        [MaxLength(20)]
        public string password { get; set; }
    }
}
