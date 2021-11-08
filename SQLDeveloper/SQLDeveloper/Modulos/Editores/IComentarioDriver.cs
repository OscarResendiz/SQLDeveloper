using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Editores
{
    public delegate void IComentarioDriverEvent(int id);
    public interface IComenarioDriver
    {
        void setDocumentChage(IComentarioDriverEvent onDocumentChage);
        int getId();
        void setId(int id);
        string getText();
        void setText(string texto);
        void Save();
        string getName();
        void setName(string nombre);
    }
}
   