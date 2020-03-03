using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NumberEditor
{
    public class Grid
    {
        //public static List<Point> _arrSelectedCell = new List<Point>();
        private static List<Cell> _arrSelectedCells = new List<Cell>(); 
        public static List<Cell> ArrSelectedCells
        {
            get { return _arrSelectedCells; }
            set { _arrSelectedCells = value; }
        }

        public static void DrawSelectedCell(Image<Bgra, Byte> cvImage, Point ptCell, Bgra colorBack, int thickness = -1)
        {
            var rect = new Rectangle(new Point(ptCell.X * _sizeGrid.Width, ptCell.Y * _sizeGrid.Height), _sizeGrid);
            cvImage.Draw(rect, colorBack, thickness);
        }

        /// <summary>
        /// primary color
        /// </summary>
        static Bgra _colorPrimary = new Bgra(255, 255, 255, 255);
        static public Bgra ColorPrimary
        {
            get
            {
                return _colorPrimary;
            }
            set
            {
                _colorPrimary = value;
            }
        }
        
        static Bgra _colorGridLine = new Bgra(255, 255, 255, 255);
        static public Bgra ColorGridLine
        {
            get
            {
                return _colorGridLine;
            }
            set
            {
                _colorGridLine = value;
            }
        }

        public static void Initialize()
        {
            _arrSelectedCells.Clear();            
        }

        private static Size _sizeGrid = new Size(10, 10);
        public static Size SizeGrid
        {
            get
            {
                return _sizeGrid;
            }
            set
            {
                _sizeGrid = value;
            }
        }

        private static Size _sizeGridOriginal;
        public static Size SizeGridOriginal
        {
            get { return _sizeGridOriginal; }
            set { _sizeGridOriginal = value; }
        }

        public static bool _visibleGrid = true;
        public static bool VisibleGrid
        {
            get
            {
                return _visibleGrid;
            }
            set
            {
                _visibleGrid = value;
            }
        }

        
        public static Image<Bgra, Byte> DrawGrid(Image<Bgra, Byte> cvImage)
        {
            Image<Bgra, Byte> cvImageGrid = DrawGrid(cvImage, _visibleGrid);
            return cvImageGrid;
        }

        public static Image<Bgra, Byte> DrawGrid(Image<Bgra, Byte> cvImage, Boolean visibleGrid)
        {
            Image<Bgra, Byte> cvImageGrid = cvImage;//.Copy();

            // draw background

            // draw cell selected by user
            cvImageGrid = DrawGridCellWithTransparancy(cvImageGrid, _sizeGrid);
            //cvImageGrid = DrawGridCellByDot(cvImageGrid, _sizeGrid);

            // grid line
            if (visibleGrid)
            {
                LineSegment2D line;
                // draw column
                for (int i = 0; i <= cvImageGrid.Width; i += _sizeGrid.Width)
                {
                    line = new LineSegment2D(new Point(i, 0), new Point(i, cvImageGrid.Height));
                    cvImageGrid.Draw(line, _colorGridLine, 1);
                }

                for (int i = 0; i <= cvImageGrid.Height; i += _sizeGrid.Height)
                {
                    line = new LineSegment2D(new Point(0, i), new Point(cvImageGrid.Width, i));
                    cvImageGrid.Draw(line, _colorGridLine, 1);
                }

                // outline
                var rect = new Rectangle(new Point(0, 0), new Size(cvImageGrid.Width - 1, cvImageGrid.Height - 1));
                cvImageGrid.Draw(rect, _colorGridLine, 1);
            }

            return cvImageGrid;
        }

        public static Image<Bgra, Byte> DrawGridCell(Image<Bgra, Byte> cvImage, Size sizeGrid)
        {
            for (int i = 0; i < _arrSelectedCells.Count; i++)
            {
                Point pt = _arrSelectedCells[i].PtCell;
                Image<Bgra, Byte> cvCell = new Image<Bgra, byte>(sizeGrid.Width, sizeGrid.Height, _arrSelectedCells[i].ColorCell);
                int x = pt.X * sizeGrid.Width;
                int y = pt.Y * sizeGrid.Height;
                var rect = new Rectangle(new Point(x, y), _sizeGrid);
                //cvImage.Draw(rect, _colorPrimary, -1);

                // copy ROI
                cvImage.ROI = new Rectangle(x, y, rect.Width, rect.Height);
                cvCell.CopyTo(cvImage);
                cvImage.ROI = Rectangle.Empty;
            }

            return cvImage;
        }

        public static Image<Bgra, Byte> DrawGridCellWithTransparancy(Image<Bgra, Byte> cvImage, Size sizeGrid)
        {
            // draw cell selected by user
            for (int i = 0; i < _arrSelectedCells.Count; i++)
            {
                Point pt = _arrSelectedCells[i].PtCell;
                Bgra colorCell = _arrSelectedCells[i].ColorCell;
                Image<Bgra, Byte> cvCell = new Image<Bgra, byte>(sizeGrid.Width, sizeGrid.Height, colorCell);

                float transparancy = (float)colorCell.Alpha;
                float alpha = transparancy / 255.0f;
                float beta = 1 - alpha;

                int x = pt.X * sizeGrid.Width;
                int y = pt.Y * sizeGrid.Height;
                var rect = new Rectangle(new Point(x, y), _sizeGrid);

                Image<Bgra, Byte> roi = cvImage.GetSubRect(new Rectangle(x, y, _sizeGrid.Width, _sizeGrid.Height));
                //Image<Bgra, Byte> roi = cvImage.GetSubRect(new Rectangle(100, 100, 50, 50));
                CvInvoke.AddWeighted(cvCell, alpha, roi, beta, 0, roi);
            }

            return cvImage;
        }

        public static Image<Bgra, Byte> DrawGridCellByDot(Image<Bgra, Byte> cvImage, Size sizeGrid)
        {
            Image<Bgra, Byte> cvImageGrid = cvImage;//.Copy();            

            // draw cell selected by user
            for (int i = 0; i < _arrSelectedCells.Count; i++)
            {
                //Get: Bgr PixelColor = Img[y, x];
                //Set: Img[y, x] = new Bgr(255, 0, 0);

                // fast
                //Img.Data[y, x, 0] = 255;
                //Img.Data[y, x, 1] = 0;
                //Img.Data[y, x, 2] = 0;

                Point pt = _arrSelectedCells[i].PtCell;
                Bgra colorCell = _arrSelectedCells[i].ColorCell;

                for (int j = 0; j < sizeGrid.Width; j++)
                {
                    for (int k = 0; k < sizeGrid.Height; k++)
                    {
                        int x = pt.X * sizeGrid.Width + j;
                        int y = pt.Y * sizeGrid.Height + k;

                        if (x >= cvImageGrid.Width || y >= cvImageGrid.Height)
                            continue;

                        if (x < 0 || y < 0)
                            continue;

                        //cvImageGrid[y, x] = _colorPrimary;

                        cvImageGrid.Data[y, x, 0] = (byte)((cvImageGrid.Data[y, x, 0] * (255- colorCell.Alpha) + colorCell.Blue * colorCell.Alpha) / 255);
                        cvImageGrid.Data[y, x, 1] = (byte)((cvImageGrid.Data[y, x, 1] * (255 - colorCell.Alpha) + colorCell.Green * colorCell.Alpha) / 255);
                        cvImageGrid.Data[y, x, 2] = (byte)((cvImageGrid.Data[y, x, 2] * (255 - colorCell.Alpha) + colorCell.Red * colorCell.Alpha) / 255);
                        //cvImageGrid.Data[y, x, 3] = (byte)_colorPrimary.Alpha;
                    }
                }                
            }

            return cvImageGrid;
        }

        public static Point GetCellPosFromPoint(Point point)
        {
            // convert the point into cell pos
            int x = point.X / _sizeGrid.Width;
            int y = point.Y / _sizeGrid.Height;


            // add the cell into list
            Point posCell = new Point(x, y);

            return posCell;
        }
        
        // return true if removed
        public static bool RemoveSelectedCell(Point point)
        {            
            for (int i = 0; i < _arrSelectedCells.Count; i++)
            {
                Point item = _arrSelectedCells[i].PtCell;
                if (item.Equals(point))
                {
                    _arrSelectedCells.RemoveAt(i);
                    return true;
                }
            }

            return false;
            
        }

        // return true if added
        public static bool AddSelectedCell(Cell cell)
        {
            Point ptCell = cell.PtCell;
            Bgra colorCell = cell.ColorCell;
            int x = ptCell.X;
            int y = ptCell.Y;
            // check if point is in image
            Size imageMain = ImageProc.SizeImageMain;
            if (x >= imageMain.Width / _sizeGrid.Width || y >= imageMain.Height / _sizeGrid.Height)
            {
                return false;
            }

            if (x < 0 || y < 0)
                return false;
                        
            for (int i = 0; i < _arrSelectedCells.Count; i++)
            {
                Point item = _arrSelectedCells[i].PtCell;
                if (item.Equals(ptCell))
                {
                    _arrSelectedCells[i].ColorCell = colorCell;
                    return false;
                } 
            }

            // new pos
            _arrSelectedCells.Add(cell);

            return true;
        }

        public static void ClearCells()
        {
            _arrSelectedCells.Clear();
        }


    }
}
