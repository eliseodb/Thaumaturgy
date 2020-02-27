using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Thaumaturgy.Clases
{

    public class ShotA1 : AccionBase, IEscribible
    {
        [Description("Coordenada X de la bala. Si se deja en blanco, la bala saldrá desde el jefe.")]
        [Category("Posición")]
        public string X { get; set; }

        [Description("Coordenada Y de la bala. Si se deja en blanco, la bala saldrá desde el jefe.")]
        [Category("Posición")]
        public string Y { get; set; }

        [DisplayName("Velocidad")]
        [Category("Comportamiento")]
        [Description("Velocidad con que la bala es disparada. Valores mayores a 6 son demasiado.")] 
        public string Speed { get; set; }

        [DisplayName("Dirección")]
        [Category("Comportamiento")]
        [Description("Dirección a la que apunta la bala. Ingresar un valor de 0 a 360. 0=derecha, 90=abajo, 180=izquierda, 270=arriba. Si se deja en blanco, apuntará al jugador.")] 
        public string Direction { get; set; }

        [DisplayName("Gráfico")]
        [Category("Apariencia")]
        [Description("Gráfico de la bala.")] 
        public ShotGraphics Graphic { get; set; }

        [DisplayName("Retraso")]
        [Category("Comportamiento")]
        [Description("Cantidad de frames que tarda la bala en dispararse (60 frames = 1 segundo)")] 
        public string Delay { get; set; }

        [DisplayName("Aleatorización de X")]
        [Category("Variación")]
        [Description("Cantidad máxima de píxeles que puede desviarse la coordenada X de manera aleatoria. Se aconseja un valor no mayor a 200, ya que las balas podrían salirse de la pantalla.")] 
        public int RandomX { get; set; }

        [DisplayName("Aleatorización de Y")]
        [Category("Variación")]
        [Description("Cantidad máxima de píxeles que puede desviarse la coordenada Y de manera aleatoria. Se aconseja un valor no mayor a 225, ya que las balas podrían salirse de la pantalla.")]
        public int RandomY { get; set; }

        [DisplayName("Aleatorización de dirección")]
        [Category("Variación")]
        [Description("Cantidad máxima de grados en que puede variar la dirección de manera aleatoria.")]
        public string RandomDirection { get; set; }

        [DisplayName("Aleatorización de velocidad")]
        [Category("Variación")]
        [Description("Establece cuánto puede variar la velocidad de manera aleatoria. Se aconseja no poner valores mayores a 3. Pueden ser decimales, usando punto como separador decimal (no usar coma).")]
        public string RandomSpeed { get; set; }

        [Browsable(false)]
        public string DefaultX { get; set; }
        [Browsable(false)]
        public string DefaultY { get; set; }
        [Browsable(false)]
        public string DefaultDirection { get; set; }

        public ShotA1()
        {
            DefaultX = "ObjMove_GetX(objEnemy)";
            DefaultY = "ObjMove_GetY(objEnemy)";
            DefaultDirection = "GetAngleToPlayer(objEnemy)";

            RandomX = 0;
            RandomY = 0;
            RandomDirection = "0";
            RandomSpeed = "0";
        }

        public ShotA1(string x, string y, string speed, string direction, ShotGraphics graphic, string delay)
        {
            DefaultX = "ObjMove_GetX(objEnemy)";
            DefaultY = "ObjMove_GetY(objEnemy)";
            DefaultDirection = "GetAngleToPlayer(objEnemy)";

            RandomX = 0;
            RandomY = 0;
            RandomDirection = "0";
            RandomSpeed = "0";

            X = x;
            Y = y;
            Speed = speed;
            Direction = direction;
            Graphic = graphic;
            Delay = delay;
        }

        #region Miembros de IEscribible

        public string Escribir()
        {
            if (X.Trim() == "")
            {
                X = DefaultX;
            }

            if (Y.Trim() == "")
            {
                Y = DefaultY;
            }

            if (Direction.Trim() == "")
            {
                Direction = DefaultDirection;
            }

            string xMostrar = X + "+rand("+(RandomX*-1).ToString()+","+RandomX.ToString()+")";
            string yMostrar = Y + "+rand(" + (RandomY * -1).ToString() + "," + RandomY.ToString() + ")";
            string speedMostrar = Speed + "+rand(-" + (RandomSpeed).ToString() + "," + RandomSpeed.ToString() + ")";
            string directionMostrar = Direction + "+rand(-" + (RandomDirection).ToString() + "," + RandomDirection.ToString() + ")";

            return "CreateShotA1(" + xMostrar + ", " + yMostrar + ", " + speedMostrar + ", " + directionMostrar + ", " + Graphic + ", " + Delay + ");";
        }

        #endregion

        public override string ToString()
        {
            return "Disparo ShotA1";
        }

        #region Miembros de IEscribible


        public string ToStringProps()
        {
            return X + ", " + Y + ", " + Speed + ", " + Direction + ", " + Graphic + ", " + Delay;
        }

        #endregion

        public override AccionBase Clonar()
        {
            ShotA1 o = new ShotA1();
            o.X = X;
            o.Y = Y;
            o.Speed = Speed;
            o.Direction = Direction;
            o.Graphic = Graphic;
            o.Delay = Delay;
            o.RandomX = RandomX;
            o.RandomY = RandomY;
            o.RandomDirection = RandomDirection;
            o.RandomSpeed = RandomSpeed;
            o.DefaultX = DefaultX;
            o.DefaultY = DefaultY;
            o.DefaultDirection = DefaultDirection;
            return o;
        }
    }
}
