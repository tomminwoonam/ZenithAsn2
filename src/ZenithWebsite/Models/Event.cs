using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class Event
    {

        public int EventId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime DateTo { get; set; }

        [Display( Name = "Creator" )]
        public string EventMadeBy { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual Activity Activity { get; set; }

        public int ActivityId { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }

    }
}
