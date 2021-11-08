using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    public class CNodoArchivo : CNodoBase
    {
        private CNodoLineasArchivo nodoLineas;
        public int ID_Archivo
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
       public CNodoArchivo(int id_archivo)
        {
            ID_Archivo = id_archivo;
            ImageIndex = 22;
            SelectedImageIndex = 22;
            nodoLineas = new CNodoLineasArchivo(this.ID_Archivo);
            Nodes.Add(nodoLineas);
        }
        public override void ModeloAsignado()
        {
            nodoLineas.Modelo = this.Modelo;
            ObjetosModelo.CArchivo archivo = null;
            try
            {
                archivo = Modelo.GetArchivo(this.ID_Archivo);
            }
            catch(System.Exception ex)
            {
                System.Threading.Thread.Sleep(100);
                archivo = Modelo.GetArchivo(this.ID_Archivo);
            }
            this.BackColor = archivo.BKColor;
            this.Nombre = archivo.NombreCorto;
            selecionaIcono(archivo.Extencion);
            Modelo.ArchivoObjetoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoObjetoDelete);
            Modelo.ArchivoObjetoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoObjetoInsert);
            Modelo.ArchivoUpdatetEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoUpdate);
            //CargaInformacion();
        }
        public override void Free()
        {
            base.Free();
            //libero los eventos
            Modelo.ArchivoObjetoDeleteEvent -= ArchivoObjetoDelete;
            Modelo.ArchivoObjetoInsertEvent -= ArchivoObjetoInsert;
            Modelo.ArchivoUpdatetEvent -= ArchivoUpdate;
        }
        private void selecionaIcono(string extencion)
        {
            if (extencion.ToUpper() == "CS")
            {
                ImageIndex = 25;
                SelectedImageIndex = 25;
            }
            if (extencion.ToUpper() == "XML")
            {
                ImageIndex = 26;
                SelectedImageIndex = 26;
            }
            if (extencion.ToUpper() == "XSD")
            {
                ImageIndex = 27;
                SelectedImageIndex = 27;
            }
        }
        private void ArchivoUpdate(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivo archivo = (ObjetosModelo.CArchivo)obj;
            if (archivo.ID_Archivo != this.ID_Archivo)
                return;
            Nombre = archivo.NombreCorto;
            this.BackColor = archivo.BKColor;


        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Cambiar Nombre", "rename", MenuCambiarNombre);
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
            this.AddMenuItem("Agregar Objeto", "IconoAgregar", MenuAgregarObjeto);
            this.AddMenuItem("Abrir archivo", "document", menuVerCodigo);
            this.AddMenuItem("Marcar", "Resaltar", MenuMarcar);
            this.AddMenuItem("Marcar mis Objetos", "Resaltar", MenuMarcarMisObjetos);
            this.AddMenuItem("Comentarios", "comentario", MenuComentarios);
            AddMenuItem("Buscar Cadenas", "buscar", BuscarCadenas_Click);
            AddMenuItem("Buscar Objetos en el Archivo", "buscar", BuscarObjetos_Click);
            AddMenuItem("Mapea Objetos", "database_process_icon", MapearObjetos_Click);
            this.AddMenuItem("Ver conflictos", "calabera", MenuConflictos);
//            AddMenuItem("Generar Reporte", "select", Reporte_Click);

        }

        private void ArchivoObjetoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivoObjeto obj2 = (ObjetosModelo.CArchivoObjeto)obj;
            if (obj2.ID_Archivo != this.ID_Archivo)
                return;
            CNodoArchivoObjeto nodo = new CNodoArchivoObjeto(obj2.ID_Archivo, obj2.ID_Objeto);
            nodo.Modelo = this.Modelo;
            nodo.OnObjetoSeleccionado += new CNodoArchivoObjetoEvent(ResataObjeto);
            Nodes.Add(nodo);

        }
        private void ArchivoObjetoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivoObjeto archivo = (ObjetosModelo.CArchivoObjeto)obj;
            if (archivo.ID_Archivo != this.ID_Archivo)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoArchivoObjeto))
                {
                    if (nodo.ID_Objeto == archivo.ID_Objeto)
                    {
                        CNodoArchivoObjeto nx = (CNodoArchivoObjeto)nodo;
                        nx.OnObjetoSeleccionado -= ResataObjeto;
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        private void MenuCambiarNombre(object sender, EventArgs e)
        {
            ObjetosModelo.CArchivo c = Modelo.GetArchivo(this.ID_Archivo);
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Cambiar Nombre";
            dlg.Nombre = c.NombreArchivo;
            dlg.OnNombre += new Forms.ONFormNombreEvent(RenombraArchivo);
            dlg.ShowDialog();

        }
        private bool RenombraArchivo(Forms.FormNombre dl, string nombre)
        {
            try
            {
                ObjetosModelo.CArchivo c = Modelo.GetArchivo(this.ID_Archivo);
                c.NombreArchivo = nombre;
                c.update();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("¿Eliminar el archivo?", "Eliminar", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            ObjetosModelo.CArchivo c = Modelo.GetArchivo(this.ID_Archivo);
            try
            {
                c.delete();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void MenuAgregarObjeto(object sender, EventArgs e)
        {
            Formularios.FormBuscadorObjetos dlg = new Formularios.FormBuscadorObjetos(Modelo);
            dlg.ObjetoAgregadoEvent += new Formularios.FormBuscadorObjetosEvent(ObjetoAgregado);
            dlg.ShowDialog();
        }
        private void ObjetoAgregado(int id_objeto)
        {
            if (Modelo.GetArchivoObjeto(this.ID_Archivo, id_objeto) == null)
            {
                Modelo.InsertArchivoObjeto(this.ID_Archivo, id_objeto);
            }
        }
        private void menuVerCodigo(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            //me traigo el codigo de la base de datos

            ObjetosModelo.CArchivo archivo = Modelo.GetArchivo(this.ID_Archivo);
            //mando a mostrar abrir el arhivo
            dlg.AbirArchivo(archivo.NombreArchivo);
        }
        public override void DoubleClick(System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            menuVerCodigo(null, null);
        }
        private void MenuMarcarMisObjetos(object sender, EventArgs e)
        {
            ObjetosModelo.CArchivo obj = Modelo.GetArchivo(this.ID_Archivo);
            List<ObjetosModelo.CObjeto> l = obj.getObjetos();
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.Reset();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            foreach (ObjetosModelo.CObjeto obj2 in l)
            {
                obj2.BKColor = dlg.Color;
                obj2.update();
            }

        }
        private void MenuMarcar(object sender, EventArgs e)
        {
            ObjetosModelo.CArchivo obj = Modelo.GetArchivo(this.ID_Archivo);
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.Reset();
            dlg.FullOpen = true;
            dlg.Color = obj.BKColor;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            obj.BKColor = dlg.Color;
            obj.update();
        }
        public override void AgregaRegistrosReporte(System.Data.DataTable tabla, DataRow rp, int nivel)
        {
            //if (rp != null)
            //{
            //    rp["Nivel " + nivel.ToString()] = this.Nombre;
            //}
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
            dr["Nivel " + nivel.ToString()] ="(Archivo) "+ this.Nombre;
            tabla.Rows.Add(dr);
            if (Nodes.Count > 0)
            {
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
                int x = nodo.calculaNivel(n + 1);
                if (x > max)
                    max = x;
            }
            return max;
        }

        private void MenuComentarios(object sender, EventArgs e)
        {
            try
            {
                SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
                ObjetosModelo.CArchivo obj = Modelo.GetArchivo(this.ID_Archivo);
                dlg.Texto = obj.Comentarios;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                obj.Comentarios = dlg.Texto;
                obj.update();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// resalta todos los objetos que tienen el mismo nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuConflictos(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            int n = Nodes.Count;
            for (int i = 0; i < n; i++)
            {
                CNodoBase nodo1 = (CNodoBase)Nodes[i];
                if (nodo1.GetType() == typeof(CNodoArchivoObjeto))
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        CNodoBase nodo2 = (CNodoBase)Nodes[j];
                        if (nodo2.GetType() == typeof(CNodoArchivoObjeto))
                        {
                            ObjetosModelo.CObjeto obj1, obj2;
                            obj1 = Modelo.GetObjeto(nodo1.ID_Objeto);
                            obj2 = Modelo.GetObjeto(nodo2.ID_Objeto);
                            if (obj1.Nombre == obj2.Nombre)
                            {
                                nodo1.BackColor = dlg.Color;
                                nodo2.BackColor = dlg.Color;
                            }
                        }
                    }
                }
            }
        }
        private void ResataObjeto(CNodoArchivoObjeto NodoObj)
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(NodoObj.ID_Objeto);
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoArchivoObjeto))
                {
                    ObjetosModelo.CObjeto obj2 = Modelo.GetObjeto(nodo.ID_Objeto);
                    if (obj.Nombre == obj2.Nombre)
                    {
                        nodo.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        nodo.ForeColor =System.Drawing.Color.Black;
                    }
                }

            }
        }
        private void BuscarCadenas_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CArchivo> l2 = new List<ObjetosModelo.CArchivo>();
            ObjetosModelo.CArchivo obj = Modelo.GetArchivo(this.ID_Archivo);
                    l2.Add(obj);
            setAnalizador(new Analizadores.CBucadorCadenas(Modelo, l2));
        }
        private void BuscarObjetos_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CArchivo> l2 = new List<ObjetosModelo.CArchivo>();
            ObjetosModelo.CArchivo obj = Modelo.GetArchivo(this.ID_Archivo);
            l2.Add(obj);
            setAnalizador(new Analizadores.CAnalizadorArchivo(Modelo, l2));
        }
        private void MapearObjetos_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CArchivoObjeto> l = Modelo.GetArchivoObjetos(this.ID_Archivo);
            List<ObjetosModelo.CObjeto> l2 = new List<ObjetosModelo.CObjeto>();
            foreach (ObjetosModelo.CArchivoObjeto obj in l)
            {
                ObjetosModelo.CObjeto obj2 = Modelo.GetObjeto(obj.ID_Objeto);
                l2.Add(obj2);
            }
            setAnalizador(new Analizadores.CAnalizadorDependencias(Modelo, l2));
        }
        private void CargaInformacion()
        {
            List<ObjetosModelo.CArchivoObjeto> l = Modelo.GetArchivoObjetos(this.ID_Archivo);
            foreach (ObjetosModelo.CArchivoObjeto obj in l)
            {
                CNodoArchivoObjeto nodo = new CNodoArchivoObjeto(obj.ID_Archivo, obj.ID_Objeto);
                nodo.Modelo = this.Modelo;
                nodo.OnObjetoSeleccionado += new CNodoArchivoObjetoEvent(ResataObjeto);
                Nodes.Add(nodo);
            }
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==1)
            {
                CargaInformacion();
            }
        }
    }
}
   