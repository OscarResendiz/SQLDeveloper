using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteliences
{
    public partial class CAnaliseManager : Component
    {
        public CAnaliseManager()
        {
            InitializeComponent();
        }

        public CAnaliseManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public ITextAnaliser GetAnaliser(string Tipo)
        {
            ITextAnaliser analizador = null;
            if (Tipo == MotorDB.EnumMotoresDB.SQLSERVER.ToString())
            {
                analizador = new CSQLTextAnaliser();
            }
            if (Tipo == MotorDB.EnumMotoresDB.MYSQL.ToString())
            {
                analizador = new CSQLTextAnaliser();
            }
            if (Tipo == MotorDB.EnumMotoresDB.POSTGRES.ToString())
            {
                analizador = new CSQLTextAnaliser();
            }
            return analizador;
        }
    }
}
