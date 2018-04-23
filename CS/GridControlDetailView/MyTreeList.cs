using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CustomGrid;

namespace CustomGridControl
{
    public partial class MyTreeList : UserControl, IDetailView
    {
        public MyTreeList()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get
            {
                return treeList.DataSource;
            }
            set
            {
                treeList.DataSource = value;
            }
        }

        public Control InternalControl
        {
            get
            {
                return treeList;
            }
        }

        int detailHeight = 350;
        public int DetailHeight
        {
            get { return detailHeight; }
        }
    }
}
