using System;

namespace OneWeekCalendar.model
{
    
    public class Event
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Priority { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
