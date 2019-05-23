using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Contracts
{
    public interface IDiscussionCreate
    {
        Guid DiscussionId { get; set; }
        MediaType MediaType { get; set; }
        int FilmId { get; set; }
        int TelevisionId { get; set; }
        int SportId { get; set; }
        string DiscussionTitle { get; set; }
        string Body { get; set; }
    }
}
