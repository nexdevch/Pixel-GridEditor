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
    public class ToolResizeBack : ToolItem
    {
        private bool _resizing = false;
        private List<Point> _arrListCell = new List<Point>();
        private Bgra _colorSelection = new Bgra(0, 255, 0, 255);
        private Point _ptLeftTop;
        private bool _isResizable = false;
        
        public ToolResizeBack(ImageBox imageBox, RadioButton radioButton)
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
            //_imageBox.Cursor = Cursors.SizeNWSE;
            _imageBox.Cursor = Cursors.Arrow;
            _ptLeftTop = new Point(BackProc.RectImageMain.Left, BackProc.RectImageMain.Top);
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
            _arrListCell.Clear();
            //Grid.SetTempSelectedCells(null);
            SelectionAreaProc.GetInstance().Clear();            
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // get the left top point of back image            
            if (_isResizable)
            {                
                _resizing = true;
                _imageBox.Cursor = Cursors.SizeNWSE;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _resizing)
            {
                // get last point
                _ptEnd = e.Location;
                _ptEndReal = GetRealPoint(_ptEnd);

                int width = _ptEndReal.X - _ptLeftTop.X;
                int height = _ptEndReal.Y - _ptLeftTop.Y;
                if (width < 10 || height < 10)
                {
                    return;
                }

                // resize of backimage
                BackProc.SizeBack = new Size(width, height);
                ImageProc.DrawImage();
            } else
            {
                int right = _ptLeftTop.X + BackProc.GetCopyImage().Width;
                int bottom = _ptLeftTop.Y + BackProc.GetCopyImage().Height;
                Point ptRightBottom = new Point(right, bottom);
                
                _ptEnd = e.Location;
                _ptEndReal = GetRealPoint(_ptEnd);
                bool isNear = IsNearPoint(ptRightBottom, _ptEndReal);

                if (isNear)
                {
                    _isResizable = true;
                    _imageBox.Cursor = Cursors.SizeNWSE;
                } else
                {
                    _isResizable = false;
                    _imageBox.Cursor = Cursors.Arrow;
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _resizing)
            {
                SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
                settingInfo.BackWidth = BackProc.GetCopyImage().Width;
                settingInfo.BackHeight = BackProc.GetCopyImage().Height;

                ToolManager.GetInstance().SetSettingInfo(settingInfo);
            }

            _resizing = false;
            _imageBox.Cursor = Cursors.Arrow;
        }

        public void UnloadMessageHandler()
        {
            _imageBox.MouseDown -= new MouseEventHandler(OnMouseDown);
            _imageBox.MouseMove -= new MouseEventHandler(OnMouseMove);
            _imageBox.MouseUp -= new MouseEventHandler(OnMouseUp);
        }

        private bool IsNearPoint(Point ptTartget, Point ptCur)
        {
            int x = ptTartget.X - ptCur.X;
            int y = ptTartget.Y - ptCur.Y;

            x = x * x;
            y = y * y;

            if (x + y < 32)
            {
                return true;
            }

            return false;
        }



    }
}
