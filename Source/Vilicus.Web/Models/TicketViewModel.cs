using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vilicus.Dal.Models;

namespace Vilicus.Web.Models
{
    public class TicketViewModel : TicketEditModel
    {
        [DisplayName("User")]
        public string UserDisplayName { get; set; }

        [DisplayName("Ticket Time")]
        public DateTime TicketTime { get; set; }

        [DisplayName("Status")]
        public Status StatusId { get; set; }
    }
}
