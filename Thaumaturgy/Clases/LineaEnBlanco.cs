using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    public class LineaEnBlanco:AccionBase, IEscribible
    {
        public LineaEnBlanco()
        {

        }

        #region Miembros de IEscribible

        public string Escribir()
        {
            return "";
        }

        public string ToStringProps()
        {
            return "";
        }

        #endregion

        public override string ToString()
        {
            return "";
        }

        public override AccionBase Clonar()
        {
            return new LineaEnBlanco();
        }
    }
}
