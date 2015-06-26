using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vilicus.Web.Models
{
    public class MessageEditModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
    }
}
