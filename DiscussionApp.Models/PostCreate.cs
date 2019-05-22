using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(5, ErrorMessage = "Posts must be at least 5 characters long.")]
        public string Body { get; set; }
        [Required]
        public Guid DiscussionId { get; set; }
        public override string ToString() => Body;
    }
}
