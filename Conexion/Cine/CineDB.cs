using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Cine
{
    public class CineDB
    {
        private readonly SQLiteAsyncConnection _database;
        public CineDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CineAtributos>().Wait();
        }
        public Task<List<CineAtributos>> GetMovies()
        {
            return _database.Table<CineAtributos>().ToListAsync();
        }
        public Task<int> SaveMovie(CineAtributos movie)
        {
            return _database.InsertAsync(movie);
        }

        public Task<int> DeleteAll()
        {
            return _database.DeleteAllAsync<CineAtributos>();
        }
        public Task<int> DeleteMovie(CineAtributos movie)
        {
            return _database.DeleteAsync(movie);
        }
        public Task<CineAtributos> GetMovie(int movie)
        {
            return _database.Table<CineAtributos>().Where(a => a.Id == movie).FirstOrDefaultAsync();
        }
        
    }
}

