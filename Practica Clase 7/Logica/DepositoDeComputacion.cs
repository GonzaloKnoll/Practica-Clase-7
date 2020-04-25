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
        public List<ElementoDeComputacion> Productos { get; set; }

        private DepositoDeComputacion()
        {

        }

        public static DepositoDeComputacion Instance { get
            {
                if (instance==null)
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
            Productos.Add(nuevoMonitor);
        }

        public void AgregarProducto (string modelo, string marca, int numerodeserie, string descripcionprocesador, MemoriaRAM memoriaram, string fabricante)
        {
            Computadora nuevaComputadora = new Computadora();
            nuevaComputadora.CargarDatos(modelo, marca, numerodeserie, descripcionprocesador, memoriaram, fabricante);
            Productos.Add(nuevaComputadora);
        }

        public bool EliminarProducto (string identificador)
        {
            ElementoDeComputacion productoencontrado = Productos.Find(x => x.Identificador == identificador);
            if (productoencontrado!=null)
            {
                Productos.Remove(productoencontrado);
                return true;
            }
            return false;
        }
    }
}
