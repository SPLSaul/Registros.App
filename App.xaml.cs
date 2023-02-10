using Registros.Conexion.Cine;
using Registros.Conexion.Ejercicio;
using Registros.Conexion.Libros;
using Registros.Conexion.Musica;

namespace Registros;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    private static MusicaDB musicaDatabase;    //Base de Datos Musica
    public static MusicaDB musicadatabase
    {
        get
        {
            if (musicaDatabase == null)
            {
                musicaDatabase = new MusicaDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Musica.db3"));
            }
            return musicaDatabase;
        }
    }
    private static CineDB CineDatabase; //Base de Datos Cine

    public static CineDB cineDatabase
    {
        get
        {
            if (CineDatabase == null)
            {
                CineDatabase = new CineDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Cine.db3"));
            }
            return CineDatabase;
        }
    }
    private static EjercicioDB ejercicioDB;  //Base de Datos Libros
    public static EjercicioDB ejercicioDatabase
    {
        get
        {
            if (ejercicioDB == null)
            {
                ejercicioDB = new EjercicioDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ejercicio.db3"));
            }
            return ejercicioDB;
        }
    }
    private static LibrosDB librosDB;  //Base de Datos Ejercicio
    public static LibrosDB libros
    {
        get
        {
            if (librosDB == null)
            {
                librosDB = new LibrosDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Libros.db3"));
            }
            return librosDB;
        }
    }
}
