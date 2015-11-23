using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using System.Diagnostics;
using OneWeekCalendar.model;
using OneWeekCalendar.factory;

namespace OneWeekCalendar.views
{
	public partial class CalendarDayView : ContentView, INotifyPropertyChanged
	{
		public CalendarDayViewModel CalendarDayViewModel { get; private set; }

		public CalendarDayView ()
		{
			InitializeComponent ();

			CalendarDayViewModel = new CalendarDayViewModel ();
			BindingContext = CalendarDayViewModel;
			DayListView.ItemsSource = CalendarDayViewModel.Events;
		}

		public async void OnEdit (object sender, EventArgs e) {
			var mi = ((Xamarin.Forms.MenuItem)sender);
			var calEvent = mi.CommandParameter as Event;
			this.Navigation.PushAsync (new EditEventPage (calEvent));
		}

		public async void OnDelete (object sender, EventArgs e) {
			var mi = ((Xamarin.Forms.MenuItem)sender);
			var calEvent = mi.CommandParameter as Event;

			var command = new CommandFactory ().Create (CommandFactory.Delete);
			if (command is DeleteEventCommand) {
				(command as DeleteEventCommand).CalEvent = calEvent;
				var deletedEvent = await command.Execute ();
				CalendarDayViewModel.Events.Remove (calEvent);
			}
		}
	}
}

