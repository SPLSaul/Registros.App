using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Ejercicio
{
    public class EjercicioDB
    {
        private readonly SQLiteAsyncConnection _database;
        public EjercicioDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<EjercicioAtributos>().Wait();
        }
        public Task<List<EjercicioAtributos>> GetWorkout()
        {
            return _database.Table<EjercicioAtributos>().ToListAsync();
        }
        public Task<int> SaveEjercicio(EjercicioAtributos ejercicio)
        {
            return _database.InsertAsync(ejercicio);
        }

        public Task<int> DeleteAll()
        {
            return _database.DeleteAllAsync<EjercicioAtributos>();
        }
        public Task<int> DeleteEjercicio(EjercicioAtributos ejercicio)
        {
            return _database.DeleteAsync(ejercicio);
        }
    }
}
