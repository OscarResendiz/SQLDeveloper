using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MotorDB;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoConexion : CNodoFolder
    {
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevaCarpeta;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoScript;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoDocumento;
        private System.Windows.Forms.ToolStripMenuItem MenuMultiAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuScript;

        private ManagerConnect.CConexion FConexion;
        public CNodoConexion()
        {
            Text = "Conexion";

        }
        public ManagerConnect.CConexion Conexion
        {
            get
            {
                return FConexion;
            }
            set
            {
                FConexion = value;
                if (FConexion != null)
                    Nombre = FConexion.Nombre;
            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            MenuMultiAgregar = new ToolStripMenuItem();
            MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuNuevaCarpeta = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoScript = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoDocumento = new System.Windows.Forms.ToolStripMenuItem();
            MenuScript = new ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            MenuMultiAgregar,
            this.MenuNuevoScript,
            MenuScript,
            MenuNuevoDocumento,
            MenuNuevaCarpeta ,
            this.MenuEliminar});
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ImageManager.getImagen("IconoAgregar"); // ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Objeto";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuMultiAgregar
            // 
            this.MenuMultiAgregar.Image = ImageManager.getImagen("IconoAgregar"); // ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuMultiAgregar.Name = "MenuMultiAgregar";
            this.MenuMultiAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuMultiAgregar.Text = "Agregar multiples Objetos";
            this.MenuMultiAgregar.Click += new System.EventHandler(this.MenuMultiAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuEliminar.Image = ImageManager.getImagen("IconoEliminar"); //((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuNuevaCarpeta
            // 
            this.MenuNuevaCarpeta.Image = ImageManager.getImagen("AddCarpeta"); // ((System.Drawing.Image)(resources.GetObject("AddCarpeta")));
            this.MenuNuevaCarpeta.Name = "MenuNuevaCarpeta";
            this.MenuNuevaCarpeta.Size = new System.Drawing.Size(201, 22);
            this.MenuNuevaCarpeta.Text = "Agregar Carpeta";
            this.MenuNuevaCarpeta.Click += new System.EventHandler(this.MenuNuevaCarpeta_Click);
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
            // MenuScript
            // 
            this.MenuScript.Image = ImageManager.getImagen("database_process_icon"); //((System.Drawing.Image)(resources.GetObject("database_process_icon")));
            this.MenuScript.Name = "MenuScript";
            this.MenuScript.Size = new System.Drawing.Size(201, 22);
            this.MenuScript.Text = "Generar Script de basede datos";
            this.MenuScript.Click += new System.EventHandler(this.MenuScript_Click);
             
            return MenuPrinciapl;
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            Modulos.Buscador.FormSelectObjet dlg = new Buscador.FormSelectObjet();
            dlg.Motor = ManagerConnect.ControladorConexiones.DameMotor(FConexion);
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(ObjetoSeleccionado);
            dlg.OnVerMultiObjeto += new MotorDB.OnVerObjetoEvent(MultiSeleccion);
            dlg.OnFInMultiObjeto += new OnEventoVacio(FinMultiSeleccion);
            dlg.Show(this.TreeView);
        }
        private void MenuMultiAgregar_Click(object sender, EventArgs e)
        {
            FormMultiAgregado dlg = new FormMultiAgregado(Conexion);
            dlg.OnVerMultiObjeto += new MotorDB.OnVerObjetoEvent(MultiSeleccion);
            dlg.OnFInMultiObjeto += new OnEventoVacio(FinMultiSeleccion);
            dlg.Show(this.TreeView);
        }
        
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            CNodoBase padre = (CNodoBase)this.Parent;
            padre.RefreshData();
           
        }
        public string Servidor
        {
            get;
            set;
        }
        private void FinMultiSeleccion()
        {
            Nodes.Clear();
            ModeloAsignado();

        }
        private void MultiSeleccion(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modelo.AgregaObjeto(Servidor, Nombre, nombre, tipo,false);
        }
        private void ObjetoSeleccionado(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            //veo si el objeto ya esta agregado
            foreach(CNodoBase obj in Nodes)
            {
                if (obj.GetType() == typeof(CNodoObjeto))
                {
                    if (obj.Nombre == nombre)
                    {
                        //ya esta agregado , por lo que no ignoro
                        return;
                    }
                }
            }
            // hay que agregarlo
            CNodoObjeto nodo = new CNodoObjeto();
            nodo.Nombre = nombre;
            nodo.Tipo = tipo;
            nodo.Conexion = Conexion;
            nodo.Servidor = Servidor;
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
            //lo agrego al modelo
            CModelObjeto obj2= Modelo.AgregaObjeto(Servidor, Nombre, nodo.Nombre, tipo);
            nodo.ID_Objeto = obj2.ID_Objeto;
            nodo.Carga();
        }
        public override void ModeloAsignado()
        {
            RecargaModelo();
            Modelo.OnCarpetaModelChange += new ONModeloBasicoEvent(RecargaModelo);
            Modelo.OnScriptModelChange += new ONModeloBasicoEvent(CargaScripts);
            Modelo.OnDocumentModelChange += new ONModeloBasicoEvent(CargaDocumentos);
        }
        ~CNodoConexion()
        {
            Modelo.OnCarpetaModelChange -= RecargaModelo;
            Modelo.OnScriptModelChange -= CargaScripts;
            Modelo.OnDocumentModelChange -= CargaDocumentos;
        }
        private void RecargaModelo()
        {
            CargaCarpetas();
            CargaObjetos();
            CargaScripts();
            CargaDocumentos();
        }
        private bool ExisteCarpeta(int id_carpeta)
        {
            foreach(CNodoBase obj in Nodes)
            {
                if(obj.GetType()== typeof(CNodoCarpeta))
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
        private void CargaCarpetas()
        {
            CModelConexion con = Modelo.DameConexion(Servidor, Nombre);
            List<CModelCarpeta> l = Modelo.DameCarpetasConexion(con.ID_Conexion);
            foreach (CModelCarpeta obj in l)
            {
                if (!ExisteCarpeta(obj.ID_Carpeta))
                {
                    CNodoCarpeta nodo = new CNodoCarpeta();
                    nodo.ID_Conexion = con.ID_Conexion;
                    nodo.Nombre = obj.Nombre;
                    nodo.ID_Carpeta = obj.ID_Carpeta;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.Modelo = Modelo;
                    Nodes.Add(nodo);
                }
            }
            //ahora quito los que ya no estan
            for(int i=Nodes.Count-1;i>=0;i--)
            {
                CNodoBase obj = (CNodoBase)Nodes[i];
                if(obj.GetType()== typeof(CNodoCarpeta))
                {
                    //es una carpeta
                    //checo si esta en la lista
                    CNodoCarpeta obj2 = (CNodoCarpeta)obj;
                    bool esta=false;
                    foreach(CModelCarpeta obj3 in l)
                    {
                        if(obj3.ID_Carpeta==obj2.ID_Carpeta)
                        {
                            esta = true;
                            break;
                        }
                    }
                    if(esta==false)
                    {
                        //ya no esta, por lo que hay qiue quitarla
                        Nodes.Remove(obj);
                    }
                }
            }
        }
        private void CargaObjetos()
        {
            List<CModelObjeto> l = Modelo.DameObjetosX1(Servidor, Nombre,false);
            foreach (CModelObjeto obj in l)
            {
                if (!ExisteObjeto(obj.ID_Objeto)) //si no existe lo agrega
                {
                    CNodoObjeto nodo = new CNodoObjeto();
                    nodo.Nombre = obj.Nombre;
                    nodo.Tipo = obj.TipoObjeto;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.ID_Objeto = obj.ID_Objeto;
                    nodo.Modelo = Modelo;
                    if (obj.Resaltado)
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
        private void MenuNuevaCarpeta_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(NombreCarpeta);
            dlg.ShowDialog();
        }
        private bool NombreCarpeta(Forms.FormNombre sender, string nombre)
        {
            CModelConexion con = Modelo.DameConexion(Servidor, Nombre);
            Modelo.AgregaCarpeta(con.ID_Conexion, nombre, 0);
            return true;
        }
        public override void NodeDrop(CNodoBase nodo)
        {
            CModelConexion con = Modelo.DameConexion(Servidor, Nombre);
            int id_carpetaOrigen= 0;
            if (nodo.GetType() == typeof(CNodoObjeto))
            {
                CNodoObjeto objeto = (CNodoObjeto)nodo;
                CModelConexion conobj = Modelo.DameConexion(objeto.Servidor, objeto.Conexion.Nombre);
                if (con.ID_Conexion != conobj.ID_Conexion)
                {
                    throw new Exception("El objeto no pertenece a la conexion");
                }
                //veo el tipo de nodo padre
                if(objeto.Parent.GetType()==typeof(CNodoCarpeta))
                {
                    //viene desde una carpeta
                    CNodoCarpeta carpetaPadre=(CNodoCarpeta)objeto.Parent;
                    id_carpetaOrigen = carpetaPadre.ID_Carpeta;
                }
                Modelo.MueveObjeto(objeto.ID_Objeto, 0, id_carpetaOrigen);
            }
            else if (nodo.GetType() == typeof(CNodoCarpeta))
            {
                CNodoCarpeta carpeta = (CNodoCarpeta)nodo;
                if (con.ID_Conexion != carpeta.ID_Conexion)
                {
                    throw new Exception("La carpeta no pertenece a la conexion");
                }
                Modelo.MueveCarpeta(carpeta.ID_Carpeta, 0);
            }
            else if (nodo.GetType() == typeof(CNodoScript))
            {
                CNodoScript script = (CNodoScript)nodo;
                Modelo.MueveScript(script.ID_Script, 0, con.ID_Conexion);
            }
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
            CModelConexion con = Modelo.DameConexion(Servidor, Nombre);

            List<CModelScript> l = Modelo.DameScriptsConexion(con.ID_Conexion, false);
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

        private void MenuNuevoScript_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(CodigoNuevo);
            dlg.ShowDialog();
        }
        private bool CodigoNuevo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                CModelConexion con = Modelo.DameConexion(Servidor, Nombre);

               CModelScript obj= Modelo.AgregaScript(con.ID_Conexion,0,nombre);
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
            CModelConexion con = Modelo.DameConexion(Servidor, Nombre);
            List<CModelDocument> l = Modelo.DameDocumentosConexion(con.ID_Conexion,false);
            foreach (CModelDocument obj in l)
            {
                if (!ExisteDocumento(obj.ID_Document)) //si no existe lo agrega
                {
                    CNodoDocument nodo = new CNodoDocument();
                    nodo.Nombre = obj.Nombre;
                    nodo.Conexion = Conexion;
                    nodo.Servidor = Servidor;
                    nodo.Modelo = Modelo;
                    nodo.ID_Document = obj.ID_Document;
                    nodo.ID_Carpeta = obj.ID_Carpeta;
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
        private bool DocumentoNuevo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                CModelConexion con = Modelo.DameConexion(Servidor, Nombre);
                CModelDocument obj = Modelo.AgregaDocumento(con.ID_Conexion, 0, nombre, "");
                Editores.CEditorComentarios editor = new Editores.CEditorComentarios();
                CNodoDocument nodo = new CNodoDocument();
                nodo.Nombre = obj.Nombre;
                nodo.Conexion = Conexion;
                nodo.Servidor = Servidor;
                nodo.Modelo = Modelo;
                nodo.ID_Document = obj.ID_Document;
                nodo.ID_Carpeta = obj.ID_Carpeta;
                Nodes.Add(nodo);
                editor.Driver = nodo;
                CargaDocumentos();
                //editor.ID_Document = obj.ID_Document;
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
                    CNodoObjeto nodoobj=(CNodoObjeto)nodo;
                    MotorDB.CObjeto obj=new MotorDB.CObjeto();
                    obj.Nombre=nodoobj.Nombre;
                    obj.Tipo=nodoobj.Tipo;
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
    }
}
   