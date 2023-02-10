using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Musica
{
    public class MusicaAtributos
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Genero { get; set; }
        public int Release { get; set; }
        public int Calificacion { get; set; }

    }
}
