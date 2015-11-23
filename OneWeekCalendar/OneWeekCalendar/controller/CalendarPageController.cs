using System;
using Xamarin.Forms;
using OneWeekCalendar.rest;
using OneWeekCalendar.views;
using System.Diagnostics;
using System.Threading.Tasks;
using OneWeekCalendar.model;
using System.Collections.Generic;

namespace OneWeekCalendar.controller
{
	public class CalendarPageController
	{
		public void ClearAllEventsFromUI(Grid grid)
		{
			foreach (var child in grid.Children) {
				if (child is CalendarDayView) {
					var cdv = child as CalendarDayView;
					cdv.CalendarDayViewModel.Events.Clear ();
				}
			}
		}


		public void UpdateWithWeekDays (Grid grid)
		{
			DateTime now = DateTime.Now.ToLocalTime ();
			DayOfWeek currentDay = now.DayOfWeek;
			int startDate = now.Day - (int)currentDay;

			int counter = 0;
			foreach (var child in grid.Children) {
				if (child is CalendarDayView) {
					
					var cdv = child as CalendarDayView;                    
					cdv.CalendarDayViewModel.Date = new DateTime (now.Year, now.Month, startDate + counter);
					cdv.CalendarDayViewModel.BackgroundColor = counter == (int)currentDay ? Color.Blue : Color.Red;

					counter++;
				}
			}
		}

		public async void UpdateWithEvents (Grid grid)
		{
			var calendars = await RestClient.GetCalendars ();

			var Calendar = calendars.Find (c => c.Name.Equals ("tttt", StringComparison.CurrentCultureIgnoreCase));
			updatePriority (Calendar.Events);
			foreach (var calEvent in Calendar.Events) {
				if (IsInSameWeek (calEvent.StartTime)) {
					foreach (var child in grid.Children) {
						if (child is CalendarDayView) {
							var cdv = child as CalendarDayView;
							if (cdv.CalendarDayViewModel.Date.Day == calEvent.StartTime.Day) {
								cdv.CalendarDayViewModel.Events.Add (calEvent);
							}
						}
					}
				}
			}
		}

		public void updatePriority(IList<Event> events){
			foreach (Event calEvent in events)
			{
				if (("HIGH").Equals(calEvent.Priority))
				{
					calEvent.Priority = "5";
				}
				else
				{
					calEvent.Priority = "2";
				}
			}
		}
		private bool IsInSameWeek (DateTime dt)
		{
			DateTime now = DateTime.Now;
			DayOfWeek currentDay = now.DayOfWeek;
			int startDate = now.Day - (int)currentDay;

			return now.Year == dt.Year && now.Month == dt.Month && dt.Day >= startDate && dt.Day <= startDate + 7;
		}
	}
}
