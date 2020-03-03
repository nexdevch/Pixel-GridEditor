using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace NumberEditor
{
    public class SettingInfo
    { 
        
        /*
        private int _platePosX;
        [Category("号码位置")]
        [DisplayName("号码位置 X")]
        public int PlatePosX {
            get
            {
                return _platePosX;
            }
            set
            {
                _platePosX = value;
            }
        }

        private int _platePosY;
        [Category("号码位置")]
        [DisplayName("号码位置 Y")]
        public int PlatePosY
        {
            get
            {
                return _platePosY;
            }
            set
            {
                _platePosY = value;
            }
        }
        */
        private int _imageWidth=500;
        [Category("图片")]
        [DisplayName("长度")]
        public int ImageWidth
        {
            get
            {
                return _imageWidth;
            }
            set
            {
                _imageWidth = value;
            }
        }

        private int _imageHeight=500;
        [Category("图片")]
        [DisplayName("高度")]        
        public int ImageHeight
        {
            get
            {
                return _imageHeight;
            }
            set
            {
                _imageHeight = value;
            }
        }

        private Color _primaryColor = Color.FromArgb(255,255,255);
        [Category("图片")]
        [DisplayName("颜色")]
        public Color PrimaryColor
        {
            get
            {
                return _primaryColor;
            }
            set
            {
                _primaryColor = value;
            }
        }

        private int _primaryTransparancy = 255;
        [Category("图片")]
        [DisplayName("颜色透明度")]
        [Range(0, 255)]
        public int PrimaryTransparancy
        {
            get
            {
                return _primaryTransparancy;
            }
            set
            {
                _primaryTransparancy = value;
            }
        }

        /*
        private Color _backColor;// = Color.FromArgb(0, 0, 0);
        [Category("Cell")]
        [DisplayName("Background")]
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }
        */

        private int _gridWidth = 50;
        [Category("网格")]
        [DisplayName("长度")]
        public int GridWidth
        {
            get
            {
                return _gridWidth;
            }
            set
            {
                _gridWidth = value;
            }
        }

        private int _gridHeight = 50;
        [Category("网格")]
        [DisplayName("高度")]
        public int GridHeight
        {
            get
            {
                return _gridHeight;
            }
            set
            {
                _gridHeight = value;
            }
        }
        private Color _gridColor = Color.FromArgb(255, 255, 255);
        [Category("网格")]
        [DisplayName("颜色")]
        public Color GridColor
        {
            get
            {
                return _gridColor;
            }
            set
            {
                _gridColor = value;
            }
        }

        private bool _gridVisible = true;
        [Category("网格")]
        [DisplayName("表示")]
        public bool GridVisible
        {
            get
            {
                return _gridVisible;
            }
            set
            {
                _gridVisible = value;
            }
        }

        private int _backLeft = 0;
        [Category("背景")]
        [DisplayName("X")]
        public int BackLeft
        {
            get
            {
                return _backLeft;
            }
            set
            {
                _backLeft = value;
            }
        }

        private int _backTop = 0;
        [Category("背景")]
        [DisplayName("Y")]
        public int BackTop
        {
            get
            {
                return _backTop;
            }
            set
            {
                _backTop = value;
            }
        }

        private int _backWidth = 50;
        [Category("背景")]
        [DisplayName("长度")]
        public int BackWidth
        {
            get
            {
                return _backWidth;
            }
            set
            {
                _backWidth = value;
            }
        }

        private int _backHeight = 50;
        [Category("背景")]
        [DisplayName("高度")]
        public int BackHeight
        {
            get
            {
                return _backHeight;
            }
            set
            {
                _backHeight = value;
            }
        }

        /*
        private bool _keepOriginalSize = true;
        [Category("背景")]
        [DisplayName("保持原来大小")]
        public bool KeepOriginalSize
        {
            get
            {
                return _keepOriginalSize;
            }
            set
            {
                _keepOriginalSize = value;
            }
        }*/

        private bool _backVisible = true;
        [Category("背景")]
        [DisplayName("表示")]
        public bool BackVisible
        {
            get
            {
                return _backVisible;
            }
            set
            {
                _backVisible = value;
            }
        }

        private bool _keepRatio = true;
        [Category("背景")]
        [DisplayName("保持比率")]
        public bool KeepRatio
        {
            get
            {
                return _keepRatio;
            }
            set
            {
                _keepRatio = value;
            }
        }

        private float _backRatio = 1.0f;
        [Category("背景")]
        [DisplayName("图片比率")]
        [Browsable(false)]
        public float BackRatio
        {
            get
            {
                return _backRatio;
            }
            set
            {
                _backRatio = value;
            }
        }

        private Color _backColor = Color.FromArgb(0, 0, 0);
        [Category("背景")]
        [DisplayName("颜色")]
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }

        private int _backTransparancy = 0;
        [Category("背景")]
        [DisplayName("颜色透明度")]
        [Range(0, 255)]
        public int BackTransparancy
        {
            get
            {
                return _backTransparancy;
            }
            set
            {
                _backTransparancy = value;
            }
        }

        private int _eraserWidth = 1;
        [Category("橡皮")]
        [DisplayName("长度")]
        public int EraserWidth
        {
            get
            {
                return _eraserWidth;
            }
            set
            {
                _eraserWidth = value;
            }
        }

        private int _eraserHeight = 1;
        [Category("橡皮")]
        [DisplayName("高度")]
        public int EraserHeight
        {
            get
            {
                return _eraserHeight;
            }
            set
            {
                _eraserHeight = value;
            }
        }


        /*
        private Color _colorCell = Color.White;
        [DisplayName("")]
        public Color ColorCell
        {
            get
            {
                return _colorCell;
            }

            set
            {
                _colorCell = value;
            }
        }*/

        public bool CheckPropertySettings()
        {
            bool result = true;

            if (GridWidth >= ImageWidth)
            {
                GridWidth = ImageWidth / 2;
                result = false;
            }

            if (GridHeight >= ImageHeight)
            {
                GridHeight = ImageHeight / 2;
                result = false;
            }

            if (ImageWidth <= 0)
            {
                ImageWidth = 500;
                result = false;
            }

            if (ImageHeight <= 0)
            {
                ImageHeight = 500;
                result = false;
            }

            if (GridWidth <= 0)
            {
                GridWidth = 1;
                result = false;
            }

            if (GridHeight <= 0)
            {
                GridHeight = 1;
                result = false;
            } 
            
            if (_backTransparancy < 0)
            {
                _backTransparancy = 0;
            }

            if(_backTransparancy > 255)
            {
                _backTransparancy = 255;
            }

            if (_primaryTransparancy < 0)
            {
                _primaryTransparancy = 0;
            }

            if (_primaryTransparancy > 255)
            {
                _primaryTransparancy = 255;
            }

            return result;
        }

        


    }
}
