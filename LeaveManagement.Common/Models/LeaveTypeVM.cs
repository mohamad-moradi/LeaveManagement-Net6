﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number Of Dayes")]
        [Required]
        [Range(1,25,ErrorMessage  = "Please Enter valid number")]
        public int DefaultDays { get; set; }
    }
}
