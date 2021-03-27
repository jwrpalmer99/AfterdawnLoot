//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using SQLite;
using System;

namespace AfterdawnLoot
{
    public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }

        public void Create()
        {
            //using (SQLiteConnection db = new SQLiteConnection(_path))
            //{
            //    db.CreateTable<__EFMigrationsHistory>();
            //    db.CreateTable<AspNetRoleClaims>();
            //    db.CreateTable<AspNetRoles>();
            //    db.CreateTable<AspNetUserClaims>();
            //    db.CreateTable<AspNetUserLogins>();
            //    db.CreateTable<AspNetUserRoles>();
            //    db.CreateTable<AspNetUsers>();
            //    db.CreateTable<AspNetUserTokens>();
            //    db.CreateTable<Attendance>();
            //    db.CreateTable<CharacterLoot>();
            //    db.CreateTable<Characters>();
            //    db.CreateTable<LootResults>();
            //    db.CreateTable<Players>();
            //    db.CreateTable<PointsAdjustment>();
            //    db.CreateTable<Raids>();
            //}
        }
    }
  
    public partial class Attendance
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ID { get; set; }

        [NotNull]
        public Int64 RaidID { get; set; }

        [NotNull]
        public String CharacterName { get; set; }

        public Int64? PresentStart { get; set; }

        public Int64? PresentEnd { get; set; }

    }

    public partial class CharacterLoot
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ID { get; set; }

        [NotNull]
        public string Character { get; set; }

        [NotNull]
        public String TimeStamp { get; set; }

        [NotNull]
        public string Item { get; set; }

        public Int64? LootResult { get; set; }

        public Int64 RaidID { get; set; }

        public String SourceCharacter { get; set; }
        public String Class { get; set; }

    }

    public partial class Characters
    {
        [PrimaryKey]
        public String Name { get; set; }

        [NotNull]
        public String Class { get; set; }

        [NotNull]
        public Int64 UserID { get; set; }

        [NotNull]
        public String Comment { get; set; }

        [NotNull]
        public Int64 IsMain { get; set; }

        [NotNull]
        public Int64 IsSocial { get; set; }

        [NotNull]
        public Int64 IsInactive { get; set; }

    }

    public partial class LootResults
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ID { get; set; }

        public String Description { get; set; }

    }

    public class Players
    {
        [NotNull]
        public String Name { get; set; }

        [System.ComponentModel.DataAnnotations.Key, PrimaryKey, AutoIncrement]
        public Int64 UserID { get; set; }

    }


    public partial class PlayerCharacters
    {
        [NotNull]
        public String Owner { get; set; }

        [NotNull]
        public String Name { get; set; }

        [NotNull]
        public String Class { get; set; }

        [NotNull]
        public Int64 UserID { get; set; }

        public String Comment { get; set; }

        public Int64? IsMain { get; set; }

        public Int64? IsSocial { get; set; }

        public Int64? IsInactive { get; set; }

    }

    public partial class PointsAdjustment
    {
        [NotNull]
        public String CharacterName { get; set; }

        [NotNull]
        public Int64 Adjustment { get; set; }

        public String Reason { get; set; }

        [NotNull]
        public String AdjustedBy { get; set; }

        public String TimeStamp { get; set; }

    }

    public partial class Raids
    {
        [NotNull, PrimaryKey, System.ComponentModel.DataAnnotations.Key]
        public Int64 ID { get; set; }

        [NotNull]
        public String TimeStamp { get; set; }

        public String RaidName { get; set; }

        public String AddedBy { get; set; }

        [NotNull]
        public Int64 IsComplete { get; set; }

    }

}
