using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vilicus.Web.Models
{
    public class MessageViewModel : MessageEditModel
    {
        public DateTime MessageTime { get; set; }
        public string UserDisplayName { get; set; }
    }
}
