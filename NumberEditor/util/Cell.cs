using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NumberEditor
{
    public class Cell
    {
        Point _ptCell;
        public Point PtCell {
            get { return _ptCell; }
            set { _ptCell = value; }
        }

        Bgra _colorCell = new Bgra(255, 255, 255, 255);
        public Bgra ColorCell
        {
            get { return _colorCell; }
            set { _colorCell = value; }
        }

        public Cell(Point pt, Bgra cellColor)
        {
            _ptCell = pt;
            _colorCell = cellColor;
        }
        
        public static Point GetLeftTopPoint(Point ptStart, Point ptEnd)
        {   
            // left top bottom
            int left = ptStart.X;
            int right = ptEnd.X;
            if (left > right)
            {
                left = ptEnd.X;
                right = ptStart.X;
            }

            int top = ptStart.Y;
            int bottom = ptEnd.Y;
            if (top > bottom)
            {
                top = ptEnd.Y;
                bottom = ptStart.Y;
            }

            return new Point(left, top);

        }

        public static Point GetRightBottomPoint(Point ptStart, Point ptEnd)
        {
            // left top bottom
            int left = ptStart.X;
            int right = ptEnd.X;
            if (left > right)
            {
                left = ptEnd.X;
                right = ptStart.X;
            }

            int top = ptStart.Y;
            int bottom = ptEnd.Y;
            if (top > bottom)
            {
                top = ptEnd.Y;
                bottom = ptStart.Y;
            }

            return new Point(right, bottom);

        }

    }
}
