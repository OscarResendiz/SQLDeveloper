using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    public partial class FormEliminarCadenas : Form
    {
        private ObjetosModelo.AppModel Modelo;
        List< ObjetosModelo.CLineaArchivo >Seleccionados;
        private int ID_Archivo;
        private int Eliminados;
        public FormEliminarCadenas(ObjetosModelo.AppModel modelo, int id_archivo)
        {
            InitializeComponent();
            Modelo = modelo;
            ID_Archivo = id_archivo;
        }

        private void FormEliminarCadenas_Load(object sender, EventArgs e)
        {
            if (ID_Archivo == -1)
            {
                CargaCadenasDiferentes();
                BEliminarArchivos.Visible = false;
                //cambio el evento
                this.BElimnar.Click -= new System.EventHandler(this.button3_Click);
                this.BElimnar.Click += new System.EventHandler(this.button2_Click);


            }
            else
            {
                //cargo las cadenas
                List<ObjetosModelo.CLineaArchivo> l = Modelo.GetLineasArchivo(ID_Archivo);
                foreach (ObjetosModelo.CLineaArchivo obj in l)
                {
                    Lista.Items.Add(obj);
                }
            }
        }
        private void CargaCadenasDiferentes()
        {
            //me traigo todas las lineas
            List<ObjetosModelo.CLineaArchivo> l = Modelo.GetAllLineasArchivo();
            Lista.Items.Clear();
            Lista.Items.Add(new ObjetosModelo.CLineaArchivo()
            {
                ID_Archivo = -1,
                ID_Linea = -1
                   ,
                Texto = "Seleccionar todos"
                   ,
                IdObjeto = -1
                   ,
                Modelo = null
            });
            foreach (ObjetosModelo.CLineaArchivo obj in l)
            {
                //verifico si no esta repetida
                if (TFiltro.Text.Trim() == "" || obj.Texto.ToUpper().Trim().Contains(TFiltro.Text.ToUpper().Trim()))
                {
                    bool encontrado = false;
                    foreach (ObjetosModelo.CLineaArchivo a in Lista.Items)
                    {
                        if (a.Texto == obj.Texto)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == false)
                    {
                        Lista.Items.Add(obj);
                    }
                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Seleccionados = new List<ObjetosModelo.CLineaArchivo>();
            foreach (ObjetosModelo.CLineaArchivo obj in Lista.CheckedItems)
            {
                if (obj.Modelo != null)
                {
                    Seleccionados.Add(obj);
                }
            }

            progressBar1.Maximum = Seleccionados.Count();
            BElimnar.Enabled = false;
            BEliminarArchivos.Enabled = false;
            BSalir.Enabled = false;
            Lista.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int n = Seleccionados.Count();
            for (int i = n - 1; i >= 0; i--)
            {
                ObjetosModelo.CLineaArchivo obj = Seleccionados[i];            
                obj.delete(false);
                backgroundWorker1.ReportProgress(n - i, obj);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            ObjetosModelo.CLineaArchivo obj = (ObjetosModelo.CLineaArchivo)e.UserState;
            Lista.Items.Remove(obj);
            Modelo.ReportaDeleteLineaArchivo(obj);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BElimnar.Enabled = true;
            BEliminarArchivos.Enabled = true;
            BSalir.Enabled = true;
            Lista.Enabled = true;

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Eliminados = 0;
            Seleccionados = new List<ObjetosModelo.CLineaArchivo>();
            foreach (ObjetosModelo.CLineaArchivo obj in Lista.CheckedItems)
            {
                if (obj.Modelo != null)
                {
                    Seleccionados.Add(obj);
                }
            }

            progressBar1.Maximum = Seleccionados.Count();
            BElimnar.Enabled = false;
            BEliminarArchivos.Enabled = false;
            BSalir.Enabled = false;
            Lista.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            ObjetosModelo.CLineaArchivo obj = (ObjetosModelo.CLineaArchivo)e.UserState;
            Modelo.ReportaDeleteLineaArchivo(obj);
            foreach (ObjetosModelo.CLineaArchivo obj2 in Lista.Items)
            {
                if(obj.ID_Linea==obj2.ID_Linea)
                {
                    Lista.Items.Remove(obj2);
                    return;
                }
            }

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int n = Seleccionados.Count();
            for (int i = n - 1; i >= 0; i--)
            {
                ObjetosModelo.CLineaArchivo obj = Seleccionados[i];
                List<ObjetosModelo.CLineaArchivo> l = Modelo.GetCoincidenciasLineaArchivos(obj.Texto);
                foreach (ObjetosModelo.CLineaArchivo obj2 in l)
                {
                    Eliminados++;
                    obj2.delete(false);
                    backgroundWorker2.ReportProgress(n - i, obj2);
                }
            }


        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Se eliminaron " + Eliminados.ToString() + " cadenas", "Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BElimnar.Enabled = true;
            BEliminarArchivos.Enabled = true;
            BSalir.Enabled = true;
            Lista.Enabled = true;
        }

        private void BFiltro_Click(object sender, EventArgs e)
        {
            CargaCadenasDiferentes();
        }

        private void Lista_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                bool estado = Lista.GetItemCheckState(e.Index) == CheckState.Checked;
                for (int i = 0; i < Lista.Items.Count; i++)
                {
                    if (i != 0)
                    {
                        Lista.SetItemChecked(i, !estado);
                    }
                }
            }
        }
    }
}
   