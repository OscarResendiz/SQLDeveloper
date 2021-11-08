using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoCodigoObjeto: CNodoBase
    {
        public int ID_Codigo
        {
            get
            {
                return ID_Objeto;
            }
            set
            {
                ID_Objeto = value;
            }
        }
        public CNodoCodigoObjeto(int id_codigo)
        {
            ID_Codigo = id_codigo;
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            ObjetosModelo.CCodigoObjeto obj = Modelo.GetCodigoObjeto(ID_Codigo);
            Nombre = obj.Fecha.ToString();
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Ver Codigo", "IconoEditar", MenuVerCodigo);

        }
        private void MenuVerCodigo(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            ObjetosModelo.CCodigoObjeto obj = Modelo.GetCodigoObjeto(this.ID_Codigo);
            //me traigo el codigo de la base de datos
            ObjetosModelo.CObjeto objeto = Modelo.GetObjeto(obj.ID_Objeto);
            ObjetosModelo.CConexion con = Modelo.GetConexion(objeto.ID_Conexion);
            ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
            ManagerConnect.CConexion Conexion = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //mando a mostrar el codigo
            dlg.VerCodigo(objeto.Nombre + " "+obj.Fecha.ToString(), obj.Codigo, motor, server.Nombre, Conexion.Nombre);

        }
        public override void DoubleClick(System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            base.DoubleClick(e);
            MenuVerCodigo(null, null);
        }
    }
}
   