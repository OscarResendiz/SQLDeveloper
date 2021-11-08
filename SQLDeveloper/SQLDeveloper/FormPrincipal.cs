using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crownwood.Magic.Common;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Menus;
using System.IO;
using MotorDB;
//using Modelador;
namespace SQLDeveloper
{
    public delegate void OnRecargaColoresEvent();
    public partial class FormPrincipal : Form
    {
        public event OnRecargaColoresEvent OnRecargaColores;
        #region VENTANAS ACOPLABLES
        private int childFormNumber = 0;
        protected DockingManager AdministradorVentanasAcoplables;
        private bool dox;
        WindowContent ContenedorIzquierdo;
        WindowContent ContenedorDerecho;
        private EditorManager.FormEditor VEditor;
        private bool CerrarPespaña = true;

        #endregion
        #region Ventanas comunes

        #endregion
        private bool Cerrando;
        public FormPrincipal()
        {
            Cerrando = false;
            InitializeComponent();
            EnableCOnexion = false;
            #region VENTANAS ACOPLABLES
            AdministradorVentanasAcoplables = new DockingManager(this, VisualStyle.Plain);
            AdministradorVentanasAcoplables.ContentHiding += new DockingManager.ContentHidingHandler(DestruirAlCerrar);
            #endregion
        }
        #region VENTANAS ACOPLABLES
        private void DestruirAlCerrar(Content c, CancelEventArgs e)
        {
            //Este evento se genera al momento de cerrar la venta acoplable 
            //y lo que va a hacer es cerrar la ventana y destruirla
            Form f = (Form)c.Control;
            f.Close();
        }
        private void VentanaAcoplable(Form dlg, int ImajenIndex, bool PositionTop, State state)
        {
            Size s = new Size(dlg.Width, dlg.Height);
            Content contenedor = AdministradorVentanasAcoplables.Contents.Add(dlg, dlg.Text, imageList1, ImajenIndex);
            contenedor.CaptionBar = true;
            contenedor.CloseButton = true;
            contenedor.DisplaySize = s;
            if (state == State.DockLeft)
            {
                if (ContenedorIzquierdo == null || ContenedorIzquierdo.Visible == false)
                {
                    ContenedorIzquierdo = AdministradorVentanasAcoplables.AddContentWithState(contenedor, state);
                }
                else
                {
                    AdministradorVentanasAcoplables.AddContentToWindowContent(contenedor, ContenedorIzquierdo);
                }
            }
            else if (state == State.DockRight)
            {
                if (ContenedorDerecho == null || ContenedorDerecho.Visible == false)
                {
                    ContenedorDerecho = AdministradorVentanasAcoplables.AddContentWithState(contenedor, state);
                }
                else
                {
                    AdministradorVentanasAcoplables.AddContentToWindowContent(contenedor, ContenedorDerecho);
                }
            }
            else
            {
                AdministradorVentanasAcoplables.AddContentWithState(contenedor, state);
            }
            contenedor.PropertyChanged += new Content.PropChangeHandler(PropChangeHandler);
            contenedor.PropertyChanging += new Content.PropChangeHandler(PropChangeHandlerX);
            WindowContentTabbed wct = contenedor.ParentWindowContent as WindowContentTabbed;
            if (wct != null)
            {
                wct.TabControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
                wct.TabControl.PositionTop = PositionTop;
                wct.BringContentToFront(contenedor);
            }
        }
        private void PropChangeHandler(Content c, Content.Property p)
        {
        }
        private void PropChangeHandlerX(Content c, Content.Property p)
        {
            if (c.Docked == dox)
                return;
            dox = c.Docked;
            int o = c.Order;
        }
        private bool ExisteVentanaIzquierda(Type tipo)
        {
            foreach (Content c in AdministradorVentanasAcoplables.Contents)
            {

                if (c.Control.GetType() == tipo && c.Visible)
                    return true;
            }
            return false;
        }
        private Form DameVentana(Type tipo)
        {
            foreach (Content c in AdministradorVentanasAcoplables.Contents)
            {

                if (c.Control.GetType() == tipo && c.Visible)
                    return (Form)c.Control;
            }
            return null;

        }
        private List<Content> DameContenedorVentana(Type tipo)
        {
            List<Content> l = new List<Content>();
            foreach (Content c in AdministradorVentanasAcoplables.Contents)
            {

                if (c.Control.GetType() == tipo && c.Visible)
                {
                    l.Add(c);
                }
            }
            return l;

        }
        private void CierraContenedor(Content c)
        {
            AdministradorVentanasAcoplables.Contents.Remove(c);
        }
        #endregion
        private bool EnableCOnexion
        {
            set
            {
                //aqui hay que agregar los controles que se tienen que habilitar cuando se tenga una conexion valida
                BBuscador.Enabled = value;
                BNuevaTabla.Enabled = value;
                Bnuevo.Enabled = value;
                BAbrir.Enabled = value;
                BComparar.Enabled = value;
                BDBComparer.Enabled = value;
                BSeguir.Enabled = value;
            }
        }

        private void Conecciones(object sender, EventArgs e)
        {
            if (ExisteVentanaIzquierda(typeof(ManagerConnect.FormAdminConexiones)) == false)
            {
                ManagerConnect.FormAdminConexiones AdministradorConexiones = new ManagerConnect.FormAdminConexiones();
                VentanaAcoplable(AdministradorConexiones, 0, true, State.DockLeft);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void CargaGrupos()
        {
            List<string> grupos;
            grupos = ManagerConnect.ControladorConexiones.GetGrupos();
            ComboGrupos.Items.Clear();
            foreach (string s in grupos)
            {
                ComboGrupos.Items.Add(s);
            }
        }
        private void ComboGrupos_DropDown(object sender, EventArgs e)
        {
            CargaGrupos();
        }
        private void CargaConexiones()
        {
            //me traigo el grupo seleccionado
            if (ComboGrupos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ComboConexiones.Items.Clear();
            string grupo = ComboGrupos.Text;
            List<ManagerConnect.CConexion> lista = ManagerConnect.ControladorConexiones.GetConexiones(grupo);
            foreach (ManagerConnect.CConexion obj in lista)
            {
                ComboConexiones.Items.Add(obj);
            }
        }
        private void ComboConexiones_DropDown(object sender, EventArgs e)
        {
            CargaConexiones();
        }

        private void ComboConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
                return;
            //Asigno la conexion al motor de base de datos
            ManagerConnect.CConexion obj = (ManagerConnect.CConexion)ComboConexiones.SelectedItem;
            //me traigo el motor de base de datos
            MotorDB.EnumMotoresDB tipoDB = ManagerConnect.ControladorConexiones.DameTipoMotor(obj.MotorDB);
            DBProvider.DB = MotorDB.CProviderDataBase.DameMotor(tipoDB);
            DBProvider.DB.SetConnectionName(obj.Nombre);
            DBProvider.DB.SetConnectionString(obj.ConecctionString);
            try
            {
                if (DBProvider.DB.Conectar() == false)
                {
                    MessageBox.Show("No se puede conectar a la base de datos: " + DBProvider.DB.GetStringError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DBProvider.DB.Desconectar();
                EnableCOnexion = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //evito la seleccion de la conexion
                ComboConexiones.SelectedIndex = -1;
                EnableCOnexion = false;
                return;
            }
        }

        private void BBuscador_Click(object sender, EventArgs e)
        {
            //muestro la ventana de busqueda
            if (ExisteVentanaIzquierda(typeof(Modulos.Buscador.FormBuscadorObjetos)) == false)
            {
                Modulos.Buscador.FormBuscadorObjetos dlg = new Modulos.Buscador.FormBuscadorObjetos();
                dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }

        }
        private void VerObjeto(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            //dependiendo del tipo de objeto se muestra el visor correspondiente
            switch (tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    VerCodigo(motor, nombre, motor.DameCodigoFuncction(nombre));
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    VerCodigo(motor, nombre, motor.DameCodigoStoreProcedure(nombre));
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    MuestraTabla(motor, nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    MuestraTypeTable(motor, nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    VerCodigo(motor, nombre, motor.DameCodigoTrigger(nombre));
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    MuestraVista(motor, nombre);
                    break;
            }
        }
        private void VerDependencias(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modulos.Visores.Dependencias.FormDependencias dlg = new Modulos.Visores.Dependencias.FormDependencias(motor, nombre);
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VentanaAcoplable(dlg, 5, false, State.DockLeft);
        }
        private void VerRelaciones(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modulos.Visores.Relaciones.FormRelaciones dlg = new Modulos.Visores.Relaciones.FormRelaciones(motor, nombre);
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VentanaAcoplable(dlg, 5, false, State.DockLeft);
        }
        private void VerTrrigers(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modulos.Visores.Trrigers.FormTrigger dlg = new Modulos.Visores.Trrigers.FormTrigger(nombre);
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VentanaAcoplable(dlg, 6, false, State.DockLeft);
        }
        private void MuestraTabla(MotorDB.IMotorDB motor, string nombre)
        {
            Modulos.Visores.Tabla.FormTabla dlg = new Modulos.Visores.Tabla.FormTabla(motor, nombre);
            dlg.OnVerTablaPadre += new MotorDB.OnVerObjetoEvent(VerObjeto);
            dlg.OnVerDependencias += new MotorDB.OnVerObjetoEvent(VerDependencias);
            dlg.OnVerRelaciones += new MotorDB.OnVerObjetoEvent(VerRelaciones);
            dlg.OnVerTrrigers += new MotorDB.OnVerObjetoEvent(VerTrrigers);
            dlg.OnPropiedadesCampo += new OnPropiedadesEvent(MuestraPropuedades);
            dlg.OnVerCodigoTabla += new MotorDB.OnVerObjetoEvent(VerCodigoTabla);
            VentanaAcoplable(dlg, 4, true, State.DockRight);
        }
        private void MuestraTypeTable(MotorDB.IMotorDB motor, string nombre)
        {
            Modulos.Visores.Tabla.FormTabla dlg = new Modulos.Visores.Tabla.FormTabla(motor, nombre, true);
            dlg.OnVerTablaPadre += new MotorDB.OnVerObjetoEvent(VerObjeto);
            dlg.OnVerDependencias += new MotorDB.OnVerObjetoEvent(VerDependencias);
            dlg.OnVerRelaciones += new MotorDB.OnVerObjetoEvent(VerRelaciones);
            dlg.OnVerTrrigers += new MotorDB.OnVerObjetoEvent(VerTrrigers);
            dlg.OnPropiedadesCampo += new OnPropiedadesEvent(MuestraPropuedades);
            dlg.OnVerCodigoTabla += new MotorDB.OnVerObjetoEvent(VerCodigoTabla);
            VentanaAcoplable(dlg, 4, true, State.DockRight);
        }
        private void MuestraPropuedades(Modulos.Visores.CPropiedadesBase obj)
        {
            Modulos.Visores.Propiedades.FormPropiedades dlg = null;
            dlg = (Modulos.Visores.Propiedades.FormPropiedades)DameVentana(typeof(Modulos.Visores.Propiedades.FormPropiedades));
            if (dlg == null)
                return;
            dlg.Objeto = obj;
        }

        private void Bpropiedades_Click(object sender, EventArgs e)
        {
            //muestra la ventyana de propiedades
            Modulos.Visores.Propiedades.FormPropiedades dlg = null;
            dlg = (Modulos.Visores.Propiedades.FormPropiedades)DameVentana(typeof(Modulos.Visores.Propiedades.FormPropiedades));
            if (dlg == null)
            {
                dlg = new Modulos.Visores.Propiedades.FormPropiedades();
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }
        }

        private void BNuevaTabla_Click(object sender, EventArgs e)
        {
            Modulos.CreadorTabla.FormNuevaTabla dlg = new Modulos.CreadorTabla.FormNuevaTabla(DBProvider.DB);
            dlg.OnVerTabla += new MotorDB.OnVerObjetoEvent(VerObjeto);
            dlg.ShowDialog();
        }

        private void ComboConexiones_Click(object sender, EventArgs e)
        {

        }
        private void MuestraVista(MotorDB.IMotorDB motor, string nombre)
        {
            Modulos.Visores.Vista.FormVista dlg = new Modulos.Visores.Vista.FormVista(motor, nombre);
            dlg.OnVerTablaPadre += new MotorDB.OnVerObjetoEvent(VerObjeto);
            dlg.OnVerDependencias += new MotorDB.OnVerObjetoEvent(VerDependencias);
            dlg.OnVerRelaciones += new MotorDB.OnVerObjetoEvent(VerRelaciones);
            dlg.OnVerTrrigers += new MotorDB.OnVerObjetoEvent(VerTrrigers);
            dlg.OnPropiedadesCampo += new OnPropiedadesEvent(MuestraPropuedades);
            dlg.OnVerCodigoVista += new MotorDB.OnVerObjetoEvent(VerCodigoVista);
            VentanaAcoplable(dlg, 4, true, State.DockRight);
        }
        private void CargaEditor()
        {
            if (VEditor == null)
            {
                VEditor = new EditorManager.FormEditor();
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new EditorManager.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new EditorManager.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
        }
        private void OnCerrarEditor()
        {
            VEditor = null;
        }
        private bool PuedoCerrarPestaña()
        {
            return CerrarPespaña;
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            CargaEditor();
            TextEditor.CTextEdit edit = new TextEditor.CTextEdit();
            edit.Motor = DBProvider.DB;
            edit.Nombre = "Sin titulo";
            edit.Grupo = ComboGrupos.Text;
            edit.Conexion = ComboConexiones.Text;
            edit.ColorEditor = ColorEditor;// DBProvider.DB.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new TextEditor.OnBuscarTextoEvent(BuscarTexto);
            edit.VerVariables += new TextEditor.OnBuscarTextoEvent(VerVariabes);
            edit.OnFoco += new TextEditor.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            edit.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VEditor.AgregaEditor(edit, "Sin titulo");
        }
        private void VerCodigo(MotorDB.IMotorDB motor, string nombre, string codigo)
        {
            ManagerConnect.CPropiedadesMotor propiedades = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(motor);
            CargaEditor();
            TextEditor.CTextEdit edit = new TextEditor.CTextEdit();
            edit.Motor = motor;
            edit.CodigoFuente = codigo;
            edit.Nombre = nombre;
            edit.Grupo = propiedades.Grupo;
            edit.Conexion = propiedades.Conexion.Nombre;
            edit.ColorEditor = ColorEditor;// motor.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new TextEditor.OnBuscarTextoEvent(BuscarTexto);
            edit.VerVariables += new TextEditor.OnBuscarTextoEvent(VerVariabes);
            edit.OnFoco += new TextEditor.OnBuscarTextoEvent(EditorFocoText);
            edit.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            VEditor.AgregaEditor(edit, nombre);
            edit.SetFocus();
        }
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Cerrando == true)
                return;
            CerrarPespaña = false;
            if (configuradorApp1.GetBooleanParameter("MostrarDialogoCerrar"))
            {
                if (MessageBox.Show("Cerrar la aplicación", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    Cerrando = false;
                    CerrarPespaña = true;
                    return;
                }
            }
            Cerrando = true;
            if (VEditor != null)
            {
                if(VEditor.CierraPestañas()==false)
                {
                    Cerrando = false;
                    CerrarPespaña = true;
                    return;
                }
            }
            Application.Exit();

        }
        private void VerCodigoVista(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            VerCodigo(motor, nombre, motor.DameCodigoVista(nombre));
        }
        private void VerCodigoTabla(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            VerCodigo(motor, nombre, motor.DameCodigoTabla(nombre));
        }

        private void BAbrir_Click(object sender, EventArgs e)
        {
            CargaEditor();
            TextEditor.CTextEdit edit = new TextEditor.CTextEdit();
            edit.Motor = DBProvider.DB;
            edit.Nombre = "Sin titulo";
            edit.Grupo = ComboGrupos.Text;
            edit.Conexion = ComboConexiones.Text;
            edit.ColorEditor = ColorEditor;// DBProvider.DB.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new TextEditor.OnBuscarTextoEvent(BuscarTexto);
            edit.VerVariables += new TextEditor.OnBuscarTextoEvent(VerVariabes);
            edit.OnFoco += new TextEditor.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            edit.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VEditor.AgregaEditor(edit, "Sin titulo");
            edit.Abrir();
        }

        private void gestorDeTabuladoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLDeveloper.Modulos.Herramientas.GestorBloques.FormConfigBloques dlg = new Modulos.Herramientas.GestorBloques.FormConfigBloques();
            dlg.ShowDialog();
        }

        private void MenuTemas_Click(object sender, EventArgs e)
        {
            Modulos.Herramientas.GestorColors.FormGestorColor dlg = new Modulos.Herramientas.GestorColors.FormGestorColor();
            dlg.OnEditConfigChange += new Modulos.Herramientas.GestorColors.OnEditConfigChangeEvent(EditConfigChangeEvent);
            dlg.ShowDialog();
        }
        private void EditConfigChangeEvent(string archivo)
        {
            if (OnRecargaColores != null)
                OnRecargaColores();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfig dlg = new FormConfig();
            dlg.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            VerificaColorSintaxis();
            LoadHistoryproyects();
            ManagerConnect.FormConexionInicial dlg = new ManagerConnect.FormConexionInicial();
            dlg.OnConexion += new ManagerConnect.OnFormConexionInicialEvent(ConexionInicial);
            dlg.ShowDialog();
        }
        private void ConexionInicial(string grupo, ManagerConnect.CConexion conexion)
        {
            //me cargo los grupos
            CargaGrupos();
            ComboGrupos.SelectedItem = grupo;
            CargaConexiones();
            foreach (ManagerConnect.CConexion obj in ComboConexiones.Items)
            {
                if (obj.Nombre == conexion.Nombre)
                {
                    ComboConexiones.SelectedItem = obj;
                }
            }
        }


        private void BComparar_Click(object sender, EventArgs e)
        {
            if (VEditor == null)
                return;
            Dictionary<int, EditorManager.EditorGenerico> l = VEditor.GetTabs();
            List<EditorManager.EditorGenerico> l2 = new List<EditorManager.EditorGenerico>();
            foreach (KeyValuePair<int, EditorManager.EditorGenerico> obj in l)
            {
                if (obj.Value.Comparable)
                {
                    l2.Add(obj.Value);
                }
            }
            Modulos.Comparador.FormSelector dlg = new Modulos.Comparador.FormSelector("Comprar", "Izquierda", "Derecha", l2, l2);
            dlg.OnSeleccion += new Modulos.Comparador.ONFormSelectorEvent(Comparar);
            dlg.ShowDialog();
        }
        private void MenuNuevoProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = ".dbp";
                string nombre = "";
                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                nombre = saveFileDialog1.FileName;
                if (!saveFileDialog1.FileName.Contains("."))
                    nombre = saveFileDialog1.FileName + ".dbp";
                Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.NewProject(saveFileDialog1.FileName);
                MuestraProyecto(modelo);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuAbrirProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.OpenProject(openFileDialog1.FileName);
                MuestraProyecto(modelo);
                //Modulos.ProyectAdmin.FormProyect dlg = new Modulos.ProyectAdmin.FormProyect(modelo);
                //dlg.ONVerCodigo += new Modulos.ProyectAdmin.OnFormProyectCodigoEvent(VerCodigoProyecto);
                //dlg.OnCerrarProyecto += new Modulos.ProyectAdmin.FormProyectEvent(CerrarProyecto);
                //dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
                //VentanaAcoplable(dlg, 4, true, State.DockLeft);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHistoryproyects()
        {
            try
            {
                MenuProyectoReciente.DropDownItems.Clear();
                //ahora lo agrego al menu abrir
                Dictionary<string, string> l = cProjectManager1.GetHistory();
                foreach (var obj in l)
                {
                    System.Windows.Forms.ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = obj.Key;
                    item.Tag = obj.Value;
                    item.Click += new EventHandler(MenuAbrirItem_Click);
                    MenuProyectoReciente.DropDownItems.Add(item);
                }
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        private void MenuAbrirItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                string archivo = menu.Tag.ToString();
                if (!System.IO.File.Exists(archivo))
                {
                    if (MessageBox.Show("EL proyecto: " + menu.Text + " ya no existe.\n ¿Desea quitarlo de la lista?", "Archivo no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        cProjectManager1.RemoveHistory(archivo);
                        LoadHistoryproyects();
                        return;
                    }
                }
                Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.OpenProject(archivo);
                MuestraProyecto(modelo);
                //Modulos.ProyectAdmin.FormProyect dlg = new Modulos.ProyectAdmin.FormProyect(modelo);
                //dlg.ONVerCodigo += new Modulos.ProyectAdmin.OnFormProyectCodigoEvent(VerCodigoProyecto);
                //dlg.OnCerrarProyecto += new Modulos.ProyectAdmin.FormProyectEvent(CerrarProyecto);
                //dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
                //VentanaAcoplable(dlg, 4, true, State.DockLeft);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CerrarProyecto(Modulos.ProyectAdmin.FormProyect sender, string archivo)
        {
            //cierro el formulario
            cProjectManager1.CierraProyecto(archivo);
            List<Content> l = DameContenedorVentana(typeof(Modulos.ProyectAdmin.FormProyect));
            foreach (Content c in l)
            {
                if ((Modulos.ProyectAdmin.FormProyect)c.Control == sender)
                {
                    CierraContenedor(c);
                    break;
                }
            }
            sender.Close();
        }

        private void BBuscaAvanzado_Click(object sender, EventArgs e)
        {
            //muestro la ventana de busqueda
            if (ExisteVentanaIzquierda(typeof(Modulos.Buscador.FormBuscadorAvanzado)) == false)
            {

                Modulos.Buscador.FormBuscadorAvanzado dlg = new Modulos.Buscador.FormBuscadorAvanzado(DBProvider.DB);
                dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }
        }

        private void generadorLiberiaCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulos.CSharpLibaryGenerator.FormLybraryGenrator dlg = new Modulos.CSharpLibaryGenerator.FormLybraryGenrator();
            VentanaAcoplable(dlg, 0, true, State.DockLeft);
        }
        private void Comparar(string Codigo1, string Codigo2, string titulo1, string titulo2, string ColorEditor)
        {
            CargaEditor();
            Modulos.Comparador.CompareViewer edit = new Modulos.Comparador.CompareViewer();
            edit.TextIzquierdo = Codigo1;
            edit.TextoDerecho = Codigo2;
            edit.TituloIzquierdo = titulo1;
            edit.TituloDerech = titulo2;
            edit.ColorEditor = ColorEditor;// DBProvider.DB.GetMotor().ToString();
            VEditor.AgregaEditor(edit, "Comparador");
            edit.SetFocus();
        }
        private EditorManager.EditorGenerico VerCodigoProyecto(string objeto, string codigo, MotorDB.IMotorDB motor, string grupo, string conexion, FileManager.IFileManager fm = null)
        {
            CargaEditor();

            TextEditor.CTextEdit edit = new TextEditor.CTextEdit();
            edit.Motor = motor;
            edit.CodigoFuente = codigo;
            edit.Nombre = objeto;
            edit.Grupo = grupo;
            edit.Conexion = conexion;
            edit.ColorEditor = ColorEditor;// motor.GetMotor().ToString();
            if (fm == null)
                edit.GestorArchivo = new FileManager.CFileManager();
            else
                edit.GestorArchivo = fm;
            edit.OnBuscarTexto += new TextEditor.OnBuscarTextoEvent(BuscarTexto);
            edit.VerVariables += new TextEditor.OnBuscarTextoEvent(VerVariabes);
            edit.OnFoco += new TextEditor.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            edit.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VEditor.AgregaEditor(edit, objeto);
            edit.SetFocus();
            return edit;
        }
        private void MuestraProyecto(Modulos.ProyectAdmin.ModeloBasico modelo)
        {
            Modulos.ProyectAdmin.FormProyect dlg = new Modulos.ProyectAdmin.FormProyect(modelo);
            dlg.ONVerCodigo += new Modulos.ProyectAdmin.OnFormProyectCodigoEvent(VerCodigoProyecto);
            dlg.OnCerrarProyecto += new Modulos.ProyectAdmin.FormProyectEvent(CerrarProyecto);
            dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
            dlg.OnEditorComentaro += new Modulos.ProyectAdmin.FormProyectEventEditorComentaro(MuestraEditor);
            VentanaAcoplable(dlg, 4, true, State.DockLeft);
        }
        private void MuestraEditor(EditorManager.EditorGenerico edit, string titulo)
        {
            CargaEditor();
            VEditor.AgregaEditor(edit, titulo);
            edit.SetFocus();
        }
        private string Directorio
        {
            get
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\Colores") == false)
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Colores");
                return Application.StartupPath + "\\Colores";
            }
        }
        private void VerificaColorSintaxis()
        {
            //verifica si hay archivos de definicion de colores.
            //sim no hay ninguno, crea uno por default para SQL SERVER
            string[] Archivos;
            Archivos = System.IO.Directory.GetFiles(Directorio, "*.xshd");
            if (Archivos.Length != 0)
                return;
            StreamWriter sr = System.IO.File.CreateText(Directorio + "\\SQLSERVER.xshd");
            #region escritura del archivo
            sr.WriteLine("<?xml version = \"1.0\"?>");
            sr.WriteLine("<SyntaxDefinition name = \"SQLSERVER\" extensions = \".sql\">");
            sr.WriteLine("	<Environment>");
            sr.WriteLine("		<Default      color=\"#FFFF00\" bgcolor=\"#000000\"/>");
            sr.WriteLine("		<VRuler       color = \"Blue\"/>");
            sr.WriteLine("		<Selection    bgcolor = \"LightBlue\"/>");
            sr.WriteLine("		<LineNumbers  color = \"Teal\" bgcolor = \"SystemColors.Window\"/>");
            sr.WriteLine("		<InvalidLines color = \"Red\"/>");
            sr.WriteLine("		<EOLMarkers   color = \"White\"/>");
            sr.WriteLine("		<SpaceMarkers color = \"#E0E0E5\"/>");
            sr.WriteLine("		<TabMarkers   color = \"#E0E0E5\"/>");
            sr.WriteLine("		<CaretMarker  color = \"Yellow\"/>");
            sr.WriteLine("		<FoldLine     color = \"#808080\" bgcolor=\"Black\"/>");
            sr.WriteLine("		<FoldMarker   color = \"#808080\" bgcolor=\"White\"/>");
            sr.WriteLine("	</Environment>");
            sr.WriteLine("	<Properties>");
            sr.WriteLine("		<Property name=\"LineComment\" value=\"--\"/>");
            sr.WriteLine("	</Properties>");
            sr.WriteLine("	<Digits name = \"Digits\" bold = \"true\" italic = \"false\" color=\"#C0C0C0\"/>");
            sr.WriteLine("	<RuleSets>");
            sr.WriteLine("		<RuleSet ignorecase = \"true\">");
            sr.WriteLine("			<Delimiters>=!&gt;&lt;+-/*%&amp;|^~.}{,;][?:()</Delimiters>");
            sr.WriteLine("			<Span name =\"LineComment\" bold =\"false\" italic =\"true\" color =\"#CE0000\" stopateol =\"true\">");
            sr.WriteLine("				<Begin>--</Begin>");
            sr.WriteLine("			</Span>");
            sr.WriteLine("			<Span name =\"BlockComment\" bold =\"false\" italic =\"true\" color =\"#FF0000\" stopateol =\"false\">");
            sr.WriteLine("				<Begin>/*</Begin>");
            sr.WriteLine("				<End>*/</End>");
            sr.WriteLine("			</Span>");
            sr.WriteLine("			<Span name =\"String\" bold =\"true\" italic =\"false\" color =\"#FFFFFF\" stopateol =\"false\">");
            sr.WriteLine("				<Begin>&quot;</Begin>");
            sr.WriteLine("				<End>&quot;</End>");
            sr.WriteLine("			</Span>");
            sr.WriteLine("			<Span name =\"Character\" bold =\"true\" italic =\"false\" color =\"#FFFFFF\" stopateol =\"true\">");
            sr.WriteLine("				<Begin>&apos;</Begin>");
            sr.WriteLine("				<End>&apos;</End>");
            sr.WriteLine("			</Span>");
            sr.WriteLine("			<Span name =\"LineCommentC\" bold =\"false\" italic =\"true\" color =\"#C40000\" stopateol =\"true\">");
            sr.WriteLine("				<Begin>//</Begin>");
            sr.WriteLine("			</Span>");
            sr.WriteLine("			<KeyWords name =\"JoinKeywords\" bold=\"true\" italic = \"false\" color=\"#8080FF\">");
            sr.WriteLine("				<Key word = \"INNER\" />");
            sr.WriteLine("				<Key word = \"JOIN\" />");
            sr.WriteLine("				<Key word = \"LEFT\" />");
            sr.WriteLine("				<Key word = \"RIGHT\" />");
            sr.WriteLine("				<Key word = \"OUTER\" />");
            sr.WriteLine("				<Key word = \"UNION\" />");
            sr.WriteLine("				<Key word = \"ON\" />");
            sr.WriteLine("				<Key word = \"NOCOUNT\" />");
            sr.WriteLine("				<Key word = \"OFF\" />");
            sr.WriteLine("				<Key word = \"FULL\" />");
            sr.WriteLine("				<Key word = \"ALL\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"AliasKeywords\" bold=\"true\" italic = \"false\" color=\"#0000FF\">");
            sr.WriteLine("				<Key word = \"AS\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"ComparisonKeywords\" bold=\"true\" italic = \"false\" color=\"#008080\">");
            sr.WriteLine("				<Key word = \"AND\" />");
            sr.WriteLine("				<Key word = \"OR\" />");
            sr.WriteLine("				<Key word = \"LIKE\" />");
            sr.WriteLine("				<Key word = \"IN\" />");
            sr.WriteLine("				<Key word = \"EXISTS\" />");
            sr.WriteLine("				<Key word = \"BETWEEN\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"DestructiveKeywords\" bold=\"true\" italic = \"false\" color=\"Red\">");
            sr.WriteLine("				<Key word = \"DROP\" />");
            sr.WriteLine("				<Key word = \"DELETE\" />");
            sr.WriteLine("				<Key word = \"TRUNCATE\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SpecializedKeywords\" bold=\"true\" italic = \"false\" color=\"#08D625\">");
            sr.WriteLine("				<Key word = \"TOP\" />");
            sr.WriteLine("				<Key word = \"DISTINCT\" />");
            sr.WriteLine("				<Key word = \"LIMIT\" />");
            sr.WriteLine("				<Key word = \"OPENDATASOURCE\" />");
            sr.WriteLine("				<Key word = \"GO\" />");
            sr.WriteLine("				<Key word = \"USE\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"TransactionKeyWords\" bold=\"true\" italic = \"false\" color=\"#DA800A\">");
            sr.WriteLine("				<Key word = \"COMMIMT\" />");
            sr.WriteLine("				<Key word = \"ROLLBACK\" />");
            sr.WriteLine("				<Key word = \"TRANSACTION\" />");
            sr.WriteLine("				<Key word = \"TRAN\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"DebugKeyWords\" bold=\"true\" italic = \"false\" color=\"#FF9900\">");
            sr.WriteLine("				<Key word = \"TRY\" />");
            sr.WriteLine("				<Key word = \"CATCH\" />");
            sr.WriteLine("				<Key word = \"RAISERROR\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"CursorKeywords\" bold=\"true\" italic = \"false\" color=\"#00869E\">");
            sr.WriteLine("				<Key word = \"CURSOR\" />");
            sr.WriteLine("				<Key word = \"FOR\" />");
            sr.WriteLine("				<Key word = \"OPEN\" />");
            sr.WriteLine("				<Key word = \"FETCH\" />");
            sr.WriteLine("				<Key word = \"NEXT\" />");
            sr.WriteLine("				<Key word = \"CLOSE\" />");
            sr.WriteLine("				<Key word = \"DEALLOCATE\" />");
            sr.WriteLine("				<Key word = \"FOREACH\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SqlKeywords\" bold=\"true\" italic = \"false\" color=\"#8080FF\">");
            sr.WriteLine("				<Key word = \"NOT\" />");
            sr.WriteLine("				<Key word = \"SET\" />");
            sr.WriteLine("				<Key word = \"DESC\" />");
            sr.WriteLine("				<Key word = \"ASC\" />");
            sr.WriteLine("				<Key word = \"EXEC\" />");
            sr.WriteLine("				<Key word = \"WITH\" />");
            sr.WriteLine("				<Key word = \"EXECUTE\" />");
            sr.WriteLine("				<Key word = \"identity\" />");
            sr.WriteLine("				<Key word = \"NOLOCK\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SqlActionWords\" bold=\"true\" italic = \"false\" color=\"#0080FF\">");
            sr.WriteLine("				<Key word = \"INSERT\" />");
            sr.WriteLine("				<Key word = \"SELECT\" />");
            sr.WriteLine("				<Key word = \"UPDATE\" />");
            sr.WriteLine("				<Key word = \"FROM\" />");
            sr.WriteLine("				<Key word = \"WHERE\" />");
            sr.WriteLine("				<Key word = \"HAVING\" />");
            sr.WriteLine("				<Key word = \"GROUP\" />");
            sr.WriteLine("				<Key word = \"BY\" />");
            sr.WriteLine("				<Key word = \"ORDER\" />");
            sr.WriteLine("				<Key word = \"CREATE\" />");
            sr.WriteLine("				<Key word = \"ALTER\" />");
            sr.WriteLine("				<Key word = \"ADD\" />");
            sr.WriteLine("				<Key word = \"NULL\" />");
            sr.WriteLine("				<Key word = \"INTO\" />");
            sr.WriteLine("				<Key word = \"VALUES\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SqlTypes\" bold=\"true\" italic = \"false\" color=\"#80FFFF\">");
            sr.WriteLine("				<Key word = \"VARCHAR\" />");
            sr.WriteLine("				<Key word = \"NVARCHAR\" />");
            sr.WriteLine("				<Key word = \"CHAR\" />");
            sr.WriteLine("				<Key word = \"NCHAR\" />");
            sr.WriteLine("				<Key word = \"INT\" />");
            sr.WriteLine("				<Key word = \"TEXT\" />");
            sr.WriteLine("				<Key word = \"NTEXT\" />");
            sr.WriteLine("				<Key word = \"DOUBLE\" />");
            sr.WriteLine("				<Key word = \"MONEY\" />");
            sr.WriteLine("				<Key word = \"BIT\" />");
            sr.WriteLine("				<Key word = \"DATETIME\" />");
            sr.WriteLine("				<Key word = \"DECIMAL\" />");
            sr.WriteLine("				<Key word = \"FLOAT\" />");
            sr.WriteLine("				<Key word = \"DATE\" />");
            sr.WriteLine("				<Key word = \"DEFAULT\" />");
            sr.WriteLine("				<Key word = \"real\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SqlObjects\" bold=\"true\" italic = \"true\" color=\"#FF8000\">");
            sr.WriteLine("				<Key word = \"TABLE\" />");
            sr.WriteLine("				<Key word = \"PROC\" />");
            sr.WriteLine("				<Key word = \"PROCEDURE\" />");
            sr.WriteLine("				<Key word = \"FUNCTION\" />");
            sr.WriteLine("				<Key word = \"VIEW\" />");
            sr.WriteLine("				<Key word = \"TRIGGER\" />");
            sr.WriteLine("				<Key word = \"INDEX\" />");
            sr.WriteLine("				<Key word = \"DATABASE\" />");
            sr.WriteLine("				<Key word = \"TYPE\" />");
            sr.WriteLine("				<Key word = \"column\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"FlowControlKeyWords\" bold=\"true\" italic = \"true\" color=\"#408080\">");
            sr.WriteLine("				<Key word = \"IF\" />");
            sr.WriteLine("				<Key word = \"ELSE\" />");
            sr.WriteLine("				<Key word = \"CASE\" />");
            sr.WriteLine("				<Key word = \"WHEN\" />");
            sr.WriteLine("				<Key word = \"THEN\" />");
            sr.WriteLine("				<Key word = \"WHILE\" />");
            sr.WriteLine("				<Key word = \"WAITFOR\" />");
            sr.WriteLine("				<Key word = \"DELAY\" />");
            sr.WriteLine("				<Key word = \"RETURN\" />");
            sr.WriteLine("				<Key word = \"SWITCH\" />");
            sr.WriteLine("				<Key word = \"BREAK\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"TSql\" bold=\"true\" italic = \"false\" color=\"#339900\">");
            sr.WriteLine("				<Key word = \"DECLARE\" />");
            sr.WriteLine("				<Key word = \"BEGIN\" />");
            sr.WriteLine("				<Key word = \"END\" />");
            sr.WriteLine("				<Key word = \"#REGION\" />");
            sr.WriteLine("				<Key word = \"#ENDREGION\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"Punctuation\" bold=\"false\" italic = \"false\" color=\"#FFFFFF\">");
            sr.WriteLine("				<Key word = \"(\" />");
            sr.WriteLine("				<Key word = \")\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"Operators\" bold=\"false\" italic = \"false\" color=\"#FFFFFF\">");
            sr.WriteLine("				<Key word = \"&lt;\" />");
            sr.WriteLine("				<Key word = \"&gt;\" />");
            sr.WriteLine("				<Key word = \"=\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"Functions\" bold=\"true\" italic = \"false\" color=\"BlueViolet\">");
            sr.WriteLine("				<Key word = \"SUBSTRING\" />");
            sr.WriteLine("				<Key word = \"UPPER\" />");
            sr.WriteLine("				<Key word = \"LOWER\" />");
            sr.WriteLine("				<Key word = \"REVERSE\" />");
            sr.WriteLine("				<Key word = \"REPLACE\" />");
            sr.WriteLine("				<Key word = \"LTRIM\" />");
            sr.WriteLine("				<Key word = \"RTRIM\" />");
            sr.WriteLine("				<Key word = \"CAST\" />");
            sr.WriteLine("				<Key word = \"CONVERT\" />");
            sr.WriteLine("				<Key word = \"ISNULL\" />");
            sr.WriteLine("				<Key word = \"DATEDIFF\" />");
            sr.WriteLine("				<Key word = \"GETDATE\" />");
            sr.WriteLine("				<Key word = \"FLOOR\" />");
            sr.WriteLine("				<Key word = \"openquery\" />");
            sr.WriteLine("				<Key word = \"dateadd\" />");
            sr.WriteLine("				<Key word = \"POWER\" />");
            sr.WriteLine("				<Key word = \"ISDATE\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"GroupByFunctions\" bold=\"true\" italic = \"false\" color=\"#AE1737\">");
            sr.WriteLine("				<Key word = \"SUM\" />");
            sr.WriteLine("				<Key word = \"COUNT\" />");
            sr.WriteLine("				<Key word = \"MAX\" />");
            sr.WriteLine("				<Key word = \"MIN\" />");
            sr.WriteLine("				<Key word = \"AVG\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SignosEspeciales\" bold=\"true\" italic = \"true\" color=\"#FF0000\">");
            sr.WriteLine("				<Key word = \"->\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"Constantes\" bold=\"false\" italic = \"false\" color=\"#FF8040\">");
            sr.WriteLine("				<Key word = \"month\" />");
            sr.WriteLine("				<Key word = \"YEAR\" />");
            sr.WriteLine("				<Key word = \"DAY\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("			<KeyWords name =\"SystemVariables\" bold=\"false\" italic = \"false\" color=\"#808080\">");
            sr.WriteLine("				<Key word = \"@@TRANCOUNT\" />");
            sr.WriteLine("				<Key word = \"@@Error\" />");
            sr.WriteLine("			</KeyWords>");
            sr.WriteLine("		</RuleSet>");
            sr.WriteLine("	</RuleSets>");
            sr.WriteLine("</SyntaxDefinition>");
            #endregion
            sr.Close();
        }
        private void EditorFocoText(ICSharpCode.TextEditor.TextEditorControl Editor)
        {
            Modulos.Editores.FormBuscador dlg;
            dlg = (Modulos.Editores.FormBuscador)DameVentana(typeof(Modulos.Editores.FormBuscador));
            if (dlg != null)
            {
                dlg.Editor = Editor;
            }
            Modulos.Visores.Variables.FormVariables dlg2 = (Modulos.Visores.Variables.FormVariables)DameVentana(typeof(Modulos.Visores.Variables.FormVariables));
            if (dlg2 != null)
            {
                dlg2.Editor = Editor;
            }
        }
        private void BuscarTexto(ICSharpCode.TextEditor.TextEditorControl Editor)
        {
            if (ExisteVentanaIzquierda(typeof(Modulos.Editores.FormBuscador)) == false)
            {
                Modulos.Editores.FormBuscador dlg = new Modulos.Editores.FormBuscador();
                dlg.Editor = Editor;
                VentanaAcoplable(dlg, 0, true, State.DockRight);
            }

        }
        private void VerVariabes(ICSharpCode.TextEditor.TextEditorControl Editor)
        {
            if (ExisteVentanaIzquierda(typeof(Modulos.Visores.Variables.FormVariables)) == false)
            {
                Modulos.Visores.Variables.FormVariables dlg = new Modulos.Visores.Variables.FormVariables();
                dlg.Editor = Editor;
                VentanaAcoplable(dlg, 0, true, State.DockRight);
            }
        }

        private void BDBComparer_Click(object sender, EventArgs e)
        {
            if (ExisteVentanaIzquierda(typeof(Modulos.DBComparador.ComparadorDB)) == false)
            {
                Modulos.DBComparador.ComparadorDB dlg = new Modulos.DBComparador.ComparadorDB();
                dlg.OnCompararCodigo += new Modulos.DBComparador.OnComparadorDBEvent(Comparar);
                dlg.OnVerCodigoObjeto += new Modulos.DBComparador.OnComparadorDBVerCodigoEvent(VerCodigo);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }
        }

        private void BSeguir_Click(object sender, EventArgs e)
        {
            //muestro la ventana de busqueda
            if (ExisteVentanaIzquierda(typeof(Modulos.BuscadorSeguidor.FormBuscadorSeguidor)) == false)
            {

                Modulos.BuscadorSeguidor.FormBuscadorSeguidor dlg = new Modulos.BuscadorSeguidor.FormBuscadorSeguidor(DBProvider.DB);
                dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }

        }

        private void BBuscadorTablas_Click(object sender, EventArgs e)
        {
            //muestro la ventana de busqueda
            if (ExisteVentanaIzquierda(typeof(Modulos.BuscadorTablas.FormBuscadorDependencias)) == false)
            {

                Modulos.BuscadorTablas.FormBuscadorDependencias dlg = new Modulos.BuscadorTablas.FormBuscadorDependencias(DBProvider.DB);
                dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }

        }

        private void CerrarProyectoAplicacion(Modulos.AppsAnalizer.Formularios.FormAppsAnalizer sender, string archivo)
        {
            //cierro el formulario
//            cProjectManager1.CierraProyecto(archivo);
            List<Content> l = DameContenedorVentana(typeof(Modulos.AppsAnalizer.Formularios.FormAppsAnalizer));
            foreach (Content c in l)
            {
                if ((Modulos.AppsAnalizer.Formularios.FormAppsAnalizer)c.Control == sender)
                {
                    CierraContenedor(c);
                    break;
                }
            }
            sender.Close();
        }
        private void analizadorDeAplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //saveFileDialog1.DefaultExt = ".dbp";
                //string nombre = "";
                //if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                //    return;
                //nombre = saveFileDialog1.FileName;
                //if (!saveFileDialog1.FileName.Contains("."))
                //    nombre = saveFileDialog1.FileName + ".dbp";
                //Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.NewProject(saveFileDialog1.FileName);
                //MuestraProyecto(modelo);
                Modulos.AppsAnalizer.Formularios.FormAppsAnalizer dlg = new Modulos.AppsAnalizer.Formularios.FormAppsAnalizer();
                dlg.ONVerCodigo += new Modulos.AppsAnalizer.Formularios.OnFormAppsAnalizerCodigoEvent(VerCodigoProyecto);
                dlg.OnCerrarProyecto += new Modulos.AppsAnalizer.Formularios.FormAppsAnalizerEvent(CerrarProyectoAplicacion);
                dlg.OnAbrirArchivo += new Modulos.AppsAnalizer.Formularios.FormAppsAnalizerSimpleEvent(AbrirArchivo);
                //dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
                dlg.OnEditorComentaro += new Modulos.AppsAnalizer.Formularios.FormAppsAnalizerEventEditorComentaro(MuestraEditor);
                VentanaAcoplable(dlg, 4, true, State.DockLeft);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AbrirArchivo(string archivo)
        {
            string[] l = archivo.Split('\\');
            string nombreArchivoCorto = l[l.Length - 1];
            CargaEditor();
            TextEditor.CTextEdit edit = new TextEditor.CTextEdit();
            edit.Motor = DBProvider.DB;
            edit.Nombre = nombreArchivoCorto;
            edit.Grupo = ComboGrupos.Text;
            edit.Conexion = ComboConexiones.Text;
            edit.ColorEditor = ColorEditor;// DBProvider.DB.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new TextEditor.OnBuscarTextoEvent(BuscarTexto);
            edit.VerVariables += new TextEditor.OnBuscarTextoEvent(VerVariabes);
            edit.OnFoco += new TextEditor.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            edit.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            VEditor.AgregaEditor(edit, "Sin titulo");
            edit.Abrir(archivo);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormAcercaDe dlg = new Forms.FormAcercaDe();
            dlg.ShowDialog();
        }
        private string ColorEditor
        {
            get
            {
                if (File.Exists(Directorio + "\\DefaultTeme.dft"))
                {
                    StreamReader sr = File.OpenText(Directorio + "\\DefaultTeme.dft");
                    string tema = sr.ReadToEnd();
                    sr.Close();
                    return tema;
                }
                return DBProvider.DB.GetMotor().ToString();
            }
        }
        private void Comparar(string opcion1, string opcion2, String Codigo1, String Codigo2)
        {

            CargaEditor();
            Modulos.Comparador.CompareViewer edit = new Modulos.Comparador.CompareViewer();
            edit.TextIzquierdo = Codigo1;
            edit.TextoDerecho = Codigo2;
            edit.TituloIzquierdo = opcion1;
            edit.TituloDerech = opcion2;
            edit.ColorEditor = ColorEditor;// DBProvider.DB.GetMotor().ToString();
            VEditor.AgregaEditor(edit, "Comparador");
            edit.SetFocus();

        }

        private void BModeloador_Click(object sender, EventArgs e)
        {
            if (ExisteVentanaIzquierda(typeof(Modelador.UI.FormModeler)) == false)
            {
                Modelador.UI.FormModeler dlg = new Modelador.UI.FormModeler();
                dlg.OnVerDiseñador += new EditorManager.OnShowEditorGenericoEvent(VerModeladorDiagramas);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
                dlg.VerDiseñador();
            }
        }
        private void VerModeladorDiagramas(EditorManager.EditorGenerico edit, string text)
        {
            CargaEditor();
            VEditor.AgregaEditor(edit, text);
            edit.SetFocus();
        }
    }
}
   