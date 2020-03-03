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
    public class ToolEraser : ToolItem
    {
        private List<Point> _arrListCell = new List<Point>();
        //private Bgra _colorSelection = new Bgra(0, 255, 0, 255);
        private bool _drawing = false;
        //private Image<Bgra, Byte> _cvStoredImage;
        private Bgra _colorSelection = new Bgra(0, 255, 0, 255);

        Point _ptStart;
        Point _ptStartReal;
        Size _eraserSize = new Size(1, 1);

        public ToolEraser(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;

            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseMove += new MouseEventHandler(OnMouseMove);
            imageBox.MouseUp += new MouseEventHandler(OnMouseUp);
            imageBox.MouseLeave += new System.EventHandler(OnMouseLeave);

            // cursor
            SetCursor(Properties.Resources.erase);

            //_cvStoredImage = (Image<Bgra, Byte>)_imageBox.Image;            

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            GetEraserSize();

            // get first point
            if (e.Button == MouseButtons.Left)
            {
                // remove temp selected cells
                bool result = SelectionAreaProc.GetInstance().Erase();
                if (result)
                {
                    ImageProc.DrawImage();                    
                    return;
                }

                _ptStart = e.Location;
                _ptStartReal = GetRealPoint(_ptStart);
                _drawing = true;
                               

                // copy src int cpy , init drawing
                Point cellPos = Grid.GetCellPosFromPoint(_ptStartReal);
                bool isRemoved = removeSelectedCell(cellPos);
                
                if (isRemoved)
                {
                    ImageProc.DrawImage();                    
                }
            }

        }        

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            GetEraserSize();
            _ptStart = e.Location;           

            if (e.Button == MouseButtons.Left && _drawing)
            {
                _ptStartReal = GetRealPoint(_ptStart);
                Point cellPos = Grid.GetCellPosFromPoint(_ptStartReal);

                // init
                //Grid.SetTempSelectedCells(null);
                SelectionAreaProc.GetInstance().Clear();

                // copy src int cpy , init drawing                
                bool isRemoved = removeSelectedCell(cellPos);
                if (isRemoved)
                {
                    ImageProc.DrawImage();                    
                }
            }  else
            {
                _cvImageCpy = ImageProc.GetWorkingImage().Copy();
                _imageBox.Image = _cvImageCpy;
                DrawSelectRect(_cvImageCpy, _ptStart);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _drawing = false;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {

            _imageBox.Image = ImageProc.GetWorkingImage();
            //_cvImageCpy = _cvStoredImage.Copy();
            //DrawSelectRect(_cvImageCpy, _ptStart);
        }

        public void UnloadMessageHandler()
        {
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
            _imageBox.MouseMove -= new MouseEventHandler(OnMouseMove);
            _imageBox.MouseUp -= new MouseEventHandler(OnMouseUp);
            _imageBox.MouseLeave -= new System.EventHandler(OnMouseLeave);
        }

        private void GetEraserSize()
        {
            SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
            _eraserSize = new Size(settingInfo.EraserWidth, settingInfo.EraserHeight);
        }

        private void DrawSelectRect(Image<Bgra, Byte> cvImage , Point ptCur)        {

            // make the ptCur into center
            Point ptReal = GetRealPoint(ptCur);
            //Point cellPos = Grid.GetCellPosFromNearPoint(ptReal);
            Point cellPos = Grid.GetCellPosFromPoint(ptReal);
            int eraseW = _eraserSize.Width / 2;
            int eraseH = _eraserSize.Height / 2;

            var rect = new Rectangle((cellPos.X - eraseW) * Grid.SizeGrid.Width, 
                                    (cellPos.Y -eraseH) * Grid.SizeGrid.Height, 
                                    (_eraserSize.Width )* Grid.SizeGrid.Width,
                                    (_eraserSize.Height) * Grid.SizeGrid.Height);
            //rect = new Rectangle(new Point(100, 100), new Size(100,100));
            cvImage.Draw(rect, _colorSelection, 1);
            _imageBox.Image = cvImage;
        }

        private bool removeSelectedCell(Point cellPos)
        {
            bool isRemoved = false;
            int eraseW = _eraserSize.Width / 2;
            int eraseH = _eraserSize.Height / 2;

            // erase by size
            for (int i = 0 - eraseW; i < _eraserSize.Width - eraseW; i++)
            {
                for (int j = 0 - eraseH; j < _eraserSize.Height - eraseH; j++)
                {
                    bool oneRemove = Grid.RemoveSelectedCell(new Point(cellPos.X + i, cellPos.Y + j));
                    if (oneRemove)
                    {
                        isRemoved = true;
                    }
                }
            }

            return isRemoved;
        }


    }
}
