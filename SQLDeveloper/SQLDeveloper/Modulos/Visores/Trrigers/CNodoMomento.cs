using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.Visores.Trrigers
{
    public class CNodoMomento: TreeNode
    {
        private MotorDB.EnumMomentTriger fMomento;
        public string Tabla
        {
            get;
            set;
        }
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
        public MotorDB.EnumMomentTriger Momento
        {
            get
            {
                return fMomento;
            }
            set
            {
                Nombre = value.ToString();
                fMomento = value;
            }
        }
        public CNodoMomento(string tabla,MotorDB.EnumMomentTriger m)
        {
            Momento = m;
            ImageIndex = 5;
            SelectedImageIndex = 5;
            Tabla = tabla;
        }
        public void CreaEstructura()
        {
            Nodes.Clear();
            List<MotorDB.EnumEventTriger> l = DBProvider.DB.DameEventosTriggerSoportados();
            foreach(MotorDB.EnumEventTriger obj in l)
            {
                CNodoEvento nodo = new CNodoEvento(Tabla,obj,Momento);
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
