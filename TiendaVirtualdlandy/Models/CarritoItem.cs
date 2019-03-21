using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtualdlandy.Models
{
    public class CarritoItem
    {
        private Producto producto;
        private int cantidad;

        public CarritoItem() { }

        public CarritoItem(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        public int Cantidad
        {
            get {return cantidad; }
            set { cantidad = value; }
        }
    }
}