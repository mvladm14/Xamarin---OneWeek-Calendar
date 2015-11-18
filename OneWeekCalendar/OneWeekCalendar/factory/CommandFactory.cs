using OneWeekCalendar.views;
using OneWeekCalendar.command;

namespace OneWeekCalendar.factory
{
	public class CommandFactory : IFactory<ICommand>
	{
		public static readonly string ChooseAction = "Choose action:";
		public static readonly string Cancel = "Cancel:";
		public static readonly string Clear = "Clear all events";
		public static readonly string AddEvent = "Add event";

		public ICommand Create (string action)
		{
			ICommand command = null;
			switch (action) {
			case "Cancel":
				break;
			case "Clear all events":
				break;
			case "Add event":
				command = new CreateEventCommand ();
				break;
			}
			return command;
		}
	}
}
