using System;
using OneWeekCalendar.command;
using System.Threading.Tasks;
using OneWeekCalendar.model;
using OneWeekCalendar.rest;
using System.Diagnostics;

namespace OneWeekCalendar
{
	public class EditEventCommand:EventCommand
	{
		public Event CalEvent { get; set; }

		public override async Task<Event> Execute ()
		{
			if (CalEvent == null)
				return null;

			Event modifiedEvent = await RestClient.ModifyEvent(CalEvent);
			Debug.WriteLine ("Put sent successfully");
			Debug.WriteLine ("Received back " + modifiedEvent.Name);
			return modifiedEvent;
		}
	}
}

