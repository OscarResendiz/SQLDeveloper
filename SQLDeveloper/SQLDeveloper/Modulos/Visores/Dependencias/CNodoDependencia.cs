using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.Visores.Dependencias
{
    public class CNodoDependencia: TreeNode
    {
        public String Nombre
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
        private MotorDB.EnumTipoObjeto FTipo;
        public MotorDB.EnumTipoObjeto Tipo
        {
            get
            {
                return FTipo;
            }
            set
            {
                FTipo = value;
                switch (FTipo)
                {
                    case MotorDB.EnumTipoObjeto.FUNCION:
                        ImageIndex = 2;
                        SelectedImageIndex = 2;
                        break;
                    case MotorDB.EnumTipoObjeto.PROCEDURE:
                        ImageIndex = 3;
                        SelectedImageIndex = 3;
                        break;
                    case MotorDB.EnumTipoObjeto.TABLE:
                        ImageIndex = 0;
                        SelectedImageIndex = 0;
                        break;
                    case MotorDB.EnumTipoObjeto.TRIGER:
                        ImageIndex = 4;
                        SelectedImageIndex = 4;
                        break;
                    case MotorDB.EnumTipoObjeto.VIEW:
                        ImageIndex = 1;
                        SelectedImageIndex = 1;
                        break;
                }

            }
        }
    }
}
