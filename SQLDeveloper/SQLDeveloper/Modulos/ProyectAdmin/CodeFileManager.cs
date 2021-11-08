using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CodeFileManager : FileManager.IFileManager
    {
        public event FileManager.OnFileNameChangeEvent OnFileNameChange;
        private FileManager.CFIleInfo FIleInfo;
        private ModeloBasico FModelo;
        private bool Guardando = false;
        public ModeloBasico Modelo
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
                    FModelo.OnCodigoEditableChange += new OnCodigoEditableChangeEvent(CodigoEditableChange);
                    FModelo.OnRenameCodigoEditable += new OnRenameCodigoEditableEvent(RenameCodigoEditable);
                }
            }
        }
        public int ID_Objeto
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public string Guardar(FileManager.CFIleInfo info)
        {
            Guardando = true;
            FIleInfo = info;
            CModelCodigoEditable obj = Modelo.DameCodigoEditable(ID_Objeto, Nombre);
            Modelo.ActualizaCodigoFuenteEditable(ID_Objeto, Nombre, info.Contenido);
            Guardando = false;
            return Nombre;
        }
        public string GuardarComo(FileManager.CFIleInfo info)
        {
            Guardando = true;
            FIleInfo = info;
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = Nombre;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                Guardando = false;
                return Nombre;
            }
            try
            {
                string nuevoNombre = dlg.Nombre;
                Modelo.AgregaCodigoEditable(ID_Objeto, nuevoNombre, info.Contenido);
                Nombre = nuevoNombre;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Nombre;

            }
            Guardando = false;
            return Nombre;
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
            if (ID_Objeto != id_objeto || nombre != Nombre)
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
            CModelCodigoEditable obj = Modelo.DameCodigoEditable(ID_Objeto, Nombre);
            FIleInfo = new FileManager.CFIleInfo();
            FIleInfo.Contenido = obj.Codigo;
            FIleInfo.NombreCorto = Nombre;
            FIleInfo.NombreCompleto = archivo;
            return FIleInfo;
        }
        public void RenameCodigoEditable(int id_objeto, string nombre, string nuevoNombre)
        {
            if(id_objeto==ID_Objeto  && nombre==Nombre)
            {
                if (OnFileNameChange != null)
                    OnFileNameChange(Nombre, nuevoNombre);
                Nombre = nuevoNombre;
            }
        }
    }
}
