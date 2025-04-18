﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelador.Modelo;
namespace Modelador.Genradores.Android
{
    /// <summary>
    /// genera codigo fuente kotlin para manejar base de datos room
    /// </summary>
    internal class CGeneradorKotlin
    {
        private Modelo.ModeloDatos Modelo;
        string Cadena = "";
        List<CTabla> Procesadas;
        List<CTabla> Tablas;
        public string Package
        {
            get;
            set;
        }
        public string DataBaseName
        {
            get;
            set;
        }
        public CGeneradorKotlin(Modelo.ModeloDatos modelo)
        {
            Modelo = modelo;    
        }
        /// <summary>
        /// genera el codigo de la tabla para hacerlo identidad en kotlin
        /// </summary>
        /// <param name="tabla"></param>
        public String GeneraIdentidad(Modelo.CTabla tabla)
        {
            Cadena = "package " + Package+".DataBase";
            Cadena = Cadena+ $"\nimport androidx.room.Entity\n" +
                $"import androidx.room.ForeignKey\n" +
                $"import android.os.Parcelable\n" +
                $"import kotlinx.android.parcel.Parcelize\n" +
                $"@Parcelize\n@Entity\n(\n\ttableName = \"{ tabla.Nombre}\"";
            //le agrego la llave primaria
            AgregaLLavePrimaria(tabla);
            //agrego las llaves foraneas
            AgregaLLavesForaneas(tabla);
            Cadena = Cadena + "\n)\n";
            //ahora creo la definicion de la tabla
            CreaDataClass(tabla);
            return Cadena;
        }
        /// <summary>
        /// genera el codigo para agregar la identidad de la llave primaria
        /// </summary>
        /// <param name="tabla"></param>
        private void AgregaLLavePrimaria(Modelo.CTabla tabla)
        {
            bool primero = true;
            List<CCampo> pk = tabla.GetCampoPK();
            if (pk.Count > 0)
            {
                primero = true;
                //contiene llave primaria
                Cadena = Cadena + "\n\t,primaryKeys = [";
                //recorro todos los campos para agregarlos a la definicion de la llave primaria
                foreach (CCampo campo in pk)
                {
                    if (primero == false)
                    {
                        //si no es el primero. le agrego una coma para separalo
                        Cadena = Cadena + ",";
                    }
                    Cadena = Cadena + $"\"{campo.Nombre}\"";
                    primero = false;
                }
                Cadena = Cadena + "]";
            }

        }
        /// <summary>
        /// agrega las llaves foraneas
        /// </summary>
        /// <param name="tabla"></param>
        private void AgregaLLavesForaneas(CTabla tabla)
        {
            bool primero = true;
            //me traigo las llaves foraneas
            List<CLlaveForanea> fks = tabla.Get_FkPadres();
            if (fks.Count > 0)
            {
                Cadena = Cadena + "\n\t,foreignKeys = \n\t[";
                foreach (CLlaveForanea fk in fks)
                {
                    if (primero == false)
                    {
                        Cadena = Cadena + ",";
                    }
                    AgregaLLaveForanea(fk);
                    primero = false;
                }
                Cadena = Cadena + "\n\t]";
            }

        }
        /// <summary>
        /// agrega la llave foranea
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="fk"></param>
        private void AgregaLLaveForanea(CLlaveForanea fk)
        {
            string childColumns = ", childColumns = [";
            //me traigo la tabla padre
            CTabla tablaPadre = fk.Get_TablaPadre();
            Cadena = Cadena + $"\n\t\tForeignKey(entity ={tablaPadre.Nombre}::class, parentColumns = [ ";
            //me traigo las columnas de la llave foranea
            List<CCampoReferencia> campos = fk.Get_Campos();
            bool primero = true;
            foreach(CCampoReferencia campo in campos)
            {
                if(primero==false)
                {
                    Cadena = Cadena + ",";
                    childColumns = childColumns + ",";
                }
                primero = false;
                Cadena = Cadena + $"\"{campo.Get_CampoPadre().Nombre}\"";
                childColumns = childColumns + $"\"{campo.Get_CampoHijo().Nombre}\"";
            }
            Cadena = Cadena + "]";
            childColumns = childColumns + "]";
            Cadena = Cadena + childColumns;
            Cadena = Cadena + ", onUpdate = ForeignKey.";
            //agrego la accion al actualizae
            switch (fk.AcctionUpdate)
            {
                case MotorDB.EnumAccionReferencial.NO_ACTION:
                    Cadena = Cadena + "NO_ACTION";
                    break;
                case MotorDB.EnumAccionReferencial.CASCADE:
                    Cadena = Cadena + "CASCADE";
                    break;
                case MotorDB.EnumAccionReferencial.SET_DEFAULT:
                    Cadena = Cadena + "SET_DEFAULT";
                    break;
                case MotorDB.EnumAccionReferencial.SET_NULL:
                    Cadena = Cadena + "SET_NULL";
                    break;
                case MotorDB.EnumAccionReferencial.RESTRICT:
                    Cadena = Cadena + "RESTRICT";
                    break;
            }
            //agrego la accion al borrar    
            Cadena = Cadena + ", onDelete = ForeignKey.";
            switch (fk.AcctionDelete)
            {
                case MotorDB.EnumAccionReferencial.NO_ACTION:
                    Cadena = Cadena + "NO_ACTION";
                    break;
                case MotorDB.EnumAccionReferencial.CASCADE:
                    Cadena = Cadena + "CASCADE";
                    break;
                case MotorDB.EnumAccionReferencial.SET_DEFAULT:
                    Cadena = Cadena + "SET_DEFAULT";
                    break;
                case MotorDB.EnumAccionReferencial.SET_NULL:
                    Cadena = Cadena + "SET_NULL";
                    break;
                case MotorDB.EnumAccionReferencial.RESTRICT:
                    Cadena = Cadena + "RESTRICT";
                    break;
            }
            Cadena = Cadena + ")";
        }
        /// <summary>
        /// crea el codigo del data class de la indentidad
        /// </summary>
        /// <param name="tbla"></param>
        private void CreaDataClass(CTabla tabla)
        {
            Cadena = Cadena + $"/** {tabla.Comentarios} */";
            Cadena = Cadena + $"\ndata class {tabla.Nombre}(";
            //me traigo los campos de la tabla
            List<CCampo> campos = tabla.Get_Campos();
            bool primero = true;
            foreach(CCampo campo in campos)
            {
                Cadena = Cadena + "\n\t";
                if (!primero)
                {
                    Cadena = Cadena + ",";
                }
                primero = false;
                Cadena = Cadena + $"var {campo.Nombre}:\t{campo.Get_TipoDato().Nombre}\t/** {campo.Comentarios} */";
            }
            Cadena = Cadena + "\n): Parcelable";
        }
        /// <summary>
        /// genera el codigo para actuar con la t
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public string CreaDAO(CTabla tabla)
        {
            Cadena = "package "+Package + ".DataBase"; ;
            Cadena = Cadena + "\nimport androidx.room.*";
            Cadena = Cadena + "\n@Dao";
            Cadena = Cadena + $"\ninterface DAO_{tabla.Nombre}";
            Cadena = Cadena + "{";
            //agrego el insertar un registro
            Cadena = Cadena + "\n\t@Insert(onConflict = OnConflictStrategy.REPLACE)";
            Cadena = Cadena + $"\n\tfun Insert_{tabla.Nombre}(valor: {tabla.Nombre})";
            //actualizar un registro
            Cadena = Cadena + "\n\n\t@Update";
            Cadena = Cadena + $"\n\tfun Update_{tabla.Nombre}(valor:{tabla.Nombre})";
            //eliminar un registro
            Cadena = Cadena + "\n\n\t@Delete";
            Cadena = Cadena + $"\n\tfun Delete_{tabla.Nombre}(valor:{tabla.Nombre})";
            //leer un solo registro
            List<CCampo> pks=tabla.GetCampoPK();
            if(pks.Count>0)
            {
                Cadena = Cadena + $"\n\n\t@Query(\"select* from {tabla.Nombre} where ";
                bool primero = true;
                string parametros = "(";
                foreach(CCampo campo in pks)
                {
                    if(!primero)
                    {
                        Cadena = Cadena + " and ";
                        parametros = parametros + ",";
                    }
                    primero = false;
                    Cadena = Cadena + $"{campo.Nombre}=:V{campo.Nombre}";
                    parametros = parametros + $"V{campo.Nombre}:{campo.Get_TipoDato().Nombre}";
                }
                Cadena = Cadena + "\")";
                parametros = parametros + ")";
            Cadena = Cadena + $"\n\tfun Get_{tabla.Nombre}{parametros}:{tabla.Nombre}";
            }
            CreaDAOFKs(tabla);
            GeneraIndices(tabla);
            Cadena = Cadena + "\n}";
            return Cadena;
        }
        private void CreaDAOFKs(CTabla tabla)
        {
            //leer los registro dependientes de los padres
            List<CLlaveForanea> fks = tabla.Get_FkPadres();
            foreach(CLlaveForanea fk in fks)
            {
                CreDaoFK(fk);

            }
        }
        private void CreDaoFK(CLlaveForanea fk)
        {
            Cadena = Cadena + $"\n\n\t@Query(\"select* from {fk.Get_TablaHija().Nombre} where ";
            bool primero = true;
            string parametros = "(";
            foreach(CCampoReferencia campo in fk.Get_Campos())
            {
                if (!primero)
                {
                    Cadena = Cadena + " and ";
                    parametros = parametros + ",";
                }
                primero = false;
                Cadena = Cadena + $"{campo.Get_CampoHijo().Nombre}=:V{campo.Get_CampoHijo().Nombre}";
                parametros = parametros + $"V{campo.Get_CampoHijo().Nombre}:{campo.Get_CampoHijo().Get_TipoDato().Nombre}";

            }
            Cadena = Cadena + "\")";
            parametros = parametros + ")";
            Cadena = Cadena + $"\n\tfun Get_{fk.Nombre}{parametros}:MutableList<{fk.Get_TablaHija().Nombre}>";
        }
        public string CreaDataBase()
        {
            string NombreDB = DataBaseName;// Modelo.getNombreCorto();
            Cadena = "package " + Package + ".DataBase"; ;
            Cadena = Cadena + "\nimport android.content.Context";
            Cadena = Cadena + "\nimport androidx.room.Database";
            Cadena = Cadena + "\nimport androidx.room.Room";
            Cadena = Cadena + "\nimport androidx.room.RoomDatabase";
            Cadena = Cadena + "\n@Database(entities = [";
            //recorro las tablas para agregarlas
            bool primero = true;
            Tablas= Modelo.Get_Tablas();
            foreach (CTabla tabla in Tablas)
            {
                if(primero==false)
                {
                    Cadena = Cadena + ",";
                }
                primero = false;
                Cadena = Cadena + $"{tabla.Nombre}::class";

            }
            Cadena = Cadena + "], version = 1)";
            Cadena = Cadena + $"\nabstract class {NombreDB}: RoomDatabase() "+"{";
            OrdenaTablas();
            //agrego nuevamente las tablas
            foreach (CTabla tabla in Procesadas)
            {
                Cadena = Cadena + $"\n\t";
                Cadena = Cadena + $"abstract val DAO_{tabla.Nombre}:DAO_{tabla.Nombre}\t/**{tabla.Comentarios}*/";
            }
            Cadena = Cadena + "\n}";
            Cadena = Cadena + $"\nprivate lateinit var INSTANCE:{NombreDB}";
            Cadena = Cadena + "\n";
            Cadena = Cadena + $"\nfun getDatabase(context: Context):{NombreDB}";
            Cadena = Cadena + "\n{";
            Cadena = Cadena + $"\n\tsynchronized({NombreDB}::class.java)";
            Cadena = Cadena + "\n\t{";
            Cadena = Cadena + "\n\t\tif(!::INSTANCE.isInitialized)";
            Cadena = Cadena + "\n\t\t{";
            Cadena = Cadena + $"\n\t\t\tINSTANCE= Room.databaseBuilder(context.applicationContext,{NombreDB}::class.java,\"{NombreDB}_db\").build()";
            Cadena = Cadena + "\n\t\t}";
            Cadena = Cadena + "\n\t\treturn  INSTANCE";
            Cadena = Cadena + "\n\t}";
            Cadena = Cadena + "\n}";
            return Cadena;
        }
        /// <summary>
        /// ordena las tablas para ser agregadas a la base de datos
        /// </summary>
        private void OrdenaTablas()
        {
            Procesadas = new List<CTabla>();
            //recorro todas las tablas hasta peocesarlas todas
            CTabla tabla = null;
            while (Tablas.Count > 0)
            {
                //me traigo la primer tabla
                    tabla = Tablas[0];
                //aun no se ha procesado
                ProcesaTabla(tabla);
            }
        }
        private void ProcesaTabla(CTabla tabla)
        {
            if (EstaProcesada(tabla) == false)
            {
                //veo si tiene papas
                List<CLlaveForanea> fks = tabla.Get_FkPadres();
                if (fks.Count > 0)
                {
                    //reviso si las tablas padres ya se encuentran procesadas
                    foreach (CLlaveForanea fk in fks)
                    {
                        //mando a procesar a la tabla padre
                        CTabla tablaPadre = fk.Get_TablaPadre();
                        if(tablaPadre.Nombre!=tabla.Nombre) //si la tabla no hace referencia a si misma
                            ProcesaTabla(tablaPadre);
                    }
                }
                //como ya procese a los padres, ahora proceso la tabla
                Procesadas.Add(tabla);
                QuitaTabla(tabla);
            }
        }
        private void QuitaTabla(CTabla tabla)
        {
            foreach(CTabla tabla1 in Tablas)
            {
                if(tabla.Nombre==tabla1.Nombre)
                {
                    Tablas.Remove(tabla1);
                    return;
                }
            }
        }
        private bool EstaProcesada(CTabla tabla)
        {
            foreach(CTabla tabla2 in Procesadas)
            {
                if (tabla.Nombre == tabla2.Nombre)
                    return true;
            }
            return false;
        }
        private void GeneraIndices(CTabla tabla)
        {
            List<CIndexX> indices = tabla.Get_Indexs();
            foreach(CIndexX index in indices)
            {
                if(index.GenerarFuncionX)
                {
                    CreaFuncionIndex(index, tabla);
                }
            }
        }
        private void CreaFuncionIndex(CIndexX index, CTabla tabla)
        {
            Cadena = Cadena + $"\n\n\t@Query(\"select* from {tabla.Nombre} where ";
            bool primero = true;
            string parametros = "(";            
            foreach (CCampoIndex campo in index.Get_CamposIndex())
            {
                if (!primero)
                {
                    Cadena = Cadena + " and ";
                    parametros = parametros + ",";
                }
                primero = false;
                Cadena = Cadena + $"{campo.Get_Campo().Nombre}=:V{campo.Get_Campo().Nombre}";
                parametros = parametros + $"V{campo.Get_Campo().Nombre}:{campo.Get_Campo().Get_TipoDato().Nombre}";

            }
            Cadena = Cadena + "\")";
            parametros = parametros + ")";
            if(index.MultiplesObjetos)
                Cadena = Cadena + $"\n\tfun {index.Nombre}{parametros}:MutableList<{tabla.Nombre}>";
            else
                Cadena = Cadena + $"\n\tfun {index.Nombre}{parametros}:{tabla.Nombre}";

        }
    }
}
