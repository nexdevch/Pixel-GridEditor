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
    public class ToolPencil : ToolItem
    {
        private List<Point> _arrListCell = new List<Point>();
        private Bgra _colorSelection = new Bgra(0, 255, 0, 255);
        private bool _drawing = false;

        Point _ptStart;
        Point _ptStartReal;

        public ToolPencil(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;

            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseMove += new MouseEventHandler(OnMouseMove);
            imageBox.MouseUp += new MouseEventHandler(OnMouseUp);

            // clear selection
            SelectionAreaProc.GetInstance().Clear();
            ImageProc.DrawImage();

            // cursor
            //SetCursor(Properties.Resources.pencil);
            _imageBox.Cursor = Cursors.Arrow;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // get first point

            if (e.Button == MouseButtons.Left)
            {
                _ptStart = e.Location;
                _ptStartReal = GetRealPoint(_ptStart);
                _drawing = true;

                // init
                //Grid.SetTempSelectedCells(null);                

                // copy src int cpy , init drawing
                Point cellPos = Grid.GetCellPosFromPoint(_ptStartReal);
                Cell cell = new Cell(cellPos, Grid.ColorPrimary);
                bool isAdded = Grid.AddSelectedCell(cell);
                if (isAdded)
                {
                    ImageProc.DrawImage();
                }
            }            

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _drawing)
            {
                _ptStart = e.Location;
                _ptStartReal = GetRealPoint(_ptStart);

                // init
                //Grid.SetTempSelectedCells(null);
                SelectionAreaProc.GetInstance().Clear();

                // copy src int cpy , init drawing
                Point cellPos = Grid.GetCellPosFromPoint(_ptStartReal);
                Cell cell = new Cell(cellPos, Grid.ColorPrimary);
                bool isAdded = Grid.AddSelectedCell(cell);                
                if (isAdded)
                {
                    ImageProc.DrawImage();
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _drawing = false;
        }        

        public void UnloadMessageHandler()
        {
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
            _imageBox.MouseMove -= new MouseEventHandler(OnMouseMove);
            _imageBox.MouseUp -= new MouseEventHandler(OnMouseUp);
        }

    }
}
