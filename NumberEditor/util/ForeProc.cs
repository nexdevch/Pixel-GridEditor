using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NumberEditor.util
{
    public class ForeProc
    {
        private static Bgra _colorPrimary;
        public static Bgra ColorPrimary
        {
            get { return _colorPrimary; }
            set { _colorPrimary = value; }
        }

        public static Image<Bgra, Byte> DrawForeground(Image<Bgra, Byte> cvImage)
        {
            if (cvImage == null)
                return null;

            var rect = new Rectangle(new Point(0, 0), new Size(cvImage.Width - 1, cvImage.Height - 1));
            cvImage.Draw(rect, _colorPrimary, -1);

            return cvImage;
        }
    }
}
