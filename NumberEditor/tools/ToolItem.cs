using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public class ToolItem
    {
        public ImageBox _imageBox;
        public RadioButton _radioBtn;
        public Image<Bgra, Byte> _cvImageSrc;
        public Image<Bgra, Byte> _cvImageCpy;

        public void SetRadioButton(RadioButton radioButton)
        {
            _radioBtn = radioButton;
        }

        public void SetImageBox(ImageBox imageBox)
        {
            _imageBox = imageBox;
        }

        public ToolItem() {

        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        Point _ptView = new Point(0, 0);
        public Point PtView 
        {
            get
            {
                return _ptView;
            }
            set
            {
                _ptView = value;
            }
        }

        Point _ptReal = new Point(0, 0);
        public Point PtReal
        {
            get
            {
                return GetRealPoint(_ptView);
            }
            set
            {
                _ptReal = value;
            }
        }

        /// <summary>
        /// get the position without zoom and scroll move
        /// </summary>
        /// <returns></returns>
        public Point GetRealPoint(Point point)
        {
            double zoomScale = _imageBox.ZoomScale;
            double diffX = _imageBox.HorizontalScrollBar.Value;
            double diffY = _imageBox.VerticalScrollBar.Value;
            double x = (double)(point.X) / zoomScale + diffX;
            double y = (double)(point.Y) / zoomScale + diffY;

            Point result = new Point((int)x, (int)y);
            
            return result;
        }

        public void Invalidate()
        {
            _imageBox.Image = _cvImageCpy;
        }

        public void SetCursor(Image image)
        {
            if (_imageBox != null)
            {
                Bitmap bitmap = new Bitmap(image, 30, 30);
                Icon icono = Icon.FromHandle(bitmap.GetHicon());
                _imageBox.Cursor = new Cursor(icono.Handle);
            }
            
        }


    }
}
