using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public class CNodoClase: CNodoFolder
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuRenombar;
        public CNodoClase()
        {
        }
        public int ID_Class
        {
            get;
            set;
        }
        public override void ModeloAsignado()
        {
            Modelo.OnStoreProcedureChange += new OnModeloNetEvent(StoreProcedureChange);
        }
        private void StoreProcedureChange(ModeloNet sender)
        {
            CargaModelo();
        }
        public override void CargaModelo()
        {
            List<CStoreProcedures> l = Modelo.DameSpsClase(ID_Class);
            //quito los que ya no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoSP nodo = (CNodoSP)Nodes[i];
                bool encontrado = false;
                foreach (CStoreProcedures obj in l)
                {
                    if (nodo.ID_Store == obj.ID_Store)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Nodes.Remove(nodo);
                }
            }
            //ahora agrego los nuevos
            foreach (CStoreProcedures obj in l)
            {
                bool encontrado = false;
                foreach (CNodoSP nodo in Nodes)
                {
                    if (nodo.ID_Store == obj.ID_Store)
                    {
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    CNodoSP Nnodo = new CNodoSP();
                    Nnodo.ID_Store = obj.ID_Store;
                    Nnodo.Nombre = obj.Nombre;
                    Nnodo.Modelo = Modelo;
                    Nodes.Add(Nnodo);
                }
            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuRenombar = new ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            MenuRenombar,
            MenuEliminar
            });
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuPrimaryKey
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Procedimiento almacenado";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            //
            // MenuRenombar
            //
            this.MenuRenombar.Image = ((System.Drawing.Image)(resources.GetObject("rename")));
            this.MenuRenombar.Name = "MenuRenombar";
            this.MenuRenombar.Size = new System.Drawing.Size(201, 22);
            this.MenuRenombar.Text = "Cambiar Nombre";
            this.MenuRenombar.Click += new System.EventHandler(this.MenuRenombar_Click);

            return MenuPrinciapl;
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            FormSeleccionarSPs dlg = new FormSeleccionarSPs();
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(ObjetoSeleccionado);
            List<CConexion> l = Modelo.DameConexiones();
            foreach(CConexion obj in l)
            {
                ManagerConnect.CConexion con=new ManagerConnect.CConexion()
                {
                     ConecctionString=obj.ConecctionString
                     , Nombre=obj.Nombre
                     , MotorDB=obj.MotorDB
                };
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(con);
                dlg.AgregaMotor(motor);
            }
            dlg.Show(this.TreeView.Parent);
        }
        private void ObjetoSeleccionado(MotorDB.IMotorDB motor,string objeto,MotorDB.EnumTipoObjeto tipo)        
        {
            try
            {
                CConexion con = Modelo.DameConeccionPorCadena(motor.GetConecctionString());
                Modelo.AgregaSp(objeto, con.ID_Conexion, ID_Class);
            }
            catch(System.Exception ex)
            {
                return;
            }
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar la clase del proyecto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //elimino los objhetos relacionados
            List<CStoreProcedures>l=Modelo.DameSpsClase(ID_Class);
            foreach(CStoreProcedures sp in l)
            {
                Modelo.EliminaSP(sp.ID_Store);
            }
            Modelo.EliminaClase(ID_Class);
        }
        private void MenuRenombar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = Nombre;
            dlg.OnNombre += new Forms.ONFormNombreEvent(NuevoNombre);
            dlg.ShowDialog();
        }
        private bool NuevoNombre(Forms.FormNombre sender, string nuevoNombre)
        {
            try
            {
                Modelo.ActualizaClase(ID_Class, nuevoNombre);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
