using System;
using OneWeekCalendar.command;
using OneWeekCalendar.model;
using System.Threading.Tasks;
using OneWeekCalendar.rest;

namespace OneWeekCalendar
{
	public class DeleteEventCommand : EventCommand
	{
		public Event CalEvent { get; set; }

		public override async Task<Event> Execute()
		{
			if (CalEvent == null)
				return null;
			
			Event calEvent = await RestClient.DeleteEvent(CalEvent);
			return calEvent;
		}
	}
}

