using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student:EntityBase
    {
        [Required]
        public int s_id { get; set; }
        [Required]
        public string s_name { get; set; }
        [Required]
        public string s_surname { get; set; }
        [Required]
        public string deparment { get; set; }
        [Required]
        public string advisor { get; set; }
    }
}