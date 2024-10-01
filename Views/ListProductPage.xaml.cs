using MauiSeminario.Models;
using MauiSeminario.Helpers;

namespace MauiSeminario.Views;

public partial class ListProductPage : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
    public ListProductPage()
    {
        InitializeComponent();
        LoadProducts();  // Invocación del método para cargar los productos
    }

    private async void LoadProducts()
	{
		var productos = await firebaseHelper.GetAllProductos();
		ProductsListView.ItemsSource = productos;
    }
    private async void OnEditProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var producto = button?.BindingContext as Producto;
		if (producto != null) 
		{
			await Navigation.PushAsync(new EditProductPage(producto));
		}
    }
	private async void OnDeleteProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var producto = button?.BindingContext as Producto;
		if (producto != null && !string.IsNullOrEmpty(producto.Id))
		{
			await firebaseHelper.DeleteProducto(producto.Id);
			await DisplayAlert("Exito", "Producto Eliminado", "OK");
		}
        else
        {
			await DisplayAlert("Error", "No se puede encontrar el producto", "OK");
        }
    }
}