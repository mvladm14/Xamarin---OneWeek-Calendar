using System.Collections.Generic;

namespace OneWeekCalendar.model
{
    public class Calendar
    {
        public string  _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Event> Events { get; set; }
    }
}
