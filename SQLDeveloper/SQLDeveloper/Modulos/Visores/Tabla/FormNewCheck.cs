using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Tabla
{
    public partial class FormNewCheck : Form
    {
        private string TableName;
        private MotorDB.CTabla Tabla;
        MotorDB.IMotorDB motor;
        public FormNewCheck(string tabla,MotorDB.IMotorDB db)
        {
            motor = db;
            TableName = tabla;
            Tabla = motor.DameTabla(TableName);
            InitializeComponent();
        }
        private void AsignaNombre()
        {
            //el estandar de Banames dice que las reglas deben de empesar con r
            string s = "";
            int consecutivo = 1;
            bool ok;
            do
            {
                ok = true;
                s = "r_" + TableName + consecutivo;
                //verifico si el nombre ya existe
                foreach(MotorDB.CCheck obj in Tabla.Checks)
                {
                    if(obj.Nombre.ToUpper().Trim()==s.ToUpper().Trim())
                    {
                        ok = false;
                    }
                }
                consecutivo++;
            }
            while (ok == false);
            TNombre.Text = s;
        }

        private void FormNewCheck_Load(object sender, EventArgs e)
        {
            AsignaNombre();
        }

        private void Bacpetar_Click(object sender, EventArgs e)
        {
            if (TNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe de asignar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if (TRegla.Text.Trim() == "")
            {
                MessageBox.Show("Falta la regla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            try
            {
                MotorDB.CCheck obj = new MotorDB.CCheck();
                obj.Nombre = TNombre.Text;
                obj.Regla = TRegla.Text;
                motor.AlterTable_AddCheck(TableName, obj);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }

        private void BEditor_Click(object sender, EventArgs e)
        {
            FormEditorRegla dlg = new FormEditorRegla(Tabla.Nombre, motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            TRegla.Text = dlg.CadenaResult;
        }
    }
}
