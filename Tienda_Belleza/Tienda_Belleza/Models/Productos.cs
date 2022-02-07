using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tienda_Belleza.Models
{
    public class Productos
    {
        [PrimaryKey, AutoIncrement]
        public int IdProducto { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public double Precio { get; set; }
        [MaxLength(50)]
        public int Cantidad { get; set; }
    }
}
