using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.Visores.Tabla
{
    public class CNodoTrigger:CNodoBase
    {
        public CNodoTrigger(MotorDB.IMotorDB db)
            :base(db)
        {
            ImageIndex =10;
            SelectedImageIndex = 10;
            //CreaMenu();

        }
    }
}
