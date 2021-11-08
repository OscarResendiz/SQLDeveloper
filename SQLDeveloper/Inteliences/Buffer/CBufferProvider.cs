using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;

namespace Inteliences
{
    /// <summary>
    /// Implementa un proveedor que administra los buffers para impedir que se generen varios
    /// para la misma conexion
    /// </summary>
    public partial class CBufferProvider : Component
    {
        private static List<CBuffer> ListaBuffers;
        public CBufferProvider()
        {
            Inicializa();
            InitializeComponent();
        }

        public CBufferProvider(IContainer container)
        {
            Inicializa();
            container.Add(this);

            InitializeComponent();
        }
        private static void Inicializa()
        {
            if(ListaBuffers==null)
                ListaBuffers=new List<CBuffer>();

        }
        public  CBuffer GetBuffer(IMotorDB Motor)
        {
            if (Motor == null)
                return null;
            //busco primero si ya tengo el motor registrado
            foreach(CBuffer obj in ListaBuffers)
            {
                if(obj.Motor.GetConecctionString()==Motor.GetConecctionString())
                {
                    //tiene la misma cadena de conexion, por lo que son lo mismo
                    return obj;
                }
            }
            //no lo encontre, por lo que lo agrego
            CBuffer b = new CBuffer();
            b.Motor = Motor;
            ListaBuffers.Add(b);
            return b;
        }
    }
}
