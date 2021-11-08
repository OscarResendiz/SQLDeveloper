using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Modelador.Dibujable
{
    public class DForeKey: DRectangulo
    {
        public event BuscaTablaDelegate OnBuscaTabla;
        private Pen PenFk;
        private string Nombre;
        private DTablaCapa Padre;
        private DTablaCapa Hijo;
        Point PuntoPadre ;
        Point PuntoHijo ;
        Point Pllave ;
        Point PContraLLave;

        static Bitmap llaveIzquierda;
        static Bitmap llaveDerecha;
        static Bitmap llaveArriba;
        static Bitmap llaveAbajo;
        private Brush brush;

        public DTablaCapa Tabla
        {
            get;
            set;
        }
        public int ID_FK
        {
            get;
            set;
        }
        private Modelo.CLlaveForanea LlaveForanea;
        public DForeKey()
        {
            PuntoPadre = new Point();
            PuntoHijo = new Point();
            Pllave = new Point();
            PContraLLave = new Point();
            if (llaveIzquierda == null)
                llaveIzquierda = new Bitmap(ImageManager.getImagen("llaveIzquierda"));
            if(llaveDerecha==null)
                llaveDerecha = new Bitmap(ImageManager.getImagen("llaveDerecha"));
            if (llaveArriba==null)
                llaveArriba = new Bitmap(ImageManager.getImagen("llaveArriba"));
            if (llaveAbajo==null)
                llaveAbajo = new Bitmap(ImageManager.getImagen("llaveAbajo"));
        }
        public Modelo.CLlaveForanea getFk()
        {
            if(LlaveForanea==null)
                LlaveForanea= Modelo.Get_LlaveForanea(ID_FK);
            return LlaveForanea;
        }
        protected override void ModeloAsignado()
        {
            base.ModeloAsignado();
            LlaveForanea = Modelo.Get_LlaveForanea(ID_FK);
            PenFk = new Pen(new SolidBrush(LlaveForanea.LineColor), 4);
            Nombre = LlaveForanea.Nombre;
            Modelo.OnLlaveForaneaUpdate += new Modelo.DelegateModeloDatosEvent(LlaveForaneaUpdate);
            brush = new SolidBrush(LlaveForanea.LineColor);
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnLlaveForaneaUpdate -= LlaveForaneaUpdate;
        }
        private void LlaveForaneaUpdate(Modelo.ModeloDatos modelo, int id_fk)
        {
            if(ID_FK==id_fk)
                LlaveForanea = Modelo.Get_LlaveForanea(ID_FK);

        }
        public override void Dibuja(MiGraphics graphics)
        {
            if (LlaveForanea == null)
                return;
            Color color = LlaveForanea.LineColor;
            if (LlaveForanea.Nombre == "bitacorausuario_ibfk_1")
                color = Color.Red;
            #region Obtencion de las tablas padre e hijo
            //busco la tabla padre dentro del modelo dibujado
            bool dir1 = true;
            bool dir2 = true;

            if (OnBuscaTabla == null)
                return; //como no encontre el padre, no hay nececidad de mostrar la liga
            //if(Padre==null)
                Padre = OnBuscaTabla(Tabla.ID_Capa, LlaveForanea.ID_TablaPadre);
            //if(Hijo==null)
                Hijo = OnBuscaTabla(Tabla.ID_Capa, LlaveForanea.ID_TablaHija);
            if (Padre == null || Hijo == null)
                return; //tampoco tiene caso que siga
            if (Padre.IsVisible() == false || Hijo.IsVisible() == false)
                return;
            #endregion
            #region Calaculo de las posiciones de las tablas y sus centros
            //me trago la posicion real del padre y del hijo
            Point posicionPadre = Padre.DamePosicionReal();
            Point posicionHijo = Hijo.DamePosicionReal();
            //calculo el centro de cada tabla
            Point CentroHijo = new Point(posicionHijo.X + Hijo.Dimencion.Width / 2, posicionHijo.Y + Hijo.Dimencion.Height / 2);
            Point CentroPadre = new Point(posicionPadre.X + Padre.Dimencion.Width / 2, posicionPadre.Y + Padre.Dimencion.Height / 2);
            #endregion
            if (PenFk == null)
                PenFk = new Pen(new SolidBrush(color), 4);
            #region Calculo el anguno de la linea
            double angulo = 0;
            if (CentroPadre.X != CentroHijo.X)
                angulo = Math.Atan((double)Math.Abs(CentroPadre.Y - CentroHijo.Y) / (double)Math.Abs(CentroPadre.X - CentroHijo.X));
            int posy = (int)(Math.Tan(angulo) * Padre.Dimencion.Width / 2);
            #endregion
            #region defino el punto de donde se va a dibujar la linea en el eje X del padre y el hijo
            if (CentroPadre.X < CentroHijo.X)
            {
                PuntoPadre.X = posicionPadre.X + Padre.Dimencion.Width;
                PuntoHijo.X = posicionHijo.X;
            }
            else
            {
                PuntoPadre.X = posicionPadre.X;
                PuntoHijo.X = posicionHijo.X + Hijo.Dimencion.Width;
            }

            if (CentroPadre.Y < CentroHijo.Y)
            {
                PuntoPadre.Y = CentroPadre.Y + posy;
                PuntoHijo.Y = CentroHijo.Y - posy;
            }
            else
            {
                PuntoPadre.Y = CentroPadre.Y - posy;
                PuntoHijo.Y = CentroHijo.Y + posy;
            }
            #endregion
            #region Defino los puntos donde se van a dibujar la linea desde el eje Y del padre y el hijo
            if (PuntoPadre.Y > posicionPadre.Y + Padre.Dimencion.Height || PuntoPadre.Y < posicionPadre.Y)
            {
                dir1 = false;
                angulo = 90;
                if (CentroPadre.X != CentroHijo.X)
                    angulo = Math.Atan((double)Math.Abs(CentroPadre.X - CentroHijo.X) / (double)Math.Abs(CentroPadre.Y - CentroHijo.Y));
                posy = (int)(Math.Tan(angulo) * Padre.Dimencion.Height / 2);

                if (CentroPadre.Y < CentroHijo.Y)
                {
                    PuntoPadre.Y = posicionPadre.Y + Padre.Dimencion.Height;
                }
                else
                {
                    PuntoPadre.Y = posicionPadre.Y;
                }

                if (CentroPadre.X < CentroHijo.X)
                {
                    PuntoPadre.X = CentroPadre.X + posy;
                }
                else
                {
                    PuntoPadre.X = CentroPadre.X - posy;
                }
            }
            if (PuntoHijo.Y > posicionHijo.Y + Hijo.Dimencion.Height || PuntoHijo.Y < posicionHijo.Y)
            {
                dir2 = false;
                angulo = 90;
                if (CentroPadre.X != CentroHijo.X)
                    angulo = Math.Atan((double)Math.Abs(CentroHijo.X - CentroPadre.X) / (double)Math.Abs(CentroHijo.Y - CentroPadre.Y));
                posy = (int)(Math.Tan(angulo) * Hijo.Dimencion.Height / 2);

                if (CentroHijo.Y < CentroPadre.Y)
                {
                    PuntoHijo.Y = posicionHijo.Y + Hijo.Dimencion.Height;
                }
                else
                {
                    PuntoHijo.Y = posicionHijo.Y;
                }

                if (CentroHijo.X < CentroPadre.X)
                {
                    PuntoHijo.X = CentroHijo.X + posy;
                }
                else
                {
                    PuntoHijo.X = CentroHijo.X - posy;
                }
            }
            #endregion
            //dibuja la linea desd el punto del padre y del hijo
            Rutea(graphics, PuntoPadre, PuntoHijo, Padre.ID_Tabla, Hijo.ID_Tabla, PenFk, dir1, dir2);
            #region agrego una llave que apunte al padre
            Bitmap bmp;
            #region selecciono la imagen a utilizar dependiendo de la direccion
            if (dir1)
            {
                //es el eje X
                if (CentroPadre.X < PuntoPadre.X)
                {
                    bmp = llaveIzquierda;
                }
                else
                {
                    bmp = llaveDerecha;
                }
            }
            else
            {
                //es en el eje Y
                if (CentroPadre.Y < PuntoPadre.Y)
                    bmp = llaveArriba;
                else
                    bmp = llaveAbajo;
            }
            #endregion
            #region quito los pixeles no deseados de la imagen
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (bmp.GetPixel(i, j).R == 255 && bmp.GetPixel(i, j).G == 255 && bmp.GetPixel(i, j).B == 255)
                        bmp.SetPixel(i, j, Color.Transparent);
                }
            }
            #endregion
            if (dir1)
            {
                //es el eje X
                if (CentroPadre.X < PuntoPadre.X)
                {
                    Pllave.X = PuntoPadre.X;
                    Pllave.Y = PuntoPadre.Y - bmp.Height / 2;
                }
                else
                {
                    Pllave.X = PuntoPadre.X - bmp.Width;
                    Pllave.Y = PuntoPadre.Y - bmp.Height / 2;

                }

            }
            else
            {
                if (CentroPadre.Y < PuntoPadre.Y)
                {
                    Pllave.X = PuntoPadre.X - bmp.Width / 2;
                    Pllave.Y = PuntoPadre.Y;

                }
                else
                {
                    Pllave.X = PuntoPadre.X - bmp.Width / 2;
                    Pllave.Y = PuntoPadre.Y - bmp.Height;
                }
            }
            Posicion = Pllave;
            Dimencion = bmp.Size;
            graphics.DrawImage(bmp, Pllave.X, Pllave.Y);
            #endregion
            #region Dibuja un marcador del lado del hijo para saber que aqui va la liga
            if (dir2)
            {
                //es el eje X
                if (CentroHijo.X < PuntoHijo.X)
                {
                    PContraLLave.X = PuntoHijo.X;
                    PContraLLave.Y = PuntoHijo.Y - 5;// bmp.Height / 2;
                }
                else
                {
                    PContraLLave.X = PuntoHijo.X - 10;// bmp.Width;
                    PContraLLave.Y = PuntoHijo.Y - 5;// bmp.Height / 2;

                }

            }
            else
            {
                if (CentroHijo.Y < PuntoHijo.Y)
                {
                    PContraLLave.X = PuntoHijo.X - 5;// bmp.Width / 2;
                    PContraLLave.Y = PuntoHijo.Y;

                }
                else
                {
                    PContraLLave.X = PuntoHijo.X - 5;// bmp.Width / 2;
                    PContraLLave.Y = PuntoHijo.Y - 10;// bmp.Height;
                }
            }
            graphics.FillEllipse(brush, PContraLLave.X, PContraLLave.Y, 10, 10);
            #endregion
        }
        private Point Rutea(MiGraphics graphics, Point pi, Point pf, int id_padre, int id_hijo, Pen pen, bool dir1 = false, bool dir2 = false)
        {
            //dir X indica si la direccion es en vertical (y) u horizontal (x)
            //Point pm = new Point();
            int pmX;
            int pmY;
            if (pi.X < pf.X)
                pmX = pi.X + Math.Abs(pi.X - pf.X) / 2;
            else
                pmX = pf.X + Math.Abs(pf.X - pi.X) / 2;

            if (pi.Y < pf.Y)
                pmY = pi.Y + Math.Abs(pi.Y - pf.Y) / 2;
            else
                pmY = pf.Y + Math.Abs(pf.Y - pi.Y) / 2;
            //ahora hago el trazo desde el punto inicial al punto intermedio
            if (dir1)
            {
                //la direccion es horizontal (x)
                graphics.DrawLine(pen, pi.X, pi.Y, pmX, pi.Y);
                graphics.DrawLine(pen, pmX, pi.Y, pmX, pmY);

                if (pi.Y != pmY)
                {
                    
                    graphics.FillEllipse(brush, pmX - 5, pi.Y - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pmX - 2, pi.Y - 2, 5, 5);
                    graphics.FillEllipse(brush, pmX - 5, pmY - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pmX - 2, pmY - 2, 5, 5);
                    
                }
            }
            else
            {
                //la direccion es verticar (Y)
                graphics.DrawLine(pen, pi.X, pi.Y, pi.X, pmY);
                graphics.DrawLine(pen, pi.X, pmY, pmX, pmY);

                if (pi.X != pmX)
                {
                    
                    graphics.FillEllipse(brush, pi.X - 5, pmY - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pi.X - 2, pmY - 2, 5, 5);
                    graphics.FillEllipse(brush, pmX - 5, pmY - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pmX - 2, pmY - 2, 5, 5);
                    
                }
            }
            if (dir2)
            {
                //la direccion es horizontal (x)
                graphics.DrawLine(pen, pf.X, pf.Y, pmX, pf.Y);
                graphics.DrawLine(pen, pmX, pf.Y, pmX, pmY);

                if (pf.Y != pmY)
                {
                    
                    graphics.FillEllipse(brush, pmX - 5, pf.Y - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pmX - 2, pf.Y - 2, 5, 5);
                    graphics.FillEllipse(brush, pmX - 5, pmY - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pmX - 2, pmY - 2, 5, 5);
                    
                }
            }
            else
            {
                //la direccion es verticar (Y)
                graphics.DrawLine(pen, pf.X, pf.Y, pf.X, pmY);
                graphics.DrawLine(pen, pf.X, pmY, pmX, pmY);
                if (pf.X != pmX)
                {
                    
                    graphics.FillEllipse(brush, pf.X - 5, pmY - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pf.X - 2, pmY - 2, 5, 5);

                    graphics.FillEllipse(brush, pmX - 5, pmY - 5, 10, 10);
                    graphics.FillEllipse(new SolidBrush(Color.Black), pmX - 2, pmY - 2, 5, 5);
                    
                }
            }
            return pf;
        }
        protected override void InicializaMenu(int x, int y)
        {
            base.InicializaMenu(x, y);
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }
        private void MenuEditar_Click(object sender, EventArgs arg)
        {
            try
            {
                Modelo.CLlaveForanea fk = getFk();
                UI.FormPropiedadesFK dlg = new UI.FormPropiedadesFK();
                dlg.ID_TablaHija = fk.ID_TablaHija;
                dlg.Modelo = Modelo;
                dlg.TablaPadre = fk.Get_TablaPadre();
                dlg.SetCamposReferencia(fk.Get_Campos());
                dlg.Nombre = fk.Nombre;
                dlg.AcctionUpdate = fk.AcctionUpdate;
                dlg.AcctionDelete = fk.AcctionDelete;
                dlg.LineColor = fk.LineColor;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modelo.CTabla tablaPadre = dlg.TablaPadre;
                List<UI.CCampoProFk> l = dlg.Get_Campos();
                if (fk.Nombre != dlg.Nombre || fk.AcctionDelete != dlg.AcctionDelete || fk.AcctionUpdate != dlg.AcctionUpdate || fk.LineColor != dlg.LineColor)
                {
                    fk.Nombre = dlg.Nombre;
                    fk.AcctionUpdate = dlg.AcctionUpdate;
                    fk.AcctionDelete = dlg.AcctionDelete;
                    fk.LineColor = dlg.LineColor;
                    fk.Update();
                }
                if (fk.Get_TablaPadre().ID_Tabla != tablaPadre.ID_Tabla)
                {
                    //cambiaron de tabla
                    //hay que eliminar todos los campos
                    foreach (Modelo.CCampoReferencia campo in fk.Get_Campos())
                    {
                        campo.Delete();
                    }
                    //actualizo la relacion
                    fk.ID_TablaPadre = tablaPadre.ID_Tabla;
                    fk.Update();
                    //inserto los nuevos campos
                    foreach (UI.CCampoProFk obj in l)
                    {
                        Modelo.Insert_CampoReferencia(ID_FK, obj.ID_CampoPadre, obj.ID_CampoHijo);
                    }
                    return;
                }
                //quito los campos que se modificaron
                foreach (Modelo.CCampoReferencia campo in fk.Get_Campos())
                {
                    bool encontrado = false;
                    foreach (UI.CCampoProFk obj in l)
                    {
                        if (obj.ID_CampoHijo == campo.ID_CampoHijo && obj.ID_CampoPadre == campo.ID_CampoPadre)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == false)
                    {
                        campo.Delete();
                    }
                }
                //agrego los que faltan
                foreach (UI.CCampoProFk obj in l)
                {
                    bool encontrado = false;
                    foreach (Modelo.CCampoReferencia campo in fk.Get_Campos())
                    {
                        if (obj.ID_CampoHijo == campo.ID_CampoHijo && obj.ID_CampoPadre == campo.ID_CampoPadre)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == false)
                    {
                        Modelo.Insert_CampoReferencia(ID_FK, obj.ID_CampoPadre, obj.ID_CampoHijo);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MenuEliminar_Click(object sender, EventArgs arg)
        {
            try
            {
                if (MessageBox.Show("Eliminar la Relacion " +  Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                getFk().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override bool OnMouseIn(int x, int y)
        {
            if (x >= PContraLLave.X && x <= PContraLLave.X + 10 && y >= PContraLLave.Y && y <= PContraLLave.Y + 10)
                return true;
            return base.OnMouseIn(x, y);
        }
    }
}
