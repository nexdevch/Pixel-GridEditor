using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NumberEditor
{
    
    public class ScaleProc
    {
        private static int _scaleRate = 1;
        public static int ScaleRate
        {
            get { return _scaleRate; }
            set { _scaleRate = value; }
        }

        private static Size _sizeOriginal = new Size(100, 100);
        public static Size SizeOriginal
        {
            get { return _sizeOriginal; }
            set { _sizeOriginal = value; }
        }

        public static Point GetRealPoint(int dispX, int dispY, int scrollX, int scrollY)
        {
            dispX = dispX + scrollX;
            dispY = dispY + scrollY;

            int x = dispX / scrollX;
            int y = dispY / scrollY;

            return new Point(x, y);
        }

    }
}
