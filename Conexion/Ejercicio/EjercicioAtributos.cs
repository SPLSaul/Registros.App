using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Conexion.Ejercicio
{
    public class EjercicioAtributos
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public int Peso { get; set; }
        public string Ejercicio { get; set; }
        public string Parte { get; set; }
        public int MaxRep { get; set; }
        public string Fecha { get; set; }
    }
}
