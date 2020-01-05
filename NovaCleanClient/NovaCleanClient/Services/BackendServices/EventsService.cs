using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaCleanClient.Services.BackendServices
{
    class EventsService : BackendServicesBase,IEventsService
    {
        public async Task<List<DaysEventResult>> GetDaysEvents(DateTime day)
        {
            Int32 unixTimestamp = (Int32)(day.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var uri = new Uri(BASE_URL + $"client/days-events/{unixTimestamp}");
            var result = await GetJson<List<DaysEventResult>>(uri);
            return result;
        }

        public async Task<List<List<DaysEventResult>>> GetMonthEvents(DateTime month)
        {
            Int32 unixTimestamp = (Int32)(month.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var uri = new Uri(BASE_URL + $"client/months-events/{unixTimestamp}");
            var result = await GetJson<List<List<DaysEventResult>>>(uri);
            return result;
        }
    }
}
