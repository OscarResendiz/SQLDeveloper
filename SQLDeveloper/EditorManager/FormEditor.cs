using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorManager
{
    public delegate bool OnPuedoCerrarEvent();
    public partial class FormEditor : FormBase
    {
        private bool Guardando;
        int Pi, Pf;
        Point PuntoAnterior;
        bool Moviendo;
        private bool cerrando;
        public event OnCerrarEvent OnCerrar;
        public event OnPuedoCerrarEvent OnPuedoCerrar;
        public event OnPuedoCerrarEvent onNuevo;
        public FormEditor()
        {
            cerrando = false;
            InitializeComponent();
            Guardando = false;
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            CierraPestaña(tabControl1.SelectedIndex);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            Text = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
        }

        public override void Guardar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            EditorGenerico obj = (EditorGenerico)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.Guardar();

        }
        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrando == true)
            {
                return;
            }
            if (tabControl1.TabPages.Count > 0)
            {
                //cancelo el cerrar la ventana y solo cierro la pestaña actual
                e.Cancel = true;
                TimerCerrar.Enabled = true;
                return;
            }
            if (OnCerrar != null)
                OnCerrar();
        }
        public void Cierra()
        {
            cerrando = true;
            Close();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pi = i;
                    PuntoAnterior = e.Location;
                    Moviendo = true;
                    return;
                }
            }
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moviendo == false)
                return;
            int Direccion;//-1=derecha a izquierda 1=izquieda a derecha
            //calculo la direccion del movimiento
            if (e.Location.X > PuntoAnterior.X)
            {
                //va de izquierda a derecha
                Direccion = 1;
            }
            else
            {
                Direccion = -1;
            }
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pf = i;
                    if (Pi == Pf)
                    {
                        return;
                    }
                    if (Pi < Pf)
                    {
                        //mi posicion es menor que la del raton
                        if (Direccion == -1)
                        {
                            //voy moviendome hacia abajo
                            //no hago nada
                            return;
                        }
                    }
                    else
                    {
                        //mi posicion es mayor
                        if (Direccion == 1)
                        {
                            //voy moviendome hacia arriba
                            //no hago nada
                            return;
                        }
                    }
                    TabPage p = tabControl1.TabPages[Pi];
                    TabPage p2 = new TabPage();
                    int j, k;
                    k = p.Controls.Count;
                    for (i = k - 1; i >= 0; i--)
                    {
                        p2.Controls.Add(p.Controls[0]);
                    }
                    p2.BackColor = p.BackColor;
                    p2.Text = p.Text;
                    if (Direccion == 1)
                    {
                        //hay que agregarlo mas una
                        tabControl1.TabPages.Insert(Pf + 1, p2);
                    }
                    else
                    {
                        tabControl1.TabPages.Insert(Pf, p2);
                    }
                    tabControl1.TabPages.Remove(p);
                    tabControl1.SelectedIndex = Pf;
                    Pi = Pf;
                    Moviendo = true;
                    return;
                }
            }
        }

        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pf = i;
                    if (Pi == Pf)
                    {
                        Moviendo = false;
                        return;
                    }
                    TabPage p = tabControl1.TabPages[Pi];
                    tabControl1.TabPages.RemoveAt(Pi);
                    tabControl1.TabPages.Insert(Pf, p);
                    tabControl1.SelectedIndex = Pf;
                    Pi = -1;
                    Pf = -1;
                    Moviendo = false;
                    return;
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OnPuedoCerrar != null)
            {
                if (OnPuedoCerrar() == false)
                {
                    return;
                }
            }
            CierraPestaña(tabControl1.SelectedIndex);
        }
        public void CanecaCerrarPestañas()
        {
            TimerCerrar.Enabled = false;
        }
        public bool CierraPestañas()
        {
            while (tabControl1.TabPages.Count > 0)
            {
                if (CierraPestaña(0) == false)
                    return false;
            }
            return true;
        }
        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SetFocus();
        }

        public void SetFocus()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            try
            {
                EditorGenerico obj = (EditorGenerico)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
                obj.SetFocus();
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        private void tabControl1_MouseDown_1(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pi = i;
                    PuntoAnterior = e.Location;
                    Moviendo = true;
                    return;
                }
            }

        }

        private void tabControl1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (Moviendo == false)
                return;
            int Direccion;//-1=derecha a izquierda 1=izquieda a derecha
            //calculo la direccion del movimiento
            if (e.Location.X > PuntoAnterior.X)
            {
                //va de izquierda a derecha
                Direccion = 1;
            }
            else
            {
                Direccion = -1;
            }
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pf = i;
                    if (Pi == Pf)
                    {
                        return;
                    }
                    if (Pi < Pf)
                    {
                        //mi posicion es menor que la del raton
                        if (Direccion == -1)
                        {
                            //voy moviendome hacia abajo
                            //no hago nada
                            return;
                        }
                    }
                    else
                    {
                        //mi posicion es mayor
                        if (Direccion == 1)
                        {
                            //voy moviendome hacia arriba
                            //no hago nada
                            return;
                        }
                    }
                    TabPage p = tabControl1.TabPages[Pi];
                    TabPage p2 = new TabPage();
                    int j, k;
                    k = p.Controls.Count;
                    for (i = k - 1; i >= 0; i--)
                    {
                        p2.Controls.Add(p.Controls[0]);
                    }
                    p2.BackColor = p.BackColor;
                    p2.Text = p.Text;
                    p2.Tag = p.Tag;
                    if (Direccion == 1)
                    {
                        //hay que agregarlo mas una
                        tabControl1.TabPages.Insert(Pf + 1, p2);
                    }
                    else
                    {
                        tabControl1.TabPages.Insert(Pf, p2);
                    }
                    tabControl1.TabPages.Remove(p);
                    tabControl1.SelectedIndex = Pf;
                    Pi = Pf;
                    Moviendo = true;
                    return;
                }
            }

        }

        private void tabControl1_MouseUp_1(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pf = i;
                    if (Pi == Pf)
                    {
                        Moviendo = false;
                        return;
                    }
                    TabPage p = tabControl1.TabPages[Pi];
                    tabControl1.TabPages.RemoveAt(Pi);
                    tabControl1.TabPages.Insert(Pf, p);
                    tabControl1.SelectedIndex = Pf;
                    Pi = -1;
                    Pf = -1;
                    Moviendo = false;
                    return;
                }
            }
        }
        public void AgregaEditor(EditorGenerico obj, string nombre)
        {
            //primero veo si ya existe el editor
            foreach(TabPage c in tabControl1.TabPages)
            {
                if(c.Tag.GetType()==obj.GetType())
                {
                    if(c.Tag==obj)
                    {
                        tabControl1.SelectedTab = c;
                        return;
                    }
                }
            }
            tabControl1.TabPages.Insert(0, nombre);

            obj.Parent = tabControl1.TabPages[0];
            tabControl1.TabPages[0].Tag = obj;
            obj.Dock = DockStyle.Fill;
            obj.Show();
            tabControl1.SelectedIndex = 0;

        }

        private void cerrarTodasLasPestañasExceptoEstaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == -1)
                return;
            //me traigo la pagina que no se va a cerrar
            TabPage c = tabControl1.TabPages[tabControl1.SelectedIndex];
            while(tabControl1.TabPages.Count>1) //solo debe quedar abierta una
            {
                //checo si puedo cerrar la pagina cero
                if(tabControl1.TabPages[0]!=c)
                {
                    CierraPestaña(0);
                }
                else
                {
                    CierraPestaña(1);
                }
            }
        }

        public Dictionary<int, EditorGenerico> GetTabs()
        {
            Dictionary<int,EditorGenerico> l=new Dictionary<int,EditorGenerico>();
            for(int i=0;i<tabControl1.TabPages.Count;i++)
            {
                EditorGenerico obj=(EditorGenerico)tabControl1.TabPages[i].Tag;
                l.Add(i, obj);
            }
            return l;
        }

        private void cerrarTodasLasPestañasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CierraPestañas();
        }

        private bool CierraPestaña(int index)
        {
            //tabControl1.SelectedIndex 
            if (index == -1)
                index = 0;
            EditorGenerico obj = null;
            try
            {
                obj = (EditorGenerico)tabControl1.TabPages[index].Tag;
            }
            catch (System.Exception)
            {
                //no es un texto
                tabControl1.TabPages.RemoveAt(index);
                TimerCerrar.Enabled = false;
                Guardando = false;
                return true;
            }
            if (obj != null)
            {
                if (obj.Guardado == false)
                {
                    if (Guardando == true)
                        return true;
                    Guardando = true;
                    System.Windows.Forms.DialogResult dr = MessageBox.Show("¿Desea guardar los cambios hechos al archivo: " + tabControl1.TabPages[index].Text + "?", "Cerrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            obj.Guardar();
                            break;
                        case DialogResult.Cancel:
                            TimerCerrar.Enabled = false;
                            Guardando = false;
                            return false;
                    }
                }
            }
            tabControl1.TabPages.RemoveAt(index);
            TimerCerrar.Enabled = false;
            Guardando = false;
            return true;
        }
    }
}