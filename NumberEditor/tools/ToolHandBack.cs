using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public class ToolHandBack : ToolItem
    {

        private bool _drawing = false;
        Point _ptStart;
        //Point _ptStartReal;        

        public ToolHandBack(ImageBox imageBox, RadioButton radioButton)
        {
            _imageBox = imageBox;
            _radioBtn = radioButton;

            imageBox.MouseDown += new MouseEventHandler(OnMouseDown);
            imageBox.MouseMove += new MouseEventHandler(OnMouseMove);
            imageBox.MouseUp += new MouseEventHandler(OnMouseUp);

            // cursor
            //_imageBox.Cursor = Cursors.Hand;
            // cursor
            SetCursor(Properties.Resources.hand_back);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _ptStart = e.Location;
                //_ptStartReal = GetRealPoint(_ptStart);

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
                    //Point curPointReal = GetRealPoint(curPoint);

                    int dx = (curPoint.X - _ptStart.X);
                    int dy = (curPoint.Y - _ptStart.Y);

                    int absDX = dx;
                    if (absDX < 0) { absDX = 0 - absDX; }
                    int absDY = dy;
                    if (absDY < 0) { absDY = 0 - absDY; }

                    if (absDX >= 1 || absDY >= 1)
                    {
                        _ptStart = curPoint;
                        Rectangle rtMain = BackProc.RectImageMain;
                        rtMain.X += dx;
                        rtMain.Y += dy;

                        BackProc.RectImageMain = rtMain;
                        ImageProc.DrawImage();
                    }
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
                settingInfo.BackLeft = BackProc.RectImageMain.X;
                settingInfo.BackTop = BackProc.RectImageMain.Y;

                ToolManager.GetInstance().SetSettingInfo(settingInfo);
                ToolManager.GetInstance().GetSettingsFromProperty();
            }

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
