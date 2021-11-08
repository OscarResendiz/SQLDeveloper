using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace GridControl
{
    internal class CFiltro
    {
        public Type TipoDato
        {
            get;
            set;
        }
        public string Tabla
        {
            get;
            set;
        }
        public string Campo
        {
            get;
            set;
        }
        public string Condicion
        {
            get;
            set;
        }
        public string Valor
        {
            get;
            set;
        }
        public DataSet AplicaFiltro(DataSet ds)
        {
            DataSet res = ds.Copy();
            //me traigo la tabla a la que hay que aplicarle el filtro
            DataTable dt = res.Tables[Tabla];
            //me traigo el tipo de dato
            DataColumn columna = dt.Columns[Campo];
            TipoDato = columna.DataType;
            //recorro todos sus registros
            int  n;
            n = dt.Rows.Count;
            for (int i=n-1;i>=0;i--)
            {
                DataRow dr = dt.Rows[i];
                if (Filtra(dr)==false)
                {
                    //no paso el filtro por lo que hay que eliminarlo
                    dt.Rows.Remove(dr);
                }
            }
            return res;
        }
        private bool Empieza(DataRow dr)
        {
            string s = dr[Campo].ToString();
            int i, n, j, k;
            n = s.Length;
            k = Valor.Length;
            if (n < k)
                return false; // de entrada no empieza porque el texto es menor
            for(i=0;i<n&&i<k;i++)
            {
                if (s[i].ToString().ToUpper() != Valor[i].ToString().ToUpper())
                    return false;
            }
            return true;
        }
        private bool Contiene(DataRow dr)
        {
            string s = dr[Campo].ToString();
            return s.Contains(Valor);
        }
        private bool Termina(DataRow dr)
        {
            string s = dr[Campo].ToString();
            int i, n, j, k;
            n = s.Length;
            k = Valor.Length;
            if (n < k)
                return false; // de entrada no empieza porque el texto es menor
            for (i=n-1,j=k-1;j>=0&&i>=0;j--,i--)
            {
                if (s[i].ToString().ToUpper() != Valor[j].ToString().ToUpper())
                    return false;
            }
            return true;
        }
        private bool NoTermina(DataRow dr)
        {
            return !Termina(dr);
        }
        private bool NoEmpieza(DataRow dr)
        {
            return !Empieza(dr);
        }
        private bool NoContiene(DataRow dr)
        {
            return !Contiene(dr);
        }
        private bool Exacto(DataRow dr)
        {
            string s = dr[Campo].ToString();
            return s == Valor;
        }
        private bool MayorQue(DataRow dr)
        {
            if (TipoDato == typeof(Boolean))
            {
                Boolean a;
                Boolean b;
                a = Boolean.Parse(dr[Campo].ToString());
                b = Boolean.Parse(Valor);
                if (a == true && b == false)
                    return true;
                return false;
            }
            if (TipoDato == typeof(Byte))
            {
                Byte a;
                Byte b;
                a = Byte.Parse(dr[Campo].ToString());
                b = Byte.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(DateTime))
            {
                DateTime a;
                DateTime b;
                a = DateTime.Parse(dr[Campo].ToString());
                b = DateTime.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(Decimal))
            {
                Decimal a;
                Decimal b;
                a = Decimal.Parse(dr[Campo].ToString());
                b = Decimal.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(Double))
            {
                Double a;
                Double b;
                a = Double.Parse(dr[Campo].ToString());
                b = Double.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(Int16))
            {
                Int16 a;
                Int16 b;
                a = Int16.Parse(dr[Campo].ToString());
                b = Int16.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(Int32))
            {
                Int32 a;
                Int32 b;
                a = Int32.Parse(dr[Campo].ToString());
                b = Int32.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(Int64))
            {
                Int64 a;
                Int64 b;
                a = Int64.Parse(dr[Campo].ToString());
                b = Int64.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(TimeSpan))
            {
                TimeSpan a;
                TimeSpan b;
                a = TimeSpan.Parse(dr[Campo].ToString());
                b = TimeSpan.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(UInt16))
            {
                UInt16 a;
                UInt16 b;
                a = UInt16.Parse(dr[Campo].ToString());
                b = UInt16.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(UInt32))
            {
                UInt32 a;
                UInt32 b;
                a = UInt32.Parse(dr[Campo].ToString());
                b = UInt32.Parse(Valor);
                return a > b;
            }
            if (TipoDato == typeof(UInt64))
            {
                UInt64 a;
                UInt64 b;
                a = UInt64.Parse(dr[Campo].ToString());
                b = UInt64.Parse(Valor);
                return a > b;
            }
            return false;
        }
        private bool MenorQue(DataRow dr)
        {
            if (TipoDato == typeof(Boolean))
            {
                Boolean a;
                Boolean b;
                a = Boolean.Parse(dr[Campo].ToString());
                b = Boolean.Parse(Valor);
                if (a == true && b == false)
                    return false;
                return true;
            }
            if (TipoDato == typeof(Byte))
            {
                Byte a;
                Byte b;
                a = Byte.Parse(dr[Campo].ToString());
                b = Byte.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(DateTime))
            {
                DateTime a;
                DateTime b;
                a = DateTime.Parse(dr[Campo].ToString());
                b = DateTime.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(Decimal))
            {
                Decimal a;
                Decimal b;
                a = Decimal.Parse(dr[Campo].ToString());
                b = Decimal.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(Double))
            {
                Double a;
                Double b;
                a = Double.Parse(dr[Campo].ToString());
                b = Double.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(Int16))
            {
                Int16 a;
                Int16 b;
                a = Int16.Parse(dr[Campo].ToString());
                b = Int16.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(Int32))
            {
                Int32 a;
                Int32 b;
                a = Int32.Parse(dr[Campo].ToString());
                b = Int32.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(Int64))
            {
                Int64 a;
                Int64 b;
                a = Int64.Parse(dr[Campo].ToString());
                b = Int64.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(TimeSpan))
            {
                TimeSpan a;
                TimeSpan b;
                a = TimeSpan.Parse(dr[Campo].ToString());
                b = TimeSpan.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(UInt16))
            {
                UInt16 a;
                UInt16 b;
                a = UInt16.Parse(dr[Campo].ToString());
                b = UInt16.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(UInt32))
            {
                UInt32 a;
                UInt32 b;
                a = UInt32.Parse(dr[Campo].ToString());
                b = UInt32.Parse(Valor);
                return a < b;
            }
            if (TipoDato == typeof(UInt64))
            {
                UInt64 a;
                UInt64 b;
                a = UInt64.Parse(dr[Campo].ToString());
                b = UInt64.Parse(Valor);
                return a < b;
            }
            return false;

        }
        private bool MayoIgual(DataRow dr)
        {
            if (TipoDato == typeof(Boolean))
            {
                Boolean a;
                Boolean b;
                a = Boolean.Parse(dr[Campo].ToString());
                b = Boolean.Parse(Valor);
                if (a == true && b == false)
                    return true;
                return a == b;
            }
            if (TipoDato == typeof(Byte))
            {
                Byte a;
                Byte b;
                a = Byte.Parse(dr[Campo].ToString());
                b = Byte.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(DateTime))
            {
                DateTime a;
                DateTime b;
                a = DateTime.Parse(dr[Campo].ToString());
                b = DateTime.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(Decimal))
            {
                Decimal a;
                Decimal b;
                a = Decimal.Parse(dr[Campo].ToString());
                b = Decimal.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(Double))
            {
                Double a;
                Double b;
                a = Double.Parse(dr[Campo].ToString());
                b = Double.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(Int16))
            {
                Int16 a;
                Int16 b;
                a = Int16.Parse(dr[Campo].ToString());
                b = Int16.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(Int32))
            {
                Int32 a;
                Int32 b;
                a = Int32.Parse(dr[Campo].ToString());
                b = Int32.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(Int64))
            {
                Int64 a;
                Int64 b;
                a = Int64.Parse(dr[Campo].ToString());
                b = Int64.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(TimeSpan))
            {
                TimeSpan a;
                TimeSpan b;
                a = TimeSpan.Parse(dr[Campo].ToString());
                b = TimeSpan.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(UInt16))
            {
                UInt16 a;
                UInt16 b;
                a = UInt16.Parse(dr[Campo].ToString());
                b = UInt16.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(UInt32))
            {
                UInt32 a;
                UInt32 b;
                a = UInt32.Parse(dr[Campo].ToString());
                b = UInt32.Parse(Valor);
                return a >= b;
            }
            if (TipoDato == typeof(UInt64))
            {
                UInt64 a;
                UInt64 b;
                a = UInt64.Parse(dr[Campo].ToString());
                b = UInt64.Parse(Valor);
                return a >= b;
            }
            return false;

        }
        private bool MenorIgual(DataRow dr)
        {
            if (TipoDato == typeof(Boolean))
            {
                Boolean a;
                Boolean b;
                a = Boolean.Parse(dr[Campo].ToString());
                b = Boolean.Parse(Valor);
                if (a == true && b == false)
                    return false;
                return !(a == b);
            }
            if (TipoDato == typeof(Byte))
            {
                Byte a;
                Byte b;
                a = Byte.Parse(dr[Campo].ToString());
                b = Byte.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(DateTime))
            {
                DateTime a;
                DateTime b;
                a = DateTime.Parse(dr[Campo].ToString());
                b = DateTime.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(Decimal))
            {
                Decimal a;
                Decimal b;
                a = Decimal.Parse(dr[Campo].ToString());
                b = Decimal.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(Double))
            {
                Double a;
                Double b;
                a = Double.Parse(dr[Campo].ToString());
                b = Double.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(Int16))
            {
                Int16 a;
                Int16 b;
                a = Int16.Parse(dr[Campo].ToString());
                b = Int16.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(Int32))
            {
                Int32 a;
                Int32 b;
                a = Int32.Parse(dr[Campo].ToString());
                b = Int32.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(Int64))
            {
                Int64 a;
                Int64 b;
                a = Int64.Parse(dr[Campo].ToString());
                b = Int64.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(TimeSpan))
            {
                TimeSpan a;
                TimeSpan b;
                a = TimeSpan.Parse(dr[Campo].ToString());
                b = TimeSpan.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(UInt16))
            {
                UInt16 a;
                UInt16 b;
                a = UInt16.Parse(dr[Campo].ToString());
                b = UInt16.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(UInt32))
            {
                UInt32 a;
                UInt32 b;
                a = UInt32.Parse(dr[Campo].ToString());
                b = UInt32.Parse(Valor);
                return a <= b;
            }
            if (TipoDato == typeof(UInt64))
            {
                UInt64 a;
                UInt64 b;
                a = UInt64.Parse(dr[Campo].ToString());
                b = UInt64.Parse(Valor);
                return a <= b;
            }
            return false;

        }
        private bool Igual(DataRow dr)
        {
            if (TipoDato == typeof(Boolean))
            {
                Boolean a;
                Boolean b;
                a = Boolean.Parse(dr[Campo].ToString());
                b = Boolean.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(Byte))
            {
                Byte a;
                Byte b;
                a = Byte.Parse(dr[Campo].ToString());
                b = Byte.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(DateTime))
            {
                DateTime a;
                DateTime b;
                a = DateTime.Parse(dr[Campo].ToString());
                b = DateTime.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(Decimal))
            {
                Decimal a;
                Decimal b;
                a = Decimal.Parse(dr[Campo].ToString());
                b = Decimal.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(Double))
            {
                Double a;
                Double b;
                a = Double.Parse(dr[Campo].ToString());
                b = Double.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(Int16))
            {
                Int16 a;
                Int16 b;
                a = Int16.Parse(dr[Campo].ToString());
                b = Int16.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(Int32))
            {
                Int32 a;
                Int32 b;
                a = Int32.Parse(dr[Campo].ToString());
                b = Int32.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(Int64))
            {
                Int64 a;
                Int64 b;
                a = Int64.Parse(dr[Campo].ToString());
                b = Int64.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(TimeSpan))
            {
                TimeSpan a;
                TimeSpan b;
                a = TimeSpan.Parse(dr[Campo].ToString());
                b = TimeSpan.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(UInt16))
            {
                UInt16 a;
                UInt16 b;
                a = UInt16.Parse(dr[Campo].ToString());
                b = UInt16.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(UInt32))
            {
                UInt32 a;
                UInt32 b;
                a = UInt32.Parse(dr[Campo].ToString());
                b = UInt32.Parse(Valor);
                return a == b;
            }
            if (TipoDato == typeof(UInt64))
            {
                UInt64 a;
                UInt64 b;
                a = UInt64.Parse(dr[Campo].ToString());
                b = UInt64.Parse(Valor);
                return a == b;
            }
            return false;

        }
        private bool Diferente(DataRow dr)
        {
            return !Igual(dr);
        }
        public bool Filtra(DataRow dr)
        {
            //regresa true si pasa el filtro y false si no
            //dependiendo del filtro seleccionado verifico cual aplica
            if (Condicion == "Empieza con...")
                return Empieza(dr);
            if (Condicion == "Contiene...")
                return Contiene(dr);
            if (Condicion == "Termina con...")
                return Termina(dr);
            if (Condicion == "No empieza con...")
                return NoEmpieza(dr);
            if (Condicion == "No contiene...")
                return NoContiene(dr);
            if (Condicion == "Exactamente igual a...")
                return Exacto(dr);
            if (Condicion == ">")
                return MayorQue(dr);
            if (Condicion == "<")
                return MenorQue(dr);
            if (Condicion == ">=")
                return MayoIgual(dr);
            if (Condicion == "=")
                return Igual(dr);
            if (Condicion == "<>")
                return Diferente(dr);
            if (Condicion == "<=")
                return MenorIgual(dr);
            if (Condicion == "No termina con...")
                return NoTermina(dr);
            return true;
        }
    }
}
