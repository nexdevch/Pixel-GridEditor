using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public class ToolHand : ToolItem
    {

        private bool _drawing = false;
        Point _ptStart;
        Point _ptStartReal;

        public ToolHand(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;

            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseMove += new MouseEventHandler(OnMouseMove);
            imageBox.MouseUp += new MouseEventHandler(OnMouseUp);

            // cursor
            //_imageBox.Cursor = Cursors.Hand;
            // cursor
            SetCursor(Properties.Resources.hand);            
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _ptStart = e.Location;
                _ptStartReal = GetRealPoint(_ptStart);
                
                // if exist scroll                
                _drawing = true;

            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //SetCursor(Properties.Resources.hand);
            if (e.Button == MouseButtons.Left)
            {
                if (_drawing)
                {
                    Point curPoint = e.Location;
                    Point curPointReal = GetRealPoint(curPoint);

                    int dx = (curPointReal.X - _ptStartReal.X) *4 / 5;
                    int dy = (curPointReal.Y - _ptStartReal.Y) *4/ 5;
                    
                    // move
                    if (dx > 1)
                    {
                        // check max
                        int temp = _imageBox.HorizontalScrollBar.Value - dx;
                        if (temp < _imageBox.HorizontalScrollBar.Minimum)
                            temp = _imageBox.HorizontalScrollBar.Minimum;

                        _imageBox.HorizontalScrollBar.Value = temp;
                        _ptStartReal.X = curPointReal.X;
                        _imageBox.Refresh();
                    } else if (dx < -1)
                    {
                        // check minimum
                        int temp = _imageBox.HorizontalScrollBar.Value - dx;
                        if (temp > _imageBox.HorizontalScrollBar.Maximum)
                            temp = _imageBox.HorizontalScrollBar.Maximum;
                        
                        _imageBox.HorizontalScrollBar.Value = temp;
                        _ptStartReal.X = curPointReal.X;
                        _imageBox.Refresh();
                    }

                    if (dy > 1)
                    {
                        // check max
                        int temp = _imageBox.VerticalScrollBar.Value - dy;
                        if (temp < _imageBox.VerticalScrollBar.Minimum)
                            temp = _imageBox.VerticalScrollBar.Minimum;

                        _imageBox.VerticalScrollBar.Value = temp;
                        _ptStartReal.Y = curPointReal.Y;
                        _imageBox.Refresh();
                    }
                    else if (dy < -1)
                    {
                        // check minimum
                        int temp = _imageBox.VerticalScrollBar.Value - dy;
                        if (temp > _imageBox.VerticalScrollBar.Maximum)
                            temp = _imageBox.VerticalScrollBar.Maximum;

                        _imageBox.VerticalScrollBar.Value = temp;
                        _ptStartReal.Y = curPointReal.Y;
                        _imageBox.Refresh();
                    }                    
                    
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
