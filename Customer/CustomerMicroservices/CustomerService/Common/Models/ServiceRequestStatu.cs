using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class ServiceRequestStatu
    {
       [Key]
       public int statusId { get; set; }
        [Required]
        [MaxLength(20)]
        public string statusname { get; set; }
    }
}
