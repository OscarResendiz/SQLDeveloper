using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CNodoCarpeta : CNodoFolder
    {
        //menu
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregarCarpeta;
        private System.Windows.Forms.ToolStripMenuItem MenuRenombrar;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoScript;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoDocumento;
        private System.Windows.Forms.ToolStripMenuItem MenuMultiAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuScript;
        public CNodoCarpeta()
        {
            Nombre = "Carpeta Nueva";
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
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
                    return Modelo.DameCoemtariosCarpeta(ID_Carpeta);
                }
                return "";
            }
            set
            {
                if (Modelo != null)
                {

                    Modelo.AsignaComentariosCarpeta(ID_Carpeta, value);
                }

            }
        }
        public override void ModeloAsignado()
        {
            RecargaTodo();
            Modelo.OnCarpetaModelChange += new ONModeloBasicoEvent(RecargaTodo);
            Modelo.OnScriptModelChange += new ONModeloBasicoEvent(CargaScripts);
            Modelo.OnDocumentModelChange += new ONModeloBasicoEvent(CargaDocumentos);
        }
         ~CNodoCarpeta()
        {
            Modelo.OnCarpetaModelChange -= RecargaTodo;
            Modelo.OnScriptModelChange -= CargaScripts;
            Modelo.OnDocumentModelChange -= CargaDocumentos;
        }

        private void RecargaTodo()
        {
            CargaCarpetas();
            CargaObjetos();
            CargaScripts();
            CargaDocumentos();

        }
        private bool ExisteCarpeta(int id_carpeta)
        {
            foreach (CNodoBase obj in Nodes)
            {
                if (obj.GetType() == typeof(CNodoCarpeta))
                {
                    CNodoCarpeta obj2 = (CNodoCarpeta)obj;
                    if (obj2.ID_Carpeta == id_carpeta)
                        return true;
                }
            }
            return false;
        }
        private bool ExisteObjeto(int id_objeto)
        {
            foreach (CNodoBase obj in Nodes)
            {
                if (obj.GetType() == typeof(CNodoObjeto))
                {
                    CNodoObjeto obj2 = (CNodoObjeto)obj;
                    if (obj2.ID_Objeto == id_objeto)
                        return true;
                }
            }
            return false;
        }
        private void CargaObjetos()
        {
            List<CModelObjeto> l = Modelo.DameObjetosCarpeta(ID_Carpeta);
            foreach (CModelObjeto obj in l)
            {
                if (!ExisteObjeto(obj.ID_Objeto)) //si no existe lo agrega
                {
                    CNodoObjeto nodo = new CNodoObjeto();
                    nodo.ID_Objeto = obj.ID_Objeto;
                    nodo.Nombre = obj.Nombre;
                    nodo.Tipo = obj.TipoObjeto;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.Modelo = Modelo;
                    if(obj.Resaltado)
                    {
                        nodo.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        nodo.BackColor = Color.White;

                    }
                    Nodes.Add(nodo);
                }
            }
            //ahora quito los que ya no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoBase obj = (CNodoBase)Nodes[i];
                if (obj.GetType() == typeof(CNodoObjeto))
                {
                    //es una carpeta
                    //checo si esta en la lista
                    CNodoObjeto obj2 = (CNodoObjeto)obj;
                    bool esta = false;
                    foreach (CModelObjeto obj3 in l)
                    {
                        if (obj3.ID_Objeto == obj2.ID_Objeto)
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta == false)
                    {
                        //ya no esta, por lo que hay qiue quitarla
                        Nodes.Remove(obj);
                    }
                }
            }
        }
        private void CargaCarpetas()
        {
            List<CModelCarpeta> l = Modelo.DameCarpetasHijas(ID_Carpeta);
            foreach (CModelCarpeta obj in l)
            {
                if (!ExisteCarpeta(obj.ID_Carpeta))
                {
                    CNodoCarpeta nodo = new CNodoCarpeta();
                    nodo.Nombre = obj.Nombre;
                    nodo.ID_Conexion = ID_Conexion;
                    nodo.ID_Carpeta = obj.ID_Carpeta;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.Modelo = Modelo;
                    Nodes.Add(nodo);
                }
            }
            //ahora quito los que ya no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoBase obj = (CNodoBase)Nodes[i];
                if (obj.GetType() == typeof(CNodoCarpeta))
                {
                    //es una carpeta
                    //checo si esta en la lista
                    CNodoCarpeta obj2 = (CNodoCarpeta)obj;
                    bool esta = false;
                    foreach (CModelCarpeta obj3 in l)
                    {
                        if (obj3.ID_Carpeta == obj2.ID_Carpeta)
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta == false)
                    {
                        //ya no esta, por lo que hay qiue quitarla
                        Nodes.Remove(obj);
                    }
                }
            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAgregarCarpeta = new System.Windows.Forms.ToolStripMenuItem();
            MenuRenombrar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoScript = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoDocumento = new System.Windows.Forms.ToolStripMenuItem();
            MenuMultiAgregar = new ToolStripMenuItem();
            MenuScript = new ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuAgregar,
            MenuMultiAgregar,
            MenuComentarios,
            MenuRenombrar,
            this.MenuNuevoScript,
            MenuScript,
            MenuNuevoDocumento,
            this.MenuAgregarCarpeta,
            this.MenuEliminar
             });
            // 
            // MenuAgregarCarpeta
            // 
            this.MenuAgregarCarpeta.Image = ImageManager.getImagen("AddCarpeta"); // ((System.Drawing.Image)(resources.GetObject("AddCarpeta")));
            this.MenuAgregarCarpeta.Name = "MenuAgregarCarpeta";
            this.MenuAgregarCarpeta.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregarCarpeta.Text = "Agregar Carpeta";
            this.MenuAgregarCarpeta.Click += new System.EventHandler(this.MenuAgregarCarpeta_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ImageManager.getImagen("deleteCarpeta"); // ((System.Drawing.Image)(resources.GetObject("deleteCarpeta")));
            this.MenuEliminar.Name = "MenuRefrescar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Quitar del proyecto";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuRenombrar
            // 
            this.MenuRenombrar.Image = ImageManager.getImagen("rename"); // ((System.Drawing.Image)(resources.GetObject("rename")));
            this.MenuRenombrar.Name = "MenuRenombrar";
            this.MenuRenombrar.Size = new System.Drawing.Size(201, 22);
            this.MenuRenombrar.Text = "Cambiar Nombre";
            this.MenuRenombrar.Click += new System.EventHandler(this.MenuRenombrar_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ImageManager.getImagen("comentario"); //((System.Drawing.Image)(resources.GetObject("comentario")));
            this.MenuComentarios.Name = "MenuComentarios";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Cometarios";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ImageManager.getImagen("IconoAgregar"); // ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Objeto";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuNuevoScript
            // 
            this.MenuNuevoScript.Image = ImageManager.getImagen("script2"); // ((System.Drawing.Image)(resources.GetObject("script2")));
            this.MenuNuevoScript.Name = "MenuNuevoScript";
            this.MenuNuevoScript.Size = new System.Drawing.Size(201, 22);
            this.MenuNuevoScript.Text = "Nuevo Script vacio";
            this.MenuNuevoScript.Click += new System.EventHandler(this.MenuNuevoScript_Click);
            // 
            // MenuNuevoDocumento
            // 
            this.MenuNuevoDocumento.Image = ImageManager.getImagen("document"); // ((System.Drawing.Image)(resources.GetObject("document")));
            this.MenuNuevoDocumento.Name = "MenuNuevoDocumento";
            this.MenuNuevoDocumento.Size = new System.Drawing.Size(201, 22);
            this.MenuNuevoDocumento.Text = "Nuevo Documento";
            this.MenuNuevoDocumento.Click += new System.EventHandler(this.MenuNuevoDocumento_Click);
            // 
            // MenuMultiAgregar
            // 
            this.MenuMultiAgregar.Image = ImageManager.getImagen("IconoAgregar"); // ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuMultiAgregar.Name = "MenuMultiAgregar";
            this.MenuMultiAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuMultiAgregar.Text = "Agregar multiples Objetos";
            this.MenuMultiAgregar.Click += new System.EventHandler(this.MenuMultiAgregar_Click);
            // 
            // MenuScript
            // 
            this.MenuScript.Image = ImageManager.getImagen("database_process_icon"); // ((System.Drawing.Image)(resources.GetObject("database_process_icon")));
            this.MenuScript.Name = "MenuScript";
            this.MenuScript.Size = new System.Drawing.Size(201, 22);
            this.MenuScript.Text = "Generar Script de basede datos";
            this.MenuScript.Click += new System.EventHandler(this.MenuScript_Click);
            //
            return MenuPrinciapl;
        }

        private void MenuMultiAgregar_Click(object sender, EventArgs e)
        {
            FormMultiAgregado dlg = new FormMultiAgregado(Conexion);
            dlg.OnVerMultiObjeto += new MotorDB.OnVerObjetoEvent(MultiSeleccion);
            dlg.OnFInMultiObjeto += new MotorDB.OnEventoVacio(FinMultiSeleccion);
            dlg.Show(this.TreeView);
        }
        private void MenuAgregarCarpeta_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(NombreCarpeta);
            dlg.ShowDialog();
        }
        private bool NombreCarpeta(Forms.FormNombre sender, string nombre)
        {
            Modelo.AgregaCarpeta(ID_Conexion, nombre, ID_Carpeta);
            return true;
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar: " + Nombre + " del proyecto?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Modelo.EliminaCarpeta(ID_Carpeta);
                //Parent.Nodes.Remove(this);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void MenuRenombrar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = Nombre;
            dlg.OnNombre += new Forms.ONFormNombreEvent(ReNombraCarpeta);
            dlg.ShowDialog();

        }
        private bool ReNombraCarpeta(Forms.FormNombre sender, string nombre)
        {
            if (Nombre == nombre)
                return true;
            Modelo.RenombraCarpeta(ID_Carpeta, nombre);
            Nombre = nombre;
            return true;
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
            dlg.Texto = Comentarios;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Comentarios = dlg.Texto;
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            Modulos.Buscador.FormSelectObjet dlg = new Buscador.FormSelectObjet();
            dlg.Motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(ObjetoSeleccionado);
            dlg.OnVerMultiObjeto += new MotorDB.OnVerObjetoEvent(MultiSeleccion);
            dlg.OnFInMultiObjeto += new MotorDB.OnEventoVacio(FinMultiSeleccion);
            dlg.Show(this.TreeView);
        }
        private void MultiSeleccion(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modelo.AgregaObjeto(Servidor, Nombre, nombre, tipo, false, ID_Carpeta);
            RecargaTodo();
        }
        private void ObjetoSeleccionado(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            try
            {
                //veo si el objeto ya esta agregado
                CModelObjeto obj = Modelo.DameObjeto(Servidor, Conexion.Nombre, nombre);
//                if (obj != null)
  //              {
    //                return;
      //          }
                // hay que agregarlo
                CNodoObjeto nodo = new CNodoObjeto();
                nodo.Nombre = nombre;
                nodo.Tipo = tipo;
                nodo.Conexion = Conexion;
                nodo.Servidor = Servidor;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
                //lo agrego al modelo
                CModelObjeto obj2 = Modelo.AgregaObjeto(Servidor, Conexion.Nombre, nodo.Nombre, tipo, true, ID_Carpeta);
                nodo.ID_Objeto = obj2.ID_Objeto;
                nodo.Carga();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RecargaTodo();
        }
        private void FinMultiSeleccion()
        {
            Nodes.Clear();
            RecargaTodo();
        }
        public override void NodeDrop(CNodoBase nodo)
        {
            if (nodo.GetType() == typeof(CNodoObjeto))
            {
                CNodoObjeto objeto = (CNodoObjeto)nodo;
                CModelConexion conobj = Modelo.DameConexion(objeto.Servidor, objeto.Conexion.Nombre);
                int id_carpetaOrigen = 0;
                if (objeto.Parent.GetType() == typeof(CNodoCarpeta))
                {
                    //viene desde una carpeta
                    CNodoCarpeta carpetaPadre = (CNodoCarpeta)objeto.Parent;
                    id_carpetaOrigen = carpetaPadre.ID_Carpeta;
                }
                Modelo.MueveObjeto(objeto.ID_Objeto, ID_Carpeta, id_carpetaOrigen);
            }
            else if (nodo.GetType() == typeof(CNodoCarpeta))
            {
                CNodoCarpeta carpeta = (CNodoCarpeta)nodo;
                Modelo.MueveCarpeta(carpeta.ID_Carpeta, ID_Carpeta);
            }
            else if (nodo.GetType() == typeof(CNodoScript))
            {
                CNodoScript script = (CNodoScript)nodo;
                Modelo.MueveScript(script.ID_Script, ID_Carpeta, ID_Conexion);
            }
            else if (nodo.GetType() == typeof(CNodoDocument))
            {
                CNodoDocument documento = (CNodoDocument)nodo;
                Modelo.MueveDocumento(documento.ID_Document, ID_Carpeta, ID_Conexion);
            }
        }
        private void MenuNuevoScript_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(CodigoNuevo);
            dlg.ShowDialog();
        }
        private bool ExisteScript(int id_script)
        {
            foreach (CNodoBase obj in Nodes)
            {
                if (obj.GetType() == typeof(CNodoScript))
                {
                    CNodoScript obj2 = (CNodoScript)obj;
                    if (obj2.ID_Script == id_script)
                        return true;
                }
            }
            return false;
        }
        private void CargaScripts()
        {
            List<CModelScript> l = Modelo.DameScriptsCarpeta(ID_Carpeta);
            foreach (CModelScript obj in l)
            {
                if (!ExisteScript(obj.ID_Script)) //si no existe lo agrega
                {
                    CNodoScript nodo = new CNodoScript();
                    nodo.Nombre = obj.Nombre;
                    //nodo.Tipo = obj.TipoObjeto;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.Modelo = Modelo;
                    nodo.ID_Script = obj.ID_Script;
                    nodo.ID_Carpeta = obj.ID_Carpeta;
                    //nodo.Parent = this;
                    Nodes.Add(nodo);
                }
            }
            //ahora quito los que ya no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoBase obj = (CNodoBase)Nodes[i];
                if (obj.GetType() == typeof(CNodoScript))
                {
                    //es una carpeta
                    //checo si esta en la lista
                    CNodoScript obj2 = (CNodoScript)obj;
                    bool esta = false;
                    foreach (CModelScript obj3 in l)
                    {
                        if (obj3.ID_Script == obj2.ID_Script)
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta == false)
                    {
                        //ya no esta, por lo que hay qiue quitarla
                        Nodes.Remove(obj);
                    }
                }
            }
        }
        private bool CodigoNuevo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                CModelScript obj = Modelo.AgregaScript(ID_Conexion, ID_Carpeta, nombre);
                CargaScripts();
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                FormProyect dlg = (FormProyect)TreeView.Tag;
                CodeScriptManager fm = new CodeScriptManager();
                fm.ID_Script = obj.ID_Script;
                fm.Nombre = nombre;
                fm.Modelo = Modelo;
                dlg.VerCodigo(nombre, "", motor, Servidor, Conexion.Nombre, fm);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //--------------------------------------------------manejo de documentos--------------
        private bool ExisteDocumento(int id_documento)
        {
            foreach (CNodoBase obj in Nodes)
            {
                if (obj.GetType() == typeof(CNodoDocument))
                {
                    CNodoDocument obj2 = (CNodoDocument)obj;
                    if (obj2.ID_Document == id_documento)
                        return true;
                }
            }
            return false;
        }
        private void CargaDocumentos()
        {
            List<CModelDocument> l = Modelo.DameDocumentosCarpeta(ID_Carpeta);
            foreach (CModelDocument obj in l)
            {
                if (!ExisteDocumento(obj.ID_Document)) //si no existe lo agrega
                {
                    CNodoDocument nodo = new CNodoDocument();
                    nodo.Nombre = obj.Nombre;
                    //nodo.Tipo = obj.TipoObjeto;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.Modelo = Modelo;
                    nodo.ID_Document = obj.ID_Document;
                    nodo.ID_Carpeta = obj.ID_Carpeta;
                    //nodo.Parent = this;
                    Nodes.Add(nodo);
                }
            }
            //ahora quito los que ya no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoBase obj = (CNodoBase)Nodes[i];
                if (obj.GetType() == typeof(CNodoDocument))
                {
                    //es una carpeta
                    //checo si esta en la lista
                    CNodoDocument obj2 = (CNodoDocument)obj;
                    bool esta = false;
                    foreach (CModelDocument obj3 in l)
                    {
                        if (obj3.ID_Document == obj2.ID_Document)
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta == false)
                    {
                        //ya no esta, por lo que hay qiue quitarla
                        Nodes.Remove(obj);
                    }
                }
            }
        }
        private void MenuNuevoDocumento_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(DocumentoNuevo);
            dlg.ShowDialog();
        }
        private void MenuScript_Click(object sender, EventArgs e)
        {
            FormProyect dlg = (FormProyect)TreeView.Tag;
            try
            {
                dlg.Cursor = Cursors.WaitCursor;
                List<MotorDB.CObjeto> l = new List<MotorDB.CObjeto>();
                //recorro mis nodos para buscar los objetos y agregarlos
                foreach (CNodoBase nodo in Nodes)
                {
                    if (nodo.GetType() == typeof(CNodoObjeto))
                    {
                        CNodoObjeto nodoobj = (CNodoObjeto)nodo;
                        MotorDB.CObjeto obj = new MotorDB.CObjeto();
                        obj.Nombre = nodoobj.Nombre;
                        obj.Tipo = nodoobj.Tipo;
                        l.Add(obj);
                    }
                }
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                string codigo = motor.CreaScript(l);
                dlg.VerCodigo("Script", codigo, motor, Servidor, Conexion.Nombre);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dlg.Cursor = Cursors.Default;

        }
        private bool DocumentoNuevo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                CModelDocument obj = Modelo.AgregaDocumento(ID_Conexion, ID_Carpeta, nombre, "");
                Editores.CEditorComentarios editor = new Editores.CEditorComentarios();

                CNodoDocument nodo = new CNodoDocument();
                nodo.Nombre = obj.Nombre;
                //nodo.Tipo = obj.TipoObjeto;
                nodo.Conexion = Conexion;
                nodo.Servidor = Servidor;
                nodo.Modelo = Modelo;
                nodo.ID_Document = obj.ID_Document;
                nodo.ID_Carpeta = obj.ID_Carpeta;
                //nodo.Parent = this;
                Nodes.Add(nodo);
                editor.Driver = nodo;
                CargaDocumentos();
                //me traigo el acceso al formulario
                FormProyect dlg = (FormProyect)TreeView.Tag;
                dlg.EditorComentario(editor, obj.Nombre);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
   