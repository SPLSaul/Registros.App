using Android.Media;
using Microsoft.Maui.Controls;
using Org.Apache.Http.Authentication;
using Registros.Conexion.Libros;
using static Android.Icu.Text.CaseMap;

namespace Registros.Paginas;

public partial class Libros : ContentPage
{
    public Libros()
    {
        InitializeComponent();
    }
    async void btnAgregar(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(autor.Text) && !string.IsNullOrWhiteSpace(titulo.Text) && !string.IsNullOrWhiteSpace(genero.Text)
            && !string.IsNullOrWhiteSpace(rating.Text) && !string.IsNullOrWhiteSpace(publicacion.Text))
        {

            await App.libros.SaveLibro(new LibrosAtributos
            {
                Autor = autor.Text,
                Titulo = titulo.Text,
                Genero = genero.Text,
                Calificacion = int.Parse(rating.Text),
                Publicacion = int.Parse(publicacion.Text)
            });
            autor.Text = string.Empty;
            titulo.Text = string.Empty;
            genero.Text = string.Empty;
            rating.Text = string.Empty;
            publicacion.Text = string.Empty;
            colleciontView.ItemsSource = await App.libros.GetLibros();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        colleciontView.ItemsSource = await App.libros.GetLibros();
    }
    async void btnEliminarTodo(object sender, EventArgs e)
    {
        await App.libros.DeleteAll();
        colleciontView.ItemsSource = await App.libros.GetLibros();
    }
    async void btnEliminar(object sender, EventArgs e)
    {
        string id = ((MenuItem)sender).CommandParameter.ToString();
        var libro = await App.libros.GetLibro(Convert.ToInt32(id));
        await App.libros.DeleteLibro(libro);
        await DisplayAlert("Borrar", "Se ha eliminado exitosamente", "Ok");
        colleciontView.ItemsSource = await App.libros.GetLibros();
    }
}