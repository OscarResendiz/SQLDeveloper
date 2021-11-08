using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorManager;
using Modelador.Modelo;
using Modelador.Dibujable;

namespace Modelador.UI
{
    public partial class Lienzo : EditorGenerico
    {
        private ModeloDatos FModelo;
        public Lienzo()
        {
            InitializeComponent();
            prueba();
        }
        public ModeloDatos Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if(FModelo!=null)
                {
                    FModelo.OnFileNameChange += new DelegateModeloEvent(Modelo_FileNameChange);
                    controlDibujable1.Modelo = FModelo;
                    controlDibujable1.InicializaComponentes();
                    controladorCapas1.Modelo = FModelo;
                }
            }
        }
        private void Modelo_FileNameChange(ModeloDatos modelo)
        {
            PageText = modelo.getNombreCorto();
        }
        private void prueba()
        {
            CheckBox cb = new CheckBox();
            cb.Text = "Cuadricula";
            cb.Checked = true;
            cb.Height = 50;
            cb.CheckStateChanged += new EventHandler(ActivarCuadricula);
            ToolStripControlHost host = new ToolStripControlHost(cb);
            toolStrip1.Items.Insert(0, host);
        }
        private void ActivarCuadricula(object sender, EventArgs arg)
        {
            CheckBox cb = (CheckBox)sender;
            controlDibujable1.MostrarCuadricula = cb.Checked;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            controlDibujable1.HScroolValue = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            controlDibujable1.VScroolValue = e.NewValue;

        }
        protected override bool GetGuardado()
        {
            return !Modelo.Modificado;
        }
        public override void Guardar()
        {
            Modelo.Guardar();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modelo.Modificado)
                {
                    if (MessageBox.Show("Desea guardar los cambios", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BGuardar_Click(null, null);
                    }
                }
                //mando a crear el archivo
                Modelo.Nuevo();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Archivo de Modelo|*.Mdl";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                BNuevo_Click(null, null);
                Modelo.Abrir(dlg.FileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modelo.FileName.Trim() == "")
                {
                    BguardarComo_Click(null, null);
                    return;
                }
                Modelo.Guardar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BguardarComo_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivo de Modelo|*.Mdl";
            dlg.FileName = Modelo.FileName;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Modelo.FileName = dlg.FileName;
            Modelo.Guardar();
        }
    }
}
