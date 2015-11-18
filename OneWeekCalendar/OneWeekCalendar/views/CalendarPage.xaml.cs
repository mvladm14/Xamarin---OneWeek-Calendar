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
            UpdateWithWeekDays(Grid);
            UpdateWithEvents(Grid);
        }

        private void UpdateWithWeekDays(Grid grid)
        {
			Debug.WriteLine ("UpdateWithWeekDays");
            _controller.UpdateWithWeekDays(grid);
		}

		private void UpdateWithEvents(Grid grid)
		{
			Debug.WriteLine ("UpdateWithEvents");
			_controller.UpdateWithEvents(grid);
		}
    }
}
