using System;
using Xamarin.Forms;

namespace OneWeekCalendar.views
{
	public class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			var menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

			Master = menuPage;

            Detail = new NavigationPage (new CalendarPage()); 
        }

		public void NavigateTo (MenuItem menu)
		{
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = new NavigationPage (displayPage);

			IsPresented = false;
		}
	}
}

