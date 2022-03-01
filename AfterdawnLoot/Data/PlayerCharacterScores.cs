using AfterdawnLoot;
using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerCharacterScores : PlayerCharacters
{
    public decimal Score;
    public decimal TotalAttendance;
    public decimal WeeklyAttendance;
    public decimal TotalGiven;
    public decimal TotalReceived;
    public string LastRaid {get
        {
            if (Attendance == null || Attendance.Count < 1) return "";
            DateTime lastdt = Attendance.OrderBy(i => i.Item1).ToList().Last().Item1;
            if (lastdt.Date == DateTime.Now.Date) return ("Today");
            if ((DateTime.Now - lastdt).Days < 7) return (lastdt.DayOfWeek.ToString());
            return ((DateTime.Now - lastdt).Days).ToString() + " days" ;
        }
    }
    public List<Tuple<DateTime, string>> LootGiven;
    public List<Tuple<DateTime, string>> LootReceived;
    public List<Tuple<DateTime, decimal>> Attendance;
    public List<PointsAdjustment> Adjustments;
    public PlayerCharacterScores(PlayerCharacters p)
    {
        this.Name = p.Name;
        this.Owner = p.Owner;
        this.Class = p.Class;
        this.IsMain = p.IsMain;
        this.IsInactive = p.IsInactive;
        this.IsSocial = p.IsSocial;
        this.UserID = p.UserID;
        this.Comment = p.Comment;
    }

    public double AdjustmentTotal
    {
        get { if (Adjustments == null) return 0; return Adjustments.Sum(a => a.Adjustment); }
    }

   
}

public class PlayerDateSorter : IComparer<PlayerCharacterScores>
{
     public int Compare(PlayerCharacterScores x, PlayerCharacterScores y)
    {
        if (x.Attendance.Count == 0 && y.Attendance.Count  == 0) return 0;
        if (x.Attendance.Count == 0) return 1;
        if (y.Attendance.Count == 0) return -1;
        DateTime lastx = x.Attendance.OrderBy(i => i.Item1).Last().Item1;
        DateTime lasty = y.Attendance.OrderBy(i => i.Item1).Last().Item1;
        if (lastx < lasty) return 1;
        if (lastx == lasty)
        {
            return x.Name.CompareTo(y.Name);
        }
        if (lastx > lasty) return -1;
        return 0;
    }
}