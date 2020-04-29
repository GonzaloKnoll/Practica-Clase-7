using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class InfoProductoArgs : EventArgs
    {
        public string Tipo { get; set; }
        public string Identificador { get; set; }
        public string Operacion { get; set; }

        /// <summary>
        /// Esto les permite retornar todo el objeto como argumento del evento. A futuro si tuvieran otras subclases no tendrian que modificar el codigo.
        /// </summary>
        /// <param name="productoAgregado"></param>
        //public InfoProductoArgs(ElementoDeComputacion productoAgregado)
        //{
        //    this.ProductoAgregado = productoAgregado;
        //}
    }
}
