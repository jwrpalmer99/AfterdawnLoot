using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AfterdawnLoot;


public class Globals
{
    public static bool updating = false;
    public static List<Raids> global_raids;
    public static List<CharacterLoot> global_loot;
    public static List<Attendance> global_attendance;
    public static List<PlayerCharacters> player_char;
    public static long UserID;
    public static List<LootResults> global_lootresults;
    public static List<PointsAdjustment> global_pointadjustments;
    public static List<PlayerCharacterScores> playerscores = new List<PlayerCharacterScores> { };
    public static List<string> classes = new List<string> { "DeathKnight", "DemonHunter", "Druid", "Hunter", "Mage", "Monk", "Paladin", "Priest", "Rogue", "Shaman", "Warlock", "Warrior" };

}
public class CounterIncreasedMessage
{
    public int _currentCount;

    public CounterIncreasedMessage(int cc)
    {
        _currentCount = cc;
    } 
}

public class UserState
{
    public event Action OnChange;
    public bool showAlts {get; set;}
    public bool show14Days {get; set;} = true;

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}

public class RefreshScores{ }