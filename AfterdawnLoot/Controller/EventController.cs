using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorFullCalendar.Data;

namespace AfterdawnLoot
{
    [Route("api/Events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public EventController()
        {
        }

        [HttpGet]
        public List<CalendarDateItem> GetEventsDateRange()
        {
            return GetEvents().ToList();
        }

        [HttpGet("{amount}")]
        public List<CalendarDateItem> GetEventsDateRange(int amount)
        {
            return CalendarPageBase.GetRandomEvents(amount);
        }

        private static CalendarDateItem[] GetEvents()
        {
            var eventList = new CalendarDateItem[Globals.global_raids.Count() * 10];
            var player_chars = Globals.player_char.Where(p => p.UserID == Globals.UserID);


            int i = 0;
            foreach (var raid in Globals.global_raids)
            {
                DateTime raidtime = Convert.ToDateTime(raid.TimeStamp);
                //check attendance
                bool isStart = false;
                bool isEnd = false;
                foreach (var p in player_chars)
                {
                    var att = Globals.global_attendance.Where(r => r.RaidID == raid.ID && r.CharacterName == p.Name);
                    if (att.Count() > 0)
                    {
                        if (att.First().PresentStart == 1) isStart = true;
                        if (att.First().PresentEnd == 1) isEnd = true;
                    }
                }

                var cditem = new CalendarDateItem();
                cditem.allDay = true;
                cditem.startTime = raidtime;
                cditem.endTime = raidtime + new TimeSpan(0, 0, 1);
                cditem.start = cditem.startTime;
                cditem.end = cditem.endTime;
                cditem.title = raid.RaidName;
                if (isEnd && isStart)
                    cditem.backgroundColor = "#77a441";
                else if (isStart || isEnd)
                    cditem.backgroundColor = "#FFA500";
                else
                    cditem.backgroundColor = "#c3666f";
                cditem.textColor = "#000000";
                cditem.rendering = "background";
                cditem.url = "./ManageLoot/" + raid.ID.ToString();
                eventList[i] = (cditem);
                i++;

                var cditem2 = new CalendarDateItem();
                cditem2.allDay = true;
                cditem2.startTime = raidtime;
                cditem2.endTime = raidtime + new TimeSpan(0, 0, 1);
                cditem2.start = cditem.startTime;
                cditem2.end = cditem.endTime;
                cditem2.title = " " + raid.RaidName;
                cditem2.borderColor = "Orange";

                if (isEnd && isStart)
                    cditem2.backgroundColor = "#77a441";
                else if (isStart || isEnd)
                    cditem2.backgroundColor = "#FFA500";
                else
                    cditem2.backgroundColor = "#c3666f";
                cditem2.textColor = "#000000";
                cditem2.url = "./ManageLoot/" + raid.ID.ToString();

                eventList[i] = (cditem2);
                i++;

                //now get the loot
                List<string> given = new List<string> { };
                List<string> taken = new List<string> { };
                var cultureInfo = new System.Globalization.CultureInfo("en-GB");
                foreach (var chr in player_chars)
                {

                    var ploot = Globals.global_loot.Where(x => x.RaidID == raid.ID && x.SourceCharacter == chr.Name);
                    foreach (var loot in ploot)
                    {
                        string lresult = Globals.global_lootresults.Where(x => x.ID == loot.LootResult).Select(a => a.Description).FirstOrDefault().ToString();
                        if (!lresult.ToLower().Contains("personal"))
                        {
                            given.Add(ParseLootName(loot.Item));
                        }
                    }

                    ploot = Globals.global_loot.Where(x => x.RaidID == raid.ID && x.Character == chr.Name);

                    foreach (var loot in ploot)
                    {
                        string lresult = Globals.global_lootresults.Where(x => x.ID == loot.LootResult).Select(a => a.Description).FirstOrDefault().ToString();
                        if (!lresult.ToLower().Contains("disenchant")
                            && !lresult.ToLower().Contains("pass")
                            && !lresult.ToLower().Contains("awarded")
                            && !lresult.ToLower().Contains("off")
                            && !lresult.ToLower().Contains("transmog")
                            && !lresult.ToLower().Contains("personal"))
                        {
                            taken.Add(ParseLootName(loot.Item));

                        }
                    }
                }
                if (given.Count > 0)
                {
                    //add given items
                    var cditem3 = new CalendarDateItem();
                    cditem3.allDay = true;
                    cditem3.startTime = raidtime + new TimeSpan(0, 0, 1);
                    cditem3.endTime = raidtime + new TimeSpan(0, 0, 2);
                    cditem3.start = cditem3.startTime;
                    cditem3.end = cditem3.endTime;
                    cditem3.title = string.Join('\n', given);
                    cditem3.backgroundColor = "#77a441";
                    cditem3.rendering = "";

                    eventList[i] = (cditem3);
                    i++;
                }

                if (taken.Count > 0)
                {
                    //add received items
                    var cditem3 = new CalendarDateItem();
                    cditem3.allDay = true;
                    cditem3.startTime = raidtime + new TimeSpan(0, 0, 2);
                    cditem3.endTime = raidtime + new TimeSpan(0, 0, 3);
                    cditem3.start = cditem3.startTime;
                    cditem3.end = cditem3.endTime;
                    cditem3.title = string.Join('\n', taken);
                    cditem3.backgroundColor = "#c3666f";
                    cditem3.rendering = "";

                    eventList[i] = (cditem3);
                    i++;
                }
            }


            foreach (var chr in player_chars)
            {

                //look for point adjustments
                var adjusts = Globals.global_pointadjustments.Where(p => p.CharacterName == chr.Name).ToList();
                foreach (var adj in adjusts)
                {
                    var cditemadj = new CalendarDateItem();
                    cditemadj.allDay = true;
                    cditemadj.startTime = Convert.ToDateTime(adj.TimeStamp);
                    cditemadj.endTime = Convert.ToDateTime(adj.TimeStamp) + new TimeSpan(0, 0, 1);
                    cditemadj.start = cditemadj.startTime;
                    cditemadj.end = cditemadj.endTime;
                    cditemadj.title = adj.Adjustment + " - " + adj.Reason;
                    //cditemadj.borderColor = "Purple";

                    if (adj.Adjustment > 0)
                        cditemadj.title = "+" + cditemadj.title;

                    if (adj.Adjustment > 0)
                        cditemadj.backgroundColor = "#77a441";
                    else
                        cditemadj.backgroundColor = "#FFA500";
                    cditemadj.textColor = "#000000";

                    eventList[i] = (cditemadj);
                    i++;
                }
            }
            Array.Resize(ref eventList, i);
            Array.Reverse(eventList);
            return eventList;

        }


        private static string ParseLootName(string lootstring)
        {
            var elem = lootstring.Split('"');
            if (elem == null || elem.Length < 4) return "";
            var name = elem[3];

            return name;
        }
    }

}