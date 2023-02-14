using Android.Media;
using Microsoft.Maui.Controls;
using Registros.Conexion.Cine;
using static Android.Icu.Text.CaseMap;

namespace Registros.Paginas;

public partial class Cine : ContentPage
{
    public Cine()
    {
        InitializeComponent();
    }
    async void btnAgregar(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(director.Text) && !string.IsNullOrWhiteSpace(titulo.Text) && !string.IsNullOrWhiteSpace(genero.Text)
            && !string.IsNullOrWhiteSpace(rating.Text) && !string.IsNullOrWhiteSpace(release.Text))
        {

            await App.cineDatabase.SaveMovie(new CineAtributos
            {
                Director = director.Text,
                Titulo = titulo.Text,
                Genero = genero.Text,
                Calificacion = int.Parse(rating.Text),
                Release = int.Parse(release.Text)
            });
            director.Text = string.Empty;
            titulo.Text = string.Empty;
            genero.Text = string.Empty;
            rating.Text = string.Empty;
            release.Text = string.Empty;
            colleciontView.ItemsSource = await App.cineDatabase.GetMovies();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        colleciontView.ItemsSource = await App.cineDatabase.GetMovies();
    }
    async void btnEliminar(object sender, EventArgs e)
    {
        await App.cineDatabase.DeleteAll();
        colleciontView.ItemsSource = await App.cineDatabase.GetMovies();
    }
    async void btnEliminar(object sender, EventArgs e)
    {
        var album = await App.cineDatabase.DeleteAlbum(Convert.ToInt32(Id));
        if (album != null)
        {
            await App.DeleteAlbum(album);
            await DisplayAlert("Eliminado", "Se ha eliminado correctamente","Ok");
            colleciontView.ItemsSource = await App.cineDatabase.GetMovies();
        }
    }
    async void btnEditar(object sender, EventArgs e)
    {
        await DisplayAlert("Seleccion", "Has seleccionado editar", "Ok");
    }
}