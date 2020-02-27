using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Thaumaturgy.Clases;

namespace Thaumaturgy
{
    public partial class Form1 : Form
    {
        private PropertyGrid Propiedades = new PropertyGrid();
        private Spellcard sc = new Spellcard();
        private List<string> lista = new List<string>();

        private int dragIndex = 0;
        private ListViewItem dragItem = null;

        private ListViewItem portapapeles = null;
        private AccionBase portapapeles2 = null;

        private string openFilePath = "";

        private bool primeraVez = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TxtSpell.Visible = false;
            Config.Traer();

            Propiedades.Location = new Point(10, 10);
            Propiedades.Size = new Size(200, 400);
            Propiedades.Dock = DockStyle.Fill;
            Propiedades.ToolbarVisible = false;
            this.Controls.Add(Propiedades);
            ChangeDescriptionHeight(Propiedades, 100);
            splitContainer1.Panel2.Controls.Add(Propiedades);

            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            this.Text = Application.ProductName;
            

            //Spellcard sc = new Spellcard();
            //sc.Items.Add(new Esperar(60));
            //sc.Items.Add(new ShotA1("40", "40", "2", "90", "DS_BALL_M_BLUE", "10"));

            //TxtSpell.Text = sc.Escribir();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            sc.Items.Clear();
            foreach (ListViewItem i in LstItems.Items)
            {
                sc.Items.Add((IEscribible) i.Tag);
            }

            TxtSpell.Text = sc.Escribir();

            StreamWriter writer = new StreamWriter(Config.ScriptDirectory + @"\PruebaThaumaturgy.txt");
            writer.Write(TxtSpell.Text);
            writer.Close();
        }

        private void LstItems_Click(object sender, EventArgs e)
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                Propiedades.SelectedObject = LstItems.SelectedItems[0].Tag;
            }
        }

        private void LstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarProps();
        }

        private void LstItems_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (LstItems.SelectedItems.Count > 0)
                {
                    LstItems.Items.Remove(LstItems.SelectedItems[0]);
                }
            }
        }

        private void ActualizarProps()
        {
            // Actualizar las props
            for (int i = 0; i < LstItems.Items.Count; i++)
            {
                IEscribible tag = (IEscribible)LstItems.Items[i].Tag;
                LstItems.Items[i].SubItems[1].Text = tag.ToStringProps();
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frm = new FrmAcercaDe();
            frm.ShowDialog();

            /*MessageBox.Show(@"Thaumaturgy

Versión: 0.0.1
Copyright 2015, ", "Acerca de Thaumaturgy", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
        }

        private void AgregarItemDebajoDelSeleccionado(ListViewItem item)
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                // traer el indice del item seleccionado
                int indice = LstItems.SelectedIndices[0];
                LstItems.Items.Insert(indice+1, item);

                LstItems.Items[indice + 1].Focused = true;
                LstItems.Items[indice + 1].Selected = true;
            }
            else
            {
                LstItems.Items.Add(item);

                int cantidad = LstItems.Items.Count;
                LstItems.Items[cantidad - 1].Focused = true;
                LstItems.Items[cantidad - 1].Selected = true;
            }       
        }

        private void esperarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esperar i = new Esperar("60");
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add(i.Frames);
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);

            //if (LstItems.SelectedItems.Count > 0)
            //{
            //    // traer el indice del item seleccionado
            //    int indice = LstItems.SelectedIndices[0];
            //    LstItems.Items.Insert(indice, lvi);
            //}
            //else
            //{
            //    LstItems.Items.Add(lvi);
            //}            
            
            ActualizarProps();
        }

        private void disparoShotA1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShotA1 i = new ShotA1("", "", "2", "GetAngleToPlayer(objEnemy)", ShotGraphics.DS_BALL_BS_BLUE, "10");
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add(i.Graphic.ToString());
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
            ActualizarProps();
        }

        private void probarSpellcardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sc.Items.Clear();
            foreach (ListViewItem i in LstItems.Items)
            {
                sc.Items.Add((IEscribible)i.Tag);
            }

            TxtSpell.Text = sc.Escribir();

            StreamWriter writer = new StreamWriter(Config.ScriptDirectory + @"\PruebaThaumaturgy.txt");
            writer.Write(TxtSpell.Text);
            writer.Close();

            string cwd = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            cwd += "\\" + Config.DMFPath;
            System.Diagnostics.Process.Start(cwd);
            //System.Diagnostics.Process.Start(cwd + "\\" + Config.DMFPath);
        }

        private void círculoShotA1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CirculoShotA1 i = new CirculoShotA1("", "", "2", "", "32", ShotGraphics.DS_BALL_BS_BLUE, "10");
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add(i.Graphic.ToString());
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
            ActualizarProps();
        }

        private void moverJefeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoverJefe i = new MoverJefe("200", "200", "60");
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add(i.ToStringProps());
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
            ActualizarProps();
        }



        private void CargarSpellcardDeEjemplo(List<IEscribible> lista)
        {
            LstItems.Items.Clear();

            foreach (IEscribible i in lista)
            {
                ListViewItem lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(i.ToStringProps());
                lvi.Tag = i;

                if (i is LineaEnBlanco)
                {
                    lvi.BackColor = Color.LightGray;
                }
                if (i is Comentario)
                {
                    lvi.BackColor = Color.LightYellow;
                }

                LstItems.Items.Add(lvi);
            }

            ActualizarProps();
        }

        private void spellDeSakuyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarSpellcardDeEjemplo(SpellcardsEjemploFactory.SpellDeSakuya());
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Guardar los cambios realizados?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    guardarToolStripMenuItem_Click(sender, e);
                }

                openFilePath = "";
                LstItems.Items.Clear();
                Propiedades.SelectedObject = null;

                this.Text = Application.ProductName;
            }      
            
        }

        private void nonSpellDeUtsuhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarSpellcardDeEjemplo(SpellcardsEjemploFactory.NonSpellDeUtsuho());
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                Guardar(filename);

                //sc.Items.Clear();
                //foreach (ListViewItem i in LstItems.Items)
                //{
                //    sc.Items.Add((IEscribible)i.Tag);
                //}

                //sc.PrepararParaSerializar();

                //System.Xml.Serialization.XmlSerializer writer =
                //    new System.Xml.Serialization.XmlSerializer(typeof(Spellcard));

                //string path = filename;
                //FileStream file = File.Create(path);

                //writer.Serialize(file, sc);
                //file.Close();

                //openFilePath = filename;
                //LblArchivo.Text = "Archivo actual: " + openFilePath;
            }

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!primeraVez)
            {
                DialogResult result = MessageBox.Show("¿Guardar los cambios realizados?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result != DialogResult.Cancel)
                {
                    if (result == DialogResult.Yes)
                    {
                        guardarToolStripMenuItem_Click(sender, e);
                    }

                    Abrir();

                }
            }
            else
            {
                Abrir();
            }
            
        }

        private void Abrir()
        {
            string filename = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;

                sc = new Spellcard();

                XmlSerializer serializer = new XmlSerializer(typeof(Spellcard));

                StreamReader reader = new StreamReader(filename);
                sc = (Spellcard)serializer.Deserialize(reader);
                reader.Close();

                sc.PasarDeserializacionAListaInterfaz();
                CargarSpellcardDeEjemplo(sc.Items);

                openFilePath = filename;
                this.Text = Path.GetFileName(openFilePath) + " - " + Application.ProductName;

                primeraVez = false;
            }
        }

        private void LstItems_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Link);
        }

        private void LstItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

            Point cp = LstItems.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = LstItems.GetItemAt(cp.X, cp.Y);

            dragIndex = dragToItem.Index;
            dragItem = dragToItem;
        }

        private void LstItems_DragDrop(object sender, DragEventArgs e)
        {
            Point cp = LstItems.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = LstItems.GetItemAt(cp.X, cp.Y);
            int dropIndex = dragToItem.Index;

            IntercambiarItems(dragIndex, dropIndex);

            //MessageBox.Show("Item que arrastramos: " + dragItem.ToString());
            //MessageBox.Show("Indice del item que arrastramos: " + dragIndex);
            //MessageBox.Show("Item destino: " + dragToItem.ToString());
            //MessageBox.Show("Indice destino: " + dropIndex.ToString());
        }

        private void IntercambiarItems(int indice1, int indice2)
        {
            try
            {
                ListViewItem temp = (ListViewItem)LstItems.Items[indice1].Clone();
                LstItems.Items[indice1] = (ListViewItem)LstItems.Items[indice2].Clone();
                LstItems.Items[indice2] = temp;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFilePath == "")
            {
                guardarComoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                Guardar(openFilePath);
            }
        }

        private void Guardar(string path)
        {
            sc.Items.Clear();
            foreach (ListViewItem i in LstItems.Items)
            {
                sc.Items.Add((IEscribible)i.Tag);
            }

            sc.PrepararParaSerializar();

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Spellcard));

            FileStream file = File.Create(path);

            writer.Serialize(file, sc);
            file.Close();

            openFilePath = path;
            this.Text = Path.GetFileName(openFilePath) + " - " + Application.ProductName;

            MessageBox.Show("Archivo guardado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Guardar los cambios realizados?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    guardarToolStripMenuItem_Click(sender, e);
                }

                Application.Exit();

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Guardar los cambios realizados?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    guardarToolStripMenuItem_Click(sender, e);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private static void ChangeDescriptionHeight(PropertyGrid grid, int height)
        {
            if (grid == null) throw new ArgumentNullException("grid");

            foreach (Control control in grid.Controls)
                if (control.GetType().Name == "DocComment")
                {
                    FieldInfo fieldInfo = control.GetType().BaseType.GetField("userSized",
                      BindingFlags.Instance |
                      BindingFlags.NonPublic);
                    fieldInfo.SetValue(control, true);
                    control.Height = height;
                    return;
                }
        }

        private void Copiar()
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                portapapeles2 = (AccionBase)LstItems.SelectedItems[0].Tag;
                portapapeles = new ListViewItem();
                portapapeles.BackColor = LstItems.SelectedItems[0].BackColor;

                //portapapeles = new ListViewItem();
                //portapapeles.Tag = (IEscribible)LstItems.SelectedItems[0].Tag;
            }
        }

        private void Cortar()
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                Copiar();
                LstItems.SelectedItems[0].Remove();
            }
        }

        private void Pegar()
        {
            if (portapapeles2 != null)
            {
                ListViewItem item = new ListViewItem(portapapeles2.ToString());
                item.Tag = portapapeles2.Clonar();
                item.SubItems.Add("");
                item.BackColor = portapapeles.BackColor;
                LstItems.Items.Add(item);

                LstItems.Items[LstItems.Items.Count - 1].Focused = true;
                LstItems.Items[LstItems.Items.Count - 1].Selected = true;

                ActualizarProps();
            }
        }

        private void MoverArriba()
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                int a = LstItems.SelectedItems[0].Index;
                if (a > 0)
                {
                    IntercambiarItems(a, a - 1);

                    LstItems.Items[a - 1].Focused = true;
                    LstItems.Items[a - 1].Selected = true;
                }
            }
        }

        private void MoverAbajo()
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                int a = LstItems.SelectedItems[0].Index;
                if (a < LstItems.Items.Count - 1)
                {
                    IntercambiarItems(a, a + 1);

                    LstItems.Items[a + 1].Focused = true;
                    LstItems.Items[a + 1].Selected = true;
                }
            }
        }

        private void Borrar()
        {
            if (LstItems.SelectedItems.Count > 0)
            {
                LstItems.Items.Remove(LstItems.SelectedItems[0]);
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pegar();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void moverArribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoverArriba();
        }

        private void moverAbajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoverAbajo();
        }

        private void BtnNuevoTool_Click(object sender, EventArgs e)
        {
            nuevoToolStripMenuItem_Click(sender, e);
        }

        private void BtnAbrirTool_Click(object sender, EventArgs e)
        {
            abrirToolStripMenuItem_Click(sender, e);
        }

        private void BtnGuardarTool_Click(object sender, EventArgs e)
        {
            guardarToolStripMenuItem_Click(sender, e);
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cortar();
        }

        private void BtnCortarTool_Click(object sender, EventArgs e)
        {
            Cortar();
        }

        private void BtnCopiarTool_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void BtnPegarTool_Click(object sender, EventArgs e)
        {
            Pegar();
        }

        private void BtnEliminarTool_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void BtnMoverArribaTool_Click(object sender, EventArgs e)
        {
            MoverArriba();
        }

        private void BtnMoverAbajoTool_Click(object sender, EventArgs e)
        {
            MoverAbajo();
        }

        private void BtnJugarTool_Click(object sender, EventArgs e)
        {
            probarSpellcardToolStripMenuItem_Click(sender, e);
        }

        private void espejoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspejoHorizontal i = new EspejoHorizontal();
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add("");
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
        }

        private void espejoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspejoVertical i = new EspejoVertical();
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add("");
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
        }

        private void girarPantalla180GradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaGirar180Grados i = new PantallaGirar180Grados();
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add("");
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
        }

        private void panelDeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtSpell.Visible = panelDeScriptToolStripMenuItem.Checked;
        }

        private void comentarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comentario i = new Comentario();
            
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add(i.ToStringProps());
            lvi.BackColor = Color.LightGoldenrodYellow;
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
            ActualizarProps();
        }

        private void lineaEnBlancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineaEnBlanco i = new LineaEnBlanco();
            ListViewItem lvi = new ListViewItem(i.ToString());
            lvi.SubItems.Add(i.ToStringProps());
            lvi.BackColor = Color.LightGray;
            lvi.Tag = i;
            AgregarItemDebajoDelSeleccionado(lvi);
            ActualizarProps();
        }

    }
}
