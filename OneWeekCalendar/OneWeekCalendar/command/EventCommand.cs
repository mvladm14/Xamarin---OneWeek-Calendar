using Xamarin.Forms;
using System.Threading.Tasks;

namespace OneWeekCalendar.command
{
    public abstract class EventCommand : ICommand
    {
		public abstract void Execute();
    }
}
