using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Thaumaturgy.Clases
{
    public class Spellcard:AccionBase, IEscribible
    {
        [XmlIgnore]
        public List<IEscribible> Items { get; set; }

        public List<AccionBase> ItemsSerializable { get; set; }

        public Spellcard()
        {
            Items = new List<IEscribible>();
            ItemsSerializable = new List<AccionBase>();
        }

        public void PrepararParaSerializar()
        {
            ItemsSerializable.Clear();

            foreach (IEscribible item in Items)
            {
                AccionBase accion = (AccionBase)item;
                ItemsSerializable.Add(accion);
            }
        }

        public void PasarDeserializacionAListaInterfaz()
        {
            Items.Clear();

            foreach (AccionBase item in ItemsSerializable)
            {
                IEscribible accion = (IEscribible)item;
                Items.Add(accion);
            }
        }

        #region Miembros de IEscribible

        public string Escribir()
        {
            StreamReader reader = new StreamReader("plantilla.txt");
            String plantilla = reader.ReadToEnd();
            reader.Close();

            String itemsEscritos = "";
            foreach (IEscribible item in Items)
            {
                itemsEscritos += item.Escribir() + @"
";
            }

            String spell = plantilla.Replace("/**ITEMS*/", itemsEscritos);

            return spell;
        }

        #endregion

        #region Miembros de IEscribible


        public string ToStringProps()
        {
            return "";
        }

        #endregion
    }
}
