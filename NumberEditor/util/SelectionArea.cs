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
    public enum POINT_TYPE
    {
        NONE = 0,
        LEFT_TOP,
        LEFT_BOTTOM,
        RIGHT_TOP,
        RIGHT_BOTTOM
    }

    public class SelectionArea
    {
        public List<Point> _arrCells = new List<Point>();
        public ImageBox _imageBox;
        
        bool _selected = false;
        public bool Selected
        {
            get{ return _selected;}
            set{_selected = value;}
        }

        private Bgra _colorPrimary = new Bgra(0, 255, 0, 255);
        public Bgra ColorPrimary
        {
            get { return _colorPrimary; }
            set { _colorPrimary = value; }
        }

        private Point _ptLeftTop = Point.Empty;
        public Point PtLeftTop
        {
            get { return _ptLeftTop; }
            set { _ptLeftTop = value; }
        }

        private Point _ptRightBottom = Point.Empty;
        public Point PtRightBottom
        {
            get { return _ptRightBottom; }
            set { _ptRightBottom = value; }
        }

        private POINT_TYPE _pointType = POINT_TYPE.NONE;

        public SelectionArea(ImageBox imageBox)
        {
            _imageBox = imageBox;
        }

        public POINT_TYPE CheckPointType(Point pt)
        {
            int limit = 5;
            int diff = DiffPoints(_ptLeftTop, pt);
            if (diff < limit)
            {
                _pointType = POINT_TYPE.LEFT_TOP;
                _imageBox.Cursor = Cursors.SizeNWSE;
                return POINT_TYPE.LEFT_TOP;
            }

            // left bottom
            diff = DiffPoints(new Point(_ptLeftTop.X, _ptRightBottom.Y), pt);
            if (diff < limit)
            {
                _pointType = POINT_TYPE.LEFT_BOTTOM;
                _imageBox.Cursor = Cursors.SizeNESW;
                return POINT_TYPE.LEFT_BOTTOM;
            }

            // right top
            diff = DiffPoints(new Point(_ptRightBottom.X, _ptLeftTop.Y), pt);
            if (diff < limit)
            {
                _pointType = POINT_TYPE.RIGHT_TOP;
                _imageBox.Cursor = Cursors.SizeNESW;
                return POINT_TYPE.RIGHT_TOP;
            }

            // right bottom
            diff = DiffPoints(new Point(_ptRightBottom.X, _ptRightBottom.Y), pt);
            if (diff < limit)
            {
                _pointType = POINT_TYPE.RIGHT_BOTTOM;
                _imageBox.Cursor = Cursors.SizeNWSE;
                return POINT_TYPE.RIGHT_BOTTOM;
            }

            _imageBox.Cursor = Cursors.Arrow;
            return POINT_TYPE.NONE;
        }

        private int DiffPoints(Point pt1, Point pt2)
        {
            int diff = Math.Abs(pt1.X - pt2.X) + Math.Abs(pt1.Y - pt2.Y);
            return diff;
        }

        public void Clear()
        {
            //_arrCells.Clear();
        }

        public bool IsInRect(Point pt)
        {
            if (_ptLeftTop.IsEmpty || _ptRightBottom.IsEmpty)
            {
                return false;
            }

            Rectangle rectangle = new Rectangle(_ptLeftTop.X, _ptLeftTop.Y, _ptRightBottom.X - _ptLeftTop.X, _ptRightBottom.Y - _ptLeftTop.Y);

            if (rectangle.Contains(pt))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Image<Bgra, Byte> DrawSelectRect(Image<Bgra, Byte> cvImage)
        {
            int w = _ptRightBottom.X - _ptLeftTop.X ;
            int h = _ptRightBottom.Y - _ptLeftTop.Y ;
            Rectangle rectangle = new Rectangle(_ptLeftTop.X, _ptLeftTop.Y, w, h);
            /*Rectangle rectangle = new Rectangle(new Point(ptCellLeftTop.X * Grid.SizeGrid.Width, ptCellLeftTop.Y * Grid.SizeGrid.Height),
                                    new Size((ptCellRightBottom.X - ptCellLeftTop.X + 1) * Grid.SizeGrid.Width, (ptCellRightBottom.Y - ptCellLeftTop.Y + 1) * Grid.SizeGrid.Height));
            */
            cvImage.Draw(rectangle, _colorPrimary, 1);

            return cvImage;
        }        

        public void SetDrawSelectRect(Image<Bgra, Byte> cvImage, Point pt)
        {
            if (_ptLeftTop.IsEmpty)
            {
                _ptLeftTop = pt;
            }

            _ptRightBottom = pt;

            DrawSelectRect(cvImage);
        }

        public void SetResizeSelectRect(Image<Bgra, Byte> cvImage, Point pt)
        {
            if (_pointType == POINT_TYPE.LEFT_TOP)
            {
                _ptLeftTop = pt;
            } else if (_pointType == POINT_TYPE.LEFT_BOTTOM)
            {
                _ptLeftTop.X = pt.X;
                _ptRightBottom.Y = pt.Y;
            } else if (_pointType == POINT_TYPE.RIGHT_TOP)
            {
                _ptLeftTop.Y = pt.Y;
                _ptRightBottom.X = pt.X;
            } else if (_pointType == POINT_TYPE.RIGHT_BOTTOM)
            {
                _ptRightBottom = pt;
            }

            DrawSelectRect(cvImage);
        }

        /*
        public void AddCellPos()
        {
            _arrCells.Clear();

            Point cellPosLeftTop = Grid.GetCellPosFromPoint(_ptLeftTop);
            Point cellPosRightBottom = Grid.GetCellPosFromPoint(_ptRightBottom);

            for (int i = cellPosLeftTop.X; i <= cellPosRightBottom.X; i++)
            {
                for (int j = cellPosLeftTop.Y; j <= cellPosRightBottom.Y; j++)
                {
                    //Point cellPos = Grid.GetCellPosFromPoint(new Point(i, j));
                    _arrCells.Add(new Point(i, j));
                }
            }

        }*/

        public List<Point> GetCells()
        {
            _arrCells.Clear();

            Point cellPosLeftTop = Grid.GetCellPosFromPoint(_ptLeftTop);
            Point cellPosRightBottom = Grid.GetCellPosFromPoint(_ptRightBottom);

            for (int i = cellPosLeftTop.X; i < cellPosRightBottom.X; i++)
            {
                for (int j = cellPosLeftTop.Y; j < cellPosRightBottom.Y; j++)
                {
                    //Point cellPos = Grid.GetCellPosFromPoint(new Point(i, j));
                    _arrCells.Add(new Point(i, j));
                }
            }

            return _arrCells;
        }

    }
}
