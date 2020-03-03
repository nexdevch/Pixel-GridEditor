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
    public class ToolFill : ToolItem
    {
        public static Bgra _colorPrimary = new Bgra(255, 255, 255, 255);
        private Point _ptStart;
        private Point _ptStartReal;
        private List<Point> _arrSelCells = new List<Point>();
        
        public ToolFill(ImageBox imageBox, RadioButton radioButton)
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

        private void DrawSelectionCell()
        {
            //Point ptLeftTop = Cell.GetLeftTopPoint(_ptStartReal, _ptEndReal);
            //Point ptRightBottom = Cell.GetRightBottomPoint(_ptStartReal, _ptEndReal);

            // draw rectangle
            //var rect = new Rectangle(ptLeftTop, new Size(ptRightBottom.X - ptLeftTop.X, ptRightBottom.Y - ptLeftTop.Y));
            //_cvImageCpy.Draw(rect, _selectionColor, 1);
            for (int i = 0; i < _arrSelCells.Count; i++)
            {
                Grid.DrawSelectedCell(_cvImageCpy, _arrSelCells[i], _colorPrimary);
            }

        }

        public void UnloadMessageHandler()
        {
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
            _imageBox.MouseMove -= new MouseEventHandler(OnMouseMove);
            _imageBox.MouseUp -= new MouseEventHandler(OnMouseUp);
        }
    }
}
