using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    public class EspejoHorizontal:AccionBase, IEscribible
    {
        public EspejoHorizontal()
        {

        }

        #region Miembros de IEscribible

        string IEscribible.Escribir()
        {
            return @"EspejoHorizontal();
";
        }

        string IEscribible.ToStringProps()
        {
            return "";
        }

        #endregion

        public override string ToString()
        {
            return "Espejo horizontal";
        }

        public override AccionBase Clonar()
        {
            return new EspejoHorizontal();
        }
    }
}
