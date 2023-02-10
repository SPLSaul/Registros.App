using Registros.Paginas;
using Microsoft.Maui.Controls.Shapes;

namespace Registros;

public partial class MainPage : ContentPage
{
	int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }
    private void btnCine(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Cine());
    }
    private void btnMusica(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Musica());
    }
    private void btnLibros(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Libros());
    }
    private void btnEjercicio(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Ejercicio());
    }
}

