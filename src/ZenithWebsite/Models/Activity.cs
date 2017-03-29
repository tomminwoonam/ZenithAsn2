using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class Activity
    {

        public int ActivityId { get; set; }

        [Required]
        [Display(Name = "Activity Name")]
        public string ActivityDescription { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }

        public List<Event> Events { get; set; }

    }
}
