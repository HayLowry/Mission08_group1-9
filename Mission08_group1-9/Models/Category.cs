﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_group1_9.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
