using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtualdlandy.Models;

namespace TiendaVirtualdlandy.Controllers
{
    public class PedidoController : Controller
    {
        private TiendaVirtualContainer tiendaVirtual = new TiendaVirtualContainer();
       
        // GET: Pedido
        [Authorize]
        public ActionResult Index()
        {
            //Recupera los datos del cliente en sesión
            Cliente c = tiendaVirtual.Clientes.Where(x => x.username == User.Identity.Name).First();
            int idCliente = c.Id; // Almacena el id del cliente en sesión
            return View(tiendaVirtual.Pedidos.Where(item => item.Cliente_Id == idCliente).ToList());
        }
    }
}