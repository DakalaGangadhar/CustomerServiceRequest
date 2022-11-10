using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Country
    {
        [Key]
        public int cId { get; set; }
        [Required]
        [MaxLength(50)]
        public string countryname { get; set; }
    }
}
