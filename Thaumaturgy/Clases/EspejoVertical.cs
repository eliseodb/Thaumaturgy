using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    public class EspejoVertical:AccionBase, IEscribible
    {
        public EspejoVertical()
        {

        }

        #region Miembros de IEscribible

        string IEscribible.Escribir()
        {
            return @"EspejoVertical();
            ";
        }

        string IEscribible.ToStringProps()
        {
            return "";
        }

        #endregion

        public override string ToString()
        {
            return "Espejo vertical";
        }

        public override AccionBase Clonar()
        {
            return new EspejoVertical();
        }
    }
}
