using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meetapp.Core;
using Meetapp.Core.Entities;
using Meetapp.Core.Responses;
using Meetapp.Services.Interfaces;

namespace Meetapp.Services.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _dbContext;

        public EventService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Response> IEventService.CreateEvent(DateTime startDate, DateTime endDate, DateTime saleExpDate, int cost, string title, string location, string category, bool reqConfirm)
        {
            Response eventResponse = new Response();
            eventResponse.Errors = new List<string>();
            Event newEvent = new Event();
            newEvent.Title = title;
            newEvent.StartDate = startDate;
            newEvent.EndDate = endDate;
            newEvent.SaleExpDate = saleExpDate;
            newEvent.Location = location;
            newEvent.Category = category;
            newEvent.ReqConfirm = reqConfirm;

            await _dbContext.Events.AddAsync(@newEvent);
            await _dbContext.SaveChangesAsync();

            eventResponse.Succes = true;
            return eventResponse;
        }

        async Task<Response> IEventService.DeleteEvent(int id)
        {
            Response eventResponse = new Response();
            Event eventFromDB;
            eventFromDB = await _dbContext.Events.FindAsync(id);

            if (eventFromDB == null)
            {
                eventResponse.Errors = new List<string>();
                eventResponse.Errors.ToList().Add("There is no event with this id");
                eventResponse.Succes = false;

                return eventResponse;
            }
            else
            {
                _dbContext.Events.Remove(eventFromDB);
                await _dbContext.SaveChangesAsync();
                eventResponse.Succes = true;
                return eventResponse;
            }

        }

        async Task<Response> IEventService.GetEvent(int id)
        {
            EventResponse eventResponse = new EventResponse();
            Event eventFromDB;
            eventFromDB = await _dbContext.Events.FindAsync(id);

            if (eventFromDB == null)
            {
                eventResponse.Errors = new List<string>();
                eventResponse.Errors.ToList().Add("There is no event with this id");
                eventResponse.Succes = false;

                return eventResponse;
            }
            else
            {
                eventResponse = new EventResponse();
                eventResponse.Succes = true;
                eventResponse.eventPayload = eventFromDB;
                return eventResponse;
            }

        }

        async Task<Response> IEventService.UpdateEvent(int id, DateTime startDate, DateTime endDate, DateTime saleExpDate, int cost, string title, string location, string category, bool reqConfirm)
        {
            EventResponse eventResponse = new EventResponse();
            Event eventFromDB;
            eventFromDB = await _dbContext.Events.FindAsync(id);


            if (eventFromDB == null)
            {
                eventResponse.Errors = new List<string>();
                eventResponse.Errors.ToList().Add("There is no event with this id");
                eventResponse.Succes = false;

                return eventResponse;
            }
            else
            {
                eventFromDB.Title = title;
                eventFromDB.StartDate = startDate;
                eventFromDB.EndDate = endDate;
                eventFromDB.SaleExpDate = saleExpDate;
                eventFromDB.Location = location;
                eventFromDB.Category = category;
                eventFromDB.ReqConfirm = reqConfirm;
                eventResponse = new EventResponse();
                _dbContext.Events.Update(eventFromDB);
                await _dbContext.SaveChangesAsync();
                eventResponse.Succes = true;
                eventResponse.eventPayload = eventFromDB;
                return eventResponse;
            }
        }
    }
}
