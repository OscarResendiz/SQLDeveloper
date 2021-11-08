using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoCodigoEditable: CNodoBase
    {
        public int ID_CodigoEditable
        {
            get
            {
                return this.ID_Objeto;
            }
            set
            {
                ID_Objeto = value;
            }
        }
        public CNodoCodigoEditable(int id_codigoEditable)
        {
            this.ID_CodigoEditable = id_codigoEditable;
        }
        public override void ModeloAsignado()
        {
            ObjetosModelo.CCodigoEditable obj = Modelo.GetCodigoEditable(ID_CodigoEditable);
            Nombre = obj.Nombre;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Ver Codigo", "IconoEditar", MenuVerCodigo);
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
        }
        private void MenuVerCodigo(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            //me traigo el codigo de la base de datos
            ObjetosModelo.CCodigoEditable obj = Modelo.GetCodigoEditable(this.ID_CodigoEditable);
            string s = obj.Codigo; // se trae el codigo de la base de datos
            ObjetosModelo.CObjeto objeto = Modelo.GetObjeto(obj.ID_Objeto); ;
            ObjetosModelo.CConexion con = Modelo.GetConexion(objeto.ID_Conexion);
            ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
            ManagerConnect.CConexion Conexion = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //asigno su manejador de archivos
            AppCodeFileManager fm = new AppCodeFileManager();
            fm.Objeto = obj;
            fm.Modelo = Modelo;
            //mando a mostrar el codigo
            dlg.VerCodigo(Nombre, s, motor, server.Nombre, Conexion.Nombre,fm);
        }
        protected virtual void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("¿Deseas eliminar el codigo editable: " + Nombre + " del proyecto?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CCodigoEditable obj = Modelo.GetCodigoEditable(this.ID_CodigoEditable);
            obj.delete();
        }

    }
}
   