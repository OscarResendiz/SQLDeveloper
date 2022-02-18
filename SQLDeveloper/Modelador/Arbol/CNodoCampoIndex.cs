using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Arbol
{
    public class CNodoCampoIndex: CNodoBase
    {
        public int ID_Index
        {
            get;
            set;
        }
        public int ID_Campo
        {
            get;
            set;
        }
        public CNodoCampoIndex()
        {
            Nombre = "Campo";
        }
        public Modelo.CCampoIndex GetCampo()
        {
            return Modelo.Get_CampoIndex(ID_Index, ID_Campo);
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            CCampo campo = GetCampo().Get_Campo();
            Nombre = campo.Nombre;
            ToolTipText = campo.Comentarios;
        }
    }
}
