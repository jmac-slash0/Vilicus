using System.ComponentModel.DataAnnotations;
using Vilicus.Dal.Models;

namespace Vilicus.Web.Models
{
    public class TicketCreateViewModel
    {
        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Urgency UrgencyId { get; set; }

    }
}
