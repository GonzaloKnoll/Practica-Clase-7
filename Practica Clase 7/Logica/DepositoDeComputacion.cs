using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public sealed class DepositoDeComputacion
    {
        private static DepositoDeComputacion instance = null;
        public List<Monitor> Monitores { get; set; }
        public List<Computadora> Computadoras { get; set; }
        public EventHandler<InfoProductoArgs> ProductoAgregado_Eliminado;

        private DepositoDeComputacion()
        {
            Monitores = new List<Monitor>();
            Computadoras = new List<Computadora>();
        }

        public static DepositoDeComputacion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DepositoDeComputacion();
                }
                return instance;
            }
        }

        public void AgregarProducto(string modelo, string marca, int numerodeserie, short anodefabricacion, Nullable<int> pulgadas)
        {
            Monitor nuevoMonitor = new Monitor();
            nuevoMonitor.CargarDatos(modelo, marca, numerodeserie, anodefabricacion, pulgadas);
            Monitores.Add(nuevoMonitor);
            this.ProductoAgregado_Eliminado(this, new InfoProductoArgs()
            {
                Tipo = "Monitor",
                Identificador = nuevoMonitor.Identificador,
                Operacion = "Agregado"
            });
        }

        public void AgregarProducto(string modelo, string marca, int numerodeserie, string descripcionprocesador, MemoriaRAM memoriaram, string fabricante)
        {
            Computadora nuevaComputadora = new Computadora();
            nuevaComputadora.CargarDatos(modelo, marca, numerodeserie, descripcionprocesador, memoriaram, fabricante);
            Computadoras.Add(nuevaComputadora);
            this.ProductoAgregado_Eliminado(this, new InfoProductoArgs()
            {
                Tipo = "Computadora",
                Identificador = nuevaComputadora.Identificador,
                Operacion = "Agregado"
            });
        }

        public bool EliminarProducto(string identificador)
        {
            List<ElementoDeComputacion> productos = ObtenerListaUnicaProductos();
            ElementoDeComputacion productoaeliminar = productos.Find(x => x.Identificador == identificador);
            string tipoproducto;
            if (productoaeliminar != null)
            {
                if (productoaeliminar is Monitor)
                {
                    Monitores.Remove(productoaeliminar as Monitor);
                    tipoproducto = "Monitor";
                }
                else
                {
                    Computadoras.Remove(productoaeliminar as Computadora);
                    tipoproducto = "Computadora";
                }
                this.ProductoAgregado_Eliminado(this, new InfoProductoArgs()
                {
                    Tipo = tipoproducto,
                    Identificador = productoaeliminar.Identificador,
                    Operacion = "Eliminado"
                });
                return true;
            }
            return false;
        }

        public List<ElementoDeComputacion> ObtenerListaUnicaProductos()
        {
            List<ElementoDeComputacion> productos = new List<ElementoDeComputacion>();
            productos.AddRange(Monitores);
            productos.AddRange(Computadoras);

            //Falta ordenar 

            return productos;
        }

        public string ObtenerDescripcionProducto(ElementoDeComputacion producto)
        {
            //return producto.ObtenerDescripcion(); //Es suficiente.

            if (producto is Monitor)
            {
                return (producto as Monitor).ObtenerDescripcion();
            }
            return (producto as Computadora).ObtenerDescripcion();
        }
    }
}
