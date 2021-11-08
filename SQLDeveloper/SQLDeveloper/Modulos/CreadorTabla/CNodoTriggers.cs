using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoTriggers: CNodoFolder
    {
        CTabla Tabla;
        public CNodoTriggers(CTabla tabla)
        {
            Tabla = tabla;
            Text = "Triggers";
            MuestraTriggers();
        }
        private void MuestraTriggers()
        {
            List<MotorDB.EnumMomentTriger> l = DBProvider.DB.DameMomentosTriggerSoportados();
            foreach (MotorDB.EnumMomentTriger m in l)
            {
               CNodoMomento obj = new CNodoMomento(Tabla, m);
                Nodes.Add(obj);
                obj.CreaEstructura();
            }
            CargaTriggers();
        }
        public void CargaTriggers()
        {
            //me traigo todos los triggers asociados a la tabla
            List<MotorDB.CTrigger> l = DBProvider.DB.DameTrrigersTabla(Tabla.Nombre);
            foreach (CNodoMomento nodo in Nodes)
            {
                foreach (MotorDB.CTrigger obj in l)
                {
                    nodo.AddTrigger(obj);
                }
            }
        }
    }
}
