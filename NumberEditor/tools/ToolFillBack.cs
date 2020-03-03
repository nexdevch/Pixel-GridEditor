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
    public class ToolFillBack : ToolItem
    {
        public static Bgra _colorPrimary = new Bgra(255, 255, 255, 255);
        private Point _ptStart;
        private Point _ptStartReal;
        private List<Point> _arrSelCells = new List<Point>();
        
        public ToolFillBack(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;
            
            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseMove += new MouseEventHandler(OnMouseMove);
            imageBox.MouseUp += new MouseEventHandler(OnMouseUp);

            // cursor
            SetCursor(Properties.Resources.fill);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // copy src image
                //_cvImageSrc = ImageProc.GetWorkingImage();
                //_cvImageCpy = _cvImageSrc.Copy();

                // check pt in area
                _ptStart = e.Location;
                _ptStartReal = GetRealPoint(_ptStart);

                //Grid.ConvertTempIntoRealSelection();
                SelectionAreaProc.GetInstance().Fill();
                ImageProc.DrawImage();

            }

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void UnloadMessageHandler()
        {
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
            _imageBox.MouseMove -= new MouseEventHandler(OnMouseMove);
            _imageBox.MouseUp -= new MouseEventHandler(OnMouseUp);
        }
    }
}
