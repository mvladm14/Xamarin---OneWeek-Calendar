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

			menuPage.Menu.ItemSelected += async (sender, e) => 
			{
				if (menuPage.Menu.SelectedItem != null) {
					await NavigateTo (e.SelectedItem as MenuItem);
					menuPage.Menu.SelectedItem = null;
				}
			};

			Master = menuPage;

			Detail = new NavigationPage (new CalendarPage ()); 
		}

		public async Task<bool> NavigateTo (MenuItem menu)
		{
			if (menu.TargetType == typeof(SynchronizePage)) {
				var command = new CommandFactory ().Create (CommandFactory.Synchronize);
				command.Execute ();

				await Task.Delay (2000);

				var calendarPage = (Detail as NavigationPage).CurrentPage as CalendarPage;
				calendarPage.ClearAllEventsFromUI ();
				calendarPage.UpdateWithEvents ();
			} else {
				Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
				Detail = new NavigationPage (displayPage);
			}
			IsPresented = false;
			return true;
		}

		public void NavigateTo (MenuItem menu, Event editEvent)
		{
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType, editEvent);

			Detail = new NavigationPage (displayPage);

			IsPresented = false;
		}
	}
}

