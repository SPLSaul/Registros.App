using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Libros
{
    public class LibrosAtributos
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Publicacion { get; set; }
        public int Calificacion { get; set; }
    }
}
