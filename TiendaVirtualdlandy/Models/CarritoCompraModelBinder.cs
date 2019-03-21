using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtualdlandy.Models
{
    public class CarritoCompraModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CarritoCompra carritoCompra = (CarritoCompra)controllerContext.HttpContext.Session["Carrito"];

            if (carritoCompra == null)
            {
                carritoCompra = new CarritoCompra();
                controllerContext.HttpContext.Session["Carrito"] = carritoCompra;
            }

            return carritoCompra;
        }
    }
}