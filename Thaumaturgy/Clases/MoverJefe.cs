using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Thaumaturgy.Clases
{
    public class MoverJefe:AccionBase, IEscribible
    {
        [Description("Coordenada X de destino.")]
        public string X { get; set; }

        [Description("Coordenada Y de destino.")]
        public string Y { get; set; }

        [DisplayName("Frames")]
        [Description("Cantidad de frames que tardará en moverse (60 frames = 1 segundo)")]
        public string Frames { get; set; }

        public MoverJefe()
        {

        }

        public MoverJefe(string x, string y, string frames)
        {
            X = x;
            Y = y;
            Frames = frames;
        }

        public MoverJefe(MoverJefe o)
        {
            X = o.X;
            Y = o.Y;
            Frames = o.Frames;
        }

        #region Miembros de IEscribible

        public string Escribir()
        {
            string a = @"ObjMove_SetDestAtFrame(objEnemy, <X>, <Y>, <FRAMES>);
            ";

            a = a.Replace("<X>", X);
            a = a.Replace("<Y>", Y);
            a = a.Replace("<FRAMES>", Frames);

            return a;
        }

        public string ToStringProps()
        {
            return X + ";" + Y + " en " + Frames + " frames";
        }

        #endregion

        public override string ToString()
        {
            return "Mover jefe";
        }

        public override AccionBase Clonar()
        {
            MoverJefe o = new MoverJefe();
            o.X = X;
            o.Y = Y;
            o.Frames = Frames;
            return o;
        }
    }
}
