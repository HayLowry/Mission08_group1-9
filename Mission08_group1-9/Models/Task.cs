using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_group1_9.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string TaskTitle { get; set; }
        public string DueDate { get; set; }
        [Required]
        public bool Urgent { get; set; }
        [Required]
        public bool Important { get; set; }
        public bool Completed { get; set; }

        // Build foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
