using Microsoft.Maui.Controls;
using Registros.Conexion.Ejercicio;

namespace Registros.Paginas;

public partial class Ejercicio : ContentPage
{
    public Ejercicio()
    {
        InitializeComponent();
    }
    async void btnAgregar(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ejercicio.Text) && !string.IsNullOrWhiteSpace(peso.Text) && !string.IsNullOrWhiteSpace(parte.Text)
            && !string.IsNullOrWhiteSpace(maxRep.Text) && !string.IsNullOrWhiteSpace(fecha.Text))
        {

            await App.ejercicioDatabase.SaveEjercicio(new EjercicioAtributos
            {
                Ejercicio = ejercicio.Text,
                Peso = int.Parse(peso.Text),
                Parte = parte.Text,
                MaxRep = int.Parse(maxRep.Text),
                Fecha = fecha.Text
            });
            ejercicio.Text = string.Empty;
            peso.Text = string.Empty;
            parte.Text = string.Empty;
            maxRep.Text = string.Empty;
            fecha.Text = string.Empty;
            colleciontView.ItemsSource = await App.ejercicioDatabase.GetWorkout();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        colleciontView.ItemsSource = await App.ejercicioDatabase.GetWorkout();
    }
    async void btnEliminar(object sender, EventArgs e)
    {
        await App.ejercicioDatabase.DeleteAll();
        colleciontView.ItemsSource = await App.ejercicioDatabase.GetWorkout();
    }
}