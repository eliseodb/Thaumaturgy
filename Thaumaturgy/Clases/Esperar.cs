using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Thaumaturgy.Clases
{
    public class Esperar : AccionBase, IEscribible
    {
        [DisplayName("Frames")]
        [Description("Cantidad de frames que se dejarán correr antes de pasar a la próxima acción (60 frames = 1 segundo)")]
        public string Frames { get; set; }

        public Esperar()
        {

        }

        public Esperar(string frames)
        {
            this.Frames = frames;
        }

        public Esperar(int frames)
        {
            this.Frames = frames.ToString();
        }

        // Deep copy
        public Esperar(Esperar o)
        {
            this.Frames = o.Frames;
        }

        #region Miembros de IEscribible

        public string Escribir()
        {
            return "wait(" + Frames.ToString() + ");";
        }

        #endregion

        public override string ToString()
        {
            return "Esperar";
        }

        public string ToStringProps()
        {
            return Frames;
        }

        public override AccionBase Clonar()
        {
            Esperar o = new Esperar();
            o.Frames = Frames;
            return o;
        }
    }
}
