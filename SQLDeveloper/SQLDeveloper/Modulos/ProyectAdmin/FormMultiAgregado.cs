using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public partial class FormMultiAgregado : Form
    {
        MotorDB.IMotorDB Motor;
        List<string> Lista;
        List<string> NoEncontrados;
        public event MotorDB.OnVerObjetoEvent OnVerMultiObjeto;
        public event MotorDB.OnEventoVacio OnFInMultiObjeto;
        private ManagerConnect.CConexion Conexion;
        public FormMultiAgregado(ManagerConnect.CConexion conexion)
        {
            Conexion = conexion;
            Motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            InitializeComponent();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            BAgregar.Enabled = false;
            Lista = new List<string>();
            NoEncontrados = new List<string>();
            string []l=Texto.Text.Split('\n');
            foreach(string s in l)
            {
                if (s.Trim() != "")
                {
                    Lista.Add(s.Trim());
                }
            }
            progressBar1.Maximum = Lista.Count;
            BKProseso.RunWorkerAsync();
        }

        private void BKProseso_DoWork(object sender, DoWorkEventArgs e)
        {
            int pos = 0;
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //MotorDB.EnumTipoObjeto tipo
            foreach (string nombre in Lista)
            {
                List<MotorDB.CObjeto> l = motor.Buscar(nombre, MotorDB.EnumTipoObjeto.NONE);
                if (l.Count == 0)
                {
                    NoEncontrados.Add(nombre);
                }
                else
                {
                    //me traigo el primer objeto encontrado
                    bool ok = false;
                    foreach (MotorDB.CObjeto obj in l)
                    {

                        if (obj.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim())
                        {
                            BKProseso.ReportProgress(pos, obj);
                            ok = true;
                            break;
                        }
                    }
                    if (ok == false)
                    {
                        NoEncontrados.Add(nombre);
                    }
                }
                pos++;
            }
        }
        private void BKProseso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MotorDB.CObjeto obj=(MotorDB.CObjeto )e.UserState;
            if (OnVerMultiObjeto != null)
                OnVerMultiObjeto(Motor,obj.Nombre, obj.Tipo);
            if(progressBar1.Maximum>e.ProgressPercentage)
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }

        private void BKProseso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Texto.Text = "";
            foreach(string s in NoEncontrados)
            {
                Texto.Text = Texto.Text + s + "\r\n";
            }
            BAgregar.Enabled = true;
            if (OnFInMultiObjeto != null)
                OnFInMultiObjeto();
        }
    }
}
