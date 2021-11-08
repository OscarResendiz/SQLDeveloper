using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    public delegate void AnalizerEventString(String s);
    public delegate void AnalizerEvent();
    public interface IAnalizer
    {
        void IniciaAnalisis();
        void AddMessageEvent(AnalizerEventString e);
        void AddInitAnalisisEvent(AnalizerEvent e);
        void AddEndAnalisisEvent(AnalizerEvent e);
        void cancelarAnalisis();
    }
}
   