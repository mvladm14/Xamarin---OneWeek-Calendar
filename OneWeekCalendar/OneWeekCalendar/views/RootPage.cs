using System;
using Xamarin.Forms;
using OneWeekCalendar.model;
using OneWeekCalendar.factory;
using System.Threading.Tasks;

namespace OneWeekCalendar.views
{
	public class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			var menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

			Master = menuPage;

			Detail = new NavigationPage (new CalendarPage ()); 
		}

		public async void NavigateTo (MenuItem menu)
		{
			if (menu.TargetType == typeof(SynchronizePage)) {
				var command = new CommandFactory ().Create (CommandFactory.Synchronize);
				command.Execute ();

				await Task.Delay(2000);

				var calendarPage = (Detail as NavigationPage).CurrentPage as CalendarPage;
				calendarPage.ClearAllEventsFromUI ();
				calendarPage.UpdateWithEvents ();
				IsPresented = false;
			} 
		}

		public void NavigateTo (MenuItem menu, Event editEvent)
		{
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType, editEvent);

			Detail = new NavigationPage (displayPage);

			IsPresented = false;
		}
	}
}

