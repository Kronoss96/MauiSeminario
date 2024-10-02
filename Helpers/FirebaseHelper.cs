using Firebase.Database;
using Firebase.Database.Query;
using MauiSeminario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSeminario.Helpers
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebaseClient;
        public FirebaseHelper()
        {
            firebaseClient = new FirebaseClient("https://mauicrud-b5391-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Producto>> GetAllProductos()
        {
            var productos = await firebaseClient
                .Child("Productos")
                .OnceAsync<Producto>();
            return productos.Select(item => new Producto
            {
                Id = item.Key,
                Nombre = item.Object.Nombre,
                Descripcion = item.Object.Descripcion,
                Precio = item.Object.Precio,
            }).ToList();
        }
        public async Task AddProducto(Producto producto)
        {
            // Crea un nuevo objeto Producto sin Id
            var newProducto = new Producto
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio
            };

            await firebaseClient
                .Child("Productos")
                .PostAsync(newProducto);
        }
        public async Task UpdateProducto(string key, Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .Child(key)
                .PutAsync(producto);
        }
        public async Task DeleteProducto(string key) 
        {
            await firebaseClient
                .Child("Productos")
                .Child(key)
                .DeleteAsync();
        }
    }
}
