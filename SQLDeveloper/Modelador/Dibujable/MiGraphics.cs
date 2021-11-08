using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;
using System.Drawing.Imaging;
using static System.Drawing.Graphics;

namespace Modelador.Dibujable
{
    /// <summary>
    /// Clase que encapsula un elemento grafico para 
    /// </summary>
    public class MiGraphics
    {
//        CMapaCuadricula Mapa;
        private Graphics FGraphics;
        private Bitmap FBitmap;
        private int FWidth;
        private int FHeight;
        private int FHScroolValue; //indica el desplazamiento de la barra horizontal (la de abajo)
        private int FVScroolValue; //indica el desplazamiento de la barra Vertical (la de abajo)
        private int DesplazamientoH;
        private int DesplazamientoV;
        List<DTabla> tablas;
        public MiGraphics(int width, int height)
        {
            Desplazamiento = 30;
            Redimenciona(width, height);
        }
        /// <summary>
        /// regresa el mapa de bits interno
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitMap()
        {
            return FBitmap;
        }
        public int Height
        {
            get
            {
                return FHeight;
            }
        }
        public int Width
        {
            get
            {
                return FWidth;
            }
        }
        /// <summary>
        /// actualiza la dimecion del mapa de bits
        /// </summary>
        public void Redimenciona(int width, int height)
        {
            FHeight = height;
            FWidth = width;
            FBitmap = new Bitmap(FWidth, FHeight);
            FGraphics = Graphics.FromImage(FBitmap);
            FGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            FGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            FGraphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
//            if (Mapa == null)
  //              Mapa = new CMapaCuadricula(width, height);
    //        Mapa.Redimenciona(width, height);
        }
        public int HScroolValue
        {
            get
            {
                return FHScroolValue;
            }
            set
            {
                FHScroolValue = value;
                DesplazamientoH = FHScroolValue * Desplazamiento;
            }
        }
        public int Desplazamiento
        {
            get;set;
        }
        public int VScroolValue
        {
            get
            {
                return FVScroolValue;
            }
            set
            {
                FVScroolValue = value;
                DesplazamientoV = FVScroolValue * Desplazamiento;
            }
        }
        #region Funciones graficas
        //
        // Resumen:
        //     Obtiene un valor que especifica cómo se dibujan las imágenes compuestas en este
        //     System.Drawing.Graphics.
        //
        // Devuelve:
        //     Esta propiedad especifica un miembro de la enumeración System.Drawing.Drawing2D.CompositingMode.
        //     De manera predeterminada, es System.Drawing.Drawing2D.CompositingMode.SourceOver.
        public CompositingMode CompositingMode 
        { 
            get
            {
                return FGraphics.CompositingMode;
            }
            set
            {
                FGraphics.CompositingMode = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece la unidad de medida usada para las coordenadas de página
        //     en este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Uno de los valores de System.Drawing.GraphicsUnit que no sea System.Drawing.GraphicsUnit.World.
        //
        // Excepciones:
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     System.Drawing.Graphics.PageUnit se establece en System.Drawing.GraphicsUnit.World,
        //     que no es una unidad física.
        public GraphicsUnit PageUnit 
        {
            get
            {
                return FGraphics.PageUnit;
            }
            set
            {
                FGraphics.PageUnit = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece una copia de la transformación universal geométrica para
        //     System.Drawing.Graphics.
        //
        // Devuelve:
        //     Una copia de System.Drawing.Drawing2D.Matrix que representa la transformación
        //     universal geométrica para System.Drawing.Graphics.
        public Matrix Transform 
        { 
                get
            {
                return FGraphics.Transform;
            }
            set
            {
                FGraphics.Transform = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece el modo de interpolación asociado a este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Uno de los valores de System.Drawing.Drawing2D.InterpolationMode.
        public InterpolationMode InterpolationMode
        { 
            get
            {
                return FGraphics.InterpolationMode;
            }
            set
            {
                FGraphics.InterpolationMode = value;
            }
        }
        //
        // Resumen:
        //     Obtiene la resolución vertical de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     El valor, en puntos por pulgada, de la resolución vertical que admite este System.Drawing.Graphics.
        public float DpiY 
        { 
            get
            {
                return FGraphics.DpiY;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece un System.Drawing.Region que limita la región de dibujo de
        //     este System.Drawing.Graphics.
        //
        // Devuelve:
        //     System.Drawing.Region que limita la parte de este System.Drawing.Graphics que
        //     se encuentra disponible actualmente para dibujar.
        public Region Clip
        {
            get
            {
                return FGraphics.Clip;
            }
            set
            {
                FGraphics.Clip = value;
            }
        }
            //
        // Resumen:
        //     Obtiene o establece un valor que especifica cómo se calcula el desplazamiento
        //     de los píxeles durante la representación de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Esta propiedad especifica un miembro de la enumeración System.Drawing.Drawing2D.PixelOffsetMode.
        public PixelOffsetMode PixelOffsetMode 
        { 
            get
            {
                return FGraphics.PixelOffsetMode;
            }
            set
            {
                FGraphics.PixelOffsetMode = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece la relación de escala entre las unidades universales y las
        //     unidades de página de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Esta propiedad especifica un valor de relación de escala entre las unidades universales
        //     y las unidades de página de este System.Drawing.Graphics.
        public float PageScale 
        {
            get
            {
                return FGraphics.PageScale;
            }
            set
            {
                FGraphics.PageScale = value;
            }
        }
        //
        // Resumen:
        //     Obtiene una estructura System.Drawing.RectangleF que delimita la región de recorte
        //     de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Estructura System.Drawing.RectangleF que representa un rectángulo delimitador
        //     para la región de recorte de este System.Drawing.Graphics.
        public RectangleF ClipBounds 
        { 
            get
            {
                return FGraphics.ClipBounds;
            }
        }
        //
        // Resumen:
        //     Obtiene el rectángulo delimitador que corresponde a la región de recorte visible
        //     de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Estructura System.Drawing.RectangleF que representa un rectángulo delimitador
        //     para la región de recorte visible de este System.Drawing.Graphics.
        public RectangleF VisibleClipBounds 
        { 
            get
            {
                return FGraphics.VisibleClipBounds;
            }
        }
        //
        // Resumen:
        //     Obtiene un valor que indica si la región de recorte visible de este System.Drawing.Graphics
        //     está vacía.
        //
        // Devuelve:
        //     true si la parte visible de la región de recorte de este System.Drawing.Graphics
        //     está vacía; de lo contrario, false.
        public bool IsVisibleClipEmpty 
        { 
            get
            {
                return FGraphics.IsVisibleClipEmpty;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece la calidad de representación de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Uno de los valores de System.Drawing.Drawing2D.SmoothingMode.
        public SmoothingMode SmoothingMode 
        {
            get
            {
                return FGraphics.SmoothingMode;
            }
            set
            {
                FGraphics.SmoothingMode = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece el valor de corrección de gamma para la representación de
        //     texto.
        //
        // Devuelve:
        //     El valor de corrección gamma usado para representar texto con suavizado de contorno
        //     y ClearType.
        public int TextContrast
        { 
            get
            {
                return FGraphics.TextContrast;
            }
            set
            {
                FGraphics.TextContrast = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece el modo de representación para el texto asociado a este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Uno de los valores de System.Drawing.Text.TextRenderingHint.
        public TextRenderingHint TextRenderingHint 
        { 
            get
            {
                return FGraphics.TextRenderingHint;
            }
            set
            {
                FGraphics.TextRenderingHint = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece la calidad de representación de las imágenes compuestas que
        //     se dibujan en este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Esta propiedad especifica un miembro de la enumeración System.Drawing.Drawing2D.CompositingQuality.
        //     De manera predeterminada, es System.Drawing.Drawing2D.CompositingQuality.Default.
        public CompositingQuality CompositingQuality
        { 
            get
            {
                return FGraphics.CompositingQuality;
            }
            set
            {
                FGraphics.CompositingQuality = value;
            }
        }
        //
        // Resumen:
        //     Obtiene o establece el origen de representación de este System.Drawing.Graphics
        //     para la interpolación y los pinceles de trama.
        //
        // Devuelve:
        //     Una estructura System.Drawing.Point que representa el origen de interpolación
        //     de 8 bits por píxel y la interpolación de 16 bits por píxel y que también se
        //     usa para establecer el origen de los pinceles de trama.
        public Point RenderingOrigin
        { 
            get
            {
                return FGraphics.RenderingOrigin;
            }
            set
            {
                FGraphics.RenderingOrigin = value;
            }
        }
        //
        // Resumen:
        //     Obtiene un valor que indica si la región de recorte de este System.Drawing.Graphics
        //     está vacía.
        //
        // Devuelve:
        //     true si la región de recorte de este System.Drawing.Graphics está vacía; de lo
        //     contrario, false.
        public bool IsClipEmpty 
        {
            get
            {
                return FGraphics.IsClipEmpty;
            }
        }
        //
        // Resumen:
        //     Obtiene la resolución horizontal de este System.Drawing.Graphics.
        //
        // Devuelve:
        //     El valor, en puntos por pulgada, de la resolución horizontal que admite este
        //     System.Drawing.Graphics.
        public float DpiX 
        { 
            get
            {
                return FGraphics.DpiX;
            }
        }

        //
        // Resumen:
        //     Crea un nuevo System.Drawing.Graphics a partir del identificador especificado
        //     en un contexto de dispositivo.
        //
        // Parámetros:
        //   hdc:
        //     Identificador de un contexto de dispositivo.
        //
        // Devuelve:
        //     Este método devuelve un nuevo System.Drawing.Graphics para el contexto de dispositivo
        //     especificado.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Graphics FromHdc(IntPtr hdc)
        {
            return Graphics.FromHdc(hdc);
        }
        //
        // Resumen:
        //     Crea un nuevo System.Drawing.Graphics a partir del identificador especificado
        //     de un contexto de dispositivo y del identificador de un dispositivo.
        //
        // Parámetros:
        //   hdc:
        //     Identificador de un contexto de dispositivo.
        //
        //   hdevice:
        //     Identificador de un dispositivo.
        //
        // Devuelve:
        //     Este método devuelve un nuevo System.Drawing.Graphics para el contexto de dispositivo
        //     y el dispositivo especificados.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Graphics FromHdc(IntPtr hdc, IntPtr hdevice)
        {
            return Graphics.FromHdc(hdc, hdevice);
        }
        //
        // Resumen:
        //     Devuelve un System.Drawing.Graphics correspondiente al contexto de dispositivo
        //     especificado.
        //
        // Parámetros:
        //   hdc:
        //     Identificador de un contexto de dispositivo.
        //
        // Devuelve:
        //     System.Drawing.Graphics correspondiente al contexto de dispositivo especificado.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Graphics FromHdcInternal(IntPtr hdc)
        {
            return Graphics.FromHdcInternal(hdc);
        }
        //
        // Resumen:
        //     Crea un nuevo System.Drawing.Graphics a partir del identificador especificado
        //     de una ventana.
        //
        // Parámetros:
        //   hwnd:
        //     Identificador de una ventana.
        //
        // Devuelve:
        //     Este método devuelve un nuevo System.Drawing.Graphics para el identificador de
        //     ventana especificado.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Graphics FromHwnd(IntPtr hwnd)
        {
            return Graphics.FromHwnd(hwnd);
        }
        //
        // Resumen:
        //     Crea un nuevo System.Drawing.Graphics para el identificador de ventana especificado.
        //
        // Parámetros:
        //   hwnd:
        //     Identificador de una ventana.
        //
        // Devuelve:
        //     System.Drawing.Graphics para el identificador de ventana especificado.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Graphics FromHwndInternal(IntPtr hwnd)
        {
            return Graphics.FromHwndInternal(hwnd);
        }
        //
        // Resumen:
        //     Crea un nuevo System.Drawing.Graphics con la System.Drawing.Image especificada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image a partir de la cual se va a crear el nuevo System.Drawing.Graphics.
        //
        // Devuelve:
        //     Este método devuelve un nuevo objeto System.Drawing.Graphics para la System.Drawing.Image
        //     especificada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        //
        //   T:System.Exception:
        //     image tiene un formato de píxeles indizado o su formato no está definido.
        public static Graphics FromImage(Image image)
        {
            return Graphics.FromImage(image);
        }
        //
        // Resumen:
        //     Obtiene un identificador de la paleta actual de medios tonos de Windows.
        //
        // Devuelve:
        //     Puntero interno que especifica el identificador de la paleta.
        public static IntPtr GetHalftonePalette()
        {
            return Graphics.GetHalftonePalette();
        }
        //
        // Resumen:
        //     Agrega un comentario al System.Drawing.Imaging.Metafile actual.
        //
        // Parámetros:
        //   data:
        //     Matriz de bytes que contiene el comentario.
        public void AddMetafileComment(byte[] data)
        {
             FGraphics.AddMetafileComment(data);
        }
        //
        // Resumen:
        //     Guarda un contenedor de gráficos con el estado actual de este System.Drawing.Graphics
        //     y abre y usa un nuevo contenedor de gráficos con la transformación de escala
        //     especificada.
        //
        // Parámetros:
        //   dstrect:
        //     Estructura System.Drawing.RectangleF que, junto con el parámetro srcrect, especifica
        //     una transformación de escala para el nuevo contenedor de gráficos.
        //
        //   srcrect:
        //     Estructura System.Drawing.RectangleF que, junto con el parámetro dstrect, especifica
        //     una transformación de escala para el nuevo contenedor de gráficos.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida para el contenedor.
        //
        // Devuelve:
        //     Este método devuelve un System.Drawing.Drawing2D.GraphicsContainer que representa
        //     el estado de este System.Drawing.Graphics en el momento de la llamada al método.
        public GraphicsContainer BeginContainer(RectangleF dstrect, RectangleF srcrect, GraphicsUnit unit)
        {
            dstrect.X -= DesplazamientoH;
            srcrect.X -= DesplazamientoH;
            dstrect.Y -= DesplazamientoV;
            srcrect.Y -= DesplazamientoV;
            
            return FGraphics.BeginContainer(dstrect, srcrect, unit);
        }
        //
        // Resumen:
        //     Guarda un contenedor de gráficos con el estado actual de este System.Drawing.Graphics
        //     y abre y usa un nuevo contenedor de gráficos.
        //
        // Devuelve:
        //     Este método devuelve un System.Drawing.Drawing2D.GraphicsContainer que representa
        //     el estado de este System.Drawing.Graphics en el momento de la llamada al método.
        public GraphicsContainer BeginContainer()
        {
            return FGraphics.BeginContainer();
        }
        //
        // Resumen:
        //     Guarda un contenedor de gráficos con el estado actual de este System.Drawing.Graphics
        //     y abre y usa un nuevo contenedor de gráficos con la transformación de escala
        //     especificada.
        //
        // Parámetros:
        //   dstrect:
        //     Estructura System.Drawing.Rectangle que, junto con el parámetro srcrect, especifica
        //     una transformación de escala para el contenedor.
        //
        //   srcrect:
        //     Estructura System.Drawing.Rectangle que, junto con el parámetro dstrect, especifica
        //     una transformación de escala para el contenedor.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida para el contenedor.
        //
        // Devuelve:
        //     Este método devuelve un System.Drawing.Drawing2D.GraphicsContainer que representa
        //     el estado de este System.Drawing.Graphics en el momento de la llamada al método.
        public GraphicsContainer BeginContainer(Rectangle dstrect, Rectangle srcrect, GraphicsUnit unit)
        {
            dstrect.X -= DesplazamientoH;
            srcrect.X -= DesplazamientoH;
            dstrect.Y -= DesplazamientoV;
            srcrect.Y -= DesplazamientoV;
            return FGraphics.BeginContainer( dstrect,  srcrect,  unit);
        }
        //
        // Resumen:
        //     Borra toda la superficie de dibujo y la rellena con el color de fondo especificado.
        //
        // Parámetros:
        //   color:
        //     Estructura System.Drawing.Color que representa el color de fondo de la superficie
        //     de dibujo.
        public void Clear(Color color)
        {
            FGraphics.Clear(color);
//            Mapa.ClearAll();
            if (tablas == null)
                tablas = new List<DTabla>();
            tablas.Clear();
        }
        //
        // Resumen:
        //     Realiza una transferencia de bloque de bits de los datos de color, correspondientes
        //     a un rectángulo de píxeles, desde la pantalla a la superficie de dibujo de System.Drawing.Graphics.
        //
        // Parámetros:
        //   upperLeftSource:
        //     Punto en la esquina superior izquierda del rectángulo de origen.
        //
        //   upperLeftDestination:
        //     Punto en la esquina superior izquierda del rectángulo de destino.
        //
        //   blockRegionSize:
        //     Tamaño del área que se va a transferir.
        //
        //   copyPixelOperation:
        //     Uno de los valores de System.Drawing.CopyPixelOperation.
        //
        // Excepciones:
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     copyPixelOperation no es un miembro de System.Drawing.CopyPixelOperation.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     Error en la operación.
        public void CopyFromScreen(Point upperLeftSource, Point upperLeftDestination, Size blockRegionSize, CopyPixelOperation copyPixelOperation)
        {
            FGraphics.CopyFromScreen( upperLeftSource,  upperLeftDestination,  blockRegionSize,  copyPixelOperation);
        }
        //
        // Resumen:
        //     Realiza una transferencia de bloque de bits de los datos de color, correspondientes
        //     a un rectángulo de píxeles, desde la pantalla a la superficie de dibujo de System.Drawing.Graphics.
        //
        // Parámetros:
        //   upperLeftSource:
        //     Punto en la esquina superior izquierda del rectángulo de origen.
        //
        //   upperLeftDestination:
        //     Punto en la esquina superior izquierda del rectángulo de destino.
        //
        //   blockRegionSize:
        //     Tamaño del área que se va a transferir.
        //
        // Excepciones:
        //   T:System.ComponentModel.Win32Exception:
        //     Error en la operación.
        public void CopyFromScreen(Point upperLeftSource, Point upperLeftDestination, Size blockRegionSize)
        {
            FGraphics.CopyFromScreen( upperLeftSource,  upperLeftDestination,  blockRegionSize);
        }
        //
        // Resumen:
        //     Realiza una transferencia de bloque de bits de los datos de color, correspondientes
        //     a un rectángulo de píxeles, desde la pantalla a la superficie de dibujo de System.Drawing.Graphics.
        //
        // Parámetros:
        //   sourceX:
        //     Coordenada x del punto en la esquina superior izquierda del rectángulo de origen.
        //
        //   sourceY:
        //     Coordenada y del punto en la esquina superior izquierda del rectángulo de origen.
        //
        //   destinationX:
        //     Coordenada x del punto en la esquina superior izquierda del rectángulo de destino.
        //
        //   destinationY:
        //     Coordenada y del punto en la esquina superior izquierda del rectángulo de destino.
        //
        //   blockRegionSize:
        //     Tamaño del área que se va a transferir.
        //
        // Excepciones:
        //   T:System.ComponentModel.Win32Exception:
        //     Error en la operación.
        public void CopyFromScreen(int sourceX, int sourceY, int destinationX, int destinationY, Size blockRegionSize)
        {
            FGraphics.CopyFromScreen(sourceX, sourceY, destinationX, destinationY, blockRegionSize);
        }
        //
        // Resumen:
        //     Realiza una transferencia de bloque de bits de los datos de color, correspondientes
        //     a un rectángulo de píxeles, desde la pantalla a la superficie de dibujo de System.Drawing.Graphics.
        //
        // Parámetros:
        //   sourceX:
        //     Coordenada x del punto en la esquina superior izquierda del rectángulo de origen.
        //
        //   sourceY:
        //     Coordenada y del punto en la esquina superior izquierda del rectángulo de origen.
        //
        //   destinationX:
        //     Coordenada x del punto en la esquina superior izquierda del rectángulo de destino.
        //
        //   destinationY:
        //     Coordenada y del punto en la esquina superior izquierda del rectángulo de destino.
        //
        //   blockRegionSize:
        //     Tamaño del área que se va a transferir.
        //
        //   copyPixelOperation:
        //     Uno de los valores de System.Drawing.CopyPixelOperation.
        //
        // Excepciones:
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     copyPixelOperation no es un miembro de System.Drawing.CopyPixelOperation.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     Error en la operación.
        public void CopyFromScreen(int sourceX, int sourceY, int destinationX, int destinationY, Size blockRegionSize, CopyPixelOperation copyPixelOperation)
        {
            FGraphics.CopyFromScreen(sourceX, sourceY, destinationX, destinationY, blockRegionSize, copyPixelOperation);
        }
        //
        // Resumen:
        //     Libera todos los recursos utilizados por este System.Drawing.Graphics.
        public void Dispose()
        {
            FGraphics.Dispose();
        }
        //
        // Resumen:
        //     Dibuja un archivo que representa una parte de una elipse especificada por un
        //     par de coordenadas, un valor de ancho y un valor de alto.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del arco.
        //
        //   x:
        //     Coordenada X de la esquina superior izquierda del rectángulo que define la elipse.
        //
        //   y:
        //     Coordenada Y de la esquina superior izquierda del rectángulo que define la elipse.
        //
        //   width:
        //     Ancho del rectángulo que define la elipse.
        //
        //   height:
        //     Alto del rectángulo que define la elipse.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el punto inicial del arco.
        //
        //   sweepAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el punto final del arco.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de rects es null.
        //
        //   T:System.ArgumentNullException:
        //     rects es una matriz de longitud cero.
        public void DrawArc(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            FGraphics.DrawArc(pen, x- DesplazamientoH, y - DesplazamientoV, width, height, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja un arco que representa una parte de la elipse especificada por una estructura
        //     System.Drawing.Rectangle.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del arco.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que define los límites de la elipse.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el punto inicial del arco.
        //
        //   sweepAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el punto final del arco.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawArc(pen, rect, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja un archivo que representa una parte de una elipse especificada por un
        //     par de coordenadas, un valor de ancho y un valor de alto.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del arco.
        //
        //   x:
        //     Coordenada X de la esquina superior izquierda del rectángulo que define la elipse.
        //
        //   y:
        //     Coordenada Y de la esquina superior izquierda del rectángulo que define la elipse.
        //
        //   width:
        //     Ancho del rectángulo que define la elipse.
        //
        //   height:
        //     Alto del rectángulo que define la elipse.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el punto inicial del arco.
        //
        //   sweepAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el punto final del arco.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
             FGraphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja un arco que representa una parte de la elipse especificada por una estructura
        //     System.Drawing.RectangleF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del arco.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que define los límites de la elipse.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el punto inicial del arco.
        //
        //   sweepAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el punto final del arco.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     pen es null
        public void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawArc(pen, rect, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja una curva spline de Bézier definida por cuatro pares ordenados de coordenadas
        //     que representan puntos.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   x1:
        //     Coordenada x del punto inicial de la curva.
        //
        //   y1:
        //     Coordenada y del punto inicial de la curva.
        //
        //   x2:
        //     Coordenada x del primer punto de control de la curva.
        //
        //   y2:
        //     Coordenada y del primer punto de control de la curva.
        //
        //   x3:
        //     Coordenada x del segundo punto de control de la curva.
        //
        //   y3:
        //     Coordenada y del segundo punto de control de la curva.
        //
        //   x4:
        //     Coordenada x del punto final de la curva.
        //
        //   y4:
        //     Coordenada y del punto final de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            FGraphics.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
        }
        //
        // Resumen:
        //     Dibuja un elemento B-spline definido por cuatro estructuras System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   pt1:
        //     Estructura System.Drawing.PointF que representa el punto inicial de la curva.
        //
        //   pt2:
        //     Estructura System.Drawing.PointF que representa el primer punto de control para
        //     la curva.
        //
        //   pt3:
        //     Estructura System.Drawing.PointF que representa el segundo punto de control para
        //     la curva.
        //
        //   pt4:
        //     Estructura System.Drawing.PointF que representa el extremo de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4)
        {
            FGraphics.DrawBezier(pen, pt1, pt2, pt3, pt4);
        }
        //
        // Resumen:
        //     Dibuja un elemento B-spline definido por cuatro estructuras System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     Estructura System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   pt1:
        //     Estructura System.Drawing.Point que representa el punto inicial de la curva.
        //
        //   pt2:
        //     Estructura System.Drawing.Point que representa el primer punto de control para
        //     la curva.
        //
        //   pt3:
        //     Estructura System.Drawing.Point que representa el segundo punto de control para
        //     la curva.
        //
        //   pt4:
        //     Estructura System.Drawing.Point que representa el extremo de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawBezier(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4)
        {
            FGraphics.DrawBezier(pen, pt1, pt2, pt3, pt4);
        }
        //
        // Resumen:
        //     Dibuja una serie de elementos B-spline a partir de una matriz de estructuras
        //     System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que representan los puntos que definen
        //     la curva. El número de puntos en la matriz debe ser un múltiplo de 3 más 1, como
        //     4, 7 o 10.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawBeziers(Pen pen, PointF[] points)
        {
            FGraphics.DrawBeziers(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una serie de elementos B-spline a partir de una matriz de estructuras
        //     System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que representan los puntos que definen
        //     la curva. El número de puntos en la matriz debe ser un múltiplo de 3 más 1, como
        //     4, 7 o 10.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawBeziers(Pen pen, Point[] points)
        {
            FGraphics.DrawBeziers(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal cerrada, definida por una matriz de estructuras
        //     System.Drawing.PointF, usando la tensión especificada.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y alto de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        //   fillmode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina cómo
        //     se rellena la curva. Este parámetro es obligatorio, si bien se pasa por alto.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode)
        {
            FGraphics.DrawClosedCurve(pen, points, tension, fillmode);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal cerrada, definida por una matriz de estructuras
        //     System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y alto de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawClosedCurve(Pen pen, PointF[] points)
        {
            FGraphics.DrawClosedCurve(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal cerrada, definida por una matriz de estructuras
        //     System.Drawing.Point, usando la tensión especificada.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y alto de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        //   fillmode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina cómo
        //     se rellena la curva. Este parámetro es obligatorio, si bien se pasa por alto.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawClosedCurve(Pen pen, Point[] points, float tension, FillMode fillmode)
        {
            FGraphics.DrawClosedCurve(pen, points, tension, fillmode);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal cerrada, definida por una matriz de estructuras
        //     System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y alto de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawClosedCurve(Pen pen, Point[] points)
        {
            FGraphics.DrawClosedCurve(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.PointF con la tensión especificada.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que representan los puntos que definen
        //     la curva.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, PointF[] points, float tension)
        {
            FGraphics.DrawCurve(pen, points, tension);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.Point con la tensión especificada.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        //   offset:
        //     Desplazamiento entre el primer elemento de la matriz del parámetro points y el
        //     punto inicial de la curva.
        //
        //   numberOfSegments:
        //     Número de segmentos posteriores al punto inicial que se incluirán en la curva.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, Point[] points, int offset, int numberOfSegments, float tension)
        {
            FGraphics.DrawCurve(pen, points, offset, numberOfSegments, tension);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.Point con la tensión especificada.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, Point[] points, float tension)
        {
            FGraphics.DrawCurve(pen, points, tension);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y alto de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, Point[] points)
        {
            FGraphics.DrawCurve(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.PointF con la tensión especificada. El dibujo comienza su desplazamiento
        //     a partir del comienzo de la matriz.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        //   offset:
        //     Desplazamiento entre el primer elemento de la matriz del parámetro points y el
        //     punto inicial de la curva.
        //
        //   numberOfSegments:
        //     Número de segmentos posteriores al punto inicial que se incluirán en la curva.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension)
        {
            FGraphics.DrawCurve(pen, points, offset, numberOfSegments, tension);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.PointF. El dibujo comienza su desplazamiento a partir del comienzo
        //     de la matriz.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        //   offset:
        //     Desplazamiento entre el primer elemento de la matriz del parámetro points y el
        //     punto inicial de la curva.
        //
        //   numberOfSegments:
        //     Número de segmentos posteriores al punto inicial que se incluirán en la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments)
        {
            FGraphics.DrawCurve(pen, points, offset, numberOfSegments);
        }
        //
        // Resumen:
        //     Dibuja una curva spline cardinal a través de una matriz especificada de estructuras
        //     System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la curva.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawCurve(Pen pen, PointF[] points)
        {
            FGraphics.DrawCurve(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una elipse definida por una estructura System.Drawing.RectangleF de delimitación.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la elipse.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que define los límites de la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawEllipse(Pen pen, RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawEllipse(pen, rect);
        }
        //
        // Resumen:
        //     Dibuja una elipse definida por un rectángulo delimitador especificado por un
        //     par de coordenadas, un valor de alto y un valor de ancho.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la elipse.
        //
        //   x:
        //     Coordenada X de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   y:
        //     Coordenada Y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawEllipse(Pen pen, float x, float y, float width, float height)
        {
            FGraphics.DrawEllipse(pen, x, y, width, height);
        }
        //
        // Resumen:
        //     Dibuja una elipse especificada por una estructura System.Drawing.Rectangle de
        //     delimitación.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la elipse.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que define los límites de la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawEllipse(Pen pen, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawEllipse(pen, rect);
        }
        //
        // Resumen:
        //     Dibuja una elipse definida por un rectángulo delimitador que se especifica mediante
        //     las coordenadas de la esquina superior izquierda, un valor de alto y un valor
        //     de ancho.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la elipse.
        //
        //   x:
        //     Coordenada X de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   y:
        //     Coordenada Y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            FGraphics.DrawEllipse(pen, x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Dibuja la imagen representada por el System.Drawing.Icon especificado en las
        //     coordenadas señaladas.
        //
        // Parámetros:
        //   icon:
        //     System.Drawing.Icon que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de icon es null.
        public void DrawIcon(Icon icon, int x, int y)
        {
            FGraphics.DrawIcon(icon, x- DesplazamientoH, y - DesplazamientoV);
        }
        //
        // Resumen:
        //     Dibuja la imagen representada por el System.Drawing.Icon especificado dentro
        //     del área que indica una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   icon:
        //     System.Drawing.Icon que se va a dibujar.
        //
        //   targetRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen resultante en la superficie de pantalla. La imagen contenida en el
        //     parámetro icon se amplía o reduce según las dimensiones de esta área rectangular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de icon es null.
        public void DrawIcon(Icon icon, Rectangle targetRect)
        {
            targetRect.X -= DesplazamientoH;
            targetRect.Y -= DesplazamientoV;
            FGraphics.DrawIcon(icon, targetRect);
        }
        //
        // Resumen:
        //     Dibuja la imagen representada por el System.Drawing.Icon especificado sin transformar
        //     a escala la imagen.
        //
        // Parámetros:
        //   icon:
        //     System.Drawing.Icon que se va a dibujar.
        //
        //   targetRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen resultante. No se modifica la escala de la imagen para que encaje en
        //     el rectángulo, sino que conserva su tamaño original. Si la imagen es mayor que
        //     el rectángulo, se recorta para que quepa en él.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de icon es null.
        public void DrawIconUnstretched(Icon icon, Rectangle targetRect)
        {
            targetRect.X -= DesplazamientoH;
            targetRect.Y -= DesplazamientoV;
            FGraphics.DrawIconUnstretched(icon, targetRect);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada con su tamaño físico original y en
        //     la ubicación que se indique.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   point:
        //     Estructura System.Drawing.PointF que representa la esquina superior izquierda
        //     de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, PointF point)
        {
            FGraphics.DrawImage(image, point);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada con su tamaño físico original y en
        //     la ubicación que se indique.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, float x, float y)
        {
            FGraphics.DrawImage(image, x, y);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada en la ubicación que se indique y
        //     con el tamaño señalado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, rect);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada en la ubicación que se indique y
        //     con el tamaño señalado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        //   width:
        //     Ancho de la imagen dibujada.
        //
        //   height:
        //     Alto de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, float x, float y, float width, float height)
        {
            FGraphics.DrawImage(image, x, y, width, height);
        }
        //
        // Resumen:
        //     Dibuja la imagen especificada con su tamaño físico original y en la ubicación
        //     especificada por un par de coordenadas.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, int x, int y)
        {
            FGraphics.DrawImage(image, x- DesplazamientoH, y - DesplazamientoV);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada en la ubicación que se indique y
        //     con el tamaño señalado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, rect);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada en la ubicación que se indique y
        //     con el tamaño señalado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        //   width:
        //     Ancho de la imagen dibujada.
        //
        //   height:
        //     Alto de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, int x, int y, int width, int height)
        {
            FGraphics.DrawImage(image, x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada en la ubicación que se indique, con
        //     la forma y el tamaño señalados.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, PointF[] destPoints)
        {
            FGraphics.DrawImage(image, destPoints);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada en la ubicación que se indique, con
        //     la forma y el tamaño señalados.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Point[] destPoints)
        {
            FGraphics.DrawImage(image, destPoints);
        }
        //
        // Resumen:
        //     Dibuja una parte de una imagen en una ubicación especificada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte de System.Drawing.Image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, float x, float y, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, x, y, srcRect, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja una parte de una imagen en una ubicación especificada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, int x, int y, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            FGraphics.DrawImage(image, x- DesplazamientoH, y - DesplazamientoV, srcRect, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     de la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcRect, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcRect, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        //     según los criterios establecidos por la aplicación.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, DrawImageAbort callback)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        //   imageAttrs:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
        //     según los criterios establecidos por la aplicación.
        //
        //   callbackData:
        //     Valor que especifica datos adicionales para el delegado System.Drawing.Graphics.DrawImageAbort
        //     con el fin de usarlo al comprobar si se desea detener la ejecución del método
        //     DrawImage.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, DrawImageAbort callback, IntPtr callbackData)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback, callbackData);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttr);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        //   imageAttrs:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
        //     según los criterios establecidos por la aplicación.
        //
        //   callbackData:
        //     Valor que especifica datos adicionales para el delegado System.Drawing.Graphics.DrawImageAbort
        //     con el fin de usarlo al comprobar si se desea detener la ejecución del método
        //     DrawImage.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, DrawImageAbort callback, IntPtr callbackData)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback, callbackData);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        //   imageAttrs:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        //     según los criterios establecidos por la aplicación.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, DrawImageAbort callback)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        //   imageAttrs:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
        //     según los criterios establecidos por la aplicación.
        //
        //   callbackData:
        //     Valor que especifica datos adicionales para el delegado System.Drawing.Graphics.DrawImageAbort
        //     con el fin de usarlo al comprobar si se desea detener la ejecución del método
        //     System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32).
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, DrawImageAbort callback, int callbackData)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback, callbackData);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        //     según los criterios establecidos por la aplicación.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, DrawImageAbort callback)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image que se indique en la
        //     ubicación señalada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del objeto image
        //     que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que usará el parámetro srcRect.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
        //     según los criterios establecidos por la aplicación.
        //
        //   callbackData:
        //     Valor que especifica datos adicionales para el delegado System.Drawing.Graphics.DrawImageAbort
        //     con el fin de usarlo al comprobar si se desea detener la ejecución del método
        //     System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32).
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, DrawImageAbort callback, int callbackData)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback, callbackData);
        }
        //
        // Resumen:
        //     Dibuja la parte especificada de la System.Drawing.Image indicada en la ubicación
        //     que se señale y con el tamaño especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño de
        //     la imagen dibujada. La imagen se reduce de escala para que encaje en el rectángulo.
        //
        //   srcX:
        //     Coordenada x de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcY:
        //     Coordenada y de la esquina superior izquierda de la parte de la imagen de origen
        //     que se va a dibujar.
        //
        //   srcWidth:
        //     Ancho de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcHeight:
        //     Alto de la parte de la imagen de origen que se va a dibujar.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica las unidades
        //     de medida que se usarán para determinar el rectángulo de origen.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica la información de cambio
        //     de color y de gamma para image.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.DrawImageAbort que especifica un método al que
        //     llamar durante el dibujado de la imagen. Se llama con frecuencia a este método
        //     para comprobar si se debe detener la ejecución del método System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        //     según los criterios establecidos por la aplicación.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr, DrawImageAbort callback)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttr, callback);
        }
        //
        // Resumen:
        //     Dibuja la System.Drawing.Image especificada con su tamaño físico original y en
        //     la ubicación que se indique.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   point:
        //     Estructura System.Drawing.Point que representa la ubicación de la esquina superior
        //     izquierda de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImage(Image image, Point point)
        {
            FGraphics.DrawImage(image, point);
        }
        //
        // Resumen:
        //     Dibuja la imagen especificada con su tamaño físico original y en la ubicación
        //     especificada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   point:
        //     Estructura System.Drawing.Point que especifica la esquina superior izquierda
        //     de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImageUnscaled(Image image, Point point)
        {
            FGraphics.DrawImageUnscaled(image, point);
        }
        //
        // Resumen:
        //     Dibuja la imagen especificada con su tamaño físico original y en la ubicación
        //     especificada por un par de coordenadas.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImageUnscaled(Image image, int x, int y)
        {
            FGraphics.DrawImageUnscaled(image, x- DesplazamientoH, y - DesplazamientoV);
        }
        //
        // Resumen:
        //     Dibuja la imagen especificada con su tamaño físico original y en la ubicación
        //     especificada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   rect:
        //     System.Drawing.Rectangle que especifica la esquina superior izquierda de la imagen
        //     dibujada. Las propiedades X e Y del rectángulo especifican la esquina superior
        //     izquierda. Se omiten las propiedades Width y Height.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImageUnscaled(Image image, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawImageUnscaled(image, rect);
        }
        //
        // Resumen:
        //     Dibuja la imagen especificada con su tamaño físico original y en la ubicación
        //     especificada.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda de la imagen dibujada.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda de la imagen dibujada.
        //
        //   width:
        //     No usado.
        //
        //   height:
        //     No usado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImageUnscaled(Image image, int x, int y, int width, int height)
        {
            FGraphics.DrawImageUnscaled(image, x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Dibuja la imagen especificada sin ajustar la escala y la recorta, si es necesario,
        //     para que quepa en el rectángulo especificado.
        //
        // Parámetros:
        //   image:
        //     System.Drawing.Image que se va a dibujar.
        //
        //   rect:
        //     System.Drawing.Rectangle en el que se va a dibujar la imagen.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de image es null.
        public void DrawImageUnscaledAndClipped(Image image, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawImageUnscaledAndClipped(image, rect);
        }
        //
        // Resumen:
        //     Dibuja una línea que conecta los dos puntos especificados por los pares de coordenadas.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la línea.
        //
        //   x1:
        //     Coordenada x del primer punto.
        //
        //   y1:
        //     Coordenada y del primer punto.
        //
        //   x2:
        //     Coordenada x del segundo punto.
        //
        //   y2:
        //     Coordenada y del segundo punto.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            FGraphics.DrawLine(pen, x1, y1, x2, y2);
        }
        //
        // Resumen:
        //     Dibuja una línea que conecta dos estructuras System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la línea.
        //
        //   pt1:
        //     Estructura System.Drawing.PointF que representa el primer punto que se va a conectar.
        //
        //   pt2:
        //     Estructura System.Drawing.PointF que representa el segundo punto que se va a
        //     conectar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawLine(Pen pen, PointF pt1, PointF pt2)
        {
            FGraphics.DrawLine(pen, pt1, pt2);
        }
        //
        // Resumen:
        //     Dibuja una línea que conecta los dos puntos especificados por los pares de coordenadas.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la línea.
        //
        //   x1:
        //     Coordenada x del primer punto.
        //
        //   y1:
        //     Coordenada y del primer punto.
        //
        //   x2:
        //     Coordenada x del segundo punto.
        //
        //   y2:
        //     Coordenada y del segundo punto.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
        {
            FGraphics.DrawLine(pen, x1- DesplazamientoH, y1 - DesplazamientoV, x2- DesplazamientoH, y2 - DesplazamientoV);
        }
        //
        // Resumen:
        //     Dibuja una línea que conecta los dos puntos especificados por los pares de coordenadas.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la línea.
        //
        //   x1:
        //     Coordenada x del primer punto.
        //
        //   y1:
        //     Coordenada y del primer punto.
        //
        //   x2:
        //     Coordenada x del segundo punto.
        //
        //   y2:
        //     Coordenada y del segundo punto.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void FDrawLine(Pen pen, int x1, int y1, int x2, int y2)
        {
            FGraphics.DrawLine(pen, x1 , y1, x2 , y2);
        }
        //
        // Resumen:
        //     Dibuja una línea que conecta dos estructuras System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la línea.
        //
        //   pt1:
        //     Estructura System.Drawing.Point que representa el primer punto que se va a conectar.
        //
        //   pt2:
        //     Estructura System.Drawing.Point que representa el segundo punto que se va a conectar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawLine(Pen pen, Point pt1, Point pt2)
        {
            FGraphics.DrawLine(pen, new Point(pt1.X - DesplazamientoH,pt1.Y-DesplazamientoV),new Point( pt2.X-DesplazamientoH,pt2.Y-DesplazamientoV));
        }
        //
        // Resumen:
        //     Dibuja una serie de segmentos de línea que conectan una matriz de estructuras
        //     System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de los segmentos de
        //     línea.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que representa los puntos que se
        //     van a conectar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawLines(Pen pen, PointF[] points)
        {
            FGraphics.DrawLines(pen, points);
        }
        //
        // Resumen:
        //     Dibuja una serie de segmentos de línea que conectan una matriz de estructuras
        //     System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de los segmentos de
        //     línea.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que representa los puntos que se van
        //     a conectar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawLines(Pen pen, Point[] points)
        {
            FGraphics.DrawLines(pen, points);
        }
        //
        // Resumen:
        //     Dibuja un System.Drawing.Drawing2D.GraphicsPath.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del trazado.
        //
        //   path:
        //     System.Drawing.Drawing2D.GraphicsPath que se va a dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de path es null.
        public void DrawPath(Pen pen, GraphicsPath path)
        {
            FGraphics.DrawPath(pen, path);
        }
        //
        // Resumen:
        //     Dibuja una forma circular definida por una elipse determinada por un par de coordenadas,
        //     unos valores de ancho y alto y dos líneas radiales.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la forma de gráfico
        //     circular.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la forma de gráfico circular.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la forma de gráfico circular.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse de la que procede la forma
        //     de gráfico circular.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse de la que procede la forma
        //     de gráfico circular.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la forma de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la forma de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            FGraphics.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja una forma circular definida por una elipse, determinada por una estructura
        //     System.Drawing.Rectangle y dos líneas radiales.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la forma de gráfico
        //     circular.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que representa el rectángulo delimitador
        //     que define la elipse, de la cual procede la forma circular.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la forma de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la forma de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawPie(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawPie(pen, rect, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja una forma circular definida por una elipse determinada por un par de coordenadas,
        //     unos valores de ancho y alto y dos líneas radiales.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la forma de gráfico
        //     circular.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la forma de gráfico circular.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la forma de gráfico circular.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse de la que procede la forma
        //     de gráfico circular.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse de la que procede la forma
        //     de gráfico circular.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la forma de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la forma de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawPie(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            FGraphics.DrawPie(pen, x- DesplazamientoH, y - DesplazamientoV, width, height, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja una forma circular definida por una elipse, determinada por una estructura
        //     System.Drawing.RectangleF y dos líneas radiales.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de la forma de gráfico
        //     circular.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que representa el rectángulo delimitador
        //     que define la elipse, de la cual procede la forma circular.
        //
        //   startAngle:
        //     Ángulo en grados medido en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la forma de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la forma de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawPie(pen, rect, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja un polígono definido por una matriz de estructuras System.Drawing.PointF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del polígono.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que representa los vértices del polígono.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de points es null.
        public void DrawPolygon(Pen pen, PointF[] points)
        {
            FGraphics.DrawPolygon(pen, points);
        }
        //
        // Resumen:
        //     Dibuja un polígono definido por una matriz de estructuras System.Drawing.Point.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del polígono.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que representa los vértices del polígono.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawPolygon(Pen pen, Point[] points)
        {
            FGraphics.DrawPolygon(pen, points);
        }
        //
        // Resumen:
        //     Dibuja un rectángulo especificado por una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del rectángulo.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que representa el rectángulo que se va a
        //     dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.DrawRectangle(pen, rect);
        }
        //
        // Resumen:
        //     Dibuja un rectángulo especificado por un par de coordenadas, un valor de ancho
        //     y un valor de alto.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del rectángulo.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo que se va a dibujar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo que se va a dibujar.
        //
        //   width:
        //     Ancho del rectángulo que se va a dibujar.
        //
        //   height:
        //     Alto del rectángulo que se va a dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawRectangle(Pen pen, float x, float y, float width, float height)
        {
            FGraphics.DrawRectangle(pen, x - DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Dibuja un rectángulo especificado por un par de coordenadas, un valor de ancho
        //     y un valor de alto.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del rectángulo.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo que se va a dibujar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo que se va a dibujar.
        //
        //   width:
        //     Ancho del rectángulo que se va a dibujar.
        //
        //   height:
        //     Alto del rectángulo que se va a dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void DrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            FGraphics.DrawRectangle(pen, x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Dibuja un rectángulo especificado por un par de coordenadas las cuales no son afectadas por el desplazamiento, un valor de ancho
        //     y un valor de alto.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo del rectángulo.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo que se va a dibujar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo que se va a dibujar.
        //
        //   width:
        //     Ancho del rectángulo que se va a dibujar.
        //
        //   height:
        //     Alto del rectángulo que se va a dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null.
        public void FDrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            FGraphics.DrawRectangle(pen, x, y, width, height);
        }
        //
        // Resumen:
        //     Dibuja una serie de rectángulos especificados por las estructuras System.Drawing.Rectangle.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de los contornos de
        //     los rectángulos.
        //
        //   rects:
        //     Matriz de estructuras System.Drawing.Rectangle que representan los rectángulos
        //     que se van a dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de rects es null.
        //
        //   T:System.ArgumentException:
        //     rects es una matriz de longitud cero.
        public void DrawRectangles(Pen pen, Rectangle[] rects)
        {
            for(int i=0;i< rects.Length;i++)
            {
                rects[i].X -= DesplazamientoH;
                rects[i].Y -= DesplazamientoV;
            }
            FGraphics.DrawRectangles(pen, rects);
        }
        //
        // Resumen:
        //     Dibuja una serie de rectángulos especificados por las estructuras System.Drawing.RectangleF.
        //
        // Parámetros:
        //   pen:
        //     System.Drawing.Pen que determina el color, ancho y estilo de los contornos de
        //     los rectángulos.
        //
        //   rects:
        //     Matriz de estructuras System.Drawing.RectangleF que representan los rectángulos
        //     que se van a dibujar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de pen es null. O bien El valor de rects es null.
        //
        //   T:System.ArgumentException:
        //     rects es una matriz de longitud cero.
        public void DrawRectangles(Pen pen, RectangleF[] rects)
        {
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i].X -= DesplazamientoH;
                rects[i].Y -= DesplazamientoV;
            }

            FGraphics.DrawRectangles(pen, rects);
        }
        //
        // Resumen:
        //     Dibuja la cadena de texto especificada en el rectángulo que se indique, con los
        //     objetos System.Drawing.Brush y System.Drawing.Font dados y usando los atributos
        //     de formato del System.Drawing.StringFormat especificado.
        //
        // Parámetros:
        //   s:
        //     Cadena que se va a dibujar.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   brush:
        //     System.Drawing.Brush que determina el color y la textura del texto dibujado.
        //
        //   layoutRectangle:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación del texto dibujado.
        //
        //   format:
        //     System.Drawing.StringFormat que especifica los atributos de formato, como el
        //     espaciado de líneas y la alineación, que se aplican al texto dibujado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de s es null.
        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
        {
            layoutRectangle.X -= DesplazamientoH;
            layoutRectangle.Y -= DesplazamientoV;
            FGraphics.DrawString(s, font, brush, layoutRectangle, format);
        }
        //
        // Resumen:
        //     Dibuja la cadena de texto especificada en el rectángulo especificado y con los
        //     objetos System.Drawing.Brush y System.Drawing.Font igualmente especificados.
        //
        // Parámetros:
        //   s:
        //     Cadena que se va a dibujar.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   brush:
        //     System.Drawing.Brush que determina el color y la textura del texto dibujado.
        //
        //   layoutRectangle:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación del texto dibujado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de s es null.
        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle)
        {
            layoutRectangle.X -= DesplazamientoH;
            layoutRectangle.Y -= DesplazamientoV;
            FGraphics.DrawString(s, font, brush, layoutRectangle);
        }
        //
        // Resumen:
        //     Dibuja la cadena de texto especificada en la ubicación que se indique, con los
        //     objetos System.Drawing.Brush y System.Drawing.Font dados y usando los atributos
        //     de formato del System.Drawing.StringFormat especificado.
        //
        // Parámetros:
        //   s:
        //     Cadena que se va a dibujar.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   brush:
        //     System.Drawing.Brush que determina el color y la textura del texto dibujado.
        //
        //   point:
        //     Estructura System.Drawing.PointF que especifica la esquina superior izquierda
        //     del texto dibujado.
        //
        //   format:
        //     System.Drawing.StringFormat que especifica los atributos de formato, como el
        //     espaciado de líneas y la alineación, que se aplican al texto dibujado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de s es null.
        public void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format)
        {
            FGraphics.DrawString(s, font, brush, point, format);
        }
        //
        // Resumen:
        //     Dibuja la cadena de texto especificada en la ubicación que se indique, con los
        //     objetos System.Drawing.Brush y System.Drawing.Font dados y usando los atributos
        //     de formato del System.Drawing.StringFormat especificado.
        //
        // Parámetros:
        //   s:
        //     Cadena que se va a dibujar.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   brush:
        //     System.Drawing.Brush que determina el color y la textura del texto dibujado.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del texto dibujado.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del texto dibujado.
        //
        //   format:
        //     System.Drawing.StringFormat que especifica los atributos de formato, como el
        //     espaciado de líneas y la alineación, que se aplican al texto dibujado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de s es null.
        public void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format)
        {
            FGraphics.DrawString(s, font, brush, x, y, format);
        }
        //
        // Resumen:
        //     Dibuja la cadena de texto especificada en la ubicación especificada y con los
        //     objetos System.Drawing.Brush y System.Drawing.Font especificados.
        //
        // Parámetros:
        //   s:
        //     Cadena que se va a dibujar.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   brush:
        //     System.Drawing.Brush que determina el color y la textura del texto dibujado.
        //
        //   point:
        //     Estructura System.Drawing.PointF que especifica la esquina superior izquierda
        //     del texto dibujado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de s es null.
        public void DrawString(string s, Font font, Brush brush, PointF point)
        {
            FGraphics.DrawString(s, font, brush, point);
        }
        //
        // Resumen:
        //     Dibuja la cadena de texto especificada en la ubicación especificada y con los
        //     objetos System.Drawing.Brush y System.Drawing.Font especificados.
        //
        // Parámetros:
        //   s:
        //     Cadena que se va a dibujar.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   brush:
        //     System.Drawing.Brush que determina el color y la textura del texto dibujado.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del texto dibujado.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del texto dibujado.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de s es null.
        public void DrawString(string s, Font font, Brush brush, float x, float y)
        {
            FGraphics.DrawString(s, font, brush, x, y);
        }
        //
        // Resumen:
        //     Cierra el contenedor de gráficos actual y restaura el estado que tenía este System.Drawing.Graphics
        //     al estado guardado mediante una llamada al método System.Drawing.Graphics.BeginContainer.
        //
        // Parámetros:
        //   container:
        //     System.Drawing.Drawing2D.GraphicsContainer que representa el contenedor restaurado
        //     por este método.
        public void EndContainer(GraphicsContainer container)
        {
            FGraphics.EndContainer(container);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un punto
        //     determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.PointF que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, PointF destPoint, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            FGraphics.EnumerateMetafile(metafile, destPoint, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un punto
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.PointF que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, PointF destPoint, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            FGraphics.EnumerateMetafile(metafile, destPoint, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un paralelogramo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, PointF[] destPoints, EnumerateMetafileProc callback)
        {
            FGraphics.EnumerateMetafile(metafile, destPoints, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un punto
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.Point que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, Point destPoint, EnumerateMetafileProc callback)
        {
            FGraphics.EnumerateMetafile(metafile, destPoint, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un punto
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.Point que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, Point destPoint, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            FGraphics.EnumerateMetafile(metafile, destPoint, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un punto
        //     determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.Point que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, Point destPoint, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            FGraphics.EnumerateMetafile(metafile, destPoint, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un rectángulo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, RectangleF destRect, EnumerateMetafileProc callback)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un rectángulo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, RectangleF destRect, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un rectángulo
        //     determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, RectangleF destRect, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un rectángulo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño del
        //     metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, Rectangle destRect, EnumerateMetafileProc callback)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un punto
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.PointF que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, PointF destPoint, EnumerateMetafileProc callback)
        {
            FGraphics.EnumerateMetafile(metafile, destPoint, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un paralelogramo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, PointF[] destPoints, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            FGraphics.EnumerateMetafile(metafile, destPoints, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un paralelogramo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, Point[] destPoints, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            FGraphics.EnumerateMetafile(metafile, destPoints, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un paralelogramo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, Point[] destPoints, EnumerateMetafileProc callback)
        {
            FGraphics.EnumerateMetafile(metafile, destPoints, callback);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     paralelogramo determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, Point[] destPoints, Rectangle srcRect, GraphicsUnit unit, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoints, srcRect, unit, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     paralelogramo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoints, srcRect, srcUnit, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     paralelogramo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoints, srcRect, srcUnit, callback);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     paralelogramo determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, PointF[] destPoints, RectangleF srcRect, GraphicsUnit unit, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoints, srcRect, unit, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     paralelogramo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoints, srcRect, srcUnit, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     paralelogramo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructuras System.Drawing.RectangleF que especifican la parte del metarchivo
        //     que se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoints, srcRect, srcUnit, callback);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     rectángulo determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño del
        //     metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, Rectangle destRect, Rectangle srcRect, GraphicsUnit unit, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, srcRect, unit, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     rectángulo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño del
        //     metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, srcRect, srcUnit, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     rectángulo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño del
        //     metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, srcRect, srcUnit, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un paralelogramo
        //     determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.PointF que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, PointF[] destPoints, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            FGraphics.EnumerateMetafile(metafile, destPoints, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     rectángulo determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, RectangleF destRect, RectangleF srcRect, GraphicsUnit unit, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, srcRect, unit, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     rectángulo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, srcRect, srcUnit, callback);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     punto determinado usando los atributos de imagen especificados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.Point que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, Point destPoint, Rectangle srcRect, GraphicsUnit unit, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoint,  srcRect, unit, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado de un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     punto determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.Point que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, Point destPoint, Rectangle srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoint, srcRect, srcUnit, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado de un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     punto determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.Point que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.Rectangle que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, Point destPoint, Rectangle srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoint, srcRect, srcUnit, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un rectángulo
        //     determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño del
        //     metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, Rectangle destRect, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     punto determinado usando los atributos de imagen especificados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.PointF que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   unit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, PointF destPoint, RectangleF srcRect, GraphicsUnit unit, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoint, srcRect, unit, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado de un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     punto determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.PointF que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, PointF destPoint, RectangleF srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoint, srcRect, srcUnit, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado de un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     punto determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoint:
        //     Estructura System.Drawing.PointF que especifica la ubicación de la esquina superior
        //     izquierda del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        public void EnumerateMetafile(Metafile metafile, PointF destPoint, RectangleF srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback)
        {
            srcRect.X -= DesplazamientoH;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destPoint, srcRect, srcUnit, callback);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un paralelogramo
        //     determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destPoints:
        //     Matriz de tres estructuras System.Drawing.Point que definen un paralelogramo,
        //     el cual determina el tamaño y la ubicación del metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, Point[] destPoints, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            FGraphics.EnumerateMetafile(metafile, destPoints, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Envía los registros de un rectángulo seleccionado en un System.Drawing.Imaging.Metafile,
        //     de uno en uno, a un método de devolución de llamada para su presentación en un
        //     rectángulo determinado.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.RectangleF que especifica la ubicación y el tamaño
        //     del metarchivo dibujado.
        //
        //   srcRect:
        //     Estructura System.Drawing.RectangleF que especifica la parte del metarchivo que
        //     se va a dibujar, relativa a su esquina superior izquierda.
        //
        //   srcUnit:
        //     Miembro de la enumeración System.Drawing.GraphicsUnit que especifica la unidad
        //     de medida empleada para determinar qué parte del metarchivo contiene el rectángulo
        //     especificado por el parámetro srcRect.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        public void EnumerateMetafile(Metafile metafile, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit, EnumerateMetafileProc callback, IntPtr callbackData)
        {
            destRect.X -= DesplazamientoH;
            srcRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            srcRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, srcRect, srcUnit, callback, callbackData);
        }
        //
        // Resumen:
        //     Envía los registros del System.Drawing.Imaging.Metafile especificado, de uno
        //     en uno, a un método de devolución de llamada para su presentación en un rectángulo
        //     determinado usando los atributos de imagen dados.
        //
        // Parámetros:
        //   metafile:
        //     System.Drawing.Imaging.Metafile que se va a enumerar.
        //
        //   destRect:
        //     Estructura System.Drawing.Rectangle que especifica la ubicación y el tamaño del
        //     metarchivo dibujado.
        //
        //   callback:
        //     Delegado System.Drawing.Graphics.EnumerateMetafileProc que especifica el método
        //     al cual se envían los registros de metarchivo.
        //
        //   callbackData:
        //     Puntero interno requerido pero que se pasa por alto. De manera opcional, se puede
        //     pasar System.IntPtr.Zero para este parámetro.
        //
        //   imageAttr:
        //     System.Drawing.Imaging.ImageAttributes que especifica información de atributos
        //     de imagen para la imagen dibujada.
        public void EnumerateMetafile(Metafile metafile, Rectangle destRect, EnumerateMetafileProc callback, IntPtr callbackData, ImageAttributes imageAttr)
        {
            destRect.X -= DesplazamientoH;
            destRect.Y -= DesplazamientoV;
            FGraphics.EnumerateMetafile(metafile, destRect, callback, callbackData, imageAttr);
        }
        //
        // Resumen:
        //     Actualiza la región de recorte de este System.Drawing.Graphics con el fin de
        //     excluir el área especificada por una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.Rectangle que especifica el rectángulo que se debe
        //     excluir de la región de recorte.
        public void ExcludeClip(Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.ExcludeClip(rect);
        }
        //
        // Resumen:
        //     Actualiza la región de recorte de este System.Drawing.Graphics con el fin de
        //     excluir el área especificada por una System.Drawing.Region.
        //
        // Parámetros:
        //   region:
        //     System.Drawing.Region que especifica la región que se debe excluir de la región
        //     de recorte.
        public void ExcludeClip(Region region)
        {
            FGraphics.ExcludeClip(region);
        }
        //
        // Resumen:
        //     Rellena el interior de una curva spline cardinal cerrada, definida por una matriz
        //     de estructuras System.Drawing.PointF, usando el modo de relleno especificado.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        //   fillmode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina cómo
        //     se rellena la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode)
        {
            FGraphics.FillClosedCurve(brush, points, fillmode);
        }
        //
        // Resumen:
        //     Rellena el interior de una curva spline cardinal cerrada, definida por una matriz
        //     de estructuras System.Drawing.PointF, usando la tensión y el modo de relleno
        //     especificados.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        //   fillmode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina cómo
        //     se rellena la curva.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension)
        {
            FGraphics.FillClosedCurve(brush, points, fillmode, tension);
        }
        //
        // Resumen:
        //     Rellena el interior de una curva spline cardinal cerrada, definida por una matriz
        //     de estructuras System.Drawing.Point.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillClosedCurve(Brush brush, Point[] points)
        {
            FGraphics.FillClosedCurve(brush, points);
        }
        //
        // Resumen:
        //     Rellena el interior de una curva spline cardinal cerrada, definida por una matriz
        //     de estructuras System.Drawing.Point, usando la tensión y el modo de relleno especificados.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        //   fillmode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina cómo
        //     se rellena la curva.
        //
        //   tension:
        //     Valor mayor o igual que 0,0 F que especifica la tensión de la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode, float tension)
        {
            FGraphics.FillClosedCurve(brush, points, fillmode, tension);
        }
        //
        // Resumen:
        //     Rellena el interior de una curva spline cardinal cerrada, definida por una matriz
        //     de estructuras System.Drawing.Point, usando el modo de relleno especificado.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que definen la curva spline.
        //
        //   fillmode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina cómo
        //     se rellena la curva.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode)
        {
            FGraphics.FillClosedCurve(brush, points, fillmode);
        }
        //
        // Resumen:
        //     Rellena el interior de una curva spline cardinal cerrada, definida por una matriz
        //     de estructuras System.Drawing.PointF.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que definen la curva spline.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillClosedCurve(Brush brush, PointF[] points)
        {
            FGraphics.FillClosedCurve(brush, points);
        }
        //
        // Resumen:
        //     Rellena el interior de una elipse definida por un rectángulo delimitador especificado
        //     a su vez por una estructura System.Drawing.RectangleF.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que representa el rectángulo delimitador
        //     que define la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillEllipse(Brush brush, RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.FillEllipse(brush, rect);
        }
        //
        // Resumen:
        //     Rellena el interior de una elipse definida por un rectángulo delimitador especificado
        //     por un par de coordenadas, un valor de alto y un valor de ancho.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   x:
        //     Coordenada X de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   y:
        //     Coordenada Y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillEllipse(Brush brush, float x, float y, float width, float height)
        {
            FGraphics.FillEllipse(brush, x, y, width, height);
        }
        //
        // Resumen:
        //     Rellena el interior de una elipse definida por un rectángulo delimitador especificado
        //     a su vez por una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que representa el rectángulo delimitador
        //     que define la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillEllipse(Brush brush, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.FillEllipse(brush, rect);
        }
        //
        // Resumen:
        //     Rellena el interior de una elipse definida por un rectángulo delimitador especificado
        //     por un par de coordenadas, un valor de alto y un valor de ancho.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   x:
        //     Coordenada X de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   y:
        //     Coordenada Y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillEllipse(Brush brush, int x, int y, int width, int height)
        {
            FGraphics.FillEllipse(brush, x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Rellena el interior de un System.Drawing.Drawing2D.GraphicsPath.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   path:
        //     System.Drawing.Drawing2D.GraphicsPath que representa el trazado que se desea
        //     rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de path es null.
        public void FillPath(Brush brush, GraphicsPath path)
        {
            FGraphics.FillPath(brush, path);
        }
        //
        // Resumen:
        //     Rellena el interior de una sección de gráfico circular definida por una elipse,
        //     determinada por un par de coordenadas, unos valores de ancho y alto y dos líneas
        //     radiales.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la sección de gráfico circular.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la sección de gráfico circular.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse, de la cual procede la
        //     sección de gráfico circular.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse, de la cual procede la sección
        //     de gráfico circular.
        //
        //   startAngle:
        //     Ángulo medido en grados en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la sección de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la sección de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillPie(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            FGraphics.FillPie(brush, x- DesplazamientoH, y - DesplazamientoV, width, height, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Dibuja el interior de una sección circular definida por una elipse, determinada
        //     por una estructura System.Drawing.RectangleF y dos líneas radiales.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que representa el rectángulo delimitador
        //     que define la elipse, de la cual procede la sección de gráfico circular.
        //
        //   startAngle:
        //     Ángulo medido en grados en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la sección de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la sección de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillPie(Brush brush, Rectangle rect, float startAngle, float sweepAngle)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.FillPie(brush, rect, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Rellena el interior de una sección de gráfico circular definida por una elipse,
        //     determinada por un par de coordenadas, unos valores de ancho y alto y dos líneas
        //     radiales.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la sección de gráfico circular.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo delimitador que
        //     define la elipse de la que procede la sección de gráfico circular.
        //
        //   width:
        //     Ancho del rectángulo delimitador que define la elipse, de la cual procede la
        //     sección de gráfico circular.
        //
        //   height:
        //     Alto del rectángulo delimitador que define la elipse, de la cual procede la sección
        //     de gráfico circular.
        //
        //   startAngle:
        //     Ángulo medido en grados en el sentido de las agujas del reloj desde el eje X
        //     hasta el primer lado de la sección de gráfico circular.
        //
        //   sweepAngle:
        //     Ángulo medido en grados en sentido de las agujas del reloj desde el parámetro
        //     startAngle hasta el segundo lado de la sección de gráfico circular.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            FGraphics.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
        }
        //
        // Resumen:
        //     Rellena el interior de un polígono definido por una matriz de puntos, especificados
        //     por estructuras System.Drawing.PointF.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que representan los vértices del
        //     polígono que se van a rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillPolygon(Brush brush, PointF[] points)
        {
            FGraphics.FillPolygon(brush, points);
        }
        //
        // Resumen:
        //     Rellena el interior de un polígono definido por una matriz de puntos especificados
        //     por estructuras System.Drawing.PointF, usando el modo de relleno especificado.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.PointF que representan los vértices del
        //     polígono que se van a rellenar.
        //
        //   fillMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina el
        //     estilo del relleno.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillPolygon(Brush brush, PointF[] points, FillMode fillMode)
        {
            FGraphics.FillPolygon(brush, points, fillMode);
        }
        //
        // Resumen:
        //     Rellena el interior de un polígono definido por una matriz de puntos, especificados
        //     por estructuras System.Drawing.Point.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que representan los vértices del polígono
        //     que se van a rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillPolygon(Brush brush, Point[] points)
        {
            FGraphics.FillPolygon(brush, points);
        }
        //
        // Resumen:
        //     Rellena el interior de un polígono definido por una matriz de puntos especificados
        //     por estructuras System.Drawing.Point, usando el modo de relleno especificado.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   points:
        //     Matriz de estructuras System.Drawing.Point que representan los vértices del polígono
        //     que se van a rellenar.
        //
        //   fillMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FillMode que determina el
        //     estilo del relleno.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de points es null.
        public void FillPolygon(Brush brush, Point[] points, FillMode fillMode)
        {
            FGraphics.FillPolygon(brush, points, fillMode);
        }
        //
        // Resumen:
        //     Rellena el interior de un rectángulo especificado por un par de coordenadas,
        //     un valor de ancho y un valor de alto.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo que se va a rellenar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo que se va a rellenar.
        //
        //   width:
        //     Ancho del rectángulo que se va a rellenar.
        //
        //   height:
        //     Alto del rectángulo que se va a rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillRectangle(Brush brush, float x, float y, float width, float height)
        {
            FGraphics.FillRectangle(brush, x, y, width, height);
        }
        //
        // Resumen:
        //     Rellena el interior de un rectángulo especificado por un par de coordenadas,
        //     un valor de ancho y un valor de alto.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo que se va a rellenar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo que se va a rellenar.
        //
        //   width:
        //     Ancho del rectángulo que se va a rellenar.
        //
        //   height:
        //     Alto del rectángulo que se va a rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillRectangle(Brush brush, int x, int y, int width, int height)
        {
            FGraphics.FillRectangle(brush, x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Rellena el interior de un rectángulo especificado por una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rect:
        //     Estructura System.Drawing.Rectangle que representa el rectángulo que se va a
        //     rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillRectangle(Brush brush, Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.FillRectangle(brush, rect);
        }
        //
        // Resumen:
        //     Rellena el interior de un rectángulo especificado por una estructura System.Drawing.RectangleF.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rect:
        //     Estructura System.Drawing.RectangleF que representa el rectángulo que se va a
        //     rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null.
        public void FillRectangle(Brush brush, RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.FillRectangle(brush, rect);
        }
        //
        // Resumen:
        //     Rellena el interior de una serie de rectángulos especificados por estructuras
        //     System.Drawing.Rectangle.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rects:
        //     Matriz de estructuras System.Drawing.Rectangle que representan los rectángulos
        //     que se van a rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de rects es null.
        //
        //   T:System.ArgumentException:
        //     rects es una matriz de longitud cero.
        public void FillRectangles(Brush brush, Rectangle[] rects)
        {
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i].X -= DesplazamientoH;
                rects[i].Y -= DesplazamientoV;
            }

            FGraphics.FillRectangles(brush, rects);
        }
        //
        // Resumen:
        //     Rellena el interior de una serie de rectángulos especificados por estructuras
        //     System.Drawing.RectangleF.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   rects:
        //     Matriz de estructuras System.Drawing.RectangleF que representan los rectángulos
        //     que se van a rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de rects es null.
        //
        //   T:System.ArgumentException:
        //     Rects es una matriz de longitud cero.
        public void FillRectangles(Brush brush, RectangleF[] rects)
        {
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i].X -= DesplazamientoH;
                rects[i].Y -= DesplazamientoV;
            }
            FGraphics.FillRectangles(brush, rects);
        }
        //
        // Resumen:
        //     Rellena el interior de un System.Drawing.Region.
        //
        // Parámetros:
        //   brush:
        //     System.Drawing.Brush que determina las características del relleno.
        //
        //   region:
        //     System.Drawing.Region que representa el área que se desea rellenar.
        //
        // Excepciones:
        //   T:System.ArgumentNullException:
        //     El valor de brush es null. O bien El valor de region es null.
        public void FillRegion(Brush brush, Region region)
        {
            FGraphics.FillRegion(brush, region);
        }
        //
        // Resumen:
        //     Fuerza la ejecución de todas las operaciones de gráficos pendientes, esperando
        //     o no el método, según se especifique, a devolver un valor antes de que finalicen
        //     las operaciones.
        //
        // Parámetros:
        //   intention:
        //     Miembro de la enumeración System.Drawing.Drawing2D.FlushIntention que especifica
        //     si el método devuelve un valor inmediatamente o espera a que finalicen las operaciones
        //     existentes.
        public void Flush(FlushIntention intention)
        {
            FGraphics.Flush(intention);
        }
        //
        // Resumen:
        //     Fuerza la ejecución de todas las operaciones de gráficos pendientes y devuelve
        //     inmediatamente el control sin esperar a que finalicen las operaciones.
        public void Flush()
        {
            FGraphics.Flush();
        }
        //
        // Resumen:
        //     Obtiene el contexto de los gráficos acumulativos.
        //
        // Devuelve:
        //     System.Object que representa el contexto de los gráficos acumulativos.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object GetContextInfo()
        {
            return FGraphics.GetContextInfo();
        }
        //
        // Resumen:
        //     Obtiene el identificador del contexto de dispositivo asociado a este System.Drawing.Graphics.
        //
        // Devuelve:
        //     Identificador del contexto de dispositivo asociado a este System.Drawing.Graphics.
        public IntPtr GetHdc()
        {
            return FGraphics.GetHdc();
        }
        //
        // Resumen:
        //     Obtiene el color más próximo a la estructura System.Drawing.Color especificada.
        //
        // Parámetros:
        //   color:
        //     Estructura System.Drawing.Color para la que se va a buscar una coincidencia.
        //
        // Devuelve:
        //     Una estructura System.Drawing.Color que representa el color más próximo al especificado
        //     con el parámetro color.
        public Color GetNearestColor(Color color)
        {
            return FGraphics.GetNearestColor(color);
        }
        //
        // Resumen:
        //     Actualiza la región de recorte de este System.Drawing.Graphics a la intersección
        //     de la actual región de recorte y la System.Drawing.Region especificada.
        //
        // Parámetros:
        //   region:
        //     System.Drawing.Region que va a formar una intersección con la región actual.
        public void IntersectClip(Region region)
        {
            FGraphics.IntersectClip(region);
        }
        //
        // Resumen:
        //     Actualiza la región de recorte de este System.Drawing.Graphics a la intersección
        //     de la actual región de recorte y la estructura System.Drawing.Rectangle especificada.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.Rectangle que va a formar una intersección con la actual
        //     región de recorte.
        public void IntersectClip(Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.IntersectClip(rect);
        }
        //
        // Resumen:
        //     Actualiza la región de recorte de este System.Drawing.Graphics a la intersección
        //     de la actual región de recorte y la estructura System.Drawing.RectangleF especificada.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.RectangleF que va a formar una intersección con la
        //     actual región de recorte.
        public void IntersectClip(RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.IntersectClip(rect);
        }
        //
        // Resumen:
        //     Indica si el punto especificado por un par de coordenadas se halla contenido
        //     en la región de recorte visible de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   x:
        //     Coordenada x del punto cuya visibilidad se va a comprobar.
        //
        //   y:
        //     Coordenada y del punto cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el punto definido por los parámetros x e y está dentro de la región de
        //     recorte visible de este System.Drawing.Graphics; de lo contrario, false.
        public bool IsVisible(int x, int y)
        {
            return FGraphics.IsVisible(x- DesplazamientoH, y - DesplazamientoV);
        }
        //
        // Resumen:
        //     Indica si la estructura System.Drawing.PointF especificada está dentro de la
        //     región de recorte visible de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   point:
        //     Estructura System.Drawing.PointF cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el punto especificado por el parámetro point está dentro de la región
        //     de recorte visible de este System.Drawing.Graphics; de lo contrario, false.
        public bool IsVisible(PointF point)
        {
            return FGraphics.IsVisible(point);
        }
        //
        // Resumen:
        //     Indica si el rectángulo especificado por un par de coordenadas, un valor de ancho
        //     y un valor de alto se halla contenido en la región de recorte visible de este
        //     System.Drawing.Graphics.
        //
        // Parámetros:
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo cuya visibilidad
        //     se va a comprobar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo cuya visibilidad
        //     se va a comprobar.
        //
        //   width:
        //     Ancho del rectángulo cuya visibilidad se va a comprobar.
        //
        //   height:
        //     Alto del rectángulo cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el rectángulo definido por los parámetros x, y, width y height está dentro
        //     de la región de recorte visible de este System.Drawing.Graphics; de lo contrario,
        //     false.
        public bool IsVisible(int x, int y, int width, int height)
        {
            return FGraphics.IsVisible(x- DesplazamientoH, y - DesplazamientoV, width, height);
        }
        //
        // Resumen:
        //     Indica si el rectángulo especificado por una estructura System.Drawing.Rectangle
        //     está dentro de la región de recorte visible de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.Rectangle cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el rectángulo especificado por el parámetro rect está dentro de la región
        //     de recorte visible de este System.Drawing.Graphics; de lo contrario, false.
        public bool IsVisible(Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            return FGraphics.IsVisible(rect);
        }
        //
        // Resumen:
        //     Indica si el rectángulo especificado por una estructura System.Drawing.RectangleF
        //     está dentro de la región de recorte visible de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.RectangleF cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el rectángulo especificado por el parámetro rect está dentro de la región
        //     de recorte visible de este System.Drawing.Graphics; de lo contrario, false.
        public bool IsVisible(RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            return FGraphics.IsVisible(rect);
        }
        //
        // Resumen:
        //     Indica si el rectángulo especificado por un par de coordenadas, un valor de ancho
        //     y un valor de alto se halla contenido en la región de recorte visible de este
        //     System.Drawing.Graphics.
        //
        // Parámetros:
        //   x:
        //     Coordenada x de la esquina superior izquierda del rectángulo cuya visibilidad
        //     se va a comprobar.
        //
        //   y:
        //     Coordenada y de la esquina superior izquierda del rectángulo cuya visibilidad
        //     se va a comprobar.
        //
        //   width:
        //     Ancho del rectángulo cuya visibilidad se va a comprobar.
        //
        //   height:
        //     Alto del rectángulo cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el rectángulo definido por los parámetros x, y, width y height está dentro
        //     de la región de recorte visible de este System.Drawing.Graphics; de lo contrario,
        //     false.
        public bool IsVisible(float x, float y, float width, float height)
        {
            return FGraphics.IsVisible(x, y, width, height);
        }
        //
        // Resumen:
        //     Indica si la estructura System.Drawing.Point especificada está dentro de la región
        //     de recorte visible de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   point:
        //     Estructura System.Drawing.Point cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el punto especificado por el parámetro point está dentro de la región
        //     de recorte visible de este System.Drawing.Graphics; de lo contrario, false.
        public bool IsVisible(Point point)
        {
            return FGraphics.IsVisible(point);
        }
        //
        // Resumen:
        //     Indica si el punto especificado por un par de coordenadas se halla contenido
        //     en la región de recorte visible de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   x:
        //     Coordenada x del punto cuya visibilidad se va a comprobar.
        //
        //   y:
        //     Coordenada y del punto cuya visibilidad se va a comprobar.
        //
        // Devuelve:
        //     true si el punto definido por los parámetros x e y está dentro de la región de
        //     recorte visible de este System.Drawing.Graphics; de lo contrario, false.
        public bool IsVisible(float x, float y)
        {
            return FGraphics.IsVisible(x, y);
        }
        //
        // Resumen:
        //     Obtiene una matriz de objetos System.Drawing.Region, cada uno de los cuales delimita
        //     un intervalo de posiciones de caracteres dentro de la cadena especificada.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   layoutRect:
        //     Estructura System.Drawing.RectangleF que especifica el rectángulo correspondiente
        //     a la cadena.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat que representa la información de formato, como el
        //     espaciado interlineal.
        //
        // Devuelve:
        //     Este método devuelve una matriz de objetos System.Drawing.Region, cada uno de
        //     los cuales delimita un intervalo de posiciones de caracteres dentro de la cadena
        //     especificada.
        public Region[] MeasureCharacterRanges(string text, Font font, RectangleF layoutRect, StringFormat stringFormat)
        {
            layoutRect.X -= DesplazamientoH;
            layoutRect.Y -= DesplazamientoV;
            return FGraphics.MeasureCharacterRanges(text, font, layoutRect, stringFormat);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font que se indique
        //     y darle formato con el System.Drawing.StringFormat señalado.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   layoutArea:
        //     Estructura System.Drawing.SizeF que especifica el área máxima de presentación
        //     del texto.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat que representa la información de formato, como el
        //     espaciado interlineal.
        //
        //   charactersFitted:
        //     Número de caracteres que contiene la cadena.
        //
        //   linesFilled:
        //     Número de líneas de texto que contiene la cadena.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con los parámetros
        //     font y stringFormat.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled)
        {
            return FGraphics.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font especificada.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de la cadena.
        //
        //   width:
        //     Ancho máximo de la cadena en píxeles.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con el parámetro
        //     font.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font, int width)
        {
            return FGraphics.MeasureString(text, font, width);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font que se indique
        //     y darle formato con el System.Drawing.StringFormat señalado.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   width:
        //     Ancho máximo de la cadena.
        //
        //   format:
        //     System.Drawing.StringFormat que representa la información de formato, como el
        //     espaciado interlineal.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con los parámetros
        //     font y stringFormat.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font, int width, StringFormat format)
        {
            return FGraphics.MeasureString(text, font, width, format);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font que se indique
        //     y darle formato con el System.Drawing.StringFormat señalado.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   origin:
        //     Estructura System.Drawing.PointF que representa la esquina superior izquierda
        //     de la cadena.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat que representa la información de formato, como el
        //     espaciado interlineal.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con los parámetros
        //     font y stringFormat.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font, PointF origin, StringFormat stringFormat)
        {
            return FGraphics.MeasureString(text, font, origin, stringFormat);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font que se indique
        //     y darle formato con el System.Drawing.StringFormat señalado.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   layoutArea:
        //     Estructura System.Drawing.SizeF que especifica el área máxima de presentación
        //     del texto.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat que representa la información de formato, como el
        //     espaciado interlineal.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con los parámetros
        //     font y stringFormat.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat)
        {
            return FGraphics.MeasureString(text, font, layoutArea, stringFormat);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font especificada.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con el parámetro
        //     font.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font)
        {
            return FGraphics.MeasureString(text, font);
        }
        //
        // Resumen:
        //     Mide la cadena especificada al dibujarla con la System.Drawing.Font especificada
        //     dentro del área de presentación indicada.
        //
        // Parámetros:
        //   text:
        //     Cadena que se va a medir.
        //
        //   font:
        //     System.Drawing.Font que define el formato de texto de la cadena.
        //
        //   layoutArea:
        //     Estructura System.Drawing.SizeF que especifica el área máxima de presentación
        //     del texto.
        //
        // Devuelve:
        //     Este método devuelve una estructura System.Drawing.SizeF que representa el tamaño,
        //     en las unidades especificadas por la propiedad System.Drawing.Graphics.PageUnit,
        //     de la cadena especificada por el parámetro text que se dibuja con el parámetro
        //     font.
        //
        // Excepciones:
        //   T:System.ArgumentException:
        //     El valor de font es null.
        public SizeF MeasureString(string text, Font font, SizeF layoutArea)
        {
            return FGraphics.MeasureString(text, font, layoutArea);
        }
        //
        // Resumen:
        //     Multiplica la transformación universal de este System.Drawing.Graphics, según
        //     especifica System.Drawing.Drawing2D.Matrix.
        //
        // Parámetros:
        //   matrix:
        //     System.Drawing.Drawing2D.Matrix de 4x4 que multiplica la transformación universal.
        public void MultiplyTransform(Matrix matrix)
        {
            FGraphics.MultiplyTransform(matrix);
        }
        //
        // Resumen:
        //     Multiplica la transformación universal de este System.Drawing.Graphics, que especifica
        //     System.Drawing.Drawing2D.Matrix siguiendo el orden establecido.
        //
        // Parámetros:
        //   matrix:
        //     System.Drawing.Drawing2D.Matrix de 4x4 que multiplica la transformación universal.
        //
        //   order:
        //     Miembro de la enumeración System.Drawing.Drawing2D.MatrixOrder que determina
        //     el orden de la multiplicación.
        public void MultiplyTransform(Matrix matrix, MatrixOrder order)
        {
            FGraphics.MultiplyTransform(matrix, order);
        }
        //
        // Resumen:
        //     Libera un identificador de contexto de dispositivo obtenido mediante una llamada
        //     anterior al método System.Drawing.Graphics.GetHdc de este System.Drawing.Graphics.
        public void ReleaseHdc()

        {
            FGraphics.ReleaseHdc();
        }
        //
        // Resumen:
        //     Libera un identificador de contexto de dispositivo obtenido mediante una llamada
        //     anterior al método System.Drawing.Graphics.GetHdc de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   hdc:
        //     Identificador de un contexto de dispositivo obtenido mediante una llamada anterior
        //     al método System.Drawing.Graphics.GetHdc de este System.Drawing.Graphics.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void ReleaseHdc(IntPtr hdc)
        {
            FGraphics.ReleaseHdc(hdc);
        }
        //
        // Resumen:
        //     Libera un identificador de un contexto de dispositivo.
        //
        // Parámetros:
        //   hdc:
        //     Identificador de un contexto de dispositivo.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ReleaseHdcInternal(IntPtr hdc)
        {
            FGraphics.ReleaseHdcInternal(hdc);
        }
        //
        // Resumen:
        //     Restablece la región de recorte de este System.Drawing.Graphics en una región
        //     infinita.
        public void ResetClip()
        {
            FGraphics.ResetClip();
        }
        //
        // Resumen:
        //     Restablece la matriz de transformación universal de este System.Drawing.Graphics
        //     en la matriz de identidades.
        public void ResetTransform()
        {
            FGraphics.ResetTransform();
        }
        //
        // Resumen:
        //     Restaura el estado de este System.Drawing.Graphics en el estado representado
        //     por un System.Drawing.Drawing2D.GraphicsState.
        //
        // Parámetros:
        //   gstate:
        //     System.Drawing.Drawing2D.GraphicsState que representa el estado al que se va
        //     a restaurar este System.Drawing.Graphics.
        public void Restore(GraphicsState gstate)
        {
            FGraphics.Restore(gstate);
        }
        //
        // Resumen:
        //     Aplica la rotación especificada a la matriz de transformación de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   angle:
        //     Ángulo de rotación en grados.
        public void RotateTransform(float angle)
        {
            FGraphics.RotateTransform(angle);
        }
        //
        // Resumen:
        //     Aplica la rotación especificada a la matriz de transformación de este System.Drawing.Graphics
        //     en el orden que se establece.
        //
        // Parámetros:
        //   angle:
        //     Ángulo de rotación en grados.
        //
        //   order:
        //     Miembro de la enumeración System.Drawing.Drawing2D.MatrixOrder que especifica
        //     si la rotación se agrega o antepone a la matriz de transformación.
        public void RotateTransform(float angle, MatrixOrder order)
        {
            FGraphics.RotateTransform(angle, order);
        }
        //
        // Resumen:
        //     Guarda el estado actual de este System.Drawing.Graphics e identifica el estado
        //     guardado con un System.Drawing.Drawing2D.GraphicsState.
        //
        // Devuelve:
        //     Este método devuelve un System.Drawing.Drawing2D.GraphicsState que representa
        //     el estado guardado de este System.Drawing.Graphics.
        public GraphicsState Save()
        {
            return FGraphics.Save();
        }
        //
        // Resumen:
        //     Aplica la operación de cambio de escala especificada a la matriz de transformación
        //     de este System.Drawing.Graphics, anteponiéndola a esta última.
        //
        // Parámetros:
        //   sx:
        //     Factor de escala en la dirección x.
        //
        //   sy:
        //     Factor de escala en la dirección y.
        public void ScaleTransform(float sx, float sy)
        {
            FGraphics.ScaleTransform(sx, sy);
        }
        //
        // Resumen:
        //     Aplica la operación de cambio de escala especificada a la matriz de transformación
        //     de este System.Drawing.Graphics en el orden que se establece.
        //
        // Parámetros:
        //   sx:
        //     Factor de escala en la dirección x.
        //
        //   sy:
        //     Factor de escala en la dirección y.
        //
        //   order:
        //     Miembro de la enumeración System.Drawing.Drawing2D.MatrixOrder que especifica
        //     si la transformación de escala se agrega o antepone a la matriz de transformación.
        public void ScaleTransform(float sx, float sy, MatrixOrder order)
        {
            FGraphics.ScaleTransform(sx, sy, order);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el resultado
        //     de la operación que se indica que combina la región de recorte actual y el rectángulo
        //     especificado mediante una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.Rectangle que se va a combinar.
        //
        //   combineMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CombineMode que especifica
        //     la operación de combinación que se usará.
        public void SetClip(Rectangle rect, CombineMode combineMode)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.SetClip(rect, combineMode);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el rectángulo
        //     especificado mediante una estructura System.Drawing.RectangleF.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.RectangleF que representa la nueva región de recorte.
        public void SetClip(RectangleF rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.SetClip(rect);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el resultado
        //     de la operación que se indica que combina la región de recorte actual y el rectángulo
        //     especificado mediante una estructura System.Drawing.RectangleF.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.RectangleF que se va a combinar.
        //
        //   combineMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CombineMode que especifica
        //     la operación de combinación que se usará.
        public void SetClip(RectangleF rect, CombineMode combineMode)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.SetClip(rect, combineMode);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el System.Drawing.Drawing2D.GraphicsPath
        //     especificado.
        //
        // Parámetros:
        //   path:
        //     System.Drawing.Drawing2D.GraphicsPath que representa la nueva región de recorte.
        public void SetClip(GraphicsPath path)
        {
            FGraphics.SetClip(path);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el resultado
        //     de la operación especificada que combina la región de recorte actual y el System.Drawing.Drawing2D.GraphicsPath
        //     especificado.
        //
        // Parámetros:
        //   path:
        //     System.Drawing.Drawing2D.GraphicsPath que se va a combinar.
        //
        //   combineMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CombineMode que especifica
        //     la operación de combinación que se usará.
        public void SetClip(GraphicsPath path, CombineMode combineMode)
        {
            FGraphics.SetClip(path, combineMode);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el resultado
        //     de la operación especificada que combina la región de recorte actual y el System.Drawing.Region
        //     especificado.
        //
        // Parámetros:
        //   region:
        //     System.Drawing.Region que se va a combinar.
        //
        //   combineMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CombineMode que especifica
        //     la operación de combinación que se usará.
        public void SetClip(Region region, CombineMode combineMode)
        {
            FGraphics.SetClip(region, combineMode);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en la propiedad
        //     Clip del System.Drawing.Graphics especificado.
        //
        // Parámetros:
        //   g:
        //     System.Drawing.Graphics del que se va a tomar la nueva región de recorte.
        public void SetClip(Graphics g)
        {
            FGraphics.SetClip(g);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el resultado
        //     de la operación de combinación especificada de la región de recorte actual y
        //     la propiedad System.Drawing.Graphics.Clip del System.Drawing.Graphics indicado.
        //
        // Parámetros:
        //   g:
        //     System.Drawing.Graphics que especifica la región de recorte que se va a combinar.
        //
        //   combineMode:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CombineMode que especifica
        //     la operación de combinación que se usará.
        public void SetClip(Graphics g, CombineMode combineMode)
        {
            FGraphics.SetClip(g, combineMode);
        }
        //
        // Resumen:
        //     Establece la región de recorte de este System.Drawing.Graphics en el rectángulo
        //     especificado mediante una estructura System.Drawing.Rectangle.
        //
        // Parámetros:
        //   rect:
        //     Estructura System.Drawing.Rectangle que representa la nueva región de recorte.
        public void SetClip(Rectangle rect)
        {
            rect.X -= DesplazamientoH;
            rect.Y -= DesplazamientoV;
            FGraphics.SetClip(rect);
        }
        //
        // Resumen:
        //     Transforma una matriz de puntos de un espacio de coordenadas a otro usando las
        //     transformaciones universal y de página actuales de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   destSpace:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CoordinateSpace que especifica
        //     el espacio de coordenadas de destino.
        //
        //   srcSpace:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CoordinateSpace que especifica
        //     el espacio de coordenadas de origen.
        //
        //   pts:
        //     Matriz de estructuras System.Drawing.Point que representa los puntos que se van
        //     a transformar.
        public void TransformPoints(CoordinateSpace destSpace, CoordinateSpace srcSpace, Point[] pts)
        {
            FGraphics.TransformPoints(destSpace, srcSpace,pts);
        }
        //
        // Resumen:
        //     Transforma una matriz de puntos de un espacio de coordenadas a otro usando las
        //     transformaciones universal y de página actuales de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   destSpace:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CoordinateSpace que especifica
        //     el espacio de coordenadas de destino.
        //
        //   srcSpace:
        //     Miembro de la enumeración System.Drawing.Drawing2D.CoordinateSpace que especifica
        //     el espacio de coordenadas de origen.
        //
        //   pts:
        //     Matriz de estructuras System.Drawing.PointF que representa los puntos que se
        //     van a transformar.
        public void TransformPoints(CoordinateSpace destSpace, CoordinateSpace srcSpace, PointF[] pts)
        {
            FGraphics.TransformPoints(destSpace,srcSpace, pts);
        }
        //
        // Resumen:
        //     Traslada la región de recorte de este System.Drawing.Graphics según las magnitudes
        //     especificadas en las direcciones horizontal y vertical.
        //
        // Parámetros:
        //   dx:
        //     Coordenada x de la traslación.
        //
        //   dy:
        //     Coordenada y de la traslación.
        public void TranslateClip(float dx, float dy)
        {
            FGraphics.TranslateClip(dx, dy);
        }
        //
        // Resumen:
        //     Traslada la región de recorte de este System.Drawing.Graphics según las magnitudes
        //     especificadas en las direcciones horizontal y vertical.
        //
        // Parámetros:
        //   dx:
        //     Coordenada x de la traslación.
        //
        //   dy:
        //     Coordenada y de la traslación.
        public void TranslateClip(int dx, int dy)
        {
            FGraphics.TranslateClip(dx, dy);
        }
        //
        // Resumen:
        //     Cambia el origen del sistema de coordenadas aplicando la traslación especificada
        //     a la matriz de transformación de este System.Drawing.Graphics en el orden que
        //     se establece.
        //
        // Parámetros:
        //   dx:
        //     Coordenada x de la traslación.
        //
        //   dy:
        //     Coordenada y de la traslación.
        //
        //   order:
        //     Miembro de la enumeración System.Drawing.Drawing2D.MatrixOrder que especifica
        //     si la traslación se agrega o antepone a la matriz de transformación.
        public void TranslateTransform(float dx, float dy, MatrixOrder order)
        {
            FGraphics.TranslateTransform(dx, dy, order);
        }
        //
        // Resumen:
        //     Cambia el origen del sistema de coordenadas anteponiendo la traslación especificada
        //     a la matriz de transformación de este System.Drawing.Graphics.
        //
        // Parámetros:
        //   dx:
        //     Coordenada x de la traslación.
        //
        //   dy:
        //     Coordenada y de la traslación.
        public void TranslateTransform(float dx, float dy)
        {
            FGraphics.TranslateTransform(dx, dy);
        }
        #endregion
//        public CMapaCuadricula GetMatriz()
  //      {
    //        return Mapa;
      //      
        //}
        public void SetPixel(int x,int y, Color color)
        {
            FBitmap.SetPixel(x,y,color);
        }
        public void AddTabla(DTabla tabla)
        {
            foreach(DTabla obj in tablas)
            {
                if (obj == tabla)
                    return;
            }
            tablas.Add(tabla);
        }
        /// <summary>
        /// verifica si la recta coliciona con alguna tabla excelto la origen y destino
        /// </summary>
        /// <param name="xi"></param>
        /// <param name="yi"></param>
        /// <param name="xf"></param>
        /// <param name="yf"></param>
        /// <param name="id_tablaOrigen"></param>
        /// <param name="id_tablaDestino"></param>
        /// <returns></returns>
        public bool VerificaColicion(int xi, int yi, int xf,int yf, int id_tablaOrigen, int id_tablaDestino)
        {
            foreach(DTabla tabla in tablas)
            {
                if(tabla.ID_Tabla!=id_tablaDestino && tabla.ID_Tabla!=id_tablaOrigen)
                {
                    Point p1 = tabla.DamePosicionReal();
                    Point P2 = new Point(p1.X + tabla.Dimencion.Width, p1.Y + tabla.Dimencion.Height);
                    if(p1.X<=xi && xi<=P2.X && p1.X<=xf && xf <= P2.X && yi<=p1.Y && P2.Y<=yf)
                    {
                        /*    |
                         *  __|__
                         * |  |  |
                         * |  |  |
                         * |__|__|
                         *    |
                         *    |
                         */
                        return true;
                    }
                    if(p1.Y<=yi && yi <=P2.Y && p1.Y <= yf && yf <= P2.Y && xi<=p1.X && P2.X<=xf)
                    {
                        /*     _____
                         *     |    |
                         *  ___|____|____
                         *     |    |
                         *     |____|
                         *     
                         */
                        return true;
                    }
                    if(p1.X<=xi && xi<=P2.X && p1.Y<=yi && yi<=P2.Y)
                    {
                        /*      _____
                         *      |    |
                         *      |  __|___
                         *      |    |
                         *      |__|_|
                         *         |
                       */
                        return true;
                    }
                    if (p1.X <= xf && xf <= P2.X && p1.Y <= yf && yf <= P2.Y)
                    {
                        /*      ___|__
                         *      |  | |
                         *      |  | |
                         *    __|__  |
                         *      |____|
                         *         
                       */
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
