using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoMomento:CNodoFolder
    {
        private MotorDB.EnumMomentTriger Momento;
        CTabla Tabla;
        public CNodoMomento(CTabla tabla, EnumMomentTriger momento)
        {
            Tabla = tabla;
            Momento = momento;
            Text = Momento.ToString();

        }
        public void CreaEstructura()
        {
            Nodes.Clear();
            List<MotorDB.EnumEventTriger> l = DBProvider.DB.DameEventosTriggerSoportados();
            foreach (MotorDB.EnumEventTriger obj in l)
            {
                CNodoEvento nodo = new CNodoEvento(Tabla, obj, Momento);
                Nodes.Add(nodo);
            }
        }
        public void AddTrigger(MotorDB.CTrigger obj)
        {
            //primero veo si es de los que me corresonden a mi
            if (obj.Momento == Momento)
            {
                foreach (CNodoEvento nodo in Nodes)
                {
                    nodo.AddTrriger(obj);
                }
            }
        }
    }
}
