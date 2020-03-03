using DarkUI.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public partial class FormMain : DarkForm
    {

        //SettingInfo _settingInfo;
        //ImageFile _mainImage;
        //ImageProc _imageProc;
        
        
        public FormMain()
        {
            InitializeComponent();
            Init();            
        }

        private void Init()
        {
            ToolManager.GetInstance().Initialize(propertySetting);
            
        }

        private void btnResourcePathLoad_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    //
                    textBoxFolderPath.Text = fbd.SelectedPath;

                    comboBoxBg.Items.Clear();
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    if (files != null)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            string fileName = Path.GetFileName(files[i]);
                            string fileExt = Path.GetExtension(files[i]);
                            fileExt = fileExt.ToLower();
                            //if (fileExt.Equals(""))
                            string exts = ".jpg .jpeg .bmp .png .tiff";
                            if (exts.Contains(fileExt + " "))
                            {
                                comboBoxBg.Items.Add(fileName);
                            }
                        }                        
                    }
                }
            }
        }

        private void comboBoxBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            createBackground();
            if (ImageProc.IsInitialized())
            {
                ImageProc.DrawImage();
            }
        }

        private void createBackground()
        {
            // check if the selected item is
            object item = comboBoxBg.SelectedItem;
            if (item == null)
                return;

            string path = textBoxFolderPath.Text.ToString();
            string fullPath = path + "//" + comboBoxBg.SelectedItem.ToString();            

            if (string.IsNullOrEmpty(fullPath))
                return;

            bool result = ToolManager.GetInstance().GetSettingsFromProperty();
            if (!result)
                return;

            BackProc.Create(fullPath);

            ShowScroolbar();
        }       


        /// <summary>
        /// change setting event handler
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void propertyGridSetting_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // check ready
            SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
            bool bResult = settingInfo.CheckPropertySettings();
            if (!bResult)
                return;

            if (ImageProc.IsInitialized())
            {
                bool result = ToolManager.GetInstance().GetSettingsFromProperty();                
                if (!result)
                    return;

                ImageProc.DrawImage();
                ShowScroolbar();
            }            
            
        }      

        private void btnNew_Click(object sender, EventArgs e)
        {
            SettingInfo _settingInfo = ToolManager.GetInstance().GetSettingInfo();
            bool bResult = _settingInfo.CheckPropertySettings();
            if (!bResult)
                return;

            Size sizeImage = new Size(_settingInfo.ImageWidth, _settingInfo.ImageHeight);
            Size sizeGrid = new Size(_settingInfo.GridWidth, _settingInfo.GridHeight);
            
            // init
            ImageProc.Initialized();
            Grid.Initialize();
            BackProc.Initialized();
            bool result = ToolManager.GetInstance().GetSettingsFromProperty();
            if (!result)
                return;
            
            ImageProc.Create(imageboxMain, propertySetting);            

            // init tool
            SetCurrentToolItem((int)ToolType.DEF_TOOL_PENCIL);
            radioPencil.Checked = true;

            // background
            createBackground();

            // draw            
            ImageProc.DrawImage();
            ShowScroolbar();
        }

        private void ShowScroolbar()
        {
            imageboxMain.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            imageboxMain.SetZoomScale(imageboxMain.ZoomScale + 0.1, new Point(imageboxMain.Width / 2, imageboxMain.Height / 2));
            imageboxMain.SetZoomScale(imageboxMain.ZoomScale - 0.1, new Point(imageboxMain.Width / 2, imageboxMain.Height / 2));
            imageboxMain.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
        }

        /*
        private void btnOpen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.png, *.jpg, *.jpeg, *.tiff, *.bmp)|*.png; *.jpg; *.jpeg; *.tiff; *.bmp";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    Size gridSize = new Size(_settingInfo.GridWidth, _settingInfo.GridHeight);
                    _imageProc.Create(filePath, gridSize);
                    if (_imageProc != null)
                    {
                        _imageProc.DrawImage();
                    }

                    // change property setting
                    if (_settingInfo.ImageWidth == 0)
                    {
                        _settingInfo.ImageWidth = _imageProc.SizeImageMain.Width;
                    }

                    if (_settingInfo.ImageHeight == 0)
                    {
                        _settingInfo.ImageHeight = _imageProc.SizeImageMain.Height;
                    }

                    propertySetting.Refresh();

                }
            }
        }
        */
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = false;
            if (ImageProc.IsInitialized()) {
                ImageProc.SaveAs("");
                isSaved = true;
            }

            if (isSaved)
            {   
                SelectionAreaProc.GetInstance().Clear();
                ImageProc.DrawImage();
            }
                      
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (ImageProc.IsInitialized())
                ImageProc.ClearPoints();
        }

        private void radioHand_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHand.Checked)
                SetCurrentToolItem((int)ToolType.DEF_TOOL_HAND);
        }

        private void radioFill_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFill.Checked)
                SetCurrentToolItem((int)ToolType.DEF_TOOL_FILL);
        }

        private void radioFillBack_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFillBack.Checked)
            {
                SetCurrentToolItem((int)ToolType.DEF_TOOL_FILL_BACK);
            }
        }

        private void radioSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSelection.Checked)
                SetCurrentToolItem((int)ToolType.DEF_TOOL_SELECTION);
        }

        private void radioPencil_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPencil.Checked)
                SetCurrentToolItem((int)ToolType.DEF_TOOL_PENCIL);
        }

        private void radioMagnifier_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMagnifier.Checked)
                SetCurrentToolItem((int)ToolType.DEF_TOOL_MAGNIFIER);
        }

        private void radioButtonErase_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEraser.Checked)
                SetCurrentToolItem((int)ToolType.DEF_TOOL_ERASER);
        }

        private void radioHandBack_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHandBack.Checked)
            {
                SetCurrentToolItem((int) ToolType.DEF_TOOL_HAND_BACK);
            }
        }

        private void radioResizeBack_CheckedChanged(object sender, EventArgs e)
        {
            if(radioResizeBack.Checked)
            {
                if (BackProc.GetCopyImage() != null)
                {
                    SetCurrentToolItem((int)ToolType.DEF_TOOL_RESIZE_BACK);
                } else
                {
                    SetCurrentToolItem((int)ToolType.DEF_TOOL_NONE);
                    imageboxMain.Cursor = Cursors.Arrow;
                }
                
            }
        }

        private void SetCurrentToolItem(int toolIndex)
        {
            UnloadMessageHandler();
                        
            if (!ImageProc.IsInitialized())
                return;

            ToolManager._curToolIndex = toolIndex;
            switch (toolIndex)
            {
                case (int)ToolType.DEF_TOOL_FILL:                    
                    ToolManager._curToolItem = new ToolFill(imageboxMain, radioFill);
                    break;

                case (int)ToolType.DEF_TOOL_FILL_BACK:
                    ToolManager._curToolItem = new ToolFillBack(imageboxMain, radioFillBack);
                    break;

                case (int)ToolType.DEF_TOOL_HAND:
                    ToolManager._curToolItem = new ToolHand(imageboxMain, radioHand);
                    break;

                case (int)ToolType.DEF_TOOL_HAND_BACK:
                    ToolManager._curToolItem = new ToolHandBack(imageboxMain, radioHandBack);
                    break;

                case (int)ToolType.DEF_TOOL_MAGNIFIER:
                    ToolManager._curToolItem = new ToolMagnifier(imageboxMain, radioMagnifier);
                    break;

                case (int)ToolType.DEF_TOOL_PENCIL:
                    ToolManager._curToolItem = new ToolPencil(imageboxMain, radioPencil);
                    break;

                case (int)ToolType.DEF_TOOL_SELECTION:
                    ToolManager._curToolItem = new ToolSelection(imageboxMain, radioSelection);
                    break;

                case (int)ToolType.DEF_TOOL_ERASER:
                    ToolManager._curToolItem = new ToolEraser(imageboxMain, radioSelection);
                    break;

                case (int)ToolType.DEF_TOOL_RESIZE_BACK:
                    ToolManager._curToolItem = new ToolResizeBack(imageboxMain, radioResizeBack);
                    break;


                default:
                    ToolManager._curToolIndex = -1;
                    break;

            }
        }

        private void UnloadMessageHandler()
        {
            int toolIndex = ToolManager._curToolIndex;
            switch (toolIndex)
            {
                case (int)ToolType.DEF_TOOL_FILL:
                    ToolFill toolFill = (ToolFill) ToolManager._curToolItem;
                    toolFill.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_FILL_BACK:
                    ToolFillBack toolFillBack = (ToolFillBack)ToolManager._curToolItem;
                    toolFillBack.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_HAND:
                    ToolHand toolHand = (ToolHand)ToolManager._curToolItem;
                    toolHand.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_HAND_BACK:
                    ToolHandBack toolHandBack = (ToolHandBack)ToolManager._curToolItem;
                    toolHandBack.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_MAGNIFIER:
                    ToolMagnifier toolMagnifier = (ToolMagnifier)ToolManager._curToolItem;
                    toolMagnifier.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_PENCIL:
                    ToolPencil toolPencil = (ToolPencil)ToolManager._curToolItem;
                    toolPencil.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_SELECTION:
                    ToolSelection toolItem = (ToolSelection)ToolManager._curToolItem;
                    toolItem.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_ERASER:
                    ToolEraser toolEraser = (ToolEraser)ToolManager._curToolItem;
                    toolEraser.UnloadMessageHandler();
                    break;

                case (int)ToolType.DEF_TOOL_RESIZE_BACK:
                    ToolResizeBack toolResizeBack = (ToolResizeBack)ToolManager._curToolItem;
                    toolResizeBack.UnloadMessageHandler();
                    break;

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            SettingInfo settingInfo = ToolManager.GetInstance().GetSettingInfo();
            int toolIndex = ToolManager._curToolIndex;
            const int WM_KEYUP = 0x0101;
            const int WM_KEYDOWN = 0x0100;

            if (keyData == Keys.Delete)
            {
                //Grid.RemoveTempFromRealSelection();
                SelectionAreaProc.GetInstance().Erase();
                ImageProc.DrawImage();                

                return true;
            }
            
            if (toolIndex == (int) ToolType.DEF_TOOL_HAND_BACK)
            {
                if (keyData == Keys.Left)
                {
                    settingInfo.BackLeft = settingInfo.BackLeft - 1;                    
                }
                else if (keyData == Keys.Right)
                {
                    settingInfo.BackLeft = settingInfo.BackLeft + 1;
                }
                else if (keyData == Keys.Up)
                {
                    settingInfo.BackTop = settingInfo.BackTop - 1;
                }
                else if (keyData == Keys.Down)
                {
                    settingInfo.BackTop = settingInfo.BackTop + 1;
                }

                
                ToolManager.GetInstance().SetSettingInfo(settingInfo);
                ToolManager.GetInstance().GetSettingsFromProperty();
                ImageProc.DrawImage();
                return true;
            }
            /*
            if (keyData == (Keys.Control|Keys.ControlKey))
            {
                if (msg.Msg != WM_KEYDOWN)
                {
                    SelectionAreaProc.GetInstance().IsPressedCtrl = true;
                } else if (msg.Msg == WM_KEYUP)
                {
                    SelectionAreaProc.GetInstance().IsPressedCtrl = false;
                }
                return true;
            }*/
            

            return base.ProcessCmdKey(ref msg, keyData);
        }        

        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            Keys keys = (Keys)m.WParam;
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == (Keys.ControlKey))
            {
                //Do something
                SelectionAreaProc.GetInstance().IsPressedCtrl = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == (Keys.ControlKey))
            {
                SelectionAreaProc.GetInstance().IsPressedCtrl = false;
            }

            return base.ProcessKeyPreview(ref m);
        }

        
    }
}
