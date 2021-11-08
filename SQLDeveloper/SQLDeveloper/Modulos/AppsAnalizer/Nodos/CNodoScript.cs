using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoScript: CNodoBase
    {
        public int ID_Script
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
        private ManagerConnect.CConexion FConexion;
        private String Fservidor;
        private ManagerConnect.CConexion Conexion
        {
            get
            {
                if (FConexion == null)
                {
                    ObjetosModelo.CScript script = Modelo.GetScript(ID_Script);
//                    ObjetosModelo.CObjeto objeto = Modelo.GetObjeto(ID_Objeto);
                    ObjetosModelo.CConexion con = Modelo.GetConexion(script.ID_Conexion);
                    ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
                    Fservidor = server.Nombre;
                    FConexion = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);
                }
                return FConexion;
            }
        }

        public CNodoScript(int id_script)
        {
            ImageIndex = 20;
            SelectedImageIndex = 20;

            ID_Script = id_script;
        }
        public override void ModeloAsignado()
        {
            ObjetosModelo.CScript script = Modelo.GetScript(ID_Script);
            this.Nombre = script.Nombre;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Ver Codigo", "IconoEditar", MenuVerCodigo);
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
            this.AddMenuItem("Comentarios", "comentario", MenuComentarios);
        }
        private void MenuVerCodigo(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            //me traigo el codigo de la base de datos
            ObjetosModelo.CScript script = Modelo.GetScript(this.ID_Script);
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //asigno su manejador de archivos
            AppCodeFileManager fm = new AppCodeFileManager();
            fm.Objeto = script;
            fm.Modelo = Modelo;
            //mando a mostrar el codigo
            dlg.VerCodigo(Nombre, script.Codigo, motor, Fservidor, Conexion.Nombre,fm);

        }
        protected virtual void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("¿Deseas eliminar el script: " + Nombre + " del proyecto?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CScript script = Modelo.GetScript(this.ID_Script);
            script.delete();
        }
        private void MenuComentarios(object sender, EventArgs e)
        {
            try
            {
                SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
                ObjetosModelo.CScript script = Modelo.GetScript(this.ID_Script);
                dlg.Texto = script.Comentarios;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                script.Comentarios = dlg.Texto;
                script.update();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

    }
}
   