using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer
{
    class AppCodeFileManager : FileManager.IFileManager
    {
        private ObjetosModelo.ISalvable FObjeto;
        public event FileManager.OnFileNameChangeEvent OnFileNameChange;
        private FileManager.CFIleInfo FIleInfo;
        private ObjetosModelo.AppModel FModelo;
        private bool Guardando = false;
        public ObjetosModelo.AppModel Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if (FModelo != null)
                {
                    FModelo.OnCodigoEditableChange += new ObjetosModelo.OnCodigoEditableChangeEvent(CodigoEditableChange);
                    FModelo.OnRenameCodigoEditable += new ObjetosModelo.OnRenameCodigoEditableEvent(RenameCodigoEditable);
                }
            }
        }
        public ObjetosModelo.ISalvable Objeto
        {
            get
            {
                return FObjeto;
            }
            set
            {
                FObjeto = value;
            }
        }
        public string Guardar(FileManager.CFIleInfo info)
        {
            Guardando = true;
            FIleInfo = info;
            FObjeto.setCodigo(info.Contenido);
            FObjeto.Guardar();
            Guardando = false;
            return FObjeto.getNombre();
        }
        public string GuardarComo(FileManager.CFIleInfo info)
        {
            Guardando = true;
            FIleInfo = info;
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = FObjeto.getNombre();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                Guardando = false;
                return FObjeto.getNombre(); 
            }
            try
            {
                string nuevoNombre = dlg.Nombre;
                FObjeto.GuardarComo(nuevoNombre);
                //int ID_CodigoEditable = Modelo.InsertCodigoEditable(ID_Objeto, System.DateTime.Now, , info.Contenido, "");
                //ID_Objeto = ID_CodigoEditable;
                //Nombre = nuevoNombre;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return FObjeto.getNombre();

            }
            Guardando = false;
            return FObjeto.getNombre();
        }
        public FileManager.CFIleInfo Abrir()
        {
            return null;
        }
        public bool EnableGuardar()
        {
            return true;
        }
        public bool EnableAbrir()
        {
            return false;
        }
        public bool EnableGuardarComo()
        {
            return true;
        }
        private void CodigoEditableChange(int id_objeto, string nombre)
        {
            if (FObjeto.esTuId(id_objeto) || FObjeto.getNombre() != nombre)
                return;
            if (Guardando)
            {
                return;
            }
            if (FIleInfo != null)
                FIleInfo.FileChange(FileManager.TIPOC_AMBIO.CMABIO_CONTENIDO);
        }
        public FileManager.CFIleInfo Abrir(string archivo)
        {
//            ObjetosModelo.CCodigoEditable obj = Modelo.GetCodigoEditable(ID_Objeto);
            FIleInfo = new FileManager.CFIleInfo();
            FIleInfo.Contenido = FObjeto.getCodigo();
            FIleInfo.NombreCorto = FObjeto.getNombre();
            FIleInfo.NombreCompleto = archivo;
            return FIleInfo;
        }
        public void RenameCodigoEditable(int id_objeto, string nombre, string nuevoNombre)
        {
            if (FObjeto.esTuId(id_objeto ) &&FObjeto.getNombre() == nombre)
            {
                if (OnFileNameChange != null)
                    OnFileNameChange(nombre, nuevoNombre);
                FObjeto.setNombre( nuevoNombre);
            }
        }
    }
}
   