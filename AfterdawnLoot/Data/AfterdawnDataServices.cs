using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterdawnLoot.Data
{
    public class AfterdawnDataServices
    {
        public AfterdawnDbContext dbContext;

        #region Constructor
        public AfterdawnDataServices(AfterdawnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Players
        /// <returns></returns>
        public async Task<List<Players>> GetPlayersAsync()
        {
            return await dbContext.Players.ToListAsync();
        }
        /// <summary>
        /// This method add a new Players to the DbContext and saves it
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        public async Task<Players> AddPlayersAsync(Players Players)
        {
            try
            {
                dbContext.Players.Add(Players);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Players;
        }
        /// <summary>
        /// This method update and existing Players and saves the changes
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        public async Task<Players> UpdatePlayersAsync(Players Players)
        {
            try
            {
                var PlayersExist = dbContext.Players.FirstOrDefault(p => p.UserID == Players.UserID);
                if (PlayersExist != null)
                {
                    dbContext.Update(Players);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Players;
        }
        /// <summary>
        /// This method removes and existing Players from the DbContext and saves it
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        public async Task DeletePlayersAsync(Players Players)
        {
            try
            {
                dbContext.Players.Remove(Players);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region PointsAdjustment
        /// <returns></returns>
        public async Task<List<PointsAdjustment>> GetPointsAdjustmentAsync()
        {
            return await dbContext.PointsAdjustment.ToListAsync();
        }
        /// <summary>
        /// This method add a new Players to the DbContext and saves it
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        public async Task<PointsAdjustment> AddPointsAdjustmentAsync(PointsAdjustment PointsAdjustment)
        {
            try
            {
                dbContext.PointsAdjustment.Add(PointsAdjustment);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return PointsAdjustment;
        }
       
        /// <summary>
        /// This method removes and existing Players from the DbContext and saves it
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        public async Task DeletePointsAdjustmentAsync(PointsAdjustment PointsAdjustment)
        {
            try
            {
                dbContext.PointsAdjustment.Remove(PointsAdjustment);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Characters
        /// <returns></returns>
        public async Task<List<Characters>> GetCharactersAsync()
        {
            return await dbContext.Characters.ToListAsync();
        }
        /// <summary>
        /// This method add a new Players to the DbContext and saves it
        /// </summary>
        /// <param name="Characters"></param>
        /// <returns></returns>
        public async Task<Characters> AddCharactersAsync(Characters Characters)
        {
            try
            {
                dbContext.Characters.Add(Characters);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Characters;
        }
        /// <summary>
        /// This method update and existing Players and saves the changes
        /// </summary>
        /// <param name="Characters"></param>
        /// <returns></returns>
        public async Task<Characters> UpdateCharactersAsync(Characters Characters)
        {
            try
            {
                var CharactersExist = dbContext.Characters.FirstOrDefault(p => p.UserID == Characters.UserID);
                if (CharactersExist != null)
                {
                    dbContext.Update(Characters);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Characters;
        }

        public void UpdateCharacters(Characters Characters)
        {
            try
            {
                var CharactersExist = dbContext.Characters.FirstOrDefault(p => p.UserID == Characters.UserID);
                if (CharactersExist != null)
                {
                    dbContext.Update(Characters);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This method removes and existing Players from the DbContext and saves it
        /// </summary>
        /// <param name="Characters"></param>
        /// <returns></returns>
        public async Task DeleteCharactersAsync(Characters Characters)
        {
            try
            {
                dbContext.Characters.Remove(Characters);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Characters

        #region PlayerCharacters
        /// <returns></returns>
        public async Task<List<PlayerCharacters>> GetPlayerCharactersAsync()
        {
            return await dbContext.PlayerCharacters.ToListAsync();
        }
        
        #endregion

        #region Attendance
        /// <returns></returns>
        public async Task<List<Attendance>> GetAttendanceAsync()
        {
            return await dbContext.Attendance.ToListAsync();
        }
        /// <summary>
        /// This method add a new Attendance to the DbContext and saves it
        /// </summary>
        /// <param name="Attendance"></param>
        /// <returns></returns>
        public async Task<Attendance> AddAttendanceAsync(Attendance Attendance)
        {
            try
            {
                dbContext.Attendance.Add(Attendance);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Attendance;
        }

        public async Task<List<Attendance>> AddAttendanceListAsync(List<Attendance> Attendances)
        {
            try
            {
                await dbContext.Attendance.AddRangeAsync(Attendances);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Attendances;
        }

        public async Task<List<Attendance>> UpdateAttendanceListAsync(List<Attendance> Attendances)
        {
            try
            {
                dbContext.Attendance.UpdateRange(Attendances);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Attendances;
        }

        /// <summary>
        /// This method update and existing Attendance and saves the changes
        /// </summary>
        /// <param name="Attendance"></param>
        /// <returns></returns>
        public async Task<Attendance> UpdateAttendanceAsync(Attendance Attendance)
        {
            try
            {
                var AttendanceExist = dbContext.Attendance.FirstOrDefault(p => p.ID == Attendance.ID);
                if (AttendanceExist != null)
                {
                    dbContext.Update(Attendance);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Attendance;
        }

        public async Task DeleteAttendanceListAsync(List<Attendance> Attendances)
        {
            try
            {
                dbContext.Attendance.RemoveRange(Attendances);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method removes and existing Attendance from the DbContext and saves it
        /// </summary>
        /// <param name="Attendance"></param>
        /// <returns></returns>
        public async Task DeleteAttendanceAsync(Attendance Attendance)
        {
            try
            {
                dbContext.Attendance.Remove(Attendance);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Raids
        /// <returns></returns>
        public async Task<List<Raids>> GetRaidsAsync()
        {
            return await dbContext.Raids.ToListAsync();
        }

        public List<Raids> GetRaids()
        {
            return  dbContext.Raids.ToList();
        }


        public async Task<Raids> GetRaidByID(long RaidID)
        {
            return await dbContext.Raids.Where(x => x.ID == RaidID).FirstOrDefaultAsync(); 
        }
        /// <summary>
        /// This method add a new Raids to the DbContext and saves it
        /// </summary>
        /// <param name="Raids"></param>
        /// <returns></returns>
        public async Task<Raids> AddRaidsAsync(Raids Raids)
        {
            try
            {
                dbContext.Raids.Add(Raids);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Raids;
        }
        /// <summary>
        /// This method update and existing Raids and saves the changes
        /// </summary>
        /// <param name="Raids"></param>
        /// <returns></returns>
        public async Task<Raids> UpdateRaidsAsync(Raids Raids)
        {
            try
            {
                var RaidsExist = dbContext.Raids.FirstOrDefault(p => p.ID == Raids.ID);
                if (RaidsExist != null)
                {
                    dbContext.Update(Raids);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Raids;
        }
        /// <summary>
        /// This method removes and existing Raids from the DbContext and saves it
        /// </summary>
        /// <param name="Raids"></param>
        /// <returns></returns>
        public async Task DeleteRaidsAsync(Raids Raids)
        {
            try
            {
                dbContext.Raids.Remove(Raids);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region LootResults
        /// <returns></returns>
        public async Task<List<LootResults>> GetLootResultsAsync()
        {
            return await dbContext.LootResults.ToListAsync();
        }
        #endregion LootResults

        #region CharacterLoot
        /// <returns></returns>
        public async Task<List<CharacterLoot>> GetCharacterLootAsync()
        {
            return await dbContext.CharacterLoot.ToListAsync();
        }

        public async Task<List<CharacterLoot>> GetCharacterLootAsync(long raidID)
        {
            return await dbContext.CharacterLoot.Where(x => x.RaidID == raidID).ToListAsync();
        }

        public async Task<List<CharacterLoot>> AddCharacterLootListAsync(List<CharacterLoot> CharacterLoots)
        {
            try
            {
                await dbContext.CharacterLoot.AddRangeAsync(CharacterLoots);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return CharacterLoots;
        }

        /// <summary>
        /// This method add a new Raids to the DbContext and saves it
        /// </summary>
        /// <param name="CharacterLoot"></param>
        /// <returns></returns>
        public async Task<CharacterLoot> AddCharacterLootAsync(CharacterLoot CharacterLoot)
        {
            try
            {
                dbContext.CharacterLoot.Add(CharacterLoot);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return CharacterLoot;
        }
        /// <summary>
        /// This method update and existing Raids and saves the changes
        /// </summary>
        /// <param name="CharacterLoot"></param>
        /// <returns></returns>
        public async Task<CharacterLoot> UpdateCharacterLootAsync(CharacterLoot CharacterLoot)
        {
            try
            {
                var RaidsExist = dbContext.CharacterLoot.FirstOrDefault(p => p.ID == CharacterLoot.ID);
                if (RaidsExist != null)
                {
                    dbContext.Update(CharacterLoot);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return CharacterLoot;
        }


        public async Task DeleteCharacterLootListAsync(List<CharacterLoot> CharacterLoots)
        {
            try
            {
                dbContext.CharacterLoot.RemoveRange(CharacterLoots);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This method removes and existing Raids from the DbContext and saves it
        /// </summary>
        /// <param name="CharacterLoot"></param>
        /// <returns></returns>
        public async Task DeleteCharacterLootAsync(CharacterLoot CharacterLoot)
        {
            try
            {
                dbContext.CharacterLoot.Remove(CharacterLoot);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCharacterLoot(CharacterLoot CharacterLoot)
        {
            try
            {
                dbContext.CharacterLoot.Remove(CharacterLoot);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}