using System.Threading.Tasks;
using OneWeekCalendar.model;

namespace OneWeekCalendar.command
{
    public interface ICommand
    {
		Task<Event> Execute();
    }
}
