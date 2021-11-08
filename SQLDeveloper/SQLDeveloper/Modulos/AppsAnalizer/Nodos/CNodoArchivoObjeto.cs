using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
     public delegate void CNodoArchivoObjetoEvent(CNodoArchivoObjeto obj);
   public class CNodoArchivoObjeto : CNodoObjeto
    {
       public event CNodoArchivoObjetoEvent OnObjetoSeleccionado;
        public int ID_Archivo
        {
            get;
            set;
        }
        public CNodoArchivoObjeto(int id_archivo, int id_objeto)
            :base(id_objeto)
        {
            ID_Archivo = id_archivo;
            ID_Objeto = id_objeto;
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            ObjetosModelo.CConexion con = Modelo.GetConexion(obj.ID_Conexion);
            ObjetosModelo.CServidor ser = Modelo.GetServidor(con.ID_Servidor);
            this.Nombre =ser.Nombre+"->"+con.Nombre+"->"+obj.Nombre;
            Modelo.ObjetoUpdatetEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoUpdate);
            CargaInformacion();
        }
        public override void Free()
        {
            base.Free();
            Modelo.ObjetoUpdatetEvent -= ObjetoUpdate;
        }
        private void CargaInformacion()
        {
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            //this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
        }
        protected override void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("¿Eliminar el Objeto del archivo?", "Eliminar", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            ObjetosModelo.CArchivoObjeto c = Modelo.GetArchivoObjeto(ID_Archivo, ID_Objeto);
            try
            {
                c.delete();
           }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void ObjetoUpdate(ObjetosModelo.CObjetoBase obj)
        {
            if (this.ID_Objeto != obj.IdObjeto)
                return;
            ObjetosModelo.CObjeto objeto = (ObjetosModelo.CObjeto)obj;
            Nombre = objeto.GetNombreLargo();
            this.BackColor = objeto.BKColor;
        }
        public override void Seleccionado()
        {
            if(OnObjetoSeleccionado!=null)
            {
                OnObjetoSeleccionado(this);
            }

        }
    }
}
   