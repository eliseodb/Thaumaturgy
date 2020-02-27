using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Thaumaturgy.Clases
{
    [Serializable()]
    [XmlInclude(typeof(CirculoShotA1))]
    [XmlInclude(typeof(Esperar))]
    [XmlInclude(typeof(MoverJefe))]
    [XmlInclude(typeof(ShotA1))]
    [XmlInclude(typeof(EspejoHorizontal))]
    [XmlInclude(typeof(EspejoVertical))]
    [XmlInclude(typeof(PantallaGirar180Grados))]
    [XmlInclude(typeof(LineaEnBlanco))]
    [XmlInclude(typeof(Comentario))]
    public class AccionBase
    {
        public virtual AccionBase Clonar()
        {
            return (AccionBase)this.MemberwiseClone();
        }
    }
}
