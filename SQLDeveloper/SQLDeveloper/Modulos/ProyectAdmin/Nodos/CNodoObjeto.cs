using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoObjeto: CNodoBase
    {
        //menu del objeto
        private System.Windows.Forms.ToolStripMenuItem MenuVerCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuComparar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        private System.Windows.Forms.ToolStripMenuItem MenuCoiarCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuMarcar;
        //menu del historial
        private System.Windows.Forms.ContextMenuStrip MenuHistorial;
        private System.Windows.Forms.ToolStripMenuItem MenuVerHistorial;
        //menu codigo editable
        private System.Windows.Forms.ContextMenuStrip MenuCodigoEditable;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoCodigoEditable;

        private CNodoFolder Histirial;
        private CNodoFolder CodigoEditable;
        public CNodoObjeto()
        {
            Histirial = new CNodoFolder();
            Histirial.Nombre = "Historial";
            //Histirial.ContextMenuStrip = CreaMenuHotorial();
            Nodes.Add(Histirial);
            CodigoEditable = new CNodoFolder();
            CodigoEditable.Nombre = "Copias Editables";
            Nodes.Add(CodigoEditable);

        }
        public int ID_Objeto
        {
            get;
            set;
        }
        private MotorDB.EnumTipoObjeto FTipo;
        public MotorDB.EnumTipoObjeto Tipo
        {
            get
            {
                return FTipo;
            }
            set
            {
                FTipo = value;
                SeleccionaIcono();
            }
        }
        public ManagerConnect.CConexion Conexion
        {
            get;
            set;
        }
        public string Servidor
        {
            get;
            set;
        }
        public string Comentarios
        {
            get
            {
                if (Modelo != null)
                {
                    CModelObjeto obj = Modelo.DameObjeto(Servidor, Conexion.Nombre, Nombre);
                    return obj.Comentarios;
                }
                return "";
            }
            set
            {
                if (Modelo != null)
                {
                    Modelo.AsignaComentarioObjeto(Servidor, Conexion.Nombre, Nombre, value);
                }

            }
        }
        public override void ModeloAsignado()
        {
            Modelo.ONModeloChange += new ONModeloBasicoEvent(CargaHistroria);
            Modelo.OnNewCodigoEditable += new OnModeloBasicoObjectEvent(NewCodigoEditable);
            CargaHistroria();
            CargaCopiasEditables();
        }
        ~CNodoObjeto()
        {
            Modelo.ONModeloChange -= CargaHistroria;
            Modelo.OnNewCodigoEditable -= NewCodigoEditable;

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
        private void CargaHistroria()
        {
            try
            {
                //carga el hostoria
                CModelObjeto objeto = Modelo.DameObjeto(Servidor, Conexion.Nombre, Nombre);
                if (objeto == null)
                    return;
                if (objeto.Eliminado)
                {
                    ImageIndex = 5;
                    SelectedImageIndex = 5;
                    Tag = "Eliminado de la base de datos";
                }
                else
                {
                    SeleccionaIcono();
                }

                List<CModelCodigoObjeto> l = Modelo.DameHistorial(Servidor, Conexion.Nombre, Nombre);
                Histirial.Nodes.Clear();
                bool ok = true;
                foreach (CModelCodigoObjeto obj in l)
                {
                    CNodoCodigoObjeto nodo = new CNodoCodigoObjeto();
                    nodo.OnNodoVisto += new OnNodoSeleccionadoEvent(HistoriaVista);
                    nodo.Modelo = Modelo;
                    nodo.NombreObjeto = Nombre;
                    nodo.Fecha = obj.Fecha;
                    nodo.Servidor = Servidor;
                    nodo.Conexion = Conexion;
                    nodo.Visto = obj.Visto;
                    nodo.COdigoObjeto = obj;
                    if (obj.Visto == false)
                        ok = false;
                    Histirial.Nodes.Add(nodo);
                }
                if (ok == false)
                {
                    ForeColor = Color.Red;
                }
                else
                {
                    ForeColor = Color.Black;
                }
            }
            catch(System.Exception e)
            {
                return;
            }
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
                    s= motor.DameCodigoStoreProcedure(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s= motor.DameCodigoTabla(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s= motor.DameCodigoTrigger(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = motor.DameCodigoVista(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s = motor.DameCodigoTypeTable(Nombre);
                    break;
            }
            return s;
        }
        public override void Monitorea()
        {
            if (Conexion == null)
                return;
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //me traigo la fecha de la ultima modificacion
            DateTime f=motor.DameFechaModificacion(Nombre);
            CModelCodigoObjeto obj = Modelo.DameUltimaVersios(Servidor, Conexion.Nombre, Nombre);
            if (obj == null)
            {
                string cod = DameCodigo();
                if (cod.Trim() == "")
                    return;
                CNodoCodigoObjeto nodo = new CNodoCodigoObjeto();
                nodo.OnNodoVisto += new OnNodoSeleccionadoEvent(HistoriaVista);
                nodo.NombreObjeto = Nombre;
                nodo.Fecha = f;
                nodo.Modelo = Modelo;
                nodo.Servidor = Servidor;
                nodo.COdigoObjeto = obj; 
                nodo.Conexion = Conexion;
                Histirial.Nodes.Add(nodo);
                //lo agrego al modelo
                Modelo.AgregaCodigo(Servidor, Conexion.Nombre, Nombre, cod);
                return;
            }
            if(f!=obj.Fecha)
            {
                //cambio la fecha, ahora reviso el codigo
                string cod = DameCodigo();
                if(cod!=obj.Codigo)
                {
                    //si cambio, por lo que lo agrego
                    CNodoCodigoObjeto nodo = new CNodoCodigoObjeto();
                    nodo.OnNodoVisto += new OnNodoSeleccionadoEvent(HistoriaVista);
                    nodo.NombreObjeto = Nombre;
                    nodo.Fecha = f;
                    nodo.Modelo = Modelo;
                    nodo.Servidor = Servidor;
                    nodo.COdigoObjeto = obj;
                    nodo.Conexion = Conexion;
                    Histirial.Nodes.Add(nodo);
                    //lo agrego al modelo
                    Modelo.AgregaCodigo(Servidor, Conexion.Nombre, Nombre, cod);
                }

            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuVerCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            MenuComparar = new System.Windows.Forms.ToolStripMenuItem();
            MenuCoiarCodigo = new System.Windows.Forms.ToolStripMenuItem();
            MenuMarcar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVerCodigo,
            MenuComentarios,
            MenuMarcar ,
            MenuCoiarCodigo,
            MenuComparar,
            this.MenuEliminar
             });
            // 
            // MenuVerCodigo
            // 
            this.MenuVerCodigo.Image = ImageManager.getImagen("IconoEditar"); // ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
            this.MenuVerCodigo.Name = "MenuVerCodigo";
            this.MenuVerCodigo.Size = new System.Drawing.Size(201, 22);
            this.MenuVerCodigo.Text = "Ver Código Base de Datos";
            this.MenuVerCodigo.Click += new System.EventHandler(this.MenuVerCodigo_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ImageManager.getImagen("IconoEliminar"); // ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuRefrescar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Quitar del proyecto";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuComparar
            // 
            this.MenuComparar.Image = ImageManager.getImagen("bascula"); // ((System.Drawing.Image)(resources.GetObject("bascula")));
            this.MenuComparar.Name = "MenuComparar";
            this.MenuComparar.Size = new System.Drawing.Size(201, 22);
            this.MenuComparar.Text = "Comparar";
            this.MenuComparar.Click += new System.EventHandler(this.MenuComparar_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ImageManager.getImagen("comentario"); // ((System.Drawing.Image)(resources.GetObject("comentario")));
            this.MenuComentarios.Name = "MenuVerCodigo";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Cometarios";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);
            // 
            // MenuCoiarCodigo
            // 
            this.MenuCoiarCodigo.Image = ImageManager.getImagen("IconoAgregar"); // ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuCoiarCodigo.Name = "MenuCoiarCodigo";
            this.MenuCoiarCodigo.Size = new System.Drawing.Size(201, 22);
            this.MenuCoiarCodigo.Text = "Hacer una copia para editar";
            this.MenuCoiarCodigo.Click += new System.EventHandler(this.MenuCoiarCodigo_Click);
            // 
            // MenuMarcar
            // 
            this.MenuMarcar.Image = ImageManager.getImagen("Resaltar"); //((System.Drawing.Image)(resources.GetObject("Resaltar")));
            this.MenuMarcar.Name = "MenuMarcar";
            this.MenuMarcar.Size = new System.Drawing.Size(201, 22);
            this.MenuMarcar.Text = "Resaltar";
            this.MenuMarcar.Click += new System.EventHandler(this.MenuMarcar_Click);

             
            Histirial.ContextMenuStrip = CreaMenuHotorial();
            CodigoEditable.ContextMenuStrip = CreaMenuCodigoEditable();
            return MenuPrinciapl;
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Parent.GetType() == typeof(CNodoCarpeta))
                {
                    if (MessageBox.Show("¿Desea quitar: " + Nombre + " de la Carpeta?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    //hay que quitarlo de la carpeta
                    CNodoCarpeta padre = (CNodoCarpeta)this.Parent;
                    Modelo.QuitaObjetoCarpeta(padre.ID_Carpeta, ID_Objeto);
                }
                else
                {
                    if (MessageBox.Show("¿Desea Eliminar: " + Nombre + " del proyecto?\n Se eliminara de todas las carpetas ", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    Modelo.EliminaObjeto(Servidor, Conexion.Nombre, Nombre);
                }
                Parent.Nodes.Remove(this);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void HistoriaVista()
        {
            bool ok = true;
            foreach(CNodoCodigoObjeto nodo in Histirial.Nodes)
            {
                if (nodo.Visto == false)
                    ok = false;
            }
            if(ok==false)
            {
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Black;
            }
        }
        public void Carga()
        {
            //recarga el codigo que se encuentra actualmente en el servidor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            CNodoCodigoObjeto nodo = new CNodoCodigoObjeto();
            nodo.OnNodoVisto += new OnNodoSeleccionadoEvent(HistoriaVista);
            string codigo = DameCodigo(); // se trae el codigo de la base de datos
            nodo.NombreObjeto = Nombre;
            nodo.Fecha = motor.DameFechaModificacion(Nombre);
            nodo.Modelo = Modelo;
            nodo.Servidor = Servidor;
            nodo.Conexion = Conexion;
            Histirial.Nodes.Add(nodo);
            //lo agrego al modelo
            if (Modelo.TieneCodigo(ID_Objeto) == false)
            {
                nodo.COdigoObjeto = Modelo.AgregaCodigo(Servidor, Conexion.Nombre, Nombre, codigo);
            }
        }
        private  System.Windows.Forms.ContextMenuStrip CreaMenuHotorial()
        {
            this.MenuHistorial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuVerHistorial = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuHistorial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVerHistorial,
             });
            this.MenuHistorial.Name = "MenuHistorial";
            this.MenuHistorial.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuVerCodigo
            // 
            this.MenuVerHistorial.Image = ImageManager.getImagen("calendario"); // ((System.Drawing.Image)(resources.GetObject("calendario")));
            this.MenuVerHistorial.Name = "MenuVerHistorial";
            this.MenuVerHistorial.Size = new System.Drawing.Size(201, 22);
            this.MenuVerHistorial.Text = "Ver Historial";
            this.MenuVerHistorial.Click += new System.EventHandler(this.MenuVerHistorial_Click);
            return MenuHistorial;
        }
        private void MenuVerHistorial_Click(object sender, EventArgs e)
        {
            CargaHistroria();
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
            dlg.Texto = Comentarios;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Comentarios = dlg.Texto;
        }
        private void CargaCopiasEditables()
        {
            try
            {
                //carga las copias editables
                List<CModelCodigoEditable> l = Modelo.DameCodigosEditables(ID_Objeto);
                CodigoEditable.Nodes.Clear();
                bool ok = true;
                foreach (CModelCodigoEditable obj in l)
                {
                    CNodoCodigoEditable nodo = new CNodoCodigoEditable();
                    nodo.Modelo = Modelo;
                    nodo.Nombre = obj.Nombre;
                    nodo.Conexion = Conexion;
                    nodo.ID_Objeto = ID_Objeto;
                    nodo.Servidor = Servidor;
                    CodigoEditable.Nodes.Add(nodo);
                }
            }
            catch (System.Exception e)
            {
                return;
            }
        }
        private void MenuCoiarCodigo_Click(object sender, EventArgs e)
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
                Modelo.AgregaCodigoEditable(ID_Objeto, nombre, codigo);
                CargaCopiasEditables();
                //lo muestro para que se pueda editar
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                FormProyect dlg = (FormProyect)TreeView.Tag;
                CodeFileManager fm = new CodeFileManager();
                fm.ID_Objeto = ID_Objeto;
                fm.Nombre = nombre;
                fm.Modelo = Modelo;

                dlg.VerCodigo(nombre, codigo, motor, Servidor, Conexion.Nombre,fm);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void NewCodigoEditable(int id_objeto)
        {
            //CModelObjeto objeto = Modelo.DameObjeto(Servidor, Conexion.Nombre, Nombre);
            if(ID_Objeto==id_objeto)
                CargaCopiasEditables();

        }
        protected System.Windows.Forms.ContextMenuStrip CreaMenuCodigoEditable()
        {

            
            this.MenuCodigoEditable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuNuevoCodigoEditable = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuCodigoEditable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevoCodigoEditable
             });
            this.MenuCodigoEditable.Name = "MenuCodigoEditable";
            this.MenuCodigoEditable.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuNuevoCodigoEditable
            // 
            this.MenuNuevoCodigoEditable.Image = ImageManager.getImagen("IconoAgregar"); //((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuNuevoCodigoEditable.Name = "MenuNuevoCodigoEditable";
            this.MenuNuevoCodigoEditable.Size = new System.Drawing.Size(201, 22);
            this.MenuNuevoCodigoEditable.Text = "Nuevo codigo vacio";
            this.MenuNuevoCodigoEditable.Click += new System.EventHandler(this.MenuNuevoCodigoEditable_Click);
            return MenuCodigoEditable;
        }
        private void MenuNuevoCodigoEditable_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(CodigoNuevo);
            dlg.ShowDialog();
        }
        private bool CodigoNuevo(Forms.FormNombre sender, string nombre)
        {
            //CModelObjeto objeto = Modelo.DameObjeto(Servidor, Conexion.Nombre, Nombre);
            try
            {
                Modelo.AgregaCodigoEditable(ID_Objeto, nombre, "");
                CargaCopiasEditables();
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                FormProyect dlg = (FormProyect)TreeView.Tag;
                CodeFileManager fm = new CodeFileManager();
                fm.ID_Objeto = ID_Objeto;
                fm.Nombre = nombre;
                fm.Modelo = Modelo;
                dlg.VerCodigo(nombre, "", motor, Servidor, Conexion.Nombre,fm);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void MenuVerCodigo_Click(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            FormProyect dlg = (FormProyect)TreeView.Tag;
            //me traigo el codigo de la base de datos
            string s = DameCodigo(); // se trae el codigo de la base de datos
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //mando a mostrar el codigo
            dlg.VerCodigo(Nombre, s, motor, Servidor, Conexion.Nombre);
        }
        private void MenuComparar_Click(object sender, EventArgs e)
        {
            FormSelComparacion dlg = new FormSelComparacion(Modelo, Servidor, Conexion, Nombre, Tipo);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            FormProyect padre = (FormProyect)TreeView.Tag;
            padre.Comparar(dlg.Codigo1, dlg.Codigo2, dlg.Titulo1, dlg.Titulo2, motor.GetMotor().ToString());
        }
        private void MenuMarcar_Click(object sender, EventArgs e)
        {
            CModelObjeto obj = Modelo.DameObjeto(this.ID_Objeto);
            if (obj.Resaltado == false)
            {
                this.BackColor = Color.GreenYellow;
            }
            else
            {
                this.BackColor = Color.White;
            }
            Modelo.MarcaObjeto(this.ID_Objeto, !obj.Resaltado);
        }
    }
}
   