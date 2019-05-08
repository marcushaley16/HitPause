using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class DiscussionListItem
    {
        //public int DiscussionId { get; set; }
        public string Title { get; set; }
        [Display(Name="Created")]
        public DateTime TimeCreated { get; set; }
        [Display(Name="Type")]
        public MediaType MediaType { get; set; }
    }
}
