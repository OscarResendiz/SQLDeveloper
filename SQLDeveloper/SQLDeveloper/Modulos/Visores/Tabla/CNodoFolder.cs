﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Visores.Tabla
{
   public class CNodoFolder: CNodoBase
    {
       public CNodoFolder(MotorDB.IMotorDB db)
           :base(db)
        {
           
            //.base(db);
            ImageIndex = 2;
            SelectedImageIndex = 2;
        }
        public override void Expandido()
        {
            //se sobre escibe para manejar el vento de expandido
            ImageIndex = 3;
            SelectedImageIndex = 3;
        }
        public override void Colapsado()
        {
            //se sobre escibe para manejar el vento de colapsado
            ImageIndex = 2;
            SelectedImageIndex = 2;

        }
    }
}
