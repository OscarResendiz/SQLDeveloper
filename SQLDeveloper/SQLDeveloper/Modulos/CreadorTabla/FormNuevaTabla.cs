using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class FormNuevaTabla : Form
    {
        MotorDB.IMotorDB Motor;
        public event OnVerObjetoEvent OnVerTabla;
        CTabla Tabla;
        bool Duplicado;
        private string TableName
        {
            get
            {
                return TTabla.Text;
            }
            set
            {
                TTabla.Text = value;
            }
        }
        public FormNuevaTabla(MotorDB.IMotorDB motor)
        {
            Motor = motor;
            Tabla = new CTabla();
            InitializeComponent();
        }

        private void FormConstraints_Load(object sender, EventArgs e)
        {
            LMensaje.Text = "";
            treeView1.Nodes.Clear();
            //creo el nodo principal que es el de la tabla
            CNodoTabla nodo = new CNodoTabla(Tabla);
            treeView1.Nodes.Add(nodo);
            TTabla.Text = TableName;
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuPrimaryKey_Click(object sender, EventArgs e)
        {

        }

        private void MenuRefrescar_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.Expandido();
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.Colapsado();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            CNodoBase nodo = (CNodoBase)e.Node;
            //elimino el visor que actualmente se esta mostrando
            splitContainer1.Panel2.Controls.Clear();
            //me traigo el visor
            CVisorBase visor = nodo.GetVisor();
            //lo asigno
            splitContainer1.Panel2.Controls.Add(visor);
            //lo configuro para que abarque todo el espacio
            visor.Dock = DockStyle.Fill;
        }

        private void MenuEliminarPk_Click(object sender, EventArgs e)
        {

        }

        private void TTabla_TextChanged(object sender, EventArgs e)
        {
            TValidarNombre.Enabled = false;
            TValidarNombre.Enabled = true;
            CNodoTabla nodo = (CNodoTabla)treeView1.Nodes[0];
            nodo.NombreTabla = TableName;
        }

        private void TValidarNombre_Tick(object sender, EventArgs e)
        {
            TValidarNombre.Enabled = false;
            CTabla tabl = DBProvider.DB.DameTabla(TTabla.Text);
            if(tabl!=null)
            {
                LMensaje.Text = "La tabla ya existe";
                Duplicado = true;
            }
            else
            {
                LMensaje.Text = "";
                Duplicado = false;
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(TTabla.Text.Trim()=="")
            {
                MessageBox.Show("Falta el nombre de la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if(Tabla.Campos.Count==0)
            {
                MessageBox.Show("No ha ingresado ningun campo en la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            try
            {
                DBProvider.DB.CreaTabla(Tabla);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if(OnVerTabla!=null)
            {
                OnVerTabla(Motor, Tabla.Nombre, EnumTipoObjeto.TABLE);
            }
        }
    }
}
