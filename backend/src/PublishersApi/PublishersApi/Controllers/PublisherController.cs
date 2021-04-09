using Api.Models;
using Application.Common.Exceptions;
using Application.Services.Publisher;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService publisher;
        public PublisherController(IPublisherService publisher)
        {
            this.publisher = publisher;
        }


        public async Task<Result> Get(string id) 
        {
            try
            {
                var item = await this.publisher.Get(id);
                return new Result(true,item);
            }
            catch(NotFoundException)
            {
                return new Result(true, null);
            }
            catch (Exception ex)
            {
                return new Result(false, null,new List<string> {ex.Message});
            }
        }

        public async Task<Result> GetAll() {
            try
            {
                var item = await this.publisher.GetAll();
                return new Result(true, item);
            }
            catch (Exception ex)
            {
                return new Result(false, null, new List<string> { ex.Message });
            }
        } 
    }
}
