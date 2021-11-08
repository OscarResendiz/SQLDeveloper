using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoEvento: CNodoBase
    {
        CTabla Tabla;
        EnumEventTriger FDisparador;
        public MotorDB.EnumEventTriger Disparador
        {
            get
            {
                return FDisparador;
            }
            set
            {
                FDisparador = value;
                Text = FDisparador.ToString();
                switch (FDisparador)
                {
                    case MotorDB.EnumEventTriger.DELETE:
                        ImageIndex = 13;
                        SelectedImageIndex = 13;
                        break;
                    case MotorDB.EnumEventTriger.INSERT:
                        ImageIndex = 11;
                        SelectedImageIndex = 11;
                        break;
                    case MotorDB.EnumEventTriger.UPDATE:
                        ImageIndex = 12;
                        SelectedImageIndex = 12;
                        break;
                }
            }
        }
        public CNodoEvento(CTabla tabla, MotorDB.EnumEventTriger ev, MotorDB.EnumMomentTriger t = MotorDB.EnumMomentTriger.AFTER)
        {
            Tabla = tabla;
            Disparador = ev;
            //CreaMenu();
        }
        public void AddTrriger(MotorDB.CTrigger obj)
        {
           // Nodes.Clear();
            //recorro todos los objetos y agrego los que me corresponden
            if (obj.Disparador == Disparador)
            {
                CNodoTrigger nodo = new CNodoTrigger();
                nodo.Text = obj.Nombre;
                nodo.Tag = obj;
                Nodes.Add(nodo);
            }
        }

    }
}
