using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    class SpellcardsEjemploFactory
    {
        public static List<IEscribible> SpellDeSakuya()
        {
            List<IEscribible> lista = new List<IEscribible>();

            lista.Add(new MoverJefe("50", "430", "60"));
            lista.Add(new CirculoShotA1("", "", "2", "", "32", ShotGraphics.DS_KNIFE_KOUMA_BLUE, "10", 12, 3));
            lista.Add(new MoverJefe("210", "50", "60"));
            lista.Add(new Esperar(120));
            lista.Add(new MoverJefe("430", "430", "60"));
            lista.Add(new CirculoShotA1("", "", "2", "", "60", ShotGraphics.DS_KUNAI_RED, "10", 12, 3));
            lista.Add(new MoverJefe("210", "50", "60"));
            lista.Add(new Esperar(120));
            lista.Add(new CirculoShotA1("", "", "2", "", "32", ShotGraphics.DS_BALL_L_RED, "10", 5, 15));

            return lista;
        }

        public static List<IEscribible> NonSpellDeUtsuho()
        {
            List<IEscribible> lista = new List<IEscribible>();

            lista.Add(new CirculoShotA1("", "", "5", "0", "80", ShotGraphics.DS_BALL_S_A_YELLOW, "10", 60, 2));
            lista.Add(new Esperar(60));

            return lista;
        }
    }
}
