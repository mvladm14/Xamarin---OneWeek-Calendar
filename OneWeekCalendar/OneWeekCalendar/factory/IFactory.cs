namespace OneWeekCalendar.factory
{
    public interface IFactory<out T>
    {
        T Create(string action);
    }
}
