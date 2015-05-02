using System.ComponentModel.DataAnnotations;
using Vilicus.Dal.Models;

namespace Vilicus.Web.Models
{
    public class TicketEditViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Urgency UrgencyId { get; set; }
    }
}
