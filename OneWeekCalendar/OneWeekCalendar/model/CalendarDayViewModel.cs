using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;
using OneWeekCalendar.model;

namespace OneWeekCalendar
{
	public class CalendarDayViewModel : INotifyPropertyChanged
	{
		private DateTime _date;
		private Color _backgroundColor;
		private List<Event> _events;

		public event PropertyChangedEventHandler PropertyChanged;

		public List<Event> Events 
		{ 
			get 
			{ 
				return _events;
			}
			set
			{
				_events = value;
				//OnPropertyChanged("Events");
			}
		}

		public DateTime Date 
		{ 
			get 
			{ 
				return _date;
			}
			set
			{
				_date = value;
				OnPropertyChanged("Date");
			}
		}

		public Color BackgroundColor 
		{ 
			get 
			{ 
				return _backgroundColor;
			}
			set
			{
				_backgroundColor = value;
				OnPropertyChanged("BackgroundColor");
			}
		}

		public CalendarDayViewModel()
		{
			_events = new List<Event> ();
		}

		protected virtual void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}

