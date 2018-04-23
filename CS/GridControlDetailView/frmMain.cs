using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace CustomGridControl
{
    public partial class frmMain : Form
    {
        string[] views = new string[] { "CustomGridControl.MyTreeList", "CustomGridControl.MyVGrid" };

        public frmMain()
        {
            InitializeComponent();
            for (int i = 0; i < views.Length; i++)
                radioGroup1.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(views[i], views[i]));
            radioGroup1.Properties.Columns = views.Length;
            radioGroup1.SelectedIndex = 0;
            DataSet set = GetMasterDetail();
            customGridControl1.DataSource = set.Tables["Parent"];
            customView1.InternalControlType = views[radioGroup1.SelectedIndex];
        }

        private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable("Parent");
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("NOID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            tbl.Columns.Add("DETAILID", typeof(int));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i), i });
            return tbl;
        }

        private DataTable CreateDet1Table(int RowCount)
        {
            DataTable tbl = new DataTable("Det1");
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("DETAILID", typeof(int));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("ParentID", typeof(int));
            int id = 0;
            for (int j = 0; j < RowCount; j++)
                for (int i = 0; i < RowCount; i++)
                {
                    tbl.Rows.Add(new object[] { String.Format("Detail{1}Name{0}", i, j), i, id, -1 });
                    int parentID = id;
                    id++;
                    CreateSubRows(tbl, RowCount, i, parentID, ref id);
                }
            return tbl;
        }

        private DataTable CreateDet2Table(int RowCount) {
            DataTable tbl = new DataTable("Det2");
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("DETAILID", typeof(int));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("ParentID", typeof(int));
            int id = 0;
            for (int j = 0; j < RowCount; j++)
                for (int i = 0; i < RowCount; i++) {
                    tbl.Rows.Add(new object[] { String.Format("Detail{1}Name{0}", i, j), i, id, -1 });
                    int parentID = id;
                    id++;
                    CreateSubRows(tbl, RowCount, i, parentID, ref id);
                }
            return tbl;
        }

        private void CreateSubRows(DataTable tbl, int RowCount, int detailID, int parentID, ref int id)
        {
            for (int i = 0; i < RowCount; i++)
            {
                tbl.Rows.Add(new object[] { String.Format("SubDetail{1}Name{0}", i, parentID), detailID, id++, parentID });
            }
        }

        private DataSet GetMasterDetail()
        {
            DataSet ds = new DataSet("TestDS");
            ds.Tables.Add(CreateTable(20));
            ds.Tables.Add(CreateDet1Table(20));
            ds.Tables.Add(CreateDet2Table(20));
            DataColumn parentColumn = ds.Tables["Parent"].Columns["DETAILID"];
            DataColumn childColumn = ds.Tables["Det1"].Columns["DETAILID"];
            ds.Relations.Add(new DataRelation("relDet1", parentColumn, childColumn));
            parentColumn = ds.Tables["Parent"].Columns["DETAILID"];
            childColumn = ds.Tables["Det2"].Columns["DETAILID"];
            ds.Relations.Add(new DataRelation("relDet2", parentColumn, childColumn));
            return ds;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customView1.InternalControlType = views[radioGroup1.SelectedIndex];
        }
    }
}
