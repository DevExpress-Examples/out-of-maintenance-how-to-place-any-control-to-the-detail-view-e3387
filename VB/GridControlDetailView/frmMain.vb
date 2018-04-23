Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports System.Data

Namespace CustomGridControl
	Partial Public Class frmMain
		Inherits Form
		Private views() As String = { "CustomGridControl.MyTreeList", "CustomGridControl.MyVGrid" }

		Public Sub New()
			InitializeComponent()
			For i As Integer = 0 To views.Length - 1
				radioGroup1.Properties.Items.Add(New DevExpress.XtraEditors.Controls.RadioGroupItem(views(i), views(i)))
			Next i
			radioGroup1.Properties.Columns = views.Length
			radioGroup1.SelectedIndex = 0
			Dim [set] As DataSet = GetMasterDetail()
			customGridControl1.DataSource = [set].Tables("Parent")
			customView1.InternalControlType = views(radioGroup1.SelectedIndex)
		End Sub

		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable("Parent")
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("NOID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			tbl.Columns.Add("DETAILID", GetType(Integer))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i), i })
			Next i
			Return tbl
		End Function

		Private Function CreateDet1Table(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable("Det1")
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("DETAILID", GetType(Integer))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("ParentID", GetType(Integer))
			Dim id As Integer = 0
			For j As Integer = 0 To RowCount - 1
				For i As Integer = 0 To RowCount - 1
					tbl.Rows.Add(New Object() { String.Format("Detail{1}Name{0}", i, j), i, id, -1 })
					Dim parentID As Integer = id
					id += 1
					CreateSubRows(tbl, RowCount, i, parentID, id)
				Next i
			Next j
			Return tbl
		End Function

		Private Function CreateDet2Table(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable("Det2")
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("DETAILID", GetType(Integer))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("ParentID", GetType(Integer))
			Dim id As Integer = 0
			For j As Integer = 0 To RowCount - 1
				For i As Integer = 0 To RowCount - 1
					tbl.Rows.Add(New Object() { String.Format("Detail{1}Name{0}", i, j), i, id, -1 })
					Dim parentID As Integer = id
					id += 1
					CreateSubRows(tbl, RowCount, i, parentID, id)
				Next i
			Next j
			Return tbl
		End Function

		Private Sub CreateSubRows(ByVal tbl As DataTable, ByVal RowCount As Integer, ByVal detailID As Integer, ByVal parentID As Integer, ByRef id As Integer)
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("SubDetail{1}Name{0}", i, parentID), detailID, id, parentID })
				id += 1
			Next i
		End Sub

		Private Function GetMasterDetail() As DataSet
			Dim ds As New DataSet("TestDS")
			ds.Tables.Add(CreateTable(20))
			ds.Tables.Add(CreateDet1Table(20))
			ds.Tables.Add(CreateDet2Table(20))
			Dim parentColumn As DataColumn = ds.Tables("Parent").Columns("DETAILID")
			Dim childColumn As DataColumn = ds.Tables("Det1").Columns("DETAILID")
			ds.Relations.Add(New DataRelation("relDet1", parentColumn, childColumn))
			parentColumn = ds.Tables("Parent").Columns("DETAILID")
			childColumn = ds.Tables("Det2").Columns("DETAILID")
			ds.Relations.Add(New DataRelation("relDet2", parentColumn, childColumn))
			Return ds
		End Function

		Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioGroup1.SelectedIndexChanged
			customView1.InternalControlType = views(radioGroup1.SelectedIndex)
		End Sub
	End Class
End Namespace
