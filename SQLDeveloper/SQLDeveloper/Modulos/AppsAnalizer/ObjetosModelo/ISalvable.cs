using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    interface ISalvable
    {
        string getCodigo();
        void setCodigo(string codigo);
        void Guardar();
        void GuardarComo(string nuevoNombre);
        string getNombre();
        void setNombre(string nombre);
        bool esTuId(int id);
    }
}
   