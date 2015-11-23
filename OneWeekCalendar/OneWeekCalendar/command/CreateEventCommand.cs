using System;
using OneWeekCalendar.controller;
using OneWeekCalendar.model;
using OneWeekCalendar.rest;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OneWeekCalendar.command
{
    public class CreateEventCommand : EventCommand
    {
        public Event CalEvent { get; set; }

		public override async Task<Event> Execute()
        {
			if (CalEvent == null)
				return null;

            var calendars = await RestClient.GetCalendars();
            var calendar = calendars.Find(c => c.Name.Equals("tttt", StringComparison.CurrentCultureIgnoreCase));
            Event calEvent = await RestClient.PostEvent(CalEvent, calendar);
			Debug.WriteLine ("Post sent successfully");
			Debug.WriteLine ("Received back " + calEvent.Name);
			return calEvent;
		}
    }
}
