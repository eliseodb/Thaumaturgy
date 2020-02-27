using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    public class Comentario : AccionBase, IEscribible
    {
        public string Texto { get; set; }

        public Comentario()
        {

        }

        public Comentario(string texto)
        {
            Texto = texto;
        }

        

        public override string ToString()
        {
            return "------------";
        }

        public override AccionBase Clonar()
        {
            return new Comentario(Texto);
        }



        #region Miembros de IEscribible

        public string Escribir()
        {
            return "";
        }

        public string ToStringProps()
        {
            return Texto;
        }

        #endregion
    }
}
