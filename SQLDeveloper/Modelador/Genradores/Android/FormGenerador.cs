using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelador.Modelo;

namespace Modelador.Genradores.Android
{
    public partial class FormGenerador : Form
    {
        private Modelo.ModeloDatos Modelo;
        private bool Generando = false;
        List<CTabla> Tablas;
        private string Directorio;
        private string Package;
        private string DataBase;
        CGeneradorKotlin Generador;
        public FormGenerador(Modelo.ModeloDatos modelo)
        {
            Modelo = modelo;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (TDirectorio.Text == "")
                ok = false;
            if(TPackage.Text.Trim() =="")
                ok=false;
            if (TDatabase.Text.Trim() =="")
                ok = false;
            if (Generando == true)
                ok = false;
            BGenerar.Enabled = ok;
            BCerrar.Enabled = !Generando;
        }

        private void BGenerar_Click(object sender, EventArgs e)
        {
            Generando = true;
            Directorio = TDirectorio.Text+"\\DataBase";
            Package = TPackage.Text;
            DataBase = TDatabase.Text;
            Tablas = Modelo.Get_Tablas();
            Progreso.Maximum =Tablas.Count + 2;
            Progreso.Value = 0;
            Generador = new CGeneradorKotlin(Modelo);
            Generador.Package = Package;
            Generador.DataBaseName=DataBase;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int progreso = 0;
            string codigo = "";
            foreach (CTabla tabla in Tablas)
            {
                progreso++;
                codigo = Generador.GeneraIdentidad(tabla);
                CreaArchivo(tabla.Nombre, codigo);
                codigo = Generador.CreaDAO(tabla);
                CreaArchivo("DAO"+tabla.Nombre, codigo);
                backgroundWorker1.ReportProgress(progreso);
            }
            codigo = Generador.CreaDataBase();
            CreaArchivo(DataBase, codigo);
        }
        private void CreaArchivo(string nombre, string Codigo)
        {
            //si no existe el directorio lo crea
            if(System.IO.Directory.Exists(Directorio)==false)
            {
                System.IO.Directory.CreateDirectory(Directorio);
            }
            System.IO.StreamWriter sw = System.IO.File.CreateText(Directorio + "\\" + nombre + ".kt");
            sw.Write(Codigo);
            sw.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value=e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Generando = false;
            Progreso.Value = 0;
            MessageBox.Show("Codigo generado","Generador de codigo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BBucar_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;
            TDirectorio.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
