using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Cine
{
    public class CineAtributos
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Director { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Release { get; set; }
        public int Calificacion { get; set; }
    }
}
