using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtualdlandy.Models;

namespace TiendaVirtualdlandy.Controllers
{
    public class CarritoController : Controller
    {
        private TiendaVirtualContainer tiendaVirtual = new TiendaVirtualContainer();

        // GET: Carrito
        public ActionResult Index(int id, CarritoCompra carrito)
        {
            int indexExiste = getIndex(id, carrito);

            if (indexExiste == -1)
            {
                carrito.Add(new CarritoItem(tiendaVirtual.Productos.Find(id), 1));
            }
            else
            {
                carrito[indexExiste].Cantidad++;
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> carrito = (List<CarritoItem>)Session["Carrito"];
            carrito.RemoveAt(getIndex(id));
            return View("Index");

        }

        public ActionResult FinishCart(int stockTemporal)
        {            
            List<CarritoItem> carrito = (List<CarritoItem>)Session["Carrito"];
            if (carrito != null && carrito.Count > 0)
            {
                Pedido pedido = new Pedido();
                pedido.fecha = DateTime.Now;
                pedido.subtotal = carrito.Sum(x => x.Producto.precio * x.Cantidad);
                pedido.iva = pedido.subtotal * 0.21m;
                pedido.total = pedido.subtotal + pedido.iva;

                foreach (CarritoItem producto in carrito)
                {
                    PedidoItem pedidoItem = new PedidoItem();
                    pedidoItem.Producto_Id = producto.Producto.Id;
                    pedidoItem.cantidad = producto.Cantidad;
                    pedidoItem.total = producto.Cantidad * producto.Producto.precio;

                    tiendaVirtual.PedidoItems.Add(pedidoItem);
                }                                

                Cliente c = tiendaVirtual.Clientes.Where(x => x.username == User.Identity.Name).First();
                pedido.Cliente = c;                
                tiendaVirtual.Pedidos.Add(pedido);
                tiendaVirtual.SaveChanges();
            }
            carrito.RemoveRange(0,carrito.Count);            
            return View("FinishCart");            
        }

        private int getIndex(int id, CarritoCompra carrito)
        {
            for (int i = 0; i < carrito.Count; i++)
            {
                //Si ya existe Id de producto
                if (carrito[i].Producto.Id == id)
                    return i;
            }
            return -1;
        }

        private int getIndex(int id)
        {
            List<CarritoItem> carrito = (List<CarritoItem>)Session["Carrito"];

            for (int i = 0; i < carrito.Count; i++)
            {
                //Si ya existe Id de producto
                if (carrito[i].Producto.Id == id)
                    return i;
            }
            return -1;
        }
    }
}