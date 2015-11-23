using System;
using OneWeekCalendar.command;
using System.Threading.Tasks;
using OneWeekCalendar.rest;
using System.Diagnostics;
using OneWeekCalendar.model;

namespace OneWeekCalendar
{
	public class SynchronizeCommand : EventCommand
	{
		public override async Task<Event> Execute()
		{
			bool result = await RestClient.Synchronize ();
			Debug.WriteLine ("Synchcronize sent successfully");
			Debug.WriteLine ("Received back " + result);
			return null;
		}
	}
}

