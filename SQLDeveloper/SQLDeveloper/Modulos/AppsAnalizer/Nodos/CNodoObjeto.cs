using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Drawing;
namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    public class CNodoObjeto : CNodoBase
    {
        private ManagerConnect.CConexion FConexion;
        private String Fservidor;
        public string NombreServidor
        {
            get
            {
                return Fservidor;
            }
        }
        public ManagerConnect.CConexion Conexion
        {
            get
            {
                if (FConexion==null)
                {
                    ObjetosModelo.CObjeto objeto = Modelo.GetObjeto(ID_Objeto);
                    ObjetosModelo.CConexion con = Modelo.GetConexion(objeto.ID_Conexion);
                    ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
                    Fservidor = server.Nombre;
                    FConexion = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);
                }
                return FConexion;
            }
        }
        private CNodoHistorial Histirial;
        private CNodoGroupCodigoEditable CodigoEditable;
        private CNodoDependencias Dependencias;

        private MotorDB.EnumTipoObjeto FTipo;
        public CNodoObjeto(int id_objeto)
        {
            ID_Objeto = id_objeto;

            Histirial = new CNodoHistorial(id_objeto);
            Nodes.Add(Histirial);
            CodigoEditable = new CNodoGroupCodigoEditable(id_objeto);
            Nodes.Add(CodigoEditable);
            Dependencias = new CNodoDependencias(id_objeto);
            Nodes.Add(Dependencias);
        }
        public override void ModeloAsignado()
        {
            Dependencias.Modelo = Modelo;
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            Nombre = obj.GetNombreLargo();
            this.BackColor = obj.BKColor;
            FTipo = obj.TipoObjeto;
            Histirial.Modelo = this.Modelo;
            CodigoEditable.Modelo = Modelo;
            SeleccionaIcono();
            Modelo.ObjetoUpdatetEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoUpdate);
            Modelo.OnResaltaNombreObjeto += new ObjetosModelo.OnCodigoEditableChangeEvent(ResaltaNombreObjeto);
        }
        public override void Free()
        {
            base.Free();
            Modelo.ObjetoUpdatetEvent -= ObjetoUpdate;
            Modelo.OnResaltaNombreObjeto -= ResaltaNombreObjeto;
        }
        private void ResaltaNombreObjeto(int i, string nombre)
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(ID_Objeto);
            if (obj == null)
                return;
            if(obj.Nombre.ToUpper().Trim()==nombre.ToUpper().Trim())
            {
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Black;
            }
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Copiar Nombre Completo", "copiar", MenuCoiarNombreCompleto_Click);
            this.AddMenuItem("Ver Codigo", "IconoEditar", MenuVerCodigo);
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
            this.AddMenuItem("Comparar", "bascula", MenuComparar);
            this.AddMenuItem("Comentarios", "comentario", MenuComentarios);
            this.AddMenuItem("Copiar Codigo", "IconoAgregar", MenuCoiarCodigo);
            this.AddMenuItem("Marcar", "Resaltar", MenuMarcar);
            AddMenuItem("Mapear Objeto", "database_process_icon", MapearObjetos_Click);
            AddMenuItem("Excluir del mapeo", "calabera", ExcluirMapeo_Click);
        }
        protected override void MenuCoiarNombre_Click(object sender, EventArgs e)
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            Clipboard.SetText(obj.Nombre);
        }
        private void MenuCoiarNombreCompleto_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Nombre);
        }

        private void SeleccionaIcono()
        {
            switch (FTipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    ImageIndex = 9;
                    SelectedImageIndex = 9;
                    Tag = "Funcion";
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    ImageIndex = 10;
                    SelectedImageIndex = 10;
                    Tag = "Procediiento almacenado";
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    ImageIndex = 7;
                    SelectedImageIndex = 7;
                    Tag = "Tabla";
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    ImageIndex = 11;
                    SelectedImageIndex = 11;
                    Tag = "Trigger";
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    ImageIndex = 8;
                    SelectedImageIndex = 8;
                    Tag = "Vista";
                    break;
                case MotorDB.EnumTipoObjeto.CHECK:
                    ImageIndex = 12;
                    SelectedImageIndex = 12;
                    Tag = "Regla (Check)";
                    break;
                case MotorDB.EnumTipoObjeto.DEFAULT:
                    ImageIndex = 13;
                    SelectedImageIndex = 13;
                    Tag = "Valor por default";
                    break;
                case MotorDB.EnumTipoObjeto.FOREIGNKEY:
                    ImageIndex = 14;
                    SelectedImageIndex = 14;
                    Tag = "LLave foranea";
                    break;
                case MotorDB.EnumTipoObjeto.PRIMARYKEY:
                    ImageIndex = 15;
                    SelectedImageIndex = 15;
                    Tag = "LLave primaria";
                    break;
                case MotorDB.EnumTipoObjeto.UNIQUE:
                    ImageIndex = 16;
                    SelectedImageIndex = 16;
                    Tag = "Valor unico";
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    ImageIndex = 19;
                    SelectedImageIndex = 19;
                    Tag = "Valor unico";
                    break;
                default:
                    ImageIndex = 17;
                    SelectedImageIndex = 17;
                    Tag = "Desconocido";
                    break;
            }
        }
        public string DameCodigo()
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            string s = "";
            switch (FTipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s = motor.DameCodigoFuncction(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s = motor.DameCodigoStoreProcedure(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s = motor.DameCodigoTabla(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s = motor.DameCodigoTrigger(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = motor.DameCodigoVista(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s = motor.DameCodigoTypeTable(obj.Nombre);
                    break;
            }
            return s;
        }
        private void MenuVerCodigo(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            //me traigo el codigo de la base de datos
            string s = DameCodigo(); // se trae el codigo de la base de datos
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //mando a mostrar el codigo
            dlg.VerCodigo(obj.Nombre, s, motor, Fservidor, Conexion.Nombre);

        }
        protected virtual void MenuEliminar(object sender, EventArgs e)
        {
            if(System.Windows.MessageBox.Show("¿Deseas eliminar el objeto: "+Nombre+" del proyecto?","Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question)!= System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(ID_Objeto);
            obj.deleteCascade();
        }
        private void MenuComentarios(object sender, EventArgs e)
        {
            try
            {
                SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
                ObjetosModelo.CObjeto obj = Modelo.GetObjeto(ID_Objeto);
                dlg.Texto = obj.Comentarios;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                obj.Comentarios = dlg.Texto;
                obj.update();
            }
            catch(System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void MenuCoiarCodigo(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(CopiaCodigo);
            dlg.ShowDialog();
        }
        private bool CopiaCodigo(Forms.FormNombre sender, string nombre)
        {
            //CModelObjeto objeto = Modelo.DameObjeto(Servidor, Conexion.Nombre, Nombre);
            try
            {
                string codigo = DameCodigo();
                int ID_CodigoEditable=Modelo.InsertCodigoEditable(ID_Objeto,System.DateTime.Now,nombre,codigo,"");
                //lo muestro para que se pueda editar
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
                AppCodeFileManager fm = new AppCodeFileManager();
                ObjetosModelo.CCodigoEditable codigoEditable = Modelo.GetCodigoEditable(ID_CodigoEditable);
                fm.Objeto = codigoEditable;
                fm.Modelo = Modelo;

                dlg.VerCodigo(nombre, codigo, motor, Fservidor, Conexion.Nombre, fm);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void MenuMarcar(object sender, EventArgs e)
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.Color=obj.BKColor;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            obj.BKColor=dlg.Color;
            obj.update();
        }
        private void ObjetoUpdate(ObjetosModelo.CObjetoBase obj)
        {
            if (this.ID_Objeto != obj.IdObjeto)
                return;
            ObjetosModelo.CObjeto objeto = (ObjetosModelo.CObjeto)obj;
            Nombre = objeto.GetNombreLargo();
            this.BackColor = objeto.BKColor;
        }
        private void MenuCambiarNombre(object sender, EventArgs e)
        {

        }
        private void MenuComparar(object sender, EventArgs e)
        {

        }
        public override void AgregaRegistrosReporte(System.Data.DataTable tabla, DataRow rp, int nivel)
        {
            //if (rp != null)
            //{
            //    rp["Nivel " + nivel.ToString()] = this.Nombre;
            //}
            //agrego mi registro
            System.Data.DataRow dr = tabla.NewRow();
            //agrego los datos al registro
            if (rp != null)
            {
                for (int i = 1; i < nivel; i++)
                {
                    dr["Nivel " + i.ToString()] = rp["Nivel " + i.ToString()];

                }
            }
            dr["Nivel " + nivel.ToString()] ="("+Tag.ToString()+")"+ this.Nombre;
            //agrego un nubel mas a los campos
            tabla.Rows.Add(dr);
            if (Nodes.Count > 0)
            {
                int nivel2 = nivel + 1;
                AgregaColumna(tabla, nivel2);
                foreach (CNodoBase n in Nodes)
                {
                    n.AgregaRegistrosReporte(tabla,dr, nivel2);
                }

            }

        }
        public override int calculaNivel(int n)
        {
            if (Nodes.Count == 0)
                return n + 1;
            int max = n + 1;
            foreach (CNodoBase nodo in Nodes)
            {
                int x = nodo.calculaNivel(n+1);
                if (x > max)
                    max = x;
            }
            return max;
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            if (ForeColor.R != Color.Red.R || ForeColor.G != Color.Red.G || ForeColor.B != Color.Red.B)
            {
                Modelo.ResaltaNombreObjeto(obj.Nombre);
            }
        }
        private void MapearObjetos_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CObjeto> l2 = new List<ObjetosModelo.CObjeto>();
            ObjetosModelo.CObjeto obj2 = Modelo.GetObjeto(this.ID_Objeto);
            l2.Add(obj2);
            setAnalizador(new Analizadores.CAnalizadorDependencias(Modelo, l2));
        }
        public override void KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode== System.Windows.Forms.Keys.Delete)
            {
                MenuEliminar(null, null);
            }
            if(e.KeyCode== System.Windows.Forms.Keys.C && e.Control==true)
            {
                //copiar
                MenuCoiarNombre_Click(null, null);
            }
        }
        private void ExcluirMapeo_Click(object sender, EventArgs e)
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            if (System.Windows.MessageBox.Show("¿Deseas Excluir el objeto: " + Nombre + " del analisi de dependencias?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            Modelo.InsertExcluidos(obj.Nombre);
        }
    }
}
   