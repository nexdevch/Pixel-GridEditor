using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public class ToolMagnifier : ToolItem
    {
        double _zoomDelta = 0.1f;
        double _zoomMini = 0.4f;
        public ToolMagnifier(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;

            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseWheel += new MouseEventHandler(OnMouseWheel);

            // cursor
            SetCursor(Properties.Resources.magnifier);
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            _imageBox.FunctionalMode = ImageBox.FunctionalModeOption.PanAndZoom;

            double zoomDelta = _zoomDelta;

            if (e.Delta < 0)
            {
                zoomDelta = 0 - _zoomDelta;                
            }

            double temp = _imageBox.ZoomScale + zoomDelta;
            if (temp < _zoomMini)
                temp = _zoomMini;
            _imageBox.SetZoomScale(temp, new Point(_imageBox.Width / 2, _imageBox.Height / 2));
            _imageBox.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                Point point = e.Location;
                Point ptReal = GetRealPoint(point);
                _imageBox.FunctionalMode = ImageBox.FunctionalModeOption.PanAndZoom;

                double temp = _imageBox.ZoomScale + _zoomDelta;
                _imageBox.SetZoomScale(temp, ptReal);
                _imageBox.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
            }
        }

        public void UnloadMessageHandler()
        {
            _imageBox.MouseWheel -= new MouseEventHandler(OnMouseWheel);
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
        }


    }
}
