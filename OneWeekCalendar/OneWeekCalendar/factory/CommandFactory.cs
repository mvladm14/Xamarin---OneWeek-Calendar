using OneWeekCalendar.views;
using OneWeekCalendar.command;

namespace OneWeekCalendar.factory
{
	public class CommandFactory : IFactory<ICommand>
	{
		public const string Delete = "Delete";
		public const string AddEvent = "Add event";
		public const string EditEvent = "Edit event";
		public const string Synchronize="Synchcronize";

		public ICommand Create (string action)
		{
			ICommand command = null;
			switch (action) {
			case Delete:
				command = new DeleteEventCommand ();
				break;
			case AddEvent:
				command = new CreateEventCommand ();
				break;
			case EditEvent:
				command = new EditEventCommand ();
				break;
			case Synchronize:
				command = new SynchronizeCommand ();
				break;
			}
			return command;
		}
	}
}
