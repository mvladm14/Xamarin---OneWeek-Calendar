using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OneWeekCalendar.model;
using Newtonsoft.Json.Serialization;

namespace OneWeekCalendar.rest
{
    public class RestClient
    {
        private static readonly string url = "http://10.0.2.2:1337/api/v1/calendars/";

        public static async Task<List<Calendar>> GetCalendars()
        {
            var items = new List<Calendar>();

            var uri = new Uri(url);

            var response = await new HttpClient().GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<Calendar>>(content);
            }
            return items;
        }

        public static async Task<Calendar> GetCalendar(string calendarId)
        {
            var uri = new Uri(url + calendarId);

            var response = await new HttpClient().GetAsync(uri);

            Calendar calendar = null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                calendar = JsonConvert.DeserializeObject<Calendar>(content);
            }
            return calendar;
        }

        public static async Task<Event> PostEvent(Event calEvent, Calendar calendar)
        {
            var uri = new Uri(url + calendar._id + "/events/");
            var json = JsonConvert.SerializeObject(calEvent, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Event responeEvent = null;

            var response = await new HttpClient().PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                var reponseContent = await response.Content.ReadAsStringAsync();
                responeEvent = JsonConvert.DeserializeObject<Event>(reponseContent);
            }

            return responeEvent;
        }
    }
}
