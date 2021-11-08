using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    class CNodoProperty:CNodoBase
    {
        CProperty Property;
        public override void Recarga()
        {
            Property = (CProperty)Objeto;
            Property.PropertyNameChange += new PropertyNameChangeEvent(CambioNombre);
            Text = Property.name;
            Visor = new PropertyControl();
            Visor.Objeto = Property;
            Visor.Recarga();
        }
        private void CambioNombre(CProperty sender, string nombre)
        {
            Text = nombre;
        }

    }

}
