using System;
using System.Threading.Tasks;
using OneWeekCalendar.command;
using OneWeekCalendar.factory;
using OneWeekCalendar.model;
using Xamarin.Forms;

namespace OneWeekCalendar.views
{
	public partial class AddEventPage : ContentPage
	{
		public AddEventPage ()
		{
			InitializeComponent ();
		}

		private void OnAddEventButtonClicked (object sender, EventArgs e)
		{
			var newEvent = new Event {
				Name = Name.Text,
				Description = Description.Text,
				StartTime = StartDate.Date + StartTime.Time,
				EndTime = EndDate.Date + EndTime.Time,
				Location = Location.Text,
				Priority = Priority.Value > 2.5 ? "HIGH" : "LOW"
			};
					
			var command = new CommandFactory ().Create (CommandFactory.AddEvent);
			if (command is CreateEventCommand) {
				(command as CreateEventCommand).CalEvent = newEvent;
				command.Execute ();
			}
		}
	}
}
