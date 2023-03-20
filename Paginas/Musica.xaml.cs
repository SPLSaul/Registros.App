using Android.Media;
using Microsoft.Maui.Controls;
using Registros.Conexion.Musica;
using static Android.Provider.MediaStore.Audio;

namespace Registros.Paginas;

public partial class Musica : ContentPage
{
    public Musica()
    {
        InitializeComponent();
    }
    async void btnAgregar(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(artista.Text) && !string.IsNullOrWhiteSpace(album.Text) && !string.IsNullOrWhiteSpace(genero.Text)
            && !string.IsNullOrWhiteSpace(rating.Text) && !string.IsNullOrWhiteSpace(release.Text))
        {

            await App.musicadatabase.SaveAlbum(new MusicaAtributos
            {
                Artista = artista.Text,
                Album = album.Text,
                Genero = genero.Text,
                Calificacion = int.Parse(rating.Text),
                Release = int.Parse(release.Text)
            });
            artista.Text = string.Empty;
            album.Text = string.Empty;
            genero.Text = string.Empty;
            rating.Text = string.Empty;
            release.Text = string.Empty;
            colleciontView.ItemsSource = await App.musicadatabase.GetAlbums();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        colleciontView.ItemsSource = await App.musicadatabase.GetAlbums();
    }
    async void btnEliminarTodo(object sender, EventArgs e)
    {
        await App.musicadatabase.DeleteAll();
        colleciontView.ItemsSource = await App.musicadatabase.GetAlbums();
    }
    async void btnEliminar(object sender, EventArgs e)
    {
        string id = ((MenuItem)sender).CommandParameter.ToString();
        var album = await App.musicadatabase.GetAlbum(Convert.ToInt32(id));
        await App.musicadatabase.DeleteAlbum(album);
        await DisplayAlert("Borrar", "Se ha eliminado exitosamente", "Ok");
        colleciontView.ItemsSource = await App.musicadatabase.GetAlbums();
    }
    async void btnEditar(object sender, EventArgs e)
    {
        string id = ((MenuItem)sender).CommandParameter.ToString();
        var album = await App.musicadatabase.GetAlbum(Convert.ToInt32(id));
        await App.musicadatabase.DeleteAlbum(album);
        await App.musicadatabase.SaveAlbum(new MusicaAtributos
        {
            Artista = artista.Text,
            Album = album.Text,
            Genero = genero.Text,
            Calificacion = int.Parse(rating.Text),
            Release = int.Parse(release.Text)
        });
        artista.Text = string.Empty;
        album.Text = string.Empty;
        genero.Text = string.Empty;
        rating.Text = string.Empty;
        release.Text = string.Empty;
        colleciontView.ItemsSource = await App.musicadatabase.GetAlbums();
    }
}