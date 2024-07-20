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
        public ActionResult ListadoArea()
        {
            return View(_area.getAll());
        }
        public ActionResult ListadoAutor()
        {
            return View(_autor.getAll());
        }
        public ActionResult ListadoCliente()
        {
            return View(_cliente.getAll());
        }
        public ActionResult ListadoDetalle_Factura()
        {
            return View(_detalle_factura.getAll());
        }
        public ActionResult ListadoDetalle_Lista()
        {
            return View(_detalle_lista.getAll());
        }
        public ActionResult ListadoDocumento()
        {
            return View(_documento.getAll());
        }
        public ActionResult ListadoEmpleado()
        {
            return View(_empleado.getAll());
        }
        public ActionResult ListadoEmpresa()
        {
            return View(_empresa.getAll());
        }
        public ActionResult ListadoFactura()
        {
            return View(_factura.getAll());
        }
        public ActionResult ListadoImpresion()
        {
            return View(_impresion.getAll());
        }
        public ActionResult ListadoLibro()
        {
            return View(_libro.getAll());
        }
        public ActionResult ListadoLista()
        {
            return View(_lista.getAll());
        }
        public ActionResult ListadoMaterial()
        {
            return View(_material.getAll());
        }
        public ActionResult ListadoPrograma()
        {
            return View(_programa.getAll());
        }
        public ActionResult ListadoRecibo()
        {
            return View(_recibo.getAll());
        }
        public ActionResult ListadoTransporte()
        {
            return View(_transporte.getAll());
        }
    }

}