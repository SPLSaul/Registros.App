using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Musica
{
    public class MusicaDB
    {
        private readonly SQLiteAsyncConnection _database;
        public MusicaDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MusicaAtributos>().Wait();
        }
        public Task<List<MusicaAtributos>> GetAlbums()
        {
            return _database.Table<MusicaAtributos>().ToListAsync();
        }
        public Task<int> SaveAlbum(MusicaAtributos musica)
        {
            return _database.InsertAsync(musica);
        }

        public Task<int> DeleteAll()
        {
            return _database.DeleteAllAsync<MusicaAtributos>();
        }
        public Task<int> DeleteAlbum(MusicaAtributos musica)
        {
            return _database.DeleteAsync(musica);
        }
        public Task<MusicaAtributos> GetAlbum(int album)
        {
            return _database.Table<MusicaAtributos>().Where(a => a.Id == album).FirstOrDefaultAsync();
        }
    }
}
