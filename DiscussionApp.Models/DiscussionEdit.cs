using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class DiscussionEdit
    {
        public Guid DiscussionId { get; set; }
        public MediaType MediaType { get; set; }
        public int FilmId { get; set; }
        public string DiscussionTitle { get; set; }
        //public string Comment { get; set; }
        public virtual Film Film { get; set; }
        //public virtual TVShow TVShow { get; set; }
        //public virtual Sport Sport { get; set; }
    }
}
