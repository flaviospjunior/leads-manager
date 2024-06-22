using AutoMapper;
using Leads.Domain.Aggregates.Lead;

namespace Leads.Application.Features.Leads.Queries.GetAllLeads
{
    public class GetAllLeadsMapping : Profile
    {
        public GetAllLeadsMapping()
        {
            CreateMap<Lead, GetAllLeadsViewModel>()
                .ForMember(leadVm => leadVm.Id, dest => dest.MapFrom(lead => lead.Id))
                .ForMember(leadVm => leadVm.Status, dest => dest.MapFrom(lead => lead.Status))
                .ForMember(leadVm => leadVm.Description, dest => dest.MapFrom(lead => lead.Description))
                .ForMember(leadVm => leadVm.Price, dest => dest.MapFrom(lead => lead.Price))
                .ForMember(leadVm => leadVm.FinalPrice, dest => dest.MapFrom(lead => lead.FinalPrice))
                .ForMember(leadVm => leadVm.CreationDate, dest => dest.MapFrom(lead => lead.CreationDate))
                .ForMember(leadVm => leadVm.ContactName, dest => dest.MapFrom(lead => lead.Contact.Name))
                .ForMember(leadVm => leadVm.ContactEmail, dest => dest.MapFrom(lead => lead.Contact.Email))
                .ForMember(leadVm => leadVm.ContactPhoneNumber, dest => dest.MapFrom(lead => lead.Contact.PhoneNumber))
                .ForMember(leadVm => leadVm.Suburb, dest => dest.MapFrom(lead => string.Concat(lead.Suburb.Name, ' ', lead.Suburb.Number)))
                .ForMember(leadVm => leadVm.Category, dest => dest.MapFrom(lead => lead.Category.Name));
        }
    }
}
