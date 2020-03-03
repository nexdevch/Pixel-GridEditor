using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public class ImageProc
    {
        private static ImageBox _imageboxMain = null;
        private static PropertyGrid _propertyGridSetting = null;
        private static Image<Bgra, Byte> _cvImageWork;

        private static Size _sizeImageMain;
        public static Size SizeImageMain
        {
            get
            {
                return _sizeImageMain;
            }
            set
            {
                _sizeImageMain = value;
            }
        }

        
        static string _fileName;
        public static string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        private static Size _sizeImageOriginal;
        public static Size SizeImageOriginal
        {
            get
            {
                return _sizeImageOriginal;
            }
            set
            {
                _sizeImageOriginal = value;
            }
        }

        private static int _imageRate = 10;
        public static int ImageRate
        {
            get { return _imageRate; }
            set { _imageRate = value; }
        }
        
        public static void Create(ImageBox imageBox,  PropertyGrid propertyGrid)
        {
            _imageboxMain = imageBox;
            _propertyGridSetting = propertyGrid;
            _fileName = null;

            //_imageMainSrc = new Image<Bgra, byte>(_sizeImageMain.Width, _sizeImageMain.Height, _colorBack);
        }        

        private static void Invalidate(Image<Bgra, Byte> cvImage)
        {
            _imageboxMain.Image = cvImage;
        }        

        public static void DrawImage()
        {
            Image<Bgra, Byte> cvImageWork = BackProc.GetBackgroundImage(_sizeImageMain);
            Image<Bgra, Byte> cvImageGrid = Grid.DrawGrid(cvImageWork);
            cvImageGrid = SelectionAreaProc.GetInstance().DrawSelectRect(cvImageGrid);

            if (_cvImageWork == null)
            {
                _cvImageWork = new Image<Bgra, byte>(_sizeImageMain.Width, _sizeImageMain.Height, new Bgra(0,0,0,0));
            } else
            {
                _cvImageWork.Resize(cvImageGrid.Width, cvImageGrid.Height, Emgu.CV.CvEnum.Inter.Linear);                
            }
            _cvImageWork = cvImageGrid.Copy();

            Invalidate(cvImageGrid);            
        }

        public static Image<Bgra, Byte> GetWorkingImage()
        {
            //Image<Bgra, Byte> cvImageWork = BackProc.GetBackgroundImage(_sizeImageMain);
            //Image<Bgra, Byte> cvImageGrid = Grid.DrawGrid(cvImageWork, true);
            //cvImageGrid = SelectionAreaProc.GetInstance().DrawSelectRect(cvImageGrid);
            if (_cvImageWork == null)
            {
                DrawImage();
            }

            return _cvImageWork;
        }

        public static void ClearPoints()
        {
            Grid.ClearCells();
            DrawImage();
        }

        public static void Save()
        {
            string otherName = _fileName;
            if (string.IsNullOrEmpty(_fileName))
            {
                SaveFileDialog saveFileDlg = new SaveFileDialog();
                saveFileDlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                saveFileDlg.Title = "Save an Image File";

                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    _fileName = saveFileDlg.FileName;
                } else
                {
                    return;
                }                
            }

            try
            {
                Image<Bgra, Byte> cvImageWork = BackProc.GetBackgroundImage(_sizeImageMain);
                // resize the image into original by rate
                // this is added for pixel1 size grid
                cvImageWork = cvImageWork.Resize(_sizeImageOriginal.Width, _sizeImageOriginal.Height, Emgu.CV.CvEnum.Inter.Linear, true);

                Image<Bgra, Byte> cvImageGrid = Grid.DrawGridCellByDot(cvImageWork, Grid.SizeGridOriginal);
                //Image<Bgra, Byte> cvImageGrid = Grid.DrawGridCellWithTransparancy(cvImageWork, Grid.SizeGridOriginal);
                
                // crop selection part
                List<SelectionArea> arrSelectionAreas = SelectionAreaProc.GetInstance().GetSelectionAreas();
                if (arrSelectionAreas.Count != 0)
                {
                    for (int i = 0; i < arrSelectionAreas.Count; i++)
                    {
                        SelectionArea selectionArea = arrSelectionAreas[i];
                        Rectangle rectSel = new Rectangle(selectionArea.PtLeftTop.X,
                                                          selectionArea.PtLeftTop.Y,
                                                          selectionArea.PtRightBottom.X - selectionArea.PtLeftTop.X,
                                                          selectionArea.PtRightBottom.Y - selectionArea.PtLeftTop.Y);
                        Image<Bgra, Byte> cvImageCrop = CropImage(cvImageGrid, rectSel);

                        String fileName = _fileName;
                        if (arrSelectionAreas.Count > 1)
                        {
                            fileName = String.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(_fileName), Path.GetFileNameWithoutExtension(_fileName), i, Path.GetExtension(_fileName));
                        }
                        
                        cvImageCrop.Save(fileName);
                    }
                } else
                {
                    cvImageGrid.Save(_fileName);
                }
                
                
            }
            catch(Exception e)
            {

            }

        }

        public static void SaveAs(string paramFilePath)
        {
            // check ready for save
            if (!IsInitialized())
                return;

            if (string.IsNullOrEmpty(paramFilePath))
            {
                SaveFileDialog saveFileDlg = new SaveFileDialog();
                saveFileDlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                saveFileDlg.Title = "Save an Image File";

                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    _fileName = saveFileDlg.FileName;
                } else
                {
                    return;
                }

            }

            Save();            
        } 
        
        public static Image<Bgra, Byte> CropImage(Image<Bgra, Byte> cvImage, Rectangle rectSelection)
        {
            if (rectSelection.Width <= 0 || rectSelection.Height <= 0)
                return cvImage;

            Image<Bgra, Byte> cvImageResult = new Image<Bgra, byte>(rectSelection.Width, rectSelection.Height, new Bgra(0,0,0,0));
            cvImage.ROI = rectSelection;
            cvImage.CopyTo(cvImageResult);
            cvImage.ROI = Rectangle.Empty;

            return cvImageResult;
        }

        public static bool IsInitialized()
        {
            if (_imageboxMain == null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static void Initialized()
        {
            _imageboxMain = null;            
        }


    }


}
