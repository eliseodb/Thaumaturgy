using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thaumaturgy.Clases
{
    class Config
    {
        public static string ScriptDirectory { get; set; }
        public static string DMFPath { get; set; }

        public static void Traer()
        {
            ScriptDirectory = @"dmf\\script\\ExRumia\";
            DMFPath = "dmf\\th_dnh.exe";
        }
    }
}
