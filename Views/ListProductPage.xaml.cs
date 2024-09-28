using MauiSeminario.Models;
using MauiSeminario.Helpers;

namespace MauiSeminario.Views;

public partial class ListProductPage : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public ListProductPage()
	{
		InitializeComponent();
	}
	private async void LoadProducts()
	{
		var productos = await firebaseHelper.GetAllProductos();
		ProductsListView.ItemsSource = productos;
    }
}