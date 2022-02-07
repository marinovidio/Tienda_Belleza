using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_Belleza.Models;
using Xamarin.Forms;

namespace Tienda_Belleza
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LlenarDatos();
        }


        public async void LlenarDatos()
        {
            var productolista = await App.SQLiteDB.GetProductoAsync();
            if (productolista != null)
            {
                lstPrdoducto.ItemsSource = productolista;
            }

            else
            {
               productolista=null;
            }
        }
        public async void LlenarDatos2()
        {     
           
            var compalista = await App.SQLiteDB.GetCompraAsync();
            if (compalista != null)
            {
                lstPrdoducto.ItemsSource = compalista;
            }

            else
            {
                compalista = null;
            }
        }
        public bool ValidarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false; 
            }else if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                respuesta = false;
            }
            else if(string.IsNullOrEmpty(txtCantidad.Text))
            {
                respuesta=false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
        public bool ValidarDatos2()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtComprador.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCantidadcompra.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtNombreCompra.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProducto.Text))
            {
                Productos prod = new Productos()
                {
                    IdProducto = Convert.ToInt32(txtIdProducto),
                    Nombre = txtNombre.Text,
                    Precio = Convert.ToInt32(txtPrecio),
                    Cantidad = Convert.ToInt32(txtCantidad),
                };
                await App.SQLiteDB.SaveProductosAsync(prod);
                await DisplayAlert("Actualizar", "Actualizado correctamente", "ok");
                Limpiar();
                txtIdProducto.IsVisible = false;
                btnActualizar.IsVisible = false;
                btningresar.IsVisible = true;
                btnEliminar.IsVisible = true;
                LlenarDatos();
            }
        }

        private async void LstPrdoducto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Productos)e.SelectedItem;
            btningresar.IsVisible = false;
            txtIdProducto.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible=true;
            if (!string.IsNullOrEmpty(obj.IdProducto.ToString()))
            {
                var producto = await App.SQLiteDB.GetProductoAsync(obj.IdProducto);
                if(producto != null)
                {
                    txtIdProducto.Text = producto.IdProducto.ToString();    
                    txtNombre.Text = producto.Nombre;
                    txtPrecio.Text = producto.Precio.ToString();
                    txtCantidad.Text = producto.Cantidad.ToString();
                }
            }
        }
        public void Limpiar()
        {
            txtIdProducto.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }
        public void Limpiar2()
        {
            txtIdCompra.Text = "";
            txtComprador.Text = "";
            txtCantidadcompra.Text = "";
            txtNombreCompra.Text = "";
        }
        private async void TexEliminar_Clicked(object sender, EventArgs e)
        {
            var producto = await App.SQLiteDB.GetProductoAsync(Convert.ToInt32(txtIdProducto.Text));
            if(producto != null)
            {
                await App.SQLiteDB.DeleteproductoAsync(producto);
                await DisplayAlert("Eliminar", "Eliminado correctamente", "ok");
                Limpiar();
            }
        }

        private async void btningresar_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Productos prod = new Productos
                {
                    IdProducto = 0,
                    Nombre = txtNombre.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    Cantidad = int.Parse(txtCantidad.Text),

                };
                await App.SQLiteDB.SaveProductosAsync(prod);
                Limpiar();
                await DisplayAlert("Registro", "Datos ingresados correctamente", "ok");
                LlenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "ok");
            }
        }

        private async void btnComprarcolum_Clicked(object sender, EventArgs e)
        {
            txtNombre.IsVisible = false;
            txtPrecio.IsVisible = false;
            txtCantidad.IsVisible = false;
            txtComprador.IsVisible = true;
            txtCantidadcompra.IsVisible = true;
            txtNombreCompra.IsVisible = true;
            btningresar.IsVisible = false;
            btnComprar.IsVisible = true;
            Title.Text="Datos de la Compra";
            

        }

        private async void btnComprar_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos2())
            {
                Compra com = new Compra
                {
                    IdCompra = 0,
                    Comprador = txtComprador.Text,
                    Nombre = txtNombreCompra.Text,
                    Cantidad = int.Parse(txtCantidadcompra.Text),

                };
                await App.SQLiteDB.SaveCompraAsync(com);
                Limpiar2();
                await DisplayAlert("Registro", "Compra confirmada", "ok");
                await App.SQLiteDB.DeleteCompraAsync(com);
                LlenarDatos();

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "ok");
            }
            
        }

        
    }
}
