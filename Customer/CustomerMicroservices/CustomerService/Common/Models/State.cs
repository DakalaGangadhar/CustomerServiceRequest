using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class State
    {
        [Key]
        public int? stateId { get; set; }
        [Required]
        [MaxLength(50)]
        public string statename { get; set; }
        public int? cId { get; set; }
    }
}
