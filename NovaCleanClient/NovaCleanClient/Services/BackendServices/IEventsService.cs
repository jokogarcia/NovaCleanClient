using NovaCleanClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaCleanClient.Services.BackendServices
{
    public interface IEventsService
    {
        Task<List<DaysEventResult>> GetDaysEvents(DateTime day);
        Task<List<List<DaysEventResult>>> GetMonthEvents(DateTime month);
    }
    public class DaysEventResult
    {
        public string locationName { get; set; }
        public List<VisitEvent> eventList { get; set; }

    }
}
