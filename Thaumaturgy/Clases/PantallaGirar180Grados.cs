using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    public class PantallaGirar180Grados:AccionBase, IEscribible
    {
        public PantallaGirar180Grados()
        {

        }

        #region Miembros de IEscribible

        string IEscribible.Escribir()
        {
            return "PantallaGirar180Grados();";
        }

        string IEscribible.ToStringProps()
        {
            return "";
        }

        #endregion

        public override string ToString()
        {
            return "Girar pantalla 180 grados";
        }

        public override AccionBase Clonar()
        {
            return new PantallaGirar180Grados();
        }
    }
}
