using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infraestruture.SQL.Negocios;
using Domain.Entity;

namespace netAcademytec.Controllers
{
    public class NegociosController : Controller
    {
        almacenDAO _almacen = new almacenDAO();
        areaDAO _area = new areaDAO();
        autorDAO _autor = new autorDAO();
        clienteDAO _cliente = new clienteDAO();
        detalle_facturaDAO _detalle_factura = new detalle_facturaDAO();
        detalle_listaDAO _detalle_lista = new detalle_listaDAO();
        documentoDAO _documento = new documentoDAO();
        empleadoDAO _empleado = new empleadoDAO();
        empresaDAO _empresa = new empresaDAO();
        facturaDAO _factura = new facturaDAO();
        impresionDAO _impresion = new impresionDAO();
        libroDAO _libro = new libroDAO();
        listaDAO _lista = new listaDAO();
        materialDAO _material = new materialDAO();
        programaDAO _programa = new programaDAO();
        reciboDAO _recibo = new reciboDAO();
        transporteDAO _transporte = new transporteDAO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoAlmacen()
        {
            return View(_almacen.getAll());
        }
        public ActionResult CreateAlmacen()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Almacen());
        }
        [HttpPost]
        public ActionResult CreateAlmacen(Almacen reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _almacen.insert(reg);

            //refrescar los datos a la vista
            return View(reg);

        }
        public ActionResult DetailsAlmacen(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Almacen reg = _almacen.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoAlmacen");
            else
                return View(reg);
        }
        public ActionResult EditAlmacen(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Almacen reg = _almacen.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoAlmacen");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditAlmacen(Almacen reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _almacen.update(reg);
            return View(reg);
        }
        public ActionResult DeleteAlmacen(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _almacen.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoAlmacen");
        }
        public ActionResult ListadoArea()
        {
            return View(_area.getAll());
        }
        public ActionResult CreateArea()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Area());
        }
        [HttpPost]
        public ActionResult CreateArea(Area reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _area.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsArea(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Area reg = _area.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoArea");
            else
                return View(reg);
        }
        public ActionResult EditArea(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Area reg = _area.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoArea");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditArea(Area reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _area.update(reg);
            return View(reg);
        }
        public ActionResult DeleteArea(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _area.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoArea");
        }
        public ActionResult ListadoAutor()
        {
            return View(_autor.getAll());
        }
        public ActionResult CreateAutor()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Autor());
        }
        [HttpPost]
        public ActionResult CreateAutor(Autor reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _autor.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsAutor(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Autor reg = _autor.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoAutor");
            else
                return View(reg);
        }
        public ActionResult EditAutor(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Autor reg = _autor.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoAutor");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditAutor(Autor reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _autor.update(reg);
            return View(reg);
        }
        public ActionResult DeleteAutor(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _autor.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoAutor");
        }
        public ActionResult ListadoCliente()
        {
            return View(_cliente.getAll());
        }
        public ActionResult CreateCliente()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Cliente());
        }
        [HttpPost]
        public ActionResult CreateCliente(Cliente reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _cliente.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsCliente(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Cliente reg = _cliente.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoCliente");
            else
                return View(reg);
        }
        public ActionResult EditCliente(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Cliente reg = _cliente.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoCliente");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditCliente(Cliente reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _cliente.update(reg);
            return View(reg);
        }
        public ActionResult DeleteCliente(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _cliente.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoCliente");
        }
        public ActionResult ListadoDetalle_Factura()
        {
            return View(_detalle_factura.getAll());
        }
        public ActionResult CreateDetalle_Factura()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Detalle_Factura());
        }
        [HttpPost]
        public ActionResult CreateDetalle_Factura(Detalle_Factura reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _detalle_factura.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsDetalle_Factura(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Detalle_Factura reg = _detalle_factura.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoDetalle_Factura");
            else
                return View(reg);
        }
        public ActionResult EditDetalle_Factura(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Detalle_Factura reg = _detalle_factura.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoDetalle_Factura");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditDetalle_Factura(Detalle_Factura reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _detalle_factura.update(reg);
            return View(reg);
        }
        public ActionResult DeleteDetalle_Factura(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _detalle_factura.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoDetalle_Factura");
        }
        public ActionResult ListadoDetalle_Lista()
        {
            return View(_detalle_lista.getAll());
        }
        public ActionResult CreateDetalle_Lista()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Detalle_Lista());
        }
        [HttpPost]
        public ActionResult CreateDetalle_Lista(Detalle_Lista reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _detalle_lista.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsDetalle_Lista(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Detalle_Lista reg = _detalle_lista.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoDetalle_Lista");
            else
                return View(reg);
        }
        public ActionResult EditDetalle_Lista(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Detalle_Lista reg = _detalle_lista.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoDetalle_Lista");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditDetalle_Lista(Detalle_Lista reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _detalle_lista.update(reg);
            return View(reg);
        }
        public ActionResult DeleteDetalle_Lista(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _detalle_lista.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoDetalle_Lista");
        }
        public ActionResult ListadoDocumento()
        {
            return View(_documento.getAll());
        }
        public ActionResult CreateDocumento()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Documento());
        }
        [HttpPost]
        public ActionResult CreateDocumento(Documento reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _documento.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsDocumento(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Documento reg = _documento.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoDocumento");
            else
                return View(reg);
        }
        public ActionResult EditDocumento(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Documento reg = _documento.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoDocumento");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditDocumento(Documento reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _documento.update(reg);
            return View(reg);
        }
        public ActionResult DeleteDocumento(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _documento.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoDocumento");
        }
        public ActionResult ListadoEmpleado()
        {
            return View(_empleado.getAll());
        }
        public ActionResult CreateEmpleado()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Empleado());
        }
        [HttpPost]
        public ActionResult CreateEmpleado(Empleado reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _empleado.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsEmpleado(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Empleado reg = _empleado.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoEmpleado");
            else
                return View(reg);
        }
        public ActionResult EditEmpleado(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Empleado reg = _empleado.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoEmpleado");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditEmpleado(Empleado reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _empleado.update(reg);
            return View(reg);
        }
        public ActionResult DeleteEmpleado(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _empleado.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoEmpleado");
        }
        public ActionResult ListadoEmpresa()
        {
            return View(_empresa.getAll());
        }
        public ActionResult CreateEmpresa()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Empresa());
        }
        [HttpPost]
        public ActionResult CreateEmpresa(Empresa reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _empresa.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsEmpresa(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Empresa reg = _empresa.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoEmpresa");
            else
                return View(reg);
        }
        public ActionResult EditEmpresa(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Empresa reg = _empresa.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoEmpresa");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditEmpresa(Empresa reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _empresa.update(reg);
            return View(reg);
        }
        public ActionResult DeleteEmpresa(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _empresa.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoEmpresa");
        }
        public ActionResult ListadoFactura()
        {
            return View(_factura.getAll());
        }
        public ActionResult CreateFactura()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Factura());
        }
        [HttpPost]
        public ActionResult CreateFactura(Factura reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _factura.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsFactura(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Factura reg = _factura.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoFactura");
            else
                return View(reg);
        }
        public ActionResult EditFactura(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Factura reg = _factura.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoFactura");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditFactura(Factura reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _factura.update(reg);
            return View(reg);
        }
        public ActionResult DeleteFactura(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _factura.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoFactura");
        }
        public ActionResult ListadoImpresion()
        {
            return View(_impresion.getAll());
        }
        public ActionResult CreateImpresion()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Impresion());
        }
        [HttpPost]
        public ActionResult CreateImpresion(Impresion reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _impresion.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsImpresion(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Impresion reg = _impresion.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoImpresion");
            else
                return View(reg);
        }
        public ActionResult EditImpresion(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Impresion reg = _impresion.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoImpresion");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditImpresion(Impresion reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _impresion.update(reg);
            return View(reg);
        }
        public ActionResult DeleteImpresion(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _impresion.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoImpresion");
        }
        public ActionResult ListadoLibro()
        {
            return View(_libro.getAll());
        }
        public ActionResult CreateLibro()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Libro());
        }
        [HttpPost]
        public ActionResult CreateLibro(Libro reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _libro.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsLibro(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Libro reg = _libro.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoLibro");
            else
                return View(reg);
        }
        public ActionResult EditLibro(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Libro reg = _libro.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoLibro");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditLibro(Libro reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _libro.update(reg);
            return View(reg);
        }
        public ActionResult DeleteLibro(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _libro.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoLibro");
        }
        public ActionResult ListadoLista()
        {
            return View(_lista.getAll());
        }
        public ActionResult CreateLista()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Lista());
        }
        [HttpPost]
        public ActionResult CreateLista(Lista reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _lista.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsLista(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Lista reg = _lista.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoLista");
            else
                return View(reg);
        }
        public ActionResult EditLista(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Lista reg = _lista.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoLista");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditLista(Lista reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _lista.update(reg);
            return View(reg);
        }
        public ActionResult DeleteLista(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _lista.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoLista");
        }
        public ActionResult ListadoMaterial()
        {
            return View(_material.getAll());
        }
        public ActionResult CreateMaterial()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Material());
        }
        [HttpPost]
        public ActionResult CreateMaterial(Material reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _material.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsMaterial(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Material reg = _material.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoMaterial");
            else
                return View(reg);
        }
        public ActionResult EditMaterial(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Material reg = _material.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoMaterial");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditMaterial(Material reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _material.update(reg);
            return View(reg);
        }
        public ActionResult DeleteMaterial(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _material.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoMaterial");
        }
        public ActionResult ListadoPrograma()
        {
            return View(_programa.getAll());
        }
        public ActionResult CreatePrograma()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Programa());
        }
        [HttpPost]
        public ActionResult CreatePrograma(Programa reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _programa.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsPrograma(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Programa reg = _programa.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoPrograma");
            else
                return View(reg);
        }
        public ActionResult EditPrograma(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Programa reg = _programa.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoPrograma");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditPrograma(Programa reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _programa.update(reg);
            return View(reg);
        }
        public ActionResult DeletePrograma(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _programa.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoPrograma");
        }
        public ActionResult ListadoRecibo()
        {
            return View(_recibo.getAll());
        }
        public ActionResult CreateRecibo()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Recibo());
        }
        [HttpPost]
        public ActionResult CreateRecibo(Recibo reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _recibo.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsRecibo(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Recibo reg = _recibo.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoRecibo");
            else
                return View(reg);
        }
        public ActionResult EditRecibo(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Recibo reg = _recibo.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoRecibo");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditRecibo(Recibo reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _recibo.update(reg);
            return View(reg);
        }
        public ActionResult DeleteRecibo(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _recibo.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoRecibo");
        }
        public ActionResult ListadoTransporte()
        {
            return View(_transporte.getAll());
        }
        public ActionResult CreateTransporte()
        {
            //este GET envia a la vista un nuevo registro (instancia)
            return View(new Transporte());
        }
        [HttpPost]
        public ActionResult CreateTransporte(Transporte reg)
        {
            if (!ModelState.IsValid)
            {
                //refrescar la pagina con los datos ingresados para visualizar el mensaje
                return View(reg);
            }

            //este POST recibe los datos a traves de reg para ejecutar el proceso
            //donde el resultado del metodo se almacena en el ViewBag
            ViewBag.mensaje = _transporte.insert(reg);

            //refrescar la pagina con los datos ingresados para visualizar el mensaje
            return View(reg);
        }
        public ActionResult DetailsTransporte(int? id = null)
        {
            //evalua el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Transporte reg = _transporte.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoTransporte");
            else
                return View(reg);
        }
        public ActionResult EditTransporte(int? id = null)
        {
            //evalo el parametro opcional al realizar la busqueda
            //reg recibe el registro de la busqueda
            Transporte reg = _transporte.search(id == null ? 0 : id.Value);

            //si reg es nulo, no lo encontro, direccionar al listado, sino visualizar reg
            if (reg == null)
                return RedirectToAction("ListadoTransporte");
            else
                return View(reg);
        }
        [HttpPost]
        public ActionResult EditTransporte(Transporte reg)
        {
            //ejecutar el metodo y almaceno el mensaje de la operacion
            ViewBag.mensaje = _transporte.update(reg);
            return View(reg);
        }
        public ActionResult DeleteTransporte(int? id = null)
        {
            //eliminar por su id y redirecionar al ListadoMP (no habra vista)
            string mensaje = _transporte.delete(id == null ? 0 : id.Value);
            return RedirectToAction("ListadoTransporte");
        }
    }
}