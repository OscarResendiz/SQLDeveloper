using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoLineasArchivo : CNodoFolder
    {
        private int ID_Archivo;
        public CNodoLineasArchivo(int id_archivo)
        {
            ID_Archivo = id_archivo;
            Nombre = "Cadenas";
        }
        public override void ModeloAsignado()
        {
            Modelo.LineaArchivoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(LineaArchivoDelete);
            Modelo.LineaArchivoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(LineaArchivoInsert);
            //CargaCargaInformacion();
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaCargaInformacion();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.LineaArchivoDeleteEvent -= LineaArchivoDelete;
            Modelo.LineaArchivoInsertEvent -= LineaArchivoInsert;
        }
        private void CargaCargaInformacion()
        {
            List<ObjetosModelo.CLineaArchivo> l = Modelo.GetLineasArchivo(ID_Archivo);
            foreach(ObjetosModelo.CLineaArchivo obj in l)
            {
                CNodoLineaArchivo nodo = new CNodoLineaArchivo(obj.ID_Archivo, obj.ID_Linea);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void MenuAgregarLinea(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Agregar linea";
            dlg.Texto = "Texto";
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            try
            {
                Modelo.InsertLineaArchivo(ID_Archivo,  dlg.Nombre);
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

            }

        }
        private void LineaArchivoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CLineaArchivo linea = (ObjetosModelo.CLineaArchivo)obj;
            if (linea.ID_Archivo != this.ID_Archivo)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoLineaArchivo))
                {
                    CNodoLineaArchivo nodo2 = (CNodoLineaArchivo)nodo;
                    if (nodo2.ID_Linea == linea.ID_Linea)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        private void LineaArchivoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CLineaArchivo linea = (ObjetosModelo.CLineaArchivo)obj;
            if (linea.ID_Archivo != this.ID_Archivo)
                return;
            //primero veo si ya se encuentra en los nodos
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoLineaArchivo))
                {
                    CNodoLineaArchivo n2 = (CNodoLineaArchivo)n;
                    if (n2.ID_Archivo == linea.ID_Archivo && n2.ID_Linea == linea.ID_Linea)
                        return;
                }
            }
            CNodoLineaArchivo nodo = new CNodoLineaArchivo(linea.ID_Archivo, linea.ID_Linea);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);

        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Agregar Linea", "IconoAgregar", MenuAgregarLinea);
            this.AddMenuItem("Eliminar Lineas", "IconoEliminar", MenuAEliminarLineas);
        }
        private void MenuAEliminarLineas(object sender, EventArgs e)
        {
            Formularios.FormEliminarCadenas dlg = new Formularios.FormEliminarCadenas(Modelo, ID_Archivo);
            dlg.ShowDialog();
        }
    }
}
   