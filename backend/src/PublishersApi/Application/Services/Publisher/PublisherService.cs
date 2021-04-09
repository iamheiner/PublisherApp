using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Services.Publisher.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Publisher
{
    public interface IPublisherService
    {
        Task<PublisherDto> Get(string id);
        Task<List<PublisherDto>> GetAll();
    }

    public class PublisherService : IPublisherService
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public PublisherService(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        async Task<PublisherDto> IPublisherService.Get(string id) {
           var item = await this.dbContext.Publishers
                                           .Where(m => m.pub_id == id)
                                           .ProjectTo<PublisherDto>(this.mapper.ConfigurationProvider)
                                           .FirstOrDefaultAsync();

           if (item == null)
           {
                throw new NotFoundException(nameof(Publishers), id);
           }

           return item;
        }          
          
        Task<List<PublisherDto>> IPublisherService.GetAll() => this.dbContext.Publishers 
                                                                             .ProjectTo<PublisherDto>(this.mapper.ConfigurationProvider)            
                                                                             .OrderBy(m => m.Country)
                                                                             .ThenBy(m => m.City)
                                                                             .ToListAsync();
    }
}
