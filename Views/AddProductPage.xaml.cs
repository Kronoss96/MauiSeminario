using MauiSeminario.Models;
using MauiSeminario.Helpers;

namespace MauiSeminario.Views;

public partial class AddProductPage : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public AddProductPage()
	{
		InitializeComponent();
	}

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
		var producto = new Producto
		{
			Nombre = NombreEntry.Text,
			Descripcion = NombreEntry.Text,
			Precio = decimal.Parse(NombreEntry.Text)
		};
		await firebaseHelper.AddProducto(producto);
		await DisplayAlert("Exito", "Producto Agregado", "OK");
		await Navigation.PopAsync();
    }
}