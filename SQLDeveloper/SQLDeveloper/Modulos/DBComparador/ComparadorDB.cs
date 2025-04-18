﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;

namespace SQLDeveloper.Modulos.DBComparador
{
    public delegate void OnComparadorDBEvent(string opcion1, string opcion2, String Codigo1, String Codigo2);
    public delegate void OnComparadorDBVerCodigoEvent(MotorDB.IMotorDB motor, string nombre, string codigo);
    public partial class ComparadorDB : Form
    {
        #region variables
        private MotorDB.IMotorDB ConexionDerecha;
        MotorDB.CTipoBusqueda TipoBusqueda;
        List<MotorDB.CObjeto> ListaIzquierda;
        List<MotorDB.CObjeto> ListaDerecha;
        List<MotorDB.CObjeto> NuevosIzquierdos;
        List<MotorDB.CObjeto> NuevosDerechos;
        List<MotorDB.CObjeto> Iguales;
        DataTable Tabla;
        DataTable TablaOrg;
        EnumVer Ver;
        private bool Comparando;
        public event OnComparadorDBEvent OnCompararCodigo;
        public event OnComparadorDBVerCodigoEvent OnVerCodigoObjeto;
        #endregion
        #region Inicializaciones
        public ComparadorDB()
        {
            Comparando = false;
            InitializeComponent();
            CargaVer();
            ComboGrupo2.Tag = ComboConexion2;
            ComboVer.SelectedIndex = 0;
            CargaTipos();
            CargaGrupos();
            DBProvider.DB.SuscribeErrorMessageEvent(ErrorQuery);
        }
        private void CargaVer()
        {
            ComboVer.Items.Clear();
            ComboVer.Items.Add(EnumVer.TODOS);
            ComboVer.Items.Add(EnumVer.NUEVOS);
            ComboVer.Items.Add(EnumVer.DIFERENCIAS);
        }
        private void CargaTipos()
        {
            ComboTipo.Items.Clear();
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Todos", MotorDB.EnumTipoObjeto.NONE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Tablas", MotorDB.EnumTipoObjeto.TABLE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Type Table", MotorDB.EnumTipoObjeto.TYPE_TABLE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Vistas", MotorDB.EnumTipoObjeto.VIEW));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Procediientos almacenados", MotorDB.EnumTipoObjeto.PROCEDURE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Funciones", MotorDB.EnumTipoObjeto.FUNCION));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Trigers", MotorDB.EnumTipoObjeto.TRIGER));
            ComboTipo.SelectedIndex = 0;

        }
        private void CargaGrupos()
        {
            List<string> l = ManagerConnect.ControladorConexiones.GetGrupos();
            ComboGrupo2.Items.Clear();
            foreach (string s in l)
            {
                ComboGrupo2.Items.Add(s);
            }
        }
        #endregion
        #region Seleccion de propiedades
        private void ComboGrupo_IndexCahnge(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox combo = (System.Windows.Forms.ComboBox)sender;
            if (combo.SelectedIndex == -1)
                return;
            System.Windows.Forms.ComboBox ComboConexion = (System.Windows.Forms.ComboBox)combo.Tag;
            List<ManagerConnect.CConexion> l = ManagerConnect.ControladorConexiones.GetConexiones(combo.SelectedItem.ToString());
            ComboConexion.Items.Clear();
            foreach (ManagerConnect.CConexion obj in l)
            {
                ComboConexion.Items.Add(obj);
            }

        }
        private void ComboConexion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagerConnect.CConexion obj = (ManagerConnect.CConexion)ComboConexion2.SelectedItem;
            MotorDB.EnumMotoresDB tipoDB = ManagerConnect.ControladorConexiones.DameTipoMotor(obj.MotorDB);
            ConexionDerecha = MotorDB.CProviderDataBase.DameMotor(tipoDB);
            ConexionDerecha.SetConnectionString(obj.ConecctionString);
            ConexionDerecha.SuscribeErrorMessageEvent(ErrorQuery);
        }
        private void ErrorQuery(IMotorDB motor, string msg)
        {
            MessageBox.Show(this,msg,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ComboTipo_VisibleChanged(object sender, EventArgs e)
        {
            TipoBusqueda = (MotorDB.CTipoBusqueda)ComboTipo.SelectedItem;
        }

        private void ComboVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ver = (EnumVer)ComboVer.SelectedItem;
            FiltraDatos();
        }
        #endregion
        #region Propiedades
        private bool PuedoComparar
        {
            get
            {
                if (ComboGrupo2.SelectedIndex == -1)
                    return false;
                if (ComboConexion2.SelectedIndex == -1)
                    return false;
                if (ComboTipo.SelectedIndex == -1)
                    return false;
                if (ComboVer.SelectedIndex == -1)
                    return false;
                return true;
            }
        }
        private bool GeneralEnable
        {
            set
            {
                ComboGrupo2.Enabled = value;
                ComboConexion2.Enabled = value;
                ComboTipo.Enabled = value;
                ComboVer.Enabled = value;
                BComparar.Enabled = value;
            }
        }
        private string Status
        {
            set
            {
                TStatus.Text = value;
            }
        }
        #endregion
        #region Eventos
        private void BComparar_Click(object sender, EventArgs e)
        {
            //marco la comparacion
            dataSet1.Clear();
            Comparando = true;
            // y desactivo controles
            GeneralEnable = false;
            //inicializo componenetes
            Status = "Iniciando comparacion";
            Progreso.Value = 0;
            TipoBusqueda = (MotorDB.CTipoBusqueda)ComboTipo.SelectedItem;

            //inicio el proceso de comparacion
            BKComparar.RunWorkerAsync();
        }
        private void TimerEnable_Tick(object sender, EventArgs e)
        {
            //si esta comparando no hago nada
            if (Comparando)
                return;
            BComparar.Enabled = PuedoComparar;
        }
        #endregion
        #region proceso de comparacion
        private void ReportaProgreso(int maximo, int valor, string mensaje)
        {
            BKComparar.ReportProgress(valor, new Cprogreso(maximo, valor, mensaje));
        }
        private string DameCodigo(MotorDB.IMotorDB motor, MotorDB.CObjeto obj)
        {
            string codigo = "";
            switch (obj.Tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    codigo = motor.DameCodigoFuncction(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    codigo = motor.DameCodigoStoreProcedure(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    codigo = motor.DameCodigoTabla(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    codigo = motor.DameCodigoTrigger(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    codigo = motor.DameCodigoTypeTable(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    codigo = motor.DameCodigoVista(obj.Nombre);
                    break;
            }
            return codigo;
        }
        private void AgregaRegistroTabla(string Izquierdo, string Derecho, string TipoDiferencia, string CodigoIzquierdo, string CodigoDerecho)
        {
            DataRow dr = Tabla.NewRow();
            dr["Izquierdo"] = Izquierdo;
            dr["Derecho"] = Derecho;
            dr["TipoDiferencia"] = TipoDiferencia;
            dr["CodigoIzquierdo"] = CodigoIzquierdo;
            dr["CodigoDerecho"] = CodigoDerecho;
            Tabla.Rows.Add(dr);
        }
        private void AgregaIguales(MotorDB.CObjeto obj)
        {
            foreach (MotorDB.CObjeto objd in Iguales)
            {
                if (obj.Nombre.ToUpper().Trim() == objd.Nombre.ToUpper().Trim())
                {
                    return;
                }
            }
            string codi = DameCodigo(DBProvider.DB, obj);
            string codd = DameCodigo(ConexionDerecha, obj);
            if (codd.ToUpper().Trim() != codi.ToUpper().Trim())
            {
                AgregaRegistroTabla(obj.Nombre, obj.Nombre, "D", codi, codd);
            }
            Iguales.Add(obj);
        }
        private void AgregaIzquierdo(MotorDB.CObjeto nobj)
        {
            foreach (MotorDB.CObjeto obj in NuevosIzquierdos)
            {
                if (obj.Nombre.ToUpper().Trim() == nobj.Nombre.ToUpper().Trim())
                {
                    return;
                }
            }
            string codi = DameCodigo(DBProvider.DB, nobj);
            AgregaRegistroTabla(nobj.Nombre, "", "L", codi, "");
            NuevosIzquierdos.Add(nobj);
        }
        private void AgregaDerecho(MotorDB.CObjeto nobj)
        {
            foreach (MotorDB.CObjeto obj in NuevosDerechos)
            {
                if (obj.Nombre.ToUpper().Trim() == nobj.Nombre.ToUpper().Trim())
                {
                    return;
                }
            }
            string codi = DameCodigo(ConexionDerecha, nobj);
            AgregaRegistroTabla("", nobj.Nombre, "R", "", codi);
            NuevosDerechos.Add(nobj);
        }
        private void BKComparar_DoWork(object sender, DoWorkEventArgs e)
        {
            //me traigo el motor de base de datos
            //me traigo los objetos de las bases de datos a comparar
            ListaIzquierda = DBProvider.DB.Buscar("", TipoBusqueda.Tipo);
            ListaDerecha = ConexionDerecha.Buscar("", TipoBusqueda.Tipo);
            NuevosIzquierdos = new List<MotorDB.CObjeto>();
            NuevosDerechos = new List<MotorDB.CObjeto>();
            Iguales = new List<MotorDB.CObjeto>();
            Tabla = dataSet1.Tables["Resultado"];
            #region busco todos los que estan en base izquierda que no estan en baswe de recha
            int pos = 0;
            int maximo = ListaIzquierda.Count() + ListaDerecha.Count();
            foreach (MotorDB.CObjeto obji in ListaIzquierda)
            {
                ReportaProgreso(maximo, pos, obji.Nombre);
                pos++;
                bool encontrado = false;
                foreach (MotorDB.CObjeto objd in ListaDerecha)
                {
                    if (obji.Nombre.ToUpper().Trim() == objd.Nombre.ToUpper().Trim())
                    {
                        encontrado = true;
                        AgregaIguales(objd);
                        break;
                    }
                }
                if (encontrado == false)
                {
                    AgregaIzquierdo(obji);
                }
            }
            #endregion
            #region busco todos los que estan en base derecha que no estan en baswe de izquierda
            foreach (MotorDB.CObjeto objd in ListaDerecha)
            {
                ReportaProgreso(maximo, pos, objd.Nombre);
                pos++;
                bool encontrado = false;
                foreach (MotorDB.CObjeto obji in ListaIzquierda)
                {
                    if (obji.Nombre.ToUpper().Trim() == objd.Nombre.ToUpper().Trim())
                    {
                        encontrado = true;
                        AgregaIguales(objd);
                        break;
                    }
                }
                if (encontrado == false)
                {
                    AgregaDerecho(objd);
                }
            }
            #endregion
        }
        #endregion

        private void BKComparar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Cprogreso obj = (Cprogreso)e.UserState;
                Progreso.Maximum = obj.Maximo;
                Progreso.Value = obj.Valor;
                Status = obj.Mensaje;
            }
            catch (System.Exception ex)
            {
                return;
            }

        }

        private void BKComparar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progreso.Value = 0;
            Status = Tabla.Rows.Count+" Objetos encontrados";
            Comparando = false;
            GeneralEnable = true;
            TablaOrg = Tabla.Copy();
            ComboVer_SelectedIndexChanged(null, null);
        }
        private void FiltraDatos()
        {
            if (Tabla == null)
                return;
            DataRow[] ldr;
            DataTable dt=dataSet1.Tables["Resultado"];
            dt.Rows.Clear();
            switch (Ver)
            {
                case EnumVer.TODOS:
                    foreach (DataRow dr2 in TablaOrg.Copy().Rows)
                    {
                        DataRow dr = dt.NewRow();
                        for (int c = 0; c < dt.Columns.Count;c++ )
                        {
                            dr[c] = dr2[c];
                        }
                        dt.Rows.Add(dr);
                    }
                    break;
                case EnumVer.NUEVOS:
                    ldr = TablaOrg.Select("TipoDiferencia<>'D'");
                    foreach(DataRow dr2 in ldr)
                    {
                        DataRow dr = dt.NewRow();
                        for (int c = 0; c < dt.Columns.Count;c++ )
                        {
                            dr[c] = dr2[c];
                        }
                        dt.Rows.Add(dr);
                    }
                    break;
                case EnumVer.DIFERENCIAS:
                    ldr = TablaOrg.Select("TipoDiferencia='D'");
                    foreach(DataRow dr2 in ldr)
                    {
                        DataRow dr = dt.NewRow();
                        for (int c = 0; c < dt.Columns.Count;c++ )
                        {
                            dr[c] = dr2[c];
                        }
                        dt.Rows.Add(dr);
                    }
                    break;
            }
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            VerComparacion(Tabla.Rows[e.RowIndex]);
        }
        private void VerComparacion(DataRow dr)
        {
            if (dr["TipoDiferencia"].ToString() == "D")
            {
                //es diferencia
                if (OnCompararCodigo != null)
                {
                    ManagerConnect.CPropiedadesMotor propiedades = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(DBProvider.DB);

                    OnCompararCodigo(propiedades.Grupo + "->" + propiedades.Conexion, ComboGrupo2.Text + "->" + ComboConexion2.Text, dr["CodigoIzquierdo"].ToString(), dr["CodigoDerecho"].ToString());
                }
            }
            else
            {
                if (dr["TipoDiferencia"].ToString() == "L")
                {
                    //solo izquerdo
                    if (OnVerCodigoObjeto != null)
                        OnVerCodigoObjeto(DBProvider.DB, dr["Izquierdo"].ToString(), dr["CodigoIzquierdo"].ToString());
                }
                else
                {
                    //solo derecho
                    if (OnVerCodigoObjeto != null)
                        OnVerCodigoObjeto(ConexionDerecha, dr["Derecho"].ToString(), dr["CodigoDerecho"].ToString());
                }
            }

        }
        private void verIzquierdo(DataRow dr)
        {
            if (OnVerCodigoObjeto != null)
                OnVerCodigoObjeto(DBProvider.DB, dr["Izquierdo"].ToString(), dr["CodigoIzquierdo"].ToString());

        }
        private void abrirIzquierdoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            verIzquierdo(Tabla.Rows[dataGridView1.CurrentRow.Index]);

        }
        private void verComparacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            VerComparacion(Tabla.Rows[dataGridView1.CurrentRow.Index]);

        }
        private void verDerecho(DataRow dr)
        {
            if (OnVerCodigoObjeto != null)
                OnVerCodigoObjeto(ConexionDerecha, dr["Derecho"].ToString(), dr["CodigoDerecho"].ToString());

        }

        private void abrirDerechoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            verDerecho(Tabla.Rows[dataGridView1.CurrentRow.Index]);

        }

        private void marcarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ver todo
            if (dataGridView1.CurrentRow == null)
                return;
            verDerecho(Tabla.Rows[dataGridView1.CurrentRow.Index]);
            verIzquierdo(Tabla.Rows[dataGridView1.CurrentRow.Index]);
            VerComparacion(Tabla.Rows[dataGridView1.CurrentRow.Index]);
        }

        private void marcarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.YellowGreen;

        }


        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            dataGridView1.ClearSelection();
            dataGridView1.Rows[e.RowIndex].Selected = true;
            dataGridView1.CurrentCell= dataGridView1.Rows[e.RowIndex].Cells[0];


        }
        private string dameDropQuery(CObjeto obj)
        {
            string dropquery = "";
            switch (obj.Tipo)
            {
                case EnumTipoObjeto.FUNCION:
                    dropquery = "drop function " + obj.Nombre;
                    break;
                case EnumTipoObjeto.PROCEDURE:
                    dropquery = "drop procedure " + obj.Nombre;
                    break;
                case EnumTipoObjeto.TABLE:
                    dropquery = "drop table " + obj.Nombre;
                    break;
                case EnumTipoObjeto.TRIGER:
                    dropquery = "drop triger " + obj.Nombre;
                    break;
            }
            return dropquery;
        }
        private void pasarDeIzquierdaADerechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            DataRow dr = Tabla.Rows[dataGridView1.CurrentRow.Index];
            string izquierdo = dr["Izquierdo"].ToString();
            string codigoIzquierdo = dr["CodigoIzquierdo"].ToString();
            string dropquery = "";
            bool encontrado = false;
            //me raigo el objeto
            List<CObjeto> l= DBProvider.DB.Buscar(izquierdo);
            foreach (CObjeto obj in l)
            {
                if(obj.Nombre==izquierdo)
                {
                    encontrado = true;
                    //me salgo del bucle
                    dropquery = dameDropQuery(obj);
                    break;
                }
            }
            if(encontrado==false)//dropquery == "" && encontrado)
            {
                MessageBox.Show("Operacion no soportada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //corro el drop
                if (dropquery != "")
                {
                    //busco el objeto en el destino
                    List<CObjeto> l3 = ConexionDerecha.Buscar(izquierdo);
                    foreach (CObjeto obj in l3)
                    {
                        if (obj.Nombre == izquierdo)
                        {
                            ConexionDerecha.EjecutaQuery(dropquery);
                            break;
                        }
                    }

                    
                }
                //ejecuto el codigo
                ConexionDerecha.EjecutaQuery(codigoIzquierdo);
                //me traigo el codigo de la derecha
                List<CObjeto> l2=ConexionDerecha.Buscar(izquierdo);
                foreach (CObjeto obj in l2)
                {
                    if (obj.Nombre == izquierdo)
                    {
                        string codigo = DameCodigo(ConexionDerecha,obj);
                        if (OnVerCodigoObjeto != null)
                            OnVerCodigoObjeto(ConexionDerecha, obj.Nombre, codigo);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        private void pasarDeDerechaAIzquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            DataRow dr = Tabla.Rows[dataGridView1.CurrentRow.Index];
            string Derecho = dr["Derecho"].ToString();
            string CodigoDerecho = dr["CodigoDerecho"].ToString();
            string dropquery = "";
            bool encontrado = false;
            //me raigo el objeto
            List<CObjeto> l = ConexionDerecha.Buscar(Derecho);
            foreach (CObjeto obj in l)
            {
                if (obj.Nombre == Derecho)
                {
                    encontrado = true;
                    //me salgo del bucle
                    dropquery = dameDropQuery(obj);
                    break;
                }
            }
            if (dropquery == "" && encontrado)
            {
                MessageBox.Show("Operacion no soportada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //corro el drop
                if(dropquery!="")
                    DBProvider.DB.EjecutaQuery(dropquery);
                //ejecuto el codigo
                DBProvider.DB.EjecutaQuery(CodigoDerecho);
                //me traigo el codigo de la izquierda
                List<CObjeto> l2 = DBProvider.DB.Buscar(Derecho);
                foreach (CObjeto obj in l2)
                {
                    if (obj.Nombre == Derecho)
                    {
                        string codigo = DameCodigo(DBProvider.DB, obj);
                        if (OnVerCodigoObjeto != null)
                            OnVerCodigoObjeto(DBProvider.DB, obj.Nombre, codigo);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

        }
    }
}