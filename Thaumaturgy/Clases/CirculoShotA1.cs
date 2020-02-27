using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Thaumaturgy.Clases
{
    public class CirculoShotA1 : ShotA1, IEscribible
    {
        [DisplayName("Cantidad de balas")]
        [Description("Cantidad de balas que componen el círculo.")]
        [Category("Comportamiento")]
        public string CantidadBalas { get; set; }

        [DisplayName("Velocidad angular")]
        [Description("Velocidad de rotación del círuclo (solo tiene efecto cuando hay repeticiones). Probar con valores entre 0 y 10. Pueden ser decimales, con punto (no usar coma).")]
        [Category("Comportamiento")]
        public string AngularSpeed { get; set; }

        [DisplayName("Cantidad de repeticiones")]
        [Description("Cantidad de repeticiones del círculo.")]
        [Category("Repetición")]
        public int Repeticiones { get; set; }

        [DisplayName("Intervalo de repetición")]
        [Description("Cantidad de frames que pasan entre una repetición y otra.")]
        [Category("Repetición")]
        public int IntervaloRepeticiones { get; set; }

        [DisplayName("Apuntar al jugador")]
        [Description("Si está en true, las balas apuntan siempre al jugador (ignoran la dirección establecida).")]
        [Category("Comportamiento")]
        public bool ApuntarAlJugador { get; set; }

        [DisplayName("Disparar desde el jefe")]
        [Description("Si está en true, las balas saldrán disparadas siempre desde el jefe (ignora la posición X e Y que se establezca).")]
        [Category("Comportamiento")]
        public bool DispararDesdeElJefe { get; set; }

        public CirculoShotA1()
        {
            DefaultX = "200";
            DefaultY = "210";
            DefaultDirection = "0";
            Repeticiones = 1;
            IntervaloRepeticiones = 10;

            RandomX = 0;
            RandomY = 0;
            RandomDirection = "0";
            RandomSpeed = "0";
            AngularSpeed = "0";

            ApuntarAlJugador = true;
            DispararDesdeElJefe = true;
        }

        public CirculoShotA1(string x, string y, string speed, string direction, string cantidad, ShotGraphics graphic, string delay)
        {
            DefaultX = "ObjMove_GetX(objEnemy)";
            DefaultY = "ObjMove_GetY(objEnemy)";
            DefaultDirection = "GetAngleToPlayer(objEnemy)";
            Repeticiones = 0;
            IntervaloRepeticiones = 10;

            RandomX = 0;
            RandomY = 0;
            RandomDirection = "0";
            RandomSpeed = "0";
            AngularSpeed = "0";

            ApuntarAlJugador = true;
            DispararDesdeElJefe = true;

            X = x;
            Y = y;
            Speed = speed;
            Direction = direction;
            CantidadBalas = cantidad;
            Graphic = graphic;
            Delay = delay;
        }

        public CirculoShotA1(string x, string y, string speed, string direction, string cantidad, ShotGraphics graphic, string delay, int repeticiones, int intervaloRepeticiones)
        {
            DefaultX = "ObjMove_GetX(objEnemy)";
            DefaultY = "ObjMove_GetY(objEnemy)";
            DefaultDirection = "GetAngleToPlayer(objEnemy)";

            RandomX = 0;
            RandomY = 0;
            RandomDirection = "0";
            RandomSpeed = "0";
            AngularSpeed = "0";

            ApuntarAlJugador = true;
            DispararDesdeElJefe = true;

            X = x;
            Y = y;
            Speed = speed;
            Direction = direction;
            CantidadBalas = cantidad;
            Graphic = graphic;
            Delay = delay;
            Repeticiones = repeticiones;
            IntervaloRepeticiones = intervaloRepeticiones;
        }

        #region Miembros de IEscribible

        string IEscribible.Escribir()
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

            if (Repeticiones < 1)
            {
                Repeticiones = 1;
            }

            string xMostrar = X;
            string yMostrar = Y;
            string speedMostrar = Speed;
            string directionMostrar = Direction;

            string a = "TCirculoShotA1(<X>, <Y>, <SPEED>, <DIRECTION>, <GRAPHIC>, <DELAY>, <CANTIDADBALAS>, <REPETICIONES>, <INTERVALOREPETICIONES>, <RANDOMX>, <RANDOMY>, <RANDOMSPEED>, <RANDOMDIRECTION>, <ANGULARSPEED>, <APUNTARALJUGADOR>, <DISPARARDESDEELJEFE>);";

            a = a.Replace("<REPETICIONES>", Repeticiones.ToString());
            a = a.Replace("<INTERVALOREPETICIONES>", IntervaloRepeticiones.ToString());
            a = a.Replace("<CANTIDADBALAS>", CantidadBalas);
            a = a.Replace("<X>", xMostrar);
            a = a.Replace("<Y>", yMostrar);
            a = a.Replace("<SPEED>", speedMostrar);
            a = a.Replace("<DIRECTION>", directionMostrar);
            a = a.Replace("<GRAPHIC>", Graphic.ToString());
            a = a.Replace("<DELAY>", Delay);
            a = a.Replace("<RANDOMX>", RandomX.ToString());
            a = a.Replace("<RANDOMY>", RandomY.ToString());
            a = a.Replace("<RANDOMSPEED>", RandomSpeed.ToString());
            a = a.Replace("<RANDOMDIRECTION>", RandomDirection.ToString());
            a = a.Replace("<ANGULARSPEED>", AngularSpeed.ToString());
            a = a.Replace("<APUNTARALJUGADOR>", FuncionesGenerales.BoolToString(ApuntarAlJugador));
            a = a.Replace("<DISPARARDESDEELJEFE>", FuncionesGenerales.BoolToString(DispararDesdeElJefe));

//            if (Repeticiones > 1)
//            {
//                a = a.Replace("<HAYINTERVALO>", "wait(" + IntervaloRepeticiones.ToString() + @");
//");
//            }
//            else
//            {
//                a = a.Replace("<HAYINTERVALO>", "");
//            }

            return a;
        }

        string IEscribible.ToStringProps()
        {
            return X + ", " + Y + ", " + Speed + ", " + Direction + ", " + CantidadBalas + ", " + Graphic + ", " + Delay;
        }

        #endregion

        public override string ToString()
        {
            return "Círculo ShotA1";
        }

        public override AccionBase Clonar()
        {
            CirculoShotA1 o = new CirculoShotA1();
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
            o.CantidadBalas = CantidadBalas;
            o.AngularSpeed = AngularSpeed;
            o.Repeticiones = Repeticiones;
            o.IntervaloRepeticiones = IntervaloRepeticiones;
            o.ApuntarAlJugador = ApuntarAlJugador;
            o.DispararDesdeElJefe = DispararDesdeElJefe;
            return o;
        }
    }
}
