using BlazorFullCalendar.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AfterdawnLoot
{
    public class CalendarPageBase : ComponentBase
    {

        public static List<CalendarDateItem> GetRandomEvents(int count, int maxHours = 480, int maxEventDuration = 10, bool allday = false, string label = "Event")
        {
            var r = new Random();
            var eventList = new List<CalendarDateItem>();
            for (int i = 0; i < count; i++)
            {
                var randomStart = DateTime.Now.Subtract(new TimeSpan(r.Next(-maxHours, maxHours), r.Next(-60, 60), r.Next(-60, 60)));
                var randomEnd = randomStart.Add(new TimeSpan(r.Next(0, maxEventDuration), r.Next(15, 60), r.Next(0, 60)));
                eventList.Add(new CalendarDateItem()
                {
                    start = randomStart,
                    end = randomEnd,
                    title = $"Some {label} {r.Next(123, 12345)}",
                    backgroundColor = $"rgb({r.Next(256)},{r.Next(256)},{r.Next(256)})",
                    allDay = allday
                });
            }

            return eventList;
        }
    }
}