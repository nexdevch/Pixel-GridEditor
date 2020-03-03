using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public enum ToolType : int
    {
        DEF_TOOL_NONE = 0,
        DEF_TOOL_HAND,
        DEF_TOOL_HAND_BACK,
        DEF_TOOL_SELECTION,
        DEF_TOOL_PENCIL,
        DEF_TOOL_FILL,
        DEF_TOOL_FILL_BACK,
        DEF_TOOL_MAGNIFIER,
        DEF_TOOL_ERASER,
        DEF_TOOL_RESIZE_BACK
    }

    public class ToolManager
    {

        public static ToolItem _curToolItem;
        public static int _curToolIndex = -1;
        private  PropertyGrid _propertyGrid;
        private SettingInfo _settingInfo;
        int _imageRate = 4;

        private static ToolManager _toolManager;

        public static ToolManager GetInstance()
        {
            if (_toolManager == null)
            {
                _toolManager = new ToolManager();                
            }

            return _toolManager;
        }

        public void Initialize(PropertyGrid propertyGrid)
        {
            _propertyGrid = propertyGrid;
            _settingInfo = new SettingInfo();
            _propertyGrid.SelectedObject = _settingInfo;            
        }

        public SettingInfo CreateSettingInfo()
        {
            _settingInfo = new SettingInfo();
            _propertyGrid.SelectedObject = _settingInfo;
            return _settingInfo;
        }

        public SettingInfo GetSettingInfo()
        {
            return _settingInfo;
        }

        public void SetSettingInfo(SettingInfo settingInfo)
        {
            _settingInfo = settingInfo;
            _propertyGrid.SelectedObject = _settingInfo;
        }

        public bool GetSettingsFromProperty()
        {
            Size sizeImage = new Size(_settingInfo.ImageWidth, _settingInfo.ImageHeight);
            Size sizeGrid = new Size(_settingInfo.GridWidth, _settingInfo.GridHeight);

            // checking 
            if (sizeGrid.Width <= 0 || sizeGrid.Height <= 0)
            {
                MessageBox.Show("网格大小不合适");
                return false;
            }

            if (sizeImage.Width <= 0 || sizeImage.Height <= 0)
            {
                MessageBox.Show("图片大小不合适");
                return false;
            }

            if (sizeImage.Width < sizeGrid.Width || sizeImage.Height < sizeGrid.Height)
            {
                MessageBox.Show("图片大小比网格的应该大一点");
                return false;
            }

            // set setting

            ImageProc.SizeImageMain = sizeImage;            

            BackProc.KeepRatio = _settingInfo.KeepRatio;
            BackProc.VisibleBkGnd = _settingInfo.BackVisible;
            BackProc.ColorPrimary = new Bgra(_settingInfo.BackColor.B, _settingInfo.BackColor.G, _settingInfo.BackColor.R, _settingInfo.BackTransparancy);
            BackProc.RectImageMain = new Rectangle(_settingInfo.BackLeft, _settingInfo.BackTop, 0, 0);
            //BackProc.KeepOriginalSize = _settingInfo.KeepOriginalSize;            
            BackProc.SizeBack = new Size(_settingInfo.BackWidth, _settingInfo.BackHeight);

            Grid.SizeGrid = sizeGrid;
            Grid.SizeGridOriginal = sizeGrid;
            Grid.VisibleGrid = _settingInfo.GridVisible;
            Grid.ColorPrimary = new Bgra(_settingInfo.PrimaryColor.B, _settingInfo.PrimaryColor.G, _settingInfo.PrimaryColor.R, _settingInfo.PrimaryTransparancy);
            Grid.ColorGridLine = new Bgra(_settingInfo.GridColor.B, _settingInfo.GridColor.G, _settingInfo.GridColor.R, 255);

            // for grid pixel 1
            ImageProc.SizeImageOriginal = new Size(sizeImage.Width, sizeImage.Height);
            if (sizeGrid.Width == 1 || sizeGrid.Height == 1)
            {
                Grid.SizeGrid = new Size(sizeGrid.Width * _imageRate, sizeGrid.Height * _imageRate);
                ImageProc.SizeImageMain = new Size(sizeImage.Width * _imageRate, sizeImage.Height * _imageRate);
            }

            return true;

        }


    }

    
}
