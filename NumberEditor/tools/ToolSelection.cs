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
    public class ToolSelection : ToolItem
    {
        private bool _drawing = false;
        private bool _resizing = false;        
        private Bgra _colorSelection = new Bgra(0, 255, 0, 255);
        private SelectionArea _selectionArea;
        private POINT_TYPE _pointType = POINT_TYPE.NONE;
        private int index = 0;

        public ToolSelection(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;
            _selectionArea = new SelectionArea(imageBox);

            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseMove += new MouseEventHandler(OnMouseMove);
            imageBox.MouseUp += new MouseEventHandler(OnMouseUp);

            // cursor
            _imageBox.Cursor = Cursors.Cross;            
        }

        Point _ptStart;
        public Point PtStart
        {
            get
            {
                return _ptStart;
            }
            set
            {
                _ptStart = value;
            }
        }

        Point _ptEnd;
        public Point PtEnd
        {
            get
            {
                return _ptEnd;
            }
            set
            {
                _ptEnd = value;
            }
        }

        Point _ptStartReal;
        public Point PtStartReal
        {
            get
            {
                return GetRealPoint(_ptStart);
            }
            set
            {
                _ptStartReal = value;
            }
        }

        Point _ptEndReal;
        public Point PtEndReal
        {
            get
            {
                return GetRealPoint(_ptEndReal);
            }
            set
            {
                _ptEndReal = value;
            }
        }

        private void InitSelection()
        {
            _selectionArea.Clear();
            //Grid.SetTempSelectedCells(null);
            if (!SelectionAreaProc.GetInstance().IsPressedCtrl)
            {
                SelectionAreaProc.GetInstance().Clear();
            }            
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // get first point
            _ptStart = e.Location;
            _ptStartReal = GetRealPoint(_ptStart);
            _ptEnd = _ptStart;
            _ptEndReal = _ptStartReal;

            // copy src int cpy , init drawing
            _cvImageSrc = ImageProc.GetWorkingImage();
            _cvImageCpy = _cvImageSrc.Copy();

            if (_cvImageSrc == null)
            {
                _drawing = false;
                return;
            }

            _pointType = SelectionAreaProc.GetInstance().CheckPointType(_ptStartReal);            
            if (_pointType == POINT_TYPE.NONE)
            {
                bool isInRect = SelectionAreaProc.GetInstance().IsInRect(_ptStartReal);
                if (!isInRect)
                {
                    // new selection area
                    InitSelection();
                    _selectionArea = new SelectionArea(_imageBox);
                    //SelectionAreaProc.GetInstance().AddSelectionArea(_selectionArea);

                    _drawing = true;
                    _resizing = false;
                    _selectionArea.PtLeftTop = _ptStartReal;
                }
                else
                {
                    // inside rectangel
                    InitSelection();
                    _drawing = false;
                    _resizing = false;
                }
               
            }
            else
            {
                // resize
                _selectionArea = SelectionAreaProc.GetInstance().GetCurSelectionArea();
                
                _drawing = false;
                _resizing = true;
            }
            

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // get last point
            _ptEnd = e.Location;
            _ptEndReal = GetRealPoint(_ptEnd);

            if (e.Button == MouseButtons.Left && _drawing)
            {
                // init image
                _cvImageCpy = _cvImageSrc.Copy();                

                // draw rectangle
                _selectionArea.SetDrawSelectRect(_cvImageCpy, _ptEndReal);
                SelectionAreaProc.GetInstance().DrawSelectRect(_cvImageCpy);
                Invalidate();
            } else if (e.Button == MouseButtons.Left && _resizing) {
                _cvImageCpy = _cvImageSrc.Copy();
                
                _selectionArea.SetResizeSelectRect(_cvImageCpy, _ptEndReal);
                SelectionAreaProc.GetInstance().DrawSelectRect(_cvImageCpy);
                Invalidate();
            } else
            {
                _pointType = SelectionAreaProc.GetInstance().CheckPointType(_ptEndReal);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _ptEnd = e.Location;
            _ptEndReal = GetRealPoint(_ptEnd);
            
            if (e.Button == MouseButtons.Left && (_drawing || _resizing))
            { 
                if (_drawing)
                {
                    // check move
                    if (IsMoved(_ptStartReal, _ptEndReal) == false)
                    {
                        return;
                    }                                        
                } 

                modifySelectionSizeByGrid();                
                //_selectionArea.AddCellPos();
                SelectionAreaProc selectionAreaProc = SelectionAreaProc.GetInstance();
                selectionAreaProc.AddSelectionArea(_selectionArea);

                
                
            }
            // draw selection part
            _cvImageCpy = _cvImageSrc.Copy();
            SelectionAreaProc.GetInstance().DrawSelectRect(_cvImageCpy);
            Invalidate();

            _drawing = false;
            
        }

        private void modifySelectionSizeByGrid()
        {
            // get all point in rectangle
            Point cellPosLeftTop = Grid.GetCellPosFromPoint(_selectionArea.PtLeftTop);
            Point cellPosRightBottom = Grid.GetCellPosFromPoint(_selectionArea.PtRightBottom);
            Point ptRightBottom = _selectionArea.PtRightBottom;

            _selectionArea.PtLeftTop = new Point(cellPosLeftTop.X * Grid.SizeGrid.Width, cellPosLeftTop.Y * Grid.SizeGrid.Height);
            _selectionArea.PtRightBottom = new Point(cellPosRightBottom.X * Grid.SizeGrid.Width, cellPosRightBottom.Y * Grid.SizeGrid.Height);

            // if right bottom size is placed between grids
            
            int resultX = _selectionArea.PtRightBottom.X;
            int resultY = _selectionArea.PtRightBottom.Y;

            if (cellPosRightBottom.X * Grid.SizeGrid.Width != ptRightBottom.X)
            {
                resultX += Grid.SizeGrid.Width;
            }

            if (cellPosRightBottom.Y * Grid.SizeGrid.Height != ptRightBottom.Y)
            {
                resultY += Grid.SizeGrid.Height;
            }

            _selectionArea.PtRightBottom = new Point(resultX, resultY);

        }

        private bool IsMoved(Point pt1, Point pt2)
        {
            int diffX = Math.Abs(pt1.X - pt2.X);
            int diffY = Math.Abs(pt1.Y - pt2.Y);

            if (diffX * 2 < Grid.SizeGrid.Width)
            {
                return false;
            } 

            if (diffY * 2 < Grid.SizeGrid.Height)
            {
                return false;
            }

            return true;
        }

        /*
        private void AddTempSelectedCells(Point point)
        {
            // get cell pos
            for (int i = 0; i < _arrListCell.Count; i++)
            {
                Point item = _arrListCell[i];
                if (item.Equals(point))
                {
                    return;
                }
            }

            // new pos
            _arrListCell.Add(point);
        }*/

        private void DrawSelectRect()
        {            
            var rect = new Rectangle(_ptStartReal, new Size(_ptEndReal.X - _ptStartReal.X, _ptEndReal.Y - _ptStartReal.Y));
            //var rect = new Rectangle(new Point(100, 100), new Size(100,100));
            _cvImageCpy.Draw(rect, _colorSelection, 1);
        }

        private void DrawSelectionCell()
        {
            Point ptLeftTop = Cell.GetLeftTopPoint(_ptStartReal, _ptEndReal);
            Point ptRightBottom = Cell.GetRightBottomPoint(_ptStartReal, _ptEndReal);

            // draw rectangle
            Point ptCellLeftTop = Grid.GetCellPosFromPoint(ptLeftTop);
            Point ptCellRightBottom = Grid.GetCellPosFromPoint(ptRightBottom);

            // clear old screen
            _cvImageCpy = _cvImageSrc.Copy();
            Invalidate();

            // draw selection
            Rectangle rect = new Rectangle(new Point(ptCellLeftTop.X * Grid.SizeGrid.Width, ptCellLeftTop.Y * Grid.SizeGrid.Height),
                                    new Size((ptCellRightBottom.X - ptCellLeftTop.X + 1) * Grid.SizeGrid.Width, (ptCellRightBottom.Y - ptCellLeftTop.Y + 1) * Grid.SizeGrid.Height));
            _cvImageCpy.Draw(rect, _colorSelection, 1);

        }

        public void UnloadMessageHandler()
        {
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
            _imageBox.MouseMove -= new MouseEventHandler(OnMouseMove);
            _imageBox.MouseUp -= new MouseEventHandler(OnMouseUp);
        }



    }
}
