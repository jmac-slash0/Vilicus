
using EfEnumToLookup.LookupGenerator;
using System;
using System.Collections.Generic;
using Vilicus.Dal.Models;

namespace Vilicus.Dal
{
    public class ContextInitializer : System.Data.Entity.DropCreateDatabaseAlways<TicketContext>
    {
        protected override void Seed(TicketContext context)
        {
            EnumToLookup enumToLookup = new EnumToLookup();
            enumToLookup.SplitWords = true; // InWork -> In Work
            //enumToLookup.NameFieldLength = 50; // optional, example of how to override default values

            // Turn enums in model into database lookup tables
            enumToLookup.Apply(context);


            var clients = new List<Client>
            {
                new Client { Name = "Client Company" }
            };
            clients.ForEach(o => context.Client.Add(o));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { Id = 1, FirstName = "John", LastName = "Blakeney" },
                new User { Id = 2, FirstName = "Mason", LastName = "Allen" }
            };
            users.ForEach(o => context.User.Add(o));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
                new Ticket {
                    Subject = "First Issue",
                    Description = "Here we go again.",
                    TicketTime = DateTime.Now,
                    UrgencyId = Urgency.Critical,
                    StatusId = Status.Submitted,
                    UserId = 1 }
            };
            tickets.ForEach(o => context.Ticket.Add(o));
            context.SaveChanges();
        }
    }
}
