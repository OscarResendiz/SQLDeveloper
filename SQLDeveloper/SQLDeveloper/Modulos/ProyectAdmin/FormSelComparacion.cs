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
    public partial class FormSelComparacion : Form
    {
        private ModeloBasico Modelo;
        String Servidor;
        ManagerConnect.CConexion Conexion;
        String Nombre;
        MotorDB.EnumTipoObjeto Tipo;
        public FormSelComparacion(ModeloBasico modelo, string servidor, ManagerConnect.CConexion conexion, string nombre,MotorDB.EnumTipoObjeto tipo)
        {
            InitializeComponent();
            Text=nombre;
            Modelo = modelo;
            Nombre = nombre;
            Conexion = conexion;
            Servidor = servidor;
            Tipo=tipo;
        }

        private void FormSelComparacion_Load(object sender, EventArgs e)
        {
            //lleno los combos
            List<CModelCodigoObjeto> l = Modelo.DameHistorial(Servidor, Conexion.Nombre, Nombre);
            Combo1.Items.Add(Nombre + " en base de datos");
            Combo2.Items.Add(Nombre + " en base de datos");
            foreach (CModelCodigoObjeto obj in l)
            {
                Combo1.Items.Add(obj);
                Combo2.Items.Add(obj);
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (Combo1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el objeto a comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if (Combo2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el objeto con el cual se va a comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if(Combo1.SelectedIndex == Combo2.SelectedIndex)
            {
                MessageBox.Show("La seleccion debe ser diferente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private string DameCodigo()
        {
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            string s = "";
            switch (Tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s = motor.DameCodigoFuncction(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s = motor.DameCodigoStoreProcedure(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s = motor.DameCodigoTabla(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s = motor.DameCodigoTrigger(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = motor.DameCodigoVista(Nombre);
                    break;
            }
            return s;
        }
        public string Titulo1
        {
            get
            {
                if (Combo1.SelectedIndex == 0)
                {
                    //me traigo el motor
                    MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                    return DameCodigo();
                }
                CModelCodigoObjeto obj = (CModelCodigoObjeto)Combo1.SelectedItem;
                return obj.Fecha.ToString();

            }
        }
        public string Titulo2
        {
            get
            {
                if (Combo2.SelectedIndex == 0)
                {
                    //me traigo el motor
                    MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                    return DameCodigo();
                }
                CModelCodigoObjeto obj = (CModelCodigoObjeto)Combo2.SelectedItem;
                return obj.Fecha.ToString();

            }
        }
        public string Codigo1
        {
            get
            {
                if(Combo1.SelectedIndex==0)
                {
                    //me traigo el motor
                    MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                    return DameCodigo();
                }
                CModelCodigoObjeto obj=(CModelCodigoObjeto)Combo1.SelectedItem;
                return obj.Codigo;
            }
        }
        public string Codigo2
        {
            get
            {
                if(Combo2.SelectedIndex==0)
                {
                    //me traigo el motor
                    MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                    return DameCodigo();
                }
                CModelCodigoObjeto obj=(CModelCodigoObjeto)Combo2.SelectedItem;
                return obj.Codigo;
            }
        }

    }
}
