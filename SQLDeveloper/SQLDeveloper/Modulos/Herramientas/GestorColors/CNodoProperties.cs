using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    class CNodoProperties:CNodoBase
    {
        CProperties Properties;
        public CNodoProperties()
        {
            Text = "Propiedades";
        }
        public override void Recarga()
        {
            Properties = (CProperties)Objeto;
            Nodes.Clear();
            
            foreach(CProperty obj in Properties.Properties)
            {
                CNodoProperty Property = new CNodoProperty();
                Property.Objeto = obj;
                Property.Recarga();
                Nodes.Add(Property);
            }

        }
    }
}
