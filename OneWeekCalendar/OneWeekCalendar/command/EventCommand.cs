using Xamarin.Forms;
using System.Threading.Tasks;
using OneWeekCalendar.model;

namespace OneWeekCalendar.command
{
    public abstract class EventCommand : ICommand
    {
		public abstract Task<Event> Execute ();
    }
}
