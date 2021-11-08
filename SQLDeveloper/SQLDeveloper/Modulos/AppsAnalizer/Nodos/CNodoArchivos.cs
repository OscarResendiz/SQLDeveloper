using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    /// <summary>
    /// almacenba la lista de archivos y carpetas encontrados en los directorios
    /// </summary>
    class CNodoArchivos : CNodoFolder
    {
        int ID_Carpeta;
        public CNodoArchivos()
        {
            this.Nombre = "Archivos";
        }
        public override void ModeloAsignado()
        {
            Modelo.AbrirModeloEvent += new ObjetosModelo.OnModeloEventDelegate(AbrirModelo);
            Modelo.NuevoModeloEvent += new ObjetosModelo.OnModeloEventDelegate(NuevoModelo);
            //eventos de carpetas y archivos
            Modelo.CarpetaInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(CarpetaInsert);
            Modelo.CarpetaDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(CarpetaDelete);
            //eventos de archivos
            Modelo.ArchivoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoInsert);
            Modelo.ArchivoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ArchivoDelete);
            LimpiaNodos();
            CargaInicial();
        }
        private void LimpiaNodos()
        {
            foreach(CNodoBase n in Nodes)
            {
                n.Free();
            }
            Nodes.Clear();

        }
        public override void Free()
        {
            base.Free();
            Modelo.AbrirModeloEvent -= AbrirModelo;
            Modelo.NuevoModeloEvent -= NuevoModelo;
            //eventos de carpetas y archivos
            Modelo.CarpetaInsertEvent -= CarpetaInsert;
            Modelo.CarpetaDeleteEvent -= CarpetaDelete;
            //eventos de archivos
            Modelo.ArchivoInsertEvent -= ArchivoInsert;
            Modelo.ArchivoDeleteEvent -= ArchivoDelete;
        }
        private void AbrirModelo(ObjetosModelo.AppModel model)
        {
            CargaInicial();
        }
        private void NuevoModelo(ObjetosModelo.AppModel model)
        {
            CargaInicial();
        }
        private void CargaInicial()
        {
            //me traigo el ID de la carpeta principal
            List<ObjetosModelo.CCarpeta> l = Modelo.GetCarpetas();
            if (l.Count == 0)
                return;
            ObjetosModelo.CCarpeta obj = l[0];
            ID_Carpeta = obj.ID_Carpeta;
            //me traigo los arechivos y carpetas que pertenecen ala carpeta principal
            List<ObjetosModelo.CCarpeta> carpetas = Modelo.GetCarpetas(ID_Carpeta);
            Nodes.Clear();
            foreach (ObjetosModelo.CCarpeta carpeta in carpetas)
            {
                CNodoCarpeta nodo = new CNodoCarpeta(carpeta.ID_Carpeta);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }
            //ahora cargo los archivos
            List<ObjetosModelo.CArchivo> archivos = Modelo.GetArchivos(ID_Carpeta);
            foreach (ObjetosModelo.CArchivo archivo in archivos)
            {
                CNodoArchivo nodo = new CNodoArchivo(archivo.ID_Archivo);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }
        }
        /// <summary>
        /// se agrego una nueva  carpeta
        /// </summary>
        /// <param name="obj"></param>
        private void CarpetaInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCarpeta carpeta = null;
            try
            {
                carpeta = Modelo.GetCarpeta(obj.IdObjeto);
            }
            catch(System.Exception ex)
            {
                System.Threading.Thread.Sleep(100);
                carpeta = Modelo.GetCarpeta(obj.IdObjeto);

            }
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
            nodo.Modelo = this.Modelo;
            Nodes.Add(nodo);
        }
        /// <summary>
        /// se elimino una carpeta
        /// </summary>
        /// <param name="obj"></param>
        private void CarpetaDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCarpeta carpeta = (ObjetosModelo.CCarpeta)obj;
            if (carpeta.ID_CarpetaPadre == this.ID_Carpeta)
            {
                //me traigo el nodo que contiene la carpeta
                foreach (CNodoBase nodo in Nodes)
                {
                    if (nodo.GetType() == typeof(CNodoCarpeta))
                    {
                        CNodoCarpeta nodo2 = (CNodoCarpeta)nodo;
                        if (nodo2.ID_Carpeta == carpeta.ID_Carpeta)
                        {
                            //si es el nodo que busco
                            nodo2.Free();
                            Nodes.Remove(nodo2);
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// se ha agregado un archivo
        /// </summary>
        /// <param name="obj"></param>
        private void ArchivoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivo archivo = null;
            try
            {
                archivo = Modelo.GetArchivo(obj.IdObjeto);
            }
            catch(System.Exception ex)
            {
                System.Threading.Thread.Sleep(100);
                archivo = Modelo.GetArchivo(obj.IdObjeto);
            }
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
            nodo.Modelo = this.Modelo;
            Nodes.Add(nodo);
        }
        /// <summary>
        /// se ha eliminado un archivo
        /// </summary>
        /// <param name="obj"></param>
        private void ArchivoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CArchivo archivo = (ObjetosModelo.CArchivo)obj;// Modelo.GetArchivo(obj.IdObjeto);
            if (archivo.ID_Carpeta == this.ID_Carpeta)
            {
                //me traigo el nodo que contiene la carpeta
                foreach (CNodoBase nodo in Nodes)
                {
                    if (nodo.GetType() == typeof(CNodoArchivo))
                    {
                        CNodoArchivo nodo2 = (CNodoArchivo)nodo;
                        if (nodo2.ID_Archivo == archivo.ID_Archivo)
                        {
                            //si es el nodo que busco
                            nodo2.Free();
                            Nodes.Remove(nodo2);
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// agrega opciones al menu
        /// </summary>
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar Carpeta", "AddCarpeta", MenuNuevaCarpeta_Click);
            AddMenuItem("1. Mapear Archivos", "buscar", BuscarArchivos_Click);
            AddMenuItem("2. Quitar Carpetas Vacias", "IconoEliminar", EliminarCarpetas_Click);
            AddMenuItem("3. Buscar Cadenas", "buscar", BuscarCadenas_Click);
            AddMenuItem("4. Quitar Archivos Vacios", "IconoEliminar", EliminarArchivos_Click);
            AddMenuItem("5. Eliminar Lineas en archivos", "IconoEliminar", MenuAEliminarLineas);
            AddMenuItem("6. Buscar Objetos en Archivos", "buscar", BuscarObjetos_Click);
            AddMenuItem("7. Mapea Objetos", "database_process_icon", MapearObjetos_Click);
            AddMenuItem("8. Generar Reporte", "select", Reporte_Click);
            AddMenuItem("Quitar Marcas", "Resaltar", Resaltar_Click);
            AddMenuItem("Resaltar Objetos en archivos", "Resaltar", ResaltarObjetos_Click);

        }
        /// <summary>
        /// pide el nombre de la carpeta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuNuevaCarpeta_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Nueva carpeta";
            dlg.OnNombre += new Forms.ONFormNombreEvent(NombreCarpeta);
            dlg.ShowDialog();
        }
        /// <summary>
        /// da de alta una nueva carpeta
        /// </summary>
        /// <param name="dl"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool NombreCarpeta(Forms.FormNombre dl, string nombre )
        {
            try
            {
                Modelo.InsertCarpeta(nombre,"", ID_Carpeta);
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void BuscarArchivos_Click(object sender, EventArgs e)
        {
//            PausaHistoricos();

            setAnalizador(new Analizadores.CAnalizadorCarpetas(Modelo));
        }
        private void BuscarObjetos_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CArchivo> l = Modelo.GetArchivos();
            List<ObjetosModelo.CArchivo> l2 = new List<ObjetosModelo.CArchivo>();
            foreach(ObjetosModelo.CArchivo obj in l)
            {
                if (obj.BKColor.R != Color.GreenYellow.R || obj.BKColor.G != Color.GreenYellow.G || obj.BKColor.B != Color.GreenYellow.B)
                {
                    l2.Add(obj);
                }
            }
            setAnalizador(new Analizadores.CAnalizadorArchivo(Modelo, l2));
        }
        private void BuscarCadenas_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CArchivo> l = Modelo.GetArchivos();
            List<ObjetosModelo.CArchivo> l2 = new List<ObjetosModelo.CArchivo>();
            foreach (ObjetosModelo.CArchivo obj in l)
            {
                if (obj.BKColor.R != Color.YellowGreen.R || obj.BKColor.G != Color.YellowGreen.G || obj.BKColor.B != Color.YellowGreen.B)
                {
                    l2.Add(obj);
                }
            }
            setAnalizador(new Analizadores.CBucadorCadenas(Modelo, l2));

        }
        private void EliminarCarpetas_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show("¿Eliminar Carpetas Vaias?", "Eliminar", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    return;

                List<ObjetosModelo.CCarpeta> l = Modelo.GetCarpetasVacias();
                int n = l.Count();
                for (int i = n - 1; i >= 0; i--)
                {
                    l[i].delete();
                }
                System.Windows.MessageBox.Show("Se eliminaron " + n.ToString() + " carpetas", "Eliminar", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void EliminarArchivos_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                if (System.Windows.Forms.MessageBox.Show("¿Eliminar Archivos Vacios?", "Eliminar", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    return;
                List<ObjetosModelo.CArchivo> l = Modelo.GetArchivos();
                foreach (ObjetosModelo.CArchivo obj in l)
                {
                    bool vacio = true;
                    //veo si tiene objetos relacionados
                    if (Modelo.GetArchivoObjetos(obj.ID_Archivo).Count > 0)
                        vacio = false;
                    if (Modelo.GetLineasArchivo(obj.ID_Archivo).Count() > 0)
                        vacio = false;
                    if (vacio)
                    {
                        obj.delete();
                        n++;
                    }
                }
                System.Windows.MessageBox.Show("Se eliminaron " + n.ToString() + " Archivos", "Eliminar", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// hace el mapeado de objetos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapearObjetos_Click(object sender, EventArgs e)
        {
            List<ObjetosModelo.CObjeto> l = Modelo.GetObjetos();
            List<ObjetosModelo.CObjeto> l2 = new List<ObjetosModelo.CObjeto>();
            foreach(ObjetosModelo.CObjeto obj in l)
            {
                if(obj.BKColor.R!=Color.YellowGreen.R||obj.BKColor.G!=Color.YellowGreen.G||obj.BKColor.B!=Color.YellowGreen.B)
                {
                    l2.Add(obj);
                }
            }
            setAnalizador(new Analizadores.CAnalizadorDependencias(Modelo, l2));
        }
        
        private void Resaltar_Click(object sender, EventArgs e)
        {
            Formularios.FormDesmarcarProgress dlg = new Formularios.FormDesmarcarProgress(Modelo);
            dlg.ShowDialog();
            DesmarcarTodo();
        }
        private void ResaltarObjetos_Click(object sender, EventArgs e)
        {
            Formularios.FormDesmarcarProgress dlg = new Formularios.FormDesmarcarProgress(Modelo, false);
            dlg.ShowDialog();
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            /*
            ExpandeTodo();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            int cols = calculaNivel(1)+1;
            for (int i = 1; i < cols; i++)
            {
                AgregaColumna(tabla, i);
            }
            foreach(CNodoBase n in Nodes)
            {
                n.AgregaRegistrosReporte(tabla,null,1);
            }
             * */
            DataTable tabla = Modelo.RepoteMapeo();
            Modulos.BuscadorSeguidor.FormResultadoReporte dlg = new BuscadorSeguidor.FormResultadoReporte(tabla);
            dlg.ShowDialog();
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
        private void MenuAEliminarLineas(object sender, EventArgs e)
        {
            Formularios.FormEliminarCadenas dlg = new Formularios.FormEliminarCadenas(Modelo, -1);
            dlg.ShowDialog();
        }
    }
}
   