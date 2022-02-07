using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda_Belleza.Models
{
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int IdCompra { get; set; }
        [MaxLength(50)]
        public string Comprador { get; set; }
        [MaxLength(50)]
        public String Nombre  { get; set; }
        [MaxLength(50)]
        public int Cantidad { get; set; }
    }
}
