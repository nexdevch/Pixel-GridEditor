using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NumberEditor
{
    public class BackProc
    {
        private static Image<Bgra, Byte> _imageBkSrc = null;
        private static Image<Bgra, Byte> _imageBkCpy = null;

        private static bool _keepRatio = true;
        public static bool KeepRatio
        {
            get { return _keepRatio; }
            set { _keepRatio = value; }
        }

        static bool _visibleBkGnd = true;
        public static bool VisibleBkGnd
        {
            get { return _visibleBkGnd;}
            set { _visibleBkGnd = value;}
        }

        static Bgra _colorPrimary = new Bgra(0, 0, 0, 0);
        static public Bgra ColorPrimary
        {
            get { return _colorPrimary;}
            set{ _colorPrimary = value;}
        }

        private static Rectangle _rectBk;
        public static Rectangle RectImageMain
        {
            get { return _rectBk; }
            set { _rectBk = value; }
        }

        private static Size _sizeBack = new Size(100, 100);
        public static Size SizeBack
        {
            get { return _sizeBack; }
            set { _sizeBack = value; }
        }

        /*
        private static Boolean _keepOriginalSize = true;
        public static Boolean KeepOriginalSize
        {
            get { return _keepOriginalSize; }
            set { _keepOriginalSize = value; }
        }*/

        public static void Create(string paramFilePath)
        {
            try
            {
                _imageBkSrc = new Image<Bgra, byte>(paramFilePath);
                _imageBkCpy = _imageBkSrc.Copy();

                SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
                settingInfo.BackWidth = settingInfo.ImageWidth;
                settingInfo.BackHeight = settingInfo.ImageHeight;

                // resize by image size rate
                float rate = (float)_imageBkSrc.Height / (float)_imageBkSrc.Width;
                settingInfo.BackRatio = rate;                
                ToolManager.GetInstance().SetSettingInfo(settingInfo);
                ToolManager.GetInstance().GetSettingsFromProperty();

                // bg size
                /*
                if (_keepOriginalSize)
                {
                    _sizeBack = new Size(_imageBkSrc.Width, _imageBkSrc.Height);

                    SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
                    settingInfo.BackWidth = _imageBkSrc.Width;
                    settingInfo.BackHeight = _imageBkSrc.Height;
                                        
                    ToolManager.GetInstance().SetSettingInfo(settingInfo);
                    ToolManager.GetInstance().GetSettingsFromProperty();
                    ImageProc.DrawImage();
                }*/


            }
            catch
            {
                //return false;
            }
        }

        public static void Initialized()
        {
            _imageBkSrc = null;
            _imageBkCpy = null;
        }

        public static Image<Bgra, byte> GetCopyImage()
        {
            return _imageBkCpy;
        }

        public static Image<Bgra, byte> ResizeBkImage(Size sizeImage)
        {
            // check
            if (_imageBkSrc == null)
                return null;

            _imageBkCpy = _imageBkSrc.Resize(sizeImage.Width, sizeImage.Height, Emgu.CV.CvEnum.Inter.Linear, _keepRatio);            
            return _imageBkCpy;
        }

        public static Image<Bgra, Byte> GetBackgroundImage(Size sizeImage)
        {
            int widthWindow = sizeImage.Width;
            int heightWindow = sizeImage.Height;

            // fill background color
            Image<Bgra, byte>  cvImageMain = new Image<Bgra, byte>(widthWindow, heightWindow, _colorPrimary);

            Image<Bgra, Byte> imageBk = ResizeBkImage(new Size(_sizeBack.Width, _sizeBack.Height));
            if (imageBk == null)
            {
                return cvImageMain;
            }

            int dispX = _rectBk.Left;
            int dispY = _rectBk.Top;

            int cropX = 0;
            int cropY = 0;
            int cropWidth = imageBk.Width;
            int cropHight = imageBk.Height;

            if (_rectBk.Left < 0)
            {
                dispX = 0;
                cropX = -_rectBk.Left;
                cropWidth = imageBk.Width - cropX;
            }
            if (_rectBk.Top < 0)
            {
                dispY = 0;
                cropY = -_rectBk.Top;
                cropHight = imageBk.Height - cropY;
            }
            if (dispX+cropWidth > widthWindow)
            {
                cropWidth = widthWindow - dispX;
            }

            if(dispY+cropHight > heightWindow)
            {
                cropHight = heightWindow - dispY;
            }

            /*
            if (cropX+cropWidth > imageBk.Width)
            {
                cropWidth = imageBk.Width - cropX;
            }

            if (cropY + cropHight > imageBk.Height)
            {
                cropHight = imageBk.Height - cropY;
            }*/

            if (cropWidth <= 0 || cropHight <= 0)
            {
                return cvImageMain;
            }

            //imageBk = ImageProc.CropImage(imageBk, new Rectangle(cropX, cropY, cropWidth, cropHight));     
            if (_visibleBkGnd && imageBk != null)
            {
                imageBk.ROI = new Rectangle(cropX, cropY, cropWidth, cropHight);
                cvImageMain.ROI = new Rectangle(dispX, dispY, cropWidth, cropHight);
                imageBk.CopyTo(cvImageMain);
                cvImageMain.ROI = Rectangle.Empty;
                imageBk.ROI = Rectangle.Empty;
            }

            return cvImageMain;
        }

    }
}
