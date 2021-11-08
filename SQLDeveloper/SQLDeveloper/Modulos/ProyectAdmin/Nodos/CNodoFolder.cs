using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CNodoFolder : CNodoBase
    {
        private bool FLLeno;
        public CNodoFolder()
        {
            ImageIndex = 2;
            SelectedImageIndex = 2;
            FLLeno = false;
            FEliminado = false;
        }
        public override void Expandido()
        {
            //se sobre escibe para manejar el vento de expandido
            if (FEliminado)
            {
                ImageIndex = 5;
                SelectedImageIndex = 5;
                return;
            }
            if (FLLeno)
            {
                ImageIndex = 4;
                SelectedImageIndex = 4;
                return;
            }
            ImageIndex = 3;
            SelectedImageIndex = 3;
        }
        public override void Colapsado()
        {
            //se sobre escibe para manejar el vento de colapsado
            if(FEliminado)
            {
                ImageIndex = 5;
                SelectedImageIndex = 5;
                return;
            }
            if (FLLeno)
            {
                ImageIndex = 4;
                SelectedImageIndex = 4;
                return;
            }
            ImageIndex = 2;
            SelectedImageIndex = 2;
        }
        private void ValidaEstado()
        {
            if (IsExpanded)
            {
                Expandido();
            }
            else
            {
                Colapsado();
            }
        }
        public bool Lleno
        {
            get
            {
                return FLLeno;
            }
            set
            {
                FLLeno = value;
                ValidaEstado();
            }
        }
        private bool FEliminado;
        public bool Eliminado
        {
            get
            {
                return FEliminado;
            }
            set
            {
                FEliminado = value;
                ValidaEstado();
            }
        }
    }
}
