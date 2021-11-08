using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SQLDeveloper.Modulos.Comparador {

    public delegate void OnTextComparatorEvent(List<CDiferencia> listadDferencias);
    
    public partial class TextComparator 
    {
        private List<DataRow> separados;
        public event OnTextComparatorEvent OnComparacionTerminada;
        private List<CDiferencia> ListaDiferencias;
    

        private string FTexto1;
        private System.ComponentModel.IContainer components;
        private CDebugerExcel cDebugerExcel1;
        private string FTexto2;
        public int Sensibilidad
        {
            get;
            set;
        }
        public bool CaseSencibility
        {
            get;
            set;
        }
        public string Texto1
        {
            get
            {
                return FTexto1;
            }
            set
            {
                FTexto1 = value;
                if (FTexto1 == null)
                    return;
                string[] l1 = FTexto1.Split('\n');
                foreach (string s in l1)
                {
                    DataRow dr = TTexto1.NewRow();
                    dr["Cadena"] = s.Replace("\r", "");
                    TTexto1.Rows.Add(dr);
                }

            }
        }
        public string Algoritmo
        {
            get;
            set;
        }
        public string Texto2
        {
            get
            {
                return FTexto2;
            }
            set
            {
                FTexto2 = value;
                if (FTexto2 == null)
                    return;
                string[] l1 = FTexto2.Split('\n');
                foreach (string s in l1)
                {
                    DataRow dr = TTexto2.NewRow();
                    dr["Cadena"] = s.Replace("\r", "");
                    TTexto2.Rows.Add(dr);
                }

            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BKComprador = new System.ComponentModel.BackgroundWorker();
            this.cDebugerExcel1 = new SQLDeveloper.Modulos.Comparador.CDebugerExcel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // BKComprador
            // 
            this.BKComprador.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKComprador_DoWork);
            this.BKComprador.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKComprador_RunWorkerCompleted);
            // 
            // cDebugerExcel1
            // 
            this.cDebugerExcel1.Enabled = false;
            this.cDebugerExcel1.NombreArchivo = "DebugComparador";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private System.ComponentModel.BackgroundWorker BKComprador;
        public void Comparar()
        {
            //inicia la comparacion en segundo plano 
            if (BKComprador == null)
                InitializeComponent();
            if (BKComprador.IsBusy)
                return;
            BKComprador.RunWorkerAsync();
        }
        
        private void QuitaConflictos()
        {
            //hago un bucle que elimine todos los conflictos
            do
            {
                #region primero veo si hay registroscon varias coincidencias
                var repetidos = (
                                        from com in Comparativa where com.Eliminar==false //solo los que no esten marcados para ser eliminados
                                        group com by com.NLinea1 into grupo
                                        where grupo.Count() > 1                                     
                                        select new { NLinea = grupo.Key, conteo = grupo.Count() });
                if(repetidos.Count()==0)
                {
                    //ya no hay por lo que termino el bucle
                    break;
                }
                #endregion
                #region eliminacion de registros
                //me traigo los unicos
                var unicos = ( from u in Comparativa where !(from r in repetidos select r.NLinea).Contains(u.NLinea1) && u.Eliminar==false select u);
                foreach (var u in unicos)
                {
                    bool encontrados = false;
                    var eliminar = (from x in Comparativa
                                    where ((x.NLinea1 < u.NLinea1 && x.NLinea2 > u.NLinea2) || (x.NLinea1 > u.NLinea1 && x.NLinea2 < u.NLinea2)) //que su rango no sea valido
                                    && x.Eliminar == false
                                    select x);
                    foreach (var obj in eliminar)
                    {
                        obj.Eliminar = true;
                        obj.AcceptChanges();
                        encontrados = true;
                    }
                    if(encontrados)
                    {
                        //pregunto si ya termine
                        var repetidos2 = (
                                                from com in Comparativa
                                                where com.Eliminar == false //solo los que no esten marcados para ser eliminados
                                                group com by com.NLinea1 into grupo
                                                where grupo.Count() > 1
                                                select new { NLinea = grupo.Key, conteo = grupo.Count() });
                        if (repetidos2.Count() == 0)
                        {
                            //ya no hay por lo que termino el bucle
                            break;
                        }
                    }

                }
                #endregion
            }
            while (true);
            //elimino lo registros
            LimpiaComparativa();
        }
        private void BuscaIguales()
        {
            List<int> eliminar = new List<int>();
            //busca todas las lineas que son iguales
                var resp = (from t1 in TTexto1
                            join t2 in TTexto2 on CaseSencibility? t1.Cadena: t1.Cadena.ToUpper() equals CaseSencibility ? t2.Cadena: t2.Cadena.ToUpper()
                            where
                             t1.Cadena.Trim() != ""
                            orderby t1.Cadena.Length descending//, t1.NLinea, t2.NLinea  //lor ordeno de la mas larga a la mas corta 
                            select new { Nlinea1 = t1.NLinea, Nlinea2 = t2.NLinea, Texto = t1.Cadena });
            foreach(var obj in resp)
            {
                if (obj.Texto.Trim() != "") //las lineas vacias las ignoro en esta etapa
                {
                    //antes de agreggarlo veo si no existe
                    var existe = (from e in Comparativa 
                                  where e.NLinea1 == obj.Nlinea1 || e.NLinea2==obj.Nlinea2 
                                  || (e.NLinea1<obj.Nlinea1 && e.NLinea2>obj.Nlinea2) //que se encuentre en un rango aceptable
                                  || (e.NLinea1>obj.Nlinea1 && e.NLinea2<obj.Nlinea2)
                                  select e);
                    if (existe.Count() ==0)
                    {
                        DataRow dr = Comparativa.NewRow();
                        dr["NLinea1"] = obj.Nlinea1;
                        dr["NLinea2"] = obj.Nlinea2;
                        dr["Iguales"] = true;
                        dr["Texto1"] = obj.Texto;
                        dr["Texto2"] = obj.Texto;
                        Comparativa.Rows.Add(dr);
                    }
                }
            }
            cDebugerExcel1.AddTable(Comparativa, "BuscaIguales");
            //cDebugerExcel1.Exportar();
            //return;
            QuitaConflictos();
            //ahora marco todos los que machearon
            var procesados1 = from obj in TTexto1 join comp in Comparativa on obj.NLinea equals comp.NLinea1 select obj;
            foreach(var izquierdo in procesados1)
            {
                izquierdo.Procesado = true;
                izquierdo.AcceptChanges();
            }
            //ahora los otros
            var procesados2 = from obj in TTexto2 join comp in Comparativa on obj.NLinea equals comp.NLinea2 select obj;
            foreach (var derecho in procesados2)
            {
                derecho.Procesado = true;
                derecho.AcceptChanges();
            }
        }
        private CLineComparer ComparaPorcentaje(string izquierda, string derecha)
        {
            CLineComparer obj = null;
            if (Algoritmo == "Palabra por palabra")
                obj = new CLineComparerLex();
            else
            {
                obj = new CLineComparer();
                obj.CaseSencibity = CaseSencibility;
            }
            obj.Linea1 = izquierda;
            obj.Linea2 = derecha;
            return obj;
        }
        private void llenaParecidos()
        {
            var par = (from izq in TTexto1
                       from der in TTexto2
                       where
                          izq.Procesado == false
                          && der.Procesado == false
                          && ComparaPorcentaje(izq.Cadena, der.Cadena).Compara() >= Sensibilidad
                          orderby izq.Cadena.Length descending, izq.NLinea, der.NLinea
                       select new
                       {
                           NLinea1 = izq.NLinea
                           ,
                           NLinea2 = der.NLinea
                           ,
                           Parecido = ComparaPorcentaje(izq.Cadena, der.Cadena).Compara()
                           ,
                           Texto1 = izq.Cadena
                           ,
                           Texto2 = der.Cadena
                       }
                         );
            foreach(var obj in par)
            {
                DataRow dr = Parecidos.NewRow();
                dr["NLinea1"] = obj.NLinea1;
                dr["NLinea2"] = obj.NLinea2;
                dr["Parecido"] = obj.Parecido;
                dr["Texto1"] = obj.Texto1;
                dr["Texto2"] = obj.Texto2;
                Parecidos.Rows.Add(dr);
            }
        }
        private void ResuelveParecidosDuplicados()
        {
            //me traigo todos los parecidos y los ordenos por el mas parecido primero
            var revisar = (from p in Parecidos select p).OrderByDescending(p => p.Parecido);
            foreach(var obj in revisar)
            {
                //veo si pasa la prueba
                var busca = (from x in Comparativa
                         where (obj.NLinea1 > x.NLinea1 && obj.NLinea2 < x.NLinea2)
                         || (obj.NLinea1 < x.NLinea1 && obj.NLinea2 > x.NLinea2)
                         || obj.NLinea1 == x.NLinea1 || obj.NLinea2 == x.NLinea2
                         select x
                           );
                if(busca.Count()==0)
                {
                    //paso la prueba. Lo agrego
                    DataRow dr = Comparativa.NewRow();
                    dr["NLinea1"] = obj.NLinea1;
                    dr["NLinea2"] = obj.NLinea2;
                    if (obj.Parecido == 100)
                        dr["Iguales"] = true;
                    else
                        dr["Iguales"] = false;
                    dr["Eliminar"] = false;
                    dr["Texto1"] = obj.Texto1;
                    dr["Texto2"] = obj.Texto2;
                    Comparativa.Rows.Add(dr);
                }
            }

        }
        private void BuscaDiferencias()
        {
            llenaParecidos();
            cDebugerExcel1.AddTable(Parecidos, "llenaParecidos");
            ResuelveParecidosDuplicados();
            cDebugerExcel1.AddTable(Parecidos, "ResuelveParecidosDuplicados");
        }
        private void PreparaResultado()
        {
            //leno la lista para mostrar el resultado de la comparacion
            ListaDiferencias = new List<CDiferencia>();
            var ordenados = (from x in Comparativa select x).OrderBy(x => x.Orden);
            foreach(var obj in ordenados)
            {
                //nuevamente marco los que son iguale
                if (obj.Iguales==false && obj.Texto1 == obj.Texto2&&obj.Faltante==false)//&&obj.NLinea1!=-1 && obj.NLinea2!=-1)
                    obj.Iguales = true;
                if(obj.Iguales==true)
                {
                    CDiferencia dif = new CDiferencia()
                    {
                        Izquierda = new CLinea()
                        {
                            NLinea = obj.Orden-1,//obj.NLinea1-1,
                            Procesado = true,
                            texto = obj.Texto1
                        },
                        Derecha = new CLinea()
                        {
                            NLinea = obj.Orden-1,//obj.NLinea2-1,
                            texto = obj.Texto2,
                            Procesado = true
                        },
                        Tipo = TipoDiferencia.IGUALES
                    };
                    ListaDiferencias.Add(dif);
                }
                else if(obj.Iguales==false && obj.NLinea1!=-1 && obj.NLinea2!=-1)
                {
                    CLineComparer cmp = ComparaPorcentaje(obj.Texto1, obj.Texto2);
                    cmp.Compara();
                    CDiferencia dif = new CDiferencia()
                    {
                        Izquierda = new CLinea()
                        {
                            NLinea = obj.Orden-1,// obj.NLinea1-1,
                            Procesado = true,
                            texto = obj.Texto1
                        },
                        Derecha = new CLinea()
                        {
                            NLinea = obj.Orden-1,// obj.NLinea2-1,
                            texto = obj.Texto2,
                            Procesado = true
                        },
                        DetalleDiferencias = cmp.GetDetalle(),
                        Tipo = TipoDiferencia.DIFERENTES
                    };
                    ListaDiferencias.Add(dif);
                }
                else if(obj.NLinea2==-1)
                {
                    CDiferencia dif = new CDiferencia()
                    {
                        Tipo = TipoDiferencia.SOLO_IZQUIERDA,
                        Izquierda = new CLinea()
                        {
                            NLinea = obj.Orden-1,// obj.NLinea1-1,
                            Procesado = true,
                            texto = obj.Texto1
                        },
                        Derecha = new CLinea()
                        {
                            NLinea = obj.Orden-1,// obj.NLinea1-1,
                            texto = " ",
                            Procesado = false
                        }
                    };
                    ListaDiferencias.Add(dif);
                }
                else if(obj.NLinea1==-1)
                {
                    CDiferencia dif = new CDiferencia()
                    {
                        Tipo = TipoDiferencia.SOLO_DERECHA,
                        Derecha = new CLinea()
                        {
                            NLinea = obj.Orden-1,// obj.NLinea2-1,
                            Procesado = true,
                            texto = obj.Texto2
                        },
                        Izquierda = new CLinea()
                        {
                            NLinea = obj.Orden-1,// obj.NLinea2-1,
                            texto = " ",
                            Procesado = false
                        }
                    };
                    ListaDiferencias.Add(dif);
                }
            }
        } 
        private void OrdenaRegistros()
        {
            //primero ordeno los registros del lado izquierdo
            var izquierdos = (from x in Comparativa where x.NLinea1 > -1 select x).OrderBy(x => x.NLinea1);
            int pos = 1;
            foreach(var obj in izquierdos)
            {
                obj.Orden = pos;
                obj.AcceptChanges();
                pos ++;//= 10; //le asigno un orden separado para que se puedan agregar los faltantes
            }
            //ahora me traigo los derechos que no se han ordenado
            var derechos = (from x in Comparativa where x.NLinea1 == -1 select x).OrderBy(x => x.NLinea2);
            foreach(var obj in derechos)
            {
                //me traigo el maximo que es menor al mio
                var anterior = (from x in Comparativa where x.NLinea2 < obj.NLinea2 select x).OrderByDescending(x => x.NLinea2);
                if(anterior.Count()==0)
                {
                    //no hay registros, por lo que debe de ir antes
                    //me traigo el menor de los que siguen
                    var sigiente = (from x in Comparativa where x.NLinea2 > obj.NLinea2 select x).OrderBy(x => x.NLinea2);
                    if(sigiente.Count()==0)
                    {
                        //hay un error
                        throw new System.Exception("No lo encuentro");
                    }
                    //me traigo el primero
                    var sig = sigiente.First();
                    //debo insertarlo antes de este
                    pos = sig.Orden;
                    //recorro todos los demas hacia delante para hacer espacio
                    foreach(var x in sigiente)
                    {
                        x.Orden = x.Orden + 1;
                        x.AcceptChanges();
                    }
                    obj.Orden = pos;
                    obj.AcceptChanges();
                    //me sigo con el siguiente
                    continue;
                }
                //me traigo la posicion del anterior
                var ant = anterior.First();
                //muevo los demas hacia arriba
                pos = ant.Orden;
                var adelantar = (from x in Comparativa where x.Orden > pos select x).OrderBy(x=>x.Orden);
                foreach (var x in adelantar)
                {
                    x.Orden = x.Orden + 1;
                    x.AcceptChanges();
                }
                //asigno mi posicion
                obj.Orden = pos+1;
                obj.AcceptChanges();
            }
        }
        private void InsertaFaltantes()
        {
            //agrego los separados
            foreach (DataRow dr in separados)
            {
                Comparativa.Rows.Add(dr);
            }
            //primero recorro todos los del lado izquierdo que no estan en el lado derecho
            var izquierdos = (from i in TTexto1 where !(from c in Comparativa select c.NLinea1).Contains(i.NLinea) select i);
            foreach (var obj in izquierdos)
            {
                DataRow dr = Comparativa.NewRow();
                dr["NLinea1"] = obj.NLinea;
                dr["NLinea2"] = -1;
                dr["Iguales"] = false;
                dr["Eliminar"] = false;
                dr["Texto1"] = obj.Cadena;
                dr["Texto2"] = "";
                dr["Faltante"] = true;
                Comparativa.Rows.Add(dr);
            }
            //ahora agrego los que faltan del lado derecho
            var derechos = (from i in TTexto2 where !(from c in Comparativa select c.NLinea2).Contains(i.NLinea) select i);
            foreach (var obj in derechos)
            {
                DataRow dr = Comparativa.NewRow();
                dr["NLinea1"] = -1;
                dr["NLinea2"] = obj.NLinea;
                dr["Iguales"] = false;
                dr["Eliminar"] = false;
                dr["Texto1"] = "";
                dr["Texto2"] = obj.Cadena;
                dr["Faltante"] = true;
                Comparativa.Rows.Add(dr);
            }
        }
        private void SeparaFalsosIguales()
        {
            if (separados == null)
            {
                separados = new List<DataRow>();
            }
            //ordeno los iguales por la linea1
            //despues recorro la linea 2 buscando si hay una anterior mas adelante
            //si es asi, separo la linea actual
            //me traigo los registros ordenadas por la primer linea
            var separar = (from a in Comparativa
                           from b in Comparativa
                           where a.NLinea1 < b.NLinea1 && a.NLinea2 > b.NLinea2
                           select a
                ).Distinct();
            //hago la misma consulta pero invitiendo las lineas 
            var separar2 = (from a in Comparativa
                            from b in Comparativa
                            where a.NLinea2 < b.NLinea2 && a.NLinea1 > b.NLinea1
                            select a
                ).Distinct();
            //veo cual es el que tiene menor cantidad de modificaciones y es el que utilizo
            if (separar.Count() > separar2.Count())
                separar = separar2;
            //recorro los registros
            foreach (var obj in separar)
            {
                //marco el actual para eliminarlo
                obj.Eliminar = true;
                obj.AcceptChanges();
                //veo si hay que agregarlo
                //para agregarlo no debe de haber lieas que coincidan con las existentes
                //agrego el izquierdo
                DataRow dr = Comparativa.NewRow();
                dr["NLinea1"] = obj.NLinea1;
                dr["NLinea2"] = -1;
                dr["Iguales"] = false;
                dr["Eliminar"] = false;
                dr["Texto1"] = obj.Texto1;
                dr["Texto2"] = "";
                dr["Faltante"] = true;
                separados.Add(dr);
                //agrego el derecho
                dr = Comparativa.NewRow();
                dr["NLinea1"] = -1;
                dr["NLinea2"] = obj.NLinea2;
                dr["Iguales"] = false;
                dr["Eliminar"] = false;
                dr["Texto1"] = "";
                dr["Texto2"] = obj.Texto2;
                dr["Faltante"] = true;
                separados.Add(dr);
            }
            //elimino los marcados
            LimpiaComparativa();
            cDebugerExcel1.AddTable(Comparativa, "SeparaFalsosIguales");
        }
        private void LimpiaComparativa()
        {
            //elimina los registros marcados
            int n = Comparativa.Rows.Count;
            for(int i=n-1;i>0;i--)
            {
                DataRow dr = Comparativa.Rows[i];
                if(bool.Parse(dr["Eliminar"].ToString())==true)
                {
                    Comparativa.Rows.Remove(dr);
                }
            }
        }
        private void QuitaFalsosAgregados()
        {
            //me traigo todos los que se agregan del lado izquierdo que tenga repetida del lado derecho
            var Eli = (from a in Comparativa
                     where a.NLinea1 == -1 && a.NLinea2 != -1
                     from b in Comparativa
                     where b.NLinea2 == a.NLinea2 && b.NLinea1 != a.NLinea1
                     select a).Distinct();
            // lo mismo pro al revez
            var Eld = (from a in Comparativa
                       where a.NLinea1 != -1 && a.NLinea2 == -1
                       from b in Comparativa
                       where b.NLinea2 != a.NLinea2 && b.NLinea1 == a.NLinea1
                       select a).Distinct();
            //ahora los marco para ser eliminados
            foreach (var obj in Eli)
            {
                obj.Eliminar = true;
                obj.AcceptChanges();
            }
            foreach (var obj in Eld)
            {
                obj.Eliminar = true;
                obj.AcceptChanges();
            }
            LimpiaComparativa();
        }
        private void BKComprador_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //busco todos los que son iguales
            BuscaIguales();
            //return;
            cDebugerExcel1.AddTable(Comparativa, "BuscaIguales");
            //separa falsos positivos
            SeparaFalsosIguales();
            //ahora los que tiene diferencias
            BuscaDiferencias();
            //ahora junto los datos
           // EmpataDatos();
            //cDebugerExcel1.AddTable(Comparativa, "EmpataDatos");

            //vuelvo separar falsos iguales
            SeparaFalsosIguales();
            cDebugerExcel1.AddTable(Comparativa, "SeparaFalsosIguales");
            //ahora inserto los faltantes que no tuvieron forma de machear
            InsertaFaltantes();
            cDebugerExcel1.AddTable(Comparativa, "InsertaFaltantes");
            // vuelvo a separar falsos
            QuitaFalsosAgregados();
            cDebugerExcel1.AddTable(Comparativa, "QuitaFalsosAgregados");
            //ahora ordeno los registros
            OrdenaRegistros();
            cDebugerExcel1.AddTable(Comparativa, "OrdenaRegistros");
            //preparo el resultado
            PreparaResultado();
            cDebugerExcel1.AddTable(Comparativa, "PreparaResultado");
            cDebugerExcel1.Exportar();
        }
        private void BKComprador_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (OnComparacionTerminada != null)
                OnComparacionTerminada(ListaDiferencias);
        }
    }
}

namespace SQLDeveloper.Modulos.Comparador
{


    partial class TextComparator2
    {
    }
}
