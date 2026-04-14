using ej2_web_api_crud.Data;
using ej2_web_api_crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace ej2_web_api_crud.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsContext dbContext;
        public EventsController(EventsContext dbContext)
        {
            this.dbContext = dbContext;
            if (this.dbContext.Events.Count() == 0)
            {
                foreach (var b in DataSource.GetEvents())
                {
                    dbContext.Events.Add(b);
                }
                dbContext.SaveChanges();
            }
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get([FromQuery] Params @params)
        {
            var query = dbContext.Events.AsQueryable();

            if (@params is not null && (@params.StartDate.HasValue || @params.EndDate.HasValue))
            {

                DateTime start = @params.StartDate ?? DateTime.MinValue;
                DateTime end = @params.EndDate ?? DateTime.MaxValue;

                if (@params.StartDate.HasValue && @params.EndDate.HasValue &&
                    @params.StartDate.Value.Date == @params.EndDate.Value.Date)
                {
                    start = @params.StartDate.Value.Date;
                    end = start.AddDays(1).AddTicks(-1);
                }

                query = query.Where(e => e.EndTime >= start && e.StartTime <= end);
            }

            return Ok(query);
        }

        [HttpPost]
        public async Task Post([FromBody] Event events)
        {
            dbContext.Events.Add(events);
            await dbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Put([FromODataUri] int key, [FromBody] Event events)
        {
            var entity = await dbContext.Events.FindAsync(events.Id);
            if (entity != null)
            {
                dbContext.Entry(entity).CurrentValues.SetValues(events);
                await dbContext.SaveChangesAsync();
            }
        }

        [HttpPatch]
        public async Task Patch([FromODataUri] int key, [FromBody] Event events)
        {
            var entity = await dbContext.Events.FindAsync(key);
            if (entity != null)
            {
                dbContext.Entry(entity).CurrentValues.SetValues(events);
                await dbContext.SaveChangesAsync();
            }
        }
        [HttpDelete]
        public async Task Delete([FromODataUri] int key)
        {
            var app = dbContext.Events.Find(key);
            if (app != null)
            {
                dbContext.Events.Remove(app);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}