using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.Visores.Trrigers
{
    public class NodoTabla: TreeNode
    {
        public string Nombre
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        public NodoTabla()
        {
            ImageIndex = 0;
            SelectedImageIndex = 0;
            List<MotorDB.EnumMomentTriger> l = DBProvider.DB.DameMomentosTriggerSoportados();
            foreach(MotorDB.EnumMomentTriger m in l)
            {
                CNodoMomento obj = new CNodoMomento(Nombre,m);
                Nodes.Add(obj);
                obj.CreaEstructura();
            }
        }
        public void CargaTriggers()
        {
            //me traigo todos los triggers asociados a la tabla
            List<MotorDB.CTrigger> l = DBProvider.DB.DameTrrigersTabla(Nombre);
            foreach(CNodoMomento nodo in Nodes)
            {
                foreach (MotorDB.CTrigger obj in l)
                {
                    nodo.AddTrigger(obj);
                }
            }
        }
    }
}
