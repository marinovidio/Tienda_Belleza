using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tienda_Belleza.Models;

namespace Tienda_Belleza.DataBase
{
    public class SQLHeper
    {
        readonly SQLiteAsyncConnection db;
        public SQLHeper (String dbParth)
        {
            db = new SQLiteAsyncConnection (dbParth);
            db.CreateTableAsync<Productos>().Wait ();
            db.CreateTableAsync<Compra>().Wait ();
        }
        public Task<int> SaveProductosAsync(Productos prod)
        {
            if(prod.IdProducto!=0)
            {
                return db.UpdateAsync(prod);
            }
            else
            {
                return db.InsertAsync(prod);
            }
        }
        public Task<List<Productos>> GetProductoAsync()
        {
            return db.Table<Productos>().ToListAsync();
        }

        public Task<Productos> GetProductoAsync(int idPrdoducto)
        {
            return db.Table<Productos>().Where(a => a.IdProducto==idPrdoducto).FirstOrDefaultAsync();
        }


        public Task<int> DeleteproductoAsync(Productos producto)
        {
            return db.DeleteAsync(producto);
        }
        public Task<int> SaveCompraAsync(Compra compra)
        {
            if (compra.IdCompra != 0)
            {
                return db.UpdateAsync(compra);
            }
            else
            {
                return db.InsertAsync(compra);
            }
        }
        public Task<List<Compra>> GetCompraAsync()
        {
            return db.Table<Compra>().ToListAsync();
        }

        public Task<Compra> GetCompraAsync(int idcompra)
        {
            return db.Table<Compra>().Where(a => a.IdCompra == idcompra).FirstOrDefaultAsync();
        }
       

        public Task<int> DeleteCompraAsync(Compra compra)
        {
            return db.DeleteAsync(compra);
        }

        internal Task GetCompracantidadAsync(Compra com)
        {
            throw new NotImplementedException();
        }
    }
}
