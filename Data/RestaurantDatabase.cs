using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Proiect_Aplicatia_Mobila.Models;

namespace Proiect_Aplicatia_Mobila.Data
{
    public class RestaurantDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RestaurantDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TableList>().Wait();
            _database.CreateTableAsync<Zone>().Wait();
            _database.CreateTableAsync<Reservation>().Wait();
        }

        //TABLE
        public Task<List<TableList>> GetTableListAsync()
        {
            return _database.Table<TableList>().ToListAsync();
        }

        public Task<TableList> GetTableListAsync(int id)
        {
            return _database.Table<TableList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveTableListAsync(TableList tlist)
        {
            if (tlist.ID != 0)
            {
                return _database.UpdateAsync(tlist);
            }
            else
            {
                return _database.InsertAsync(tlist);
            }
        }
        public Task<int> DeleteTableListAsync(TableList tlist)
        {
            return _database.DeleteAsync(tlist);
        }




        //ZONE
        public Task<List<Zone>> GetZoneAsync()
        {
            return _database.Table<Zone>().ToListAsync();
        }

        public Task<Zone> GetZoneAsync(int id)
        {
            return _database.Table<Zone>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveZoneAsync(Zone zlist)
        {
            if (zlist.ID != 0)
            {
                return _database.UpdateAsync(zlist);
            }
            else
            {
                return _database.InsertAsync(zlist);
            }
        }
        public Task<int> DeleteZoneAsync(Zone zlist)
        {
            return _database.DeleteAsync(zlist);
        }


        //RESERVATION
        public Task<List<Reservation>> GetReservationAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            return _database.Table<Reservation>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveReservationAsync(Reservation rlist)
        {
            if (rlist.ID == 0)
            {
                return _database.InsertAsync(rlist);
            }

            else
            {
                return _database.UpdateAsync(rlist);

            }
        }
        public Task<int> DeleteReservationAsync(Reservation rlist)
        {
            return _database.DeleteAsync(rlist);
        }


    }
}



