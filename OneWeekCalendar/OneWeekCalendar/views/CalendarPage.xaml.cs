using OneWeekCalendar.controller;
using Xamarin.Forms;
using System.Diagnostics;

namespace OneWeekCalendar.views
{
    public partial class CalendarPage : ContentPage
    {
        private readonly CalendarPageController _controller;

        public CalendarPage()
        {
            InitializeComponent();
            _controller = new CalendarPageController();
            UpdateWithWeekDays();
            UpdateWithEvents();
        }

        private void UpdateWithWeekDays()
        {
			Debug.WriteLine ("UpdateWithWeekDays");
			_controller.UpdateWithWeekDays(Grid);
		}

		public void UpdateWithEvents()
		{
			Debug.WriteLine ("UpdateWithEvents");
			_controller.UpdateWithEvents(Grid);
		}

		public void ClearAllEventsFromUI()
		{
			_controller.ClearAllEventsFromUI (Grid);
		}
    }
}
