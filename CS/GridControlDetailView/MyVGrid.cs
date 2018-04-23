using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CustomGrid;

namespace CustomGridControl
{
    public partial class MyVGrid : UserControl, IDetailView
    {
        public MyVGrid()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get
            {
                return vGridControl1.DataSource;
            }
            set
            {
                vGridControl1.DataSource = value;
            }
        }

        public Control InternalControl
        {
            get
            {
                return vGridControl1;
            }
        }

        int detailHeight = 95;
        public int DetailHeight
        {
            get { return detailHeight; }
        }
    }
}
