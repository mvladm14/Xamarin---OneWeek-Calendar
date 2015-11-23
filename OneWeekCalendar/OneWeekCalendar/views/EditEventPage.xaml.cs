using System;
using System.Collections.Generic;

using Xamarin.Forms;
using OneWeekCalendar.model;
using OneWeekCalendar.factory;

namespace OneWeekCalendar.views
{
	public partial class EditEventPage : ContentPage
	{
		public Event _editEvent { get; private set; }

		public EditEventPage (Event editEvent)
		{
			InitializeComponent ();
			this._editEvent = editEvent;
			StartTime.Time = _editEvent.StartTime.TimeOfDay;
			EndTime.Time = _editEvent.EndTime.TimeOfDay;
			BindingContext = _editEvent;
		}

		private async void  OnEditEventButtonClicked (object sender, EventArgs e)
		{
			var command = new CommandFactory ().Create (CommandFactory.EditEvent);
			if (command is EditEventCommand) {
				_editEvent.StartTime =this.StartDate.Date + this.StartTime.Time;
				_editEvent.EndTime = this.EndDate.Date + this.EndTime.Time;
				(command as EditEventCommand).CalEvent =  _editEvent;
				await command.Execute ();
				App.RootPage.NavigateTo (new MenuItem { TargetType = typeof(CalendarPage) });
			}
		}

	}
}

