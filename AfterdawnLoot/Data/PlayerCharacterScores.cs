using AfterdawnLoot;
using System;
using System.Collections.Generic;

public class PlayerCharacterScores : PlayerCharacters
{
    public decimal Score;
    public decimal TotalAttendance;
    public decimal WeeklyAttendance;
    public decimal TotalGiven;
    public decimal TotalReceived;
    public List<Tuple<DateTime, string>> LootGiven;
    public List<Tuple<DateTime, string>> LootReceived;
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
}