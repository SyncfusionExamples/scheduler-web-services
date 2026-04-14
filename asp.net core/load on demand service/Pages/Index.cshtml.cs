using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ej2_core_schedule_app.Models;

namespace ej2_core_schedule_app.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        AppointmentContext _context;
        public IndexModel(AppointmentContext Context)
        {
            _context = Context;
        }

        public void OnGet()
        {

        }

        public JsonResult OnPostLoadData([FromBody] Params param)
        {
            DateTime startDate = DateTime.Parse(param.StartDate);
            DateTime endDate = DateTime.Parse(param.EndDate);
            var data = _context.Appointments
                .Where(app => (app.StartTime >= startDate && app.StartTime <= endDate) || (app.RecurrenceRule != null && app.RecurrenceRule != ""))
                .ToList();
            return new JsonResult(data);
        }

        public JsonResult OnPostUpdateData([FromBody] EditParams param)
        {
            if (param.action == "insert" || (param.action == "batch" && param.added.Count > 0)) // this block of code will execute while inserting the appointments 
            {
                var value = (param.action == "insert") ? param.value : param.added[0];
                DateTime startTime = Convert.ToDateTime(value.StartTime);
                DateTime endTime = Convert.ToDateTime(value.EndTime);
                Appointment appointment = new Appointment()
                {
                    StartTime = startTime.ToLocalTime(),
                    EndTime = endTime.ToLocalTime(),
                    Subject = value.Subject,
                    IsAllDay = value.IsAllDay,
                    RecurrenceRule = value.RecurrenceRule,
                    RecurrenceID = value.RecurrenceID,
                    RecurrenceException = value.RecurrenceException,
                    Description = value.Description,
                    Location = value.Location
                };
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
            }
            if (param.action == "update" || (param.action == "batch" && param.changed.Count > 0)) // this block of code will execute while removing the appointment 
            {
                var value = (param.action == "update") ? param.value : param.changed[0];
                var filterData = _context.Appointments.Where(c => c.Id == Convert.ToInt32(value.Id));
                if (filterData.Count() > 0)
                {
                    DateTime startTime = Convert.ToDateTime(value.StartTime);
                    DateTime endTime = Convert.ToDateTime(value.EndTime);
                    Appointment appointment = _context.Appointments.Single(A => A.Id == Convert.ToInt32(value.Id));
                    appointment.StartTime = startTime.ToLocalTime();
                    appointment.EndTime = endTime.ToLocalTime();
                    appointment.Subject = value.Subject;
                    appointment.IsAllDay = value.IsAllDay;
                    appointment.RecurrenceRule = value.RecurrenceRule;
                    appointment.RecurrenceID = value.RecurrenceID;
                    appointment.RecurrenceException = value.RecurrenceException;
                    appointment.Description = value.Description;
                    appointment.Location = value.Location;
                }
                _context.SaveChanges();
            }
            if (param.action == "remove" || (param.action == "batch" && param.deleted.Count > 0)) // this block of code will execute while updating the appointment 
            {
                if (param.action == "remove")
                {
                    int key = Convert.ToInt32(param.key);
                    Appointment appointment = _context.Appointments.Where(c => c.Id == key).FirstOrDefault();
                    if (appointment != null) _context.Appointments.Remove(appointment);
                }
                else
                {
                    foreach (var apps in param.deleted)
                    {
                        Appointment appointment = _context.Appointments.Where(c => c.Id == apps.Id).FirstOrDefault();
                        if (apps != null) _context.Appointments.Remove(appointment);
                    }
                }
                _context.SaveChanges();
            }
            var data = _context.Appointments.ToList();
            return new JsonResult(data);
        }
    }
    public class Params
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class EditParams
    {
        public string key { get; set; }
        public string action { get; set; }
        public List<Appointment> added { get; set; }
        public List<Appointment> changed { get; set; }
        public List<Appointment> deleted { get; set; }
        public Appointment value { get; set; }
    }
}