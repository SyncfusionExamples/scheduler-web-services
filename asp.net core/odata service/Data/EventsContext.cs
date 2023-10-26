using ej2_web_api_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace ej2_web_api_crud.Data
{
    public class EventsContext: DbContext
    {
        public EventsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
