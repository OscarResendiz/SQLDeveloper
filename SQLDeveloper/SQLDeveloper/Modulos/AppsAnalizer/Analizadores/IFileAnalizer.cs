using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    public delegate void FileAnalizerEvent(int id_archivo,int linea,string cadena,string nombreArchivo);
    interface IFileAnalizer
    {
        void analiza(ObjetosModelo.CArchivo archivo);
        void AddAnalizarObjetoEvent(FileAnalizerEvent e);
    }
}
   