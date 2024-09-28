using MauiSeminario.Models;
using MauiSeminario.Helpers;

namespace MauiSeminario.Views;

public partial class EditProductPage : ContentPage
{
    private FirebaseHelper firebaseHelper = new FirebaseHelper();
    private Producto producto;
    public EditProductPage(Producto producto)
	{
		InitializeComponent();
        this.producto = producto;

        NombreEntry.Text = producto.Nombre;
        DescripcionEntry.Text = producto.Descripcion;
        PrecioEntry.Text = producto.Precio.ToString();
    }
    private async void OnUpdateProductClicked(object sender, EventArgs e)
    {
        producto.Nombre = NombreEntry.Text;
        producto.Descripcion = DescripcionEntry.Text;
        producto.Precio = decimal.Parse(PrecioEntry.Text);

        await firebaseHelper.UpdateProducto(producto.Id, producto);
        await DisplayAlert("Exito", "Producto Editado", "OK");
        await Navigation.PopAsync();
    }
}