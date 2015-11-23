using OneWeekCalendar.rest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using OneWeekCalendar.command;
using OneWeekCalendar.factory;

namespace OneWeekCalendar.views
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () {
				Title = "New event",
				IconSource = "plus.png",
				TargetType = typeof(AddEventPage)
			});

			this.Add (new MenuItem () {
				Title = "Synchronize",
				IconSource = "synchronize.png",
				TargetType = typeof(SynchronizePage)
			});
		}
	}
}



