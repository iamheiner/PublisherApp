using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Publisher.Models
{
    public class PublisherDto: IMapFrom<Publishers>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publishers, PublisherDto>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.pub_id))
                   .ForMember(d => d.Name, opt => opt.MapFrom(s => s.pub_name))
                   .ForMember(d => d.City, opt => opt.MapFrom(s => s.city))
                   .ForMember(d => d.State, opt => opt.MapFrom(s => s.state))
                   .ForMember(d => d.Country, opt => opt.MapFrom(s => s.country));
        }
    }
}
