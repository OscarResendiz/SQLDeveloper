using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    /// <summary>
    /// clase que representa a una carpeta en especifico
    /// </summary>    
    public class CNodoCarpeta : CNodoFolder
    {
        public int ID_Carpeta
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
        public CNodoCarpeta(int id_carpeta)
        {
            ID_Carpeta = id_carpeta;
        }

        public override void ModeloAsignado()
        {
            //asigno los eventos que voy a manejar
            //eventos de carpetas
            Modelo.CarpetaInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(CarpetaInsertEvent);
            Modelo.CarpetaDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(CarpetaDeleteEvent);
            Modelo.CarpetaUpdatetEvent += new ObjetosModelo.OnAppModelEventDelegate(CarpetaUpdatetEvent);
            Modelo.CarpetaMoveEvent += new ObjetosModelo.OnAppModelEventMoveDelegate(CarpetaMovida);
            //eventos de archivos
            Modelo.ArchivoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoInsert);
            Modelo.ArchivoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoDelete);
            Modelo.ArchivoMoveEvent += new ObjetosModelo.OnAppModelEventMoveDelegate(ArchivoMovido);
            //eventos de scripts
            Modelo.ScriptInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ScriptInsert);
            Modelo.ScriptDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ScriptDelete);
            Modelo.ScriptMoveEvent += new ObjetosModelo.OnAppModelEventMoveDelegate(ScriptMovido);
            //evento de documentos
            Modelo.DocumentoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(DocumentoInsert);
            Modelo.DocumentoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(DocumentoDelete);
            Modelo.DocumentMoveEvent += new ObjetosModelo.OnAppModelEventMoveDelegate(DocumentoMovido);
            // objeto carpeta
            Modelo.ObjetoCarpetaInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoCarpetaInsert);
            Modelo.ObjetoCarpetaDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoCarpetaDelete);
            //eventos con los archivos
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(ID_Carpeta);
            this.Nombre = getNombreCorto(carpeta.Nombre);

            //CargaInformacion();
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaInformacion();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.CarpetaInsertEvent -= CarpetaInsertEvent;
            Modelo.CarpetaDeleteEvent -= CarpetaDeleteEvent;
            Modelo.CarpetaUpdatetEvent -= CarpetaUpdatetEvent;
            Modelo.CarpetaMoveEvent -= CarpetaMovida;
            //eventos de archivos
            Modelo.ArchivoInsertEvent -= ArchivoInsert;
            Modelo.ArchivoDeleteEvent -= ArchivoDelete;
            Modelo.ArchivoMoveEvent -= ArchivoMovido;
            //eventos de scripts
            Modelo.ScriptInsertEvent -= ScriptInsert;
            Modelo.ScriptDeleteEvent -= ScriptDelete;
            Modelo.ScriptMoveEvent -= ScriptMovido;
            //evento de documentos
            Modelo.DocumentoInsertEvent -= DocumentoInsert;
            Modelo.DocumentoDeleteEvent -= DocumentoDelete;
            Modelo.DocumentMoveEvent -= DocumentoMovido;
            // objeto carpeta
            Modelo.ObjetoCarpetaInsertEvent -= ObjetoCarpetaInsert;
            Modelo.ObjetoCarpetaDeleteEvent -= ObjetoCarpetaDelete;
        }
        private string getNombreCorto(string nombre)
        {
            string[] l = nombre.Split('\\');
            return l[l.Count() - 1];
        }
        #region Cargas
        /// <summary>
        /// carga las carpetas hijas
        /// </summary>
        private void CargaCarpetas()
        {
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(ID_Carpeta);
            //this.Nombre = getNombreCorto(carpeta.Nombre);
            foreach (ObjetosModelo.CCarpeta obj in carpeta.getCarpetas())
            {
                CNodoCarpeta nodo = new CNodoCarpeta(obj.ID_Carpeta);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }

        }
        /// <summary>
        /// carga los archivos que estan dentro de la carpet
        /// </summary>
        private void CargaArchivos()
        {
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(ID_Carpeta);
            foreach (ObjetosModelo.CArchivo obj in carpeta.getArchivos())
            {
                CNodoArchivo nodo = new CNodoArchivo(obj.ID_Archivo);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }

        }
        /// <summary>
        /// carga lo escripts
        /// </summary>
        private void CargaScripts()
        {
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(ID_Carpeta);
            foreach (ObjetosModelo.CScript obj in carpeta.getScripts())
            {
                CNodoScript nodo = new CNodoScript(obj.ID_Script);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        /// <summary>
        ///  carga los documentos 
        /// </summary>
        private void CargaDocumentos()
        {
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(ID_Carpeta);
            foreach (ObjetosModelo.CDocumento obj in carpeta.getDocumentos())
            {
                CNodoDocumento nodo = new CNodoDocumento(obj.ID_Document);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }

        }
        /// <summary>
        /// carga los objetos que pertenecen a la carpeta
        /// </summary>
        private void CargaObjetos()
        {
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(ID_Carpeta);
            foreach (ObjetosModelo.CObjeto obj in carpeta.getObjetos())
            {
                CNodoObjetoCarpeta nodo = new CNodoObjetoCarpeta(obj.ID_Objeto, this.ID_Carpeta);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        /// <summary>
        /// carga los datos desde el modelo
        /// </summary>
        private void CargaInformacion()
        {
            CargaCarpetas();
            CargaArchivos();
            CargaObjetos();
            CargaScripts();
            CargaDocumentos();
        }
        #endregion
        #region Eventos
        /// <summary>
        /// se inserto una carpeta
        /// </summary>
        /// <param name="obj"></param>
        private void CarpetaInsertEvent(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCarpeta carpeta = (ObjetosModelo.CCarpeta)obj;
            if (carpeta.ID_CarpetaPadre != this.ID_Carpeta)
                return;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoCarpeta))
                {
                    CNodoCarpeta n2 = (CNodoCarpeta)n;
                    if (n2.ID_Carpeta == carpeta.ID_Carpeta)
                        return;
                }
            }
            CNodoCarpeta nodo = new CNodoCarpeta(carpeta.ID_Carpeta);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);

        }
        /// <summary>
        /// se elimino una carpeta
        /// </summary>
        /// <param name="obj"></param>
        private void CarpetaDeleteEvent(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCarpeta carpeta = (ObjetosModelo.CCarpeta)obj;
            if (carpeta.ID_CarpetaPadre != this.ID_Carpeta)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoCarpeta))
                {
                    if (nodo.ID_Objeto == carpeta.ID_Carpeta)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// se modificaron los datos de la carpeta actual
        /// </summary>
        /// <param name="obj"></param>
        private void CarpetaUpdatetEvent(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCarpeta carpeta = (ObjetosModelo.CCarpeta)obj;
            if (carpeta.ID_Carpeta == this.ID_Carpeta)
            {
                Nombre = carpeta.Nombre;
            }

        }
        /// <summary>
        /// se dio de alta un archivo 
        /// </summary>
        /// <param name="obj"></param>
        private void ArchivoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivo archivo = (ObjetosModelo.CArchivo)obj;
            if (archivo.ID_Carpeta != this.ID_Carpeta)
                return;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoArchivo))
                {
                    CNodoArchivo n2 = (CNodoArchivo)n;
                    if (n2.ID_Archivo == archivo.ID_Archivo)
                        return;
                }
            }
            CNodoArchivo nodo = new CNodoArchivo(archivo.ID_Archivo);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
        /// <summary>
        /// se borro un archivo
        /// </summary>
        /// <param name="obj"></param>
        private void ArchivoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivo archivo = (ObjetosModelo.CArchivo)obj;
            if (archivo.ID_Carpeta != this.ID_Carpeta)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoArchivo))
                {
                    if (nodo.ID_Objeto == archivo.ID_Archivo)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// se inserto un script
        /// </summary>
        /// <param name="obj"></param>
        private void ScriptInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CScript script = (ObjetosModelo.CScript)obj;
            if (script.ID_Carpeta != this.ID_Carpeta)
                return;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoScript))
                {
                    CNodoScript n2 = (CNodoScript)n;
                    if (n2.ID_Script == script.ID_Script)
                        return;
                }
            }
            CNodoScript nodo = new CNodoScript(script.ID_Script);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);

        }
        /// <summary>
        /// de elimino un script
        /// </summary>
        /// <param name="obj"></param>
        private void ScriptDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CScript script = (ObjetosModelo.CScript)obj;
            if (script.ID_Carpeta != this.ID_Carpeta)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoScript))
                {
                    if(nodo.ID_Objeto == script.ID_Script)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }

        }
        /// <summary>
        /// se inserta un documento
        /// </summary>
        /// <param name="obj"></param>
        private void DocumentoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CDocumento documento = (ObjetosModelo.CDocumento)obj;
            if (documento.ID_Carpeta != this.ID_Carpeta)
                return;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoDocumento))
                {
                    CNodoDocumento n2 = (CNodoDocumento)n;
                    if (n2.ID_Document == documento.ID_Document)
                        return;
                }
            }
            CNodoDocumento nodo = new CNodoDocumento(documento.ID_Document);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
        /// <summary>
        /// se elimino un documento
        /// </summary>
        /// <param name="obj"></param>
        private void DocumentoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CDocumento documento = (ObjetosModelo.CDocumento)obj;
            if (documento.ID_Carpeta != this.ID_Carpeta)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoDocumento))
                {
                    if (nodo.ID_Objeto == documento.ID_Document)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// se asigno un objeto a una carpeta
        /// </summary>
        /// <param name="obj"></param>
        private void ObjetoCarpetaInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CObjetoCarpeta objeto = (ObjetosModelo.CObjetoCarpeta)obj;
            if (objeto.ID_Carpeta != this.ID_Carpeta)
                return;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoObjetoCarpeta))
                {
                    CNodoObjetoCarpeta n2 = (CNodoObjetoCarpeta)n;
                    if (n2.ID_Objeto == objeto.ID_Objeto)
                        return;
                }
            }
            CNodoObjetoCarpeta nodo = new CNodoObjetoCarpeta(objeto.ID_Objeto, ID_Carpeta);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);

        }
        /// <summary>
        /// Se elimina un objeto a la carpeta
        /// </summary>
        /// <param name="obj"></param>
        private void ObjetoCarpetaDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CObjetoCarpeta objeto = (ObjetosModelo.CObjetoCarpeta)obj;
            if (objeto.ID_Carpeta != this.ID_Carpeta)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoObjetoCarpeta))
                {
                    if (nodo.ID_Objeto == objeto.ID_Objeto)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        #endregion
        #region menus
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Agregar Carpeta", "AddCarpeta", MenuAgregarCarpeta);
            this.AddMenuItem("Cambiar Nombre", "rename", MenuCambiarNombre);
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
            this.AddMenuItem("Comentarios", "comentario", MenuComentarios);

            this.AddMenuItem("Agregar Archivo", "IconoAgregar", MenuAgregarArchivo);
            this.AddMenuItem("Agregar Script", "script2", MenuAgregarScript);
            this.AddMenuItem("Agregar Documento", "IconoAgregar", MenuAgregarDocumento);
            this.AddMenuItem("Agregar Objeto", "IconoAgregar", MenuAgregarObjeto);

        }
        private void MenuAgregarCarpeta(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Nueva carpeta";
            dlg.OnNombre += new Forms.ONFormNombreEvent(NombreCarpeta);
            dlg.ShowDialog();
        }
        private void MenuAgregarArchivo(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(NuevoArchivo);
            dlg.ShowDialog();

        }
        private bool NuevoArchivo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                Modelo.InsertArchivo(nombre, this.ID_Carpeta, Color.White,"");
                /*                CModelScript obj = Modelo.AgregaScript(ID_Conexion, ID_Carpeta, nombre);
                                CargaScripts();
                                MotorDB.IMotorDB motor = Conexiones.ControladorConexiones.DameMotor(Conexion);
                                FormProyect dlg = (FormProyect)TreeView.Tag;
                                CodeScriptManager fm = new CodeScriptManager();
                                fm.ID_Script = obj.ID_Script;
                                fm.Nombre = nombre;
                                fm.Modelo = Modelo;
                                dlg.VerCodigo(nombre, "", motor, Servidor, Conexion.Nombre, fm);
                  */
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// crear nuevo script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAgregarScript(object sender, EventArgs e)
        {
            try
            {
                Formularios.FormPropiedadesScript dlg = new Formularios.FormPropiedadesScript(Modelo);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                int id_script = Modelo.InsertScript(dlg.Conexion.ID_Conexion, this.ID_Carpeta, "", "", dlg.Nombre);
                //me traigo el acceso al formulario
                Formularios.FormAppsAnalizer dlg2 = (Formularios.FormAppsAnalizer)TreeView.Tag;
                //me traigo el codigo de la base de datos
                ObjetosModelo.CScript script = Modelo.GetScript(id_script);
                //me traigo el motor
                ObjetosModelo.CConexion con = Modelo.GetConexion(script.ID_Conexion);
                ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
                ManagerConnect.CConexion Conexion = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                //asigno su manejador de archivos
                AppCodeFileManager fm = new AppCodeFileManager();
                fm.Objeto = script;
                fm.Modelo = Modelo;
                //mando a mostrar el codigo
                dlg2.VerCodigo(Nombre, script.Codigo, motor, server.Nombre, Conexion.Nombre, fm);


            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void MenuAgregarDocumento(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(DocumentoNuevo);
            dlg.ShowDialog();
        }
        private bool DocumentoNuevo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                int id_document = Modelo.InsertDocumento(this.ID_Carpeta, "", nombre);

                Editores.CEditorComentarios editor = new Editores.CEditorComentarios();
                editor.Driver = new CDcoumentDriver(id_document, this.Modelo);
                Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
                //me traigo el acceso al formulario
                dlg.EditorComentario(editor, Nombre);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void MenuAgregarObjeto(object sender, EventArgs e)
        {
            Formularios.FormBuscadorObjetos dlg = new Formularios.FormBuscadorObjetos(Modelo);
            dlg.ObjetoAgregadoEvent += new Formularios.FormBuscadorObjetosEvent(ObjetoAgregado);
            dlg.ShowDialog();
        }
        private void ObjetoAgregado(int id_objeto)
        {
            if (Modelo.GetObjetoCarpeta(this.ID_Carpeta, id_objeto) == null)
            {
                Modelo.InsertObjetoCarpeta(this.ID_Carpeta, id_objeto);
            }
        }
        private void MenuCambiarNombre(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Cambiar Nombre";
            dlg.OnNombre += new Forms.ONFormNombreEvent(RenombraCarpeta);
            dlg.ShowDialog();

        }
        private void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("¿Eliminar la carpeta?", "Eliminar", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            ObjetosModelo.CCarpeta c = Modelo.GetCarpeta(ID_Carpeta);
            try
            {
                c.deleteCascade();//.delete();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void MenuComentarios(object sender, EventArgs e)
        {
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(this.ID_Carpeta);
            SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
            dlg.Texto = carpeta.Comentarios;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            carpeta.Comentarios = dlg.Texto;
            carpeta.Update();
        }
        #endregion
        /// <summary>
        /// da de alta una nueva carpeta
        /// </summary>
        /// <param name="dl"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool NombreCarpeta(Forms.FormNombre dl, string nombre)
        {
            try
            {
                Modelo.InsertCarpeta(nombre, "", ID_Carpeta);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// le cambia el nombre a la carpeta
        /// </summary>
        /// <param name="dl"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool RenombraCarpeta(Forms.FormNombre dl, string nombre)
        {
            try
            {
                ObjetosModelo.CCarpeta c = Modelo.GetCarpeta(ID_Carpeta);
                c.Nombre = nombre;
                c.Update();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// mueve el objeto dentro de la carpeta corecpondiente
        /// </summary>
        /// <param name="nodo"></param>
        public override void NodeDrop(CNodoBase nodo)
        {
            //los objetos que se van a poder moven son:
            // 1. Carpetas Excepto carpetas padres
            // 2. Archivo
            // 3. Scripts
            // 4. Documentos

            if (nodo.GetType() == typeof(Nodos.CNodoCarpeta))
            {
                //mover carpeta
                MoverCarpeta((Nodos.CNodoCarpeta)nodo);
            }
            if (nodo.GetType() == typeof(Nodos.CNodoArchivo))
            {
                //mover CNodoArchivo
                MueveArchivo((Nodos.CNodoArchivo)nodo);
            }
            if (nodo.GetType() == typeof(Nodos.CNodoDocumento))
            {
                //mover CNodoDocumento
                MueveDocumento((Nodos.CNodoDocumento)nodo);
            }
            if (nodo.GetType() == typeof(Nodos.CNodoScript))
            {
                //mover CNodoScript
                MueveScript((Nodos.CNodoScript)nodo);
            }
            if (nodo.GetType() == typeof(Nodos.CNodoObjetoCarpeta))
            {
                //mover CNodoObjeto}
                MueveObjeto((Nodos.CNodoObjetoCarpeta)nodo);
            }
        }
        /// <summary>
        /// mueve la carpeta a la carpeta actual
        /// </summary>
        /// <param name="carpeta"></param>
        private void MoverCarpeta(Nodos.CNodoCarpeta carpeta)
        {
            Modelo.moveCarpeta(carpeta.ID_Carpeta, this.ID_Carpeta);
        }
        /// <summary>
        /// mueve el archivo a la carpeta
        /// </summary>
        /// <param name="archivo"></param>
        private void MueveArchivo(Nodos.CNodoArchivo archivo)
        {
            ObjetosModelo.CArchivo obj = Modelo.GetArchivo(archivo.ID_Archivo);
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(this.ID_Carpeta);
            carpeta.moveArchivo(obj);
        }
        /// <summary>
        /// mueve el documento a la carpeta
        /// </summary>
        /// <param name="documento"></param>
        private void MueveDocumento(Nodos.CNodoDocumento documento)
        {
            ObjetosModelo.CDocumento obj = Modelo.GetDocumento(documento.ID_Document);
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(this.ID_Carpeta);
            carpeta.moveDocument(obj);

        }
        /// <summary>
        /// mueve el script a la carpeta
        /// </summary>
        /// <param name="script"></param>
        private void MueveScript(Nodos.CNodoScript script)
        {
            ObjetosModelo.CScript obj = Modelo.GetScript(script.ID_Script);
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(this.ID_Carpeta);
            carpeta.moveScript(obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objeto"></param>
        private void MueveObjeto(Nodos.CNodoObjetoCarpeta objeto)
        {
            ObjetosModelo.CObjetoCarpeta obj = Modelo.GetObjetoCarpeta(objeto.ID_Carpeta, objeto.ID_Objeto);
            ObjetosModelo.CCarpeta carpeta = Modelo.GetCarpeta(this.ID_Carpeta);
            carpeta.moveObjeto(obj);

        }
        /// <summary>
        /// se ha movido una carpeta de lugar
        /// </summary>
        /// <param name="carpeta">carpeta que se esta moviendo</param>
        /// <param name="origen">carpeta origen</param>
        /// <param name="destino">carpeta destino</param>
        private void CarpetaMovida(ObjetosModelo.CObjetoBase carpeta, ObjetosModelo.CObjetoBase origen, ObjetosModelo.CObjetoBase destino)
        {
            CNodoBase nodo = null;
            if (destino.IdObjeto != this.ID_Carpeta)
                return;
            foreach (CNodoBase tmpnodo in this.TreeView.Nodes)
            {
                nodo = tmpnodo.getNodo(carpeta.IdObjeto, typeof(CNodoCarpeta));
                if (nodo != null)
                {
                    //ya lo encontre
                    nodo.Parent.Nodes.Remove(nodo);
                    this.Nodes.Add(nodo);
                    return;
                }
            }

        }
        /// <summary>
        /// se ha movido un archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        private void ArchivoMovido(ObjetosModelo.CObjetoBase archivo, ObjetosModelo.CObjetoBase origen, ObjetosModelo.CObjetoBase destino)
        {
            CNodoBase nodo = null;
            if (destino.IdObjeto != this.ID_Carpeta)
                return;
            foreach (CNodoBase tmpnodo in this.TreeView.Nodes)
            {
                nodo = tmpnodo.getNodo(archivo.IdObjeto, typeof(CNodoArchivo));
                if (nodo != null)
                {
                    //ya lo encontre
                    nodo.Parent.Nodes.Remove(nodo);
                    this.Nodes.Add(nodo);
                    return;
                }
            }
        }
        /// <summary>
        /// Se ha movido un script
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        private void ScriptMovido(ObjetosModelo.CObjetoBase archivo, ObjetosModelo.CObjetoBase origen, ObjetosModelo.CObjetoBase destino)
        {
            CNodoBase nodo = null;
            if (destino.IdObjeto != this.ID_Carpeta)
                return;
            foreach (CNodoBase tmpnodo in this.TreeView.Nodes)
            {
                nodo = tmpnodo.getNodo(archivo.IdObjeto, typeof(CNodoScript));
                if (nodo != null)
                {
                    //ya lo encontre
                    nodo.Parent.Nodes.Remove(nodo);
                    this.Nodes.Add(nodo);
                    return;
                }
            }

        }
        /// <summary>
        /// se ha movido un documento
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        private void DocumentoMovido(ObjetosModelo.CObjetoBase archivo, ObjetosModelo.CObjetoBase origen, ObjetosModelo.CObjetoBase destino)
        {
            CNodoBase nodo = null;
            if (destino.IdObjeto != this.ID_Carpeta)
                return;
            foreach (CNodoBase tmpnodo in this.TreeView.Nodes)
            {
                nodo = tmpnodo.getNodo(archivo.IdObjeto, typeof(CNodoDocumento));
                if (nodo != null)
                {
                    //ya lo encontre
                    nodo.Parent.Nodes.Remove(nodo);
                    this.Nodes.Add(nodo);
                    return;
                }
            }

        }
        public override void AgregaRegistrosReporte(System.Data.DataTable tabla, DataRow rp, int nivel)
        {
            //if (rp != null)
            //{
            //    rp["Nivel " + nivel.ToString()] = this.Nombre;
            //}
            if (Nodes.Count > 0)
            {
                //agrego mi registro
                System.Data.DataRow dr = tabla.NewRow();

                //agrego un nubel mas a los campos
                //agrego los datos al registro
                if (rp != null)
                {
                    for (int i = 1; i < nivel; i++)
                    {
                        dr["Nivel " + i.ToString()] = rp["Nivel " + i.ToString()];

                    }
                }
                dr["Nivel " + nivel.ToString()] ="(Carpeta)"+ this.Nombre;
                tabla.Rows.Add(dr);
                int nivel2 = nivel + 1;
                AgregaColumna(tabla, nivel2);
                foreach (CNodoBase n in Nodes)
                {
                    n.AgregaRegistrosReporte(tabla, dr, nivel2);
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

    }

}
   