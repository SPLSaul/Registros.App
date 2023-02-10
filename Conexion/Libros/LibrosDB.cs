using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Libros
{
    public class LibrosDB
    {
        private readonly SQLiteAsyncConnection _database;
        public LibrosDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LibrosAtributos>().Wait();
        }
        public Task<List<LibrosAtributos>> GetLibros()
        {
            return _database.Table<LibrosAtributos>().ToListAsync();
        }
        public Task<int> SaveLibro(LibrosAtributos libro)
        {
            return _database.InsertAsync(libro);
        }

        public Task<int> DeleteAll()
        {
            return _database.DeleteAllAsync<LibrosAtributos>();
        }
        public Task<int> DeleteLibro(LibrosAtributos libro)
        {
            return _database.DeleteAsync(libro);
        }
    }
}
