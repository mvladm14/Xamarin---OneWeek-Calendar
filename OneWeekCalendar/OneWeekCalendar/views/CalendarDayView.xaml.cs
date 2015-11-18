using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using System.Diagnostics;

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
			Debug.WriteLine("Edit Context Action clicked: " + mi.CommandParameter);
		}

		public async void OnDelete (object sender, EventArgs e) {
			var mi = ((Xamarin.Forms.MenuItem)sender);
			Debug.WriteLine("Delete Context Action clicked: " + mi.CommandParameter);
		}
	}
}

