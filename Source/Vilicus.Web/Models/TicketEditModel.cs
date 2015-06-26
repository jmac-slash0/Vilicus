using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vilicus.Dal.Models;

namespace Vilicus.Web.Models
{
    public class TicketEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Urgency")]
        public Urgency UrgencyId { get; set; }
    }
}
