using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NumberEditor
{
    public class SelectionAreaProc
    {
        private static SelectionAreaProc _selectionAreaProc;
        private List<SelectionArea> _arrSelectionAreas = new List<SelectionArea>();
        int _currentIndex = 0;
        bool _isPressedCtrl = false;
        public bool IsPressedCtrl
        {
            get { return _isPressedCtrl; }
            set { _isPressedCtrl = value; }
        }

        public static SelectionAreaProc GetInstance()
        {
            if (_selectionAreaProc == null)
            {
                _selectionAreaProc = new SelectionAreaProc();
            }

            return _selectionAreaProc;
        }

        public List<SelectionArea> GetSelectionAreas()
        {
            return _arrSelectionAreas;
        }

        public SelectionArea GetSelectionArea(int index)
        {
            if (index < 0)
            {
                return null;
            }

            return _arrSelectionAreas[index];
        }

        public SelectionArea GetCurSelectionArea()
        {
            if (_currentIndex < 0)
                return null;

            return _arrSelectionAreas[_currentIndex];
        }

        public void AddSelectionArea(SelectionArea selectionArea)
        {
            _arrSelectionAreas.Add(selectionArea);
            _currentIndex = _arrSelectionAreas.Count - 1;
        }

        public void Clear()
        {
            if (_arrSelectionAreas.Count != 0)
                _arrSelectionAreas.Clear();
            
        }

        public POINT_TYPE CheckPointType(Point pt)
        {
            POINT_TYPE result = POINT_TYPE.NONE;
            _currentIndex = 0;
            for (int i = 0; i < _arrSelectionAreas.Count; i++)
            {
                result = _arrSelectionAreas[i].CheckPointType(pt);
                if (result != POINT_TYPE.NONE)
                {
                    _currentIndex = i;
                    return result;
                }
                    
            }

            return result;
        }

        public bool IsInRect(Point pt)
        {
            bool result = false;
            _currentIndex = 0;
            for (int i = 0; i < _arrSelectionAreas.Count; i++)
            {
                result = _arrSelectionAreas[i].IsInRect(pt);
                if (result)
                {
                    _currentIndex = i;
                    return result;
                }
            }

            return result;
        }

        public Image<Bgra, Byte> DrawSelectRect(Image<Bgra, Byte> cvImage)
        {
            for (int i = 0; i < _arrSelectionAreas.Count; i++)
            {
                cvImage = _arrSelectionAreas[i].DrawSelectRect(cvImage);
            }

            return cvImage;
        }
        

        public void Fill()
        {
            int cnt = _arrSelectionAreas.Count;
            for (int i = 0; i < cnt; i++)
            {
                List<Point> arrSelectionArea = _arrSelectionAreas[i].GetCells();
                for (int j = 0; j < arrSelectionArea.Count; j++)
                {
                    Point pt = arrSelectionArea[j];
                    Cell cell = new Cell(pt, Grid.ColorPrimary);
                    Grid.AddSelectedCell(cell);
                }
            }

            _arrSelectionAreas.Clear();
        }

        public void FillBack()
        {
            List<Cell> arrNewCells = new List<Cell>();
            List<Cell> arrOldCells = Grid.ArrSelectedCells;

            int cnt = _arrSelectionAreas.Count;
            for (int i = 0; i < cnt; i++)
            {
                SelectionArea selectionArea = _arrSelectionAreas[i];
                List<Point> arrSelectionArea = selectionArea.GetCells();
                Point ptLeftTop = selectionArea.PtLeftTop;
                Point ptRightBottom = selectionArea.PtRightBottom;

                // selected area left->right
                for (int j = ptLeftTop.X; j < ptRightBottom.X; j++)
                {
                    // top -> bottom
                    for (int k = ptLeftTop.Y; k < ptRightBottom.Y;k++)
                    {
                        //check already existed selected cell
                        bool isAdded = false;
                        for (int m = 0; m < arrOldCells.Count; m++)
                        {
                            Point ptCell = arrOldCells[m].PtCell;

                            if (ptCell.X == j && ptCell.Y == k)
                            {
                                arrNewCells.Add(arrOldCells[m]);
                                arrOldCells.RemoveAt(m);
                                isAdded = true;
                                break;
                            }
                        }
                    }
                }

            }

            Grid.ClearCells();
            for (int i = 0; i < arrNewCells.Count; i++)
            {
                Grid.AddSelectedCell(arrNewCells[i]);
            }
            _arrSelectionAreas.Clear();
        }

        public bool Erase()
        {
            bool result = false;
            int cnt = _arrSelectionAreas.Count;
            for (int i = 0; i < cnt; i++)
            {
                List<Point> arrSelectionArea = _arrSelectionAreas[i].GetCells();
                for (int j = 0; j < arrSelectionArea.Count; j++)
                {
                    Point pt = arrSelectionArea[j];
                    bool removed = Grid.RemoveSelectedCell(pt);
                    if (removed)
                    {
                        result = true;
                    }
                }
            }

            _arrSelectionAreas.Clear();
            return result;
        }


    }
}
