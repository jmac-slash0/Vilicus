
using AutoMapper;
using System.Linq;
using Vilicus.Dal.Models;
using Vilicus.Web.Models;

namespace Vilicus.Web.AutoMapperProfiles
{
    /// <summary>
    /// AutoMapper profile for entities (general for now, but could be expanded)
    /// </summary>
    public class GeneralProfile : Profile
    {
        /// <summary>
        /// Configure maps
        /// </summary>
        protected override void Configure()
        {
            // Ticket -> TicketViewModel
            Mapper.CreateMap<Ticket, TicketViewModel>()
                .ForMember(destination => destination.UserDisplayName, opt => opt.MapFrom(source => source.User.FirstName + " " + source.User.LastName));

            // TicketEditModel -> Ticket
            Mapper.CreateMap<TicketEditModel, Ticket>().ReverseMap();
        }
    }
}
