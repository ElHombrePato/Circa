using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.Models
{
    public class EventList
    {
        private const int TAM_MAX_GENERICO = 20;

        private int maxSize = TAM_MAX_GENERICO;
        private List<CalendarEvent> events = new List<CalendarEvent>();

        public EventList(List<CalendarEvent> events)
        {
            Events = events;
        }

       


        public int MaxSize { get => maxSize; set => maxSize = value; }
        public List<CalendarEvent> Events { get => events; set => events = value; }


    }
}
