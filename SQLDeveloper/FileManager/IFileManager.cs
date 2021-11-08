using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public delegate void OnFileNameChangeEvent(string nombre, string nuevoNombre);
    public interface IFileManager
    {
        event OnFileNameChangeEvent OnFileNameChange;
        string Guardar(CFIleInfo info);
        string GuardarComo(CFIleInfo info);
        CFIleInfo Abrir();
        CFIleInfo Abrir(string archivo);
        bool EnableGuardar();
        bool EnableAbrir();
        bool EnableGuardarComo();
    }
}
