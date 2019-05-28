using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class PostListItem
    {
        public Guid PostId { get; set; } // Should be hidden
        public Guid DiscussionId { get; set; }
        public string Body { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyy} at {0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUTC { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyy} at {0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedUTC { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorUsername { get; set; }
        public override string ToString() => Body;
    }
}
