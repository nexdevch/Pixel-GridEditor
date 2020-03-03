using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberEditor
{
    public partial class FormNew : DarkForm
    {
        /// <summary>
        /// size of new image
        /// </summary>
        public Size ImageSize
        {
            get { return new Size((int)upDownImageWidth.Value, (int)upDownImageHeight.Value); }
        }

        /// <summary>
        /// size of grid interval
        /// </summary>
        public Size GridSize
        {
            get { return new Size((int)upDownGridWidth.Value, (int)upDownGridHeight.Value); }
        }

        public FormNew()
        {
            InitializeComponent();
        }
       
    }
}
