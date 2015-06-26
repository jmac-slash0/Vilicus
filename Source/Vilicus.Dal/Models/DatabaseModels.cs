using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vilicus.Dal.Models
{

    public enum Status
    {
        Submitted = 1, // Database friendly id
        Retracted,
        Rejected,
        Accepted,
        [Description("In Work")]
        InWork,
        Resolved
    }

    public enum Urgency
    {
        Passive = 1,
        Low,
        Normal,
        High,
        Critical
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TicketTagMapping> TicketTagMapping { get; set; }
    }

    public class TicketTagMapping
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int TagId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Tag Tag { get; set; }
    }

    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime TicketTime { get; set; }
        [Required]
        public Urgency UrgencyId { get; set; }
        [Required]
        public Status StatusId { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<TicketTagMapping> TicketTagMapping { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime MessageTime { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }

        public virtual User User { get; set; }
        public virtual Ticket Ticket { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Client Employer { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Employees { get; set; }
    }
}
