Imports Microsoft.VisualBasic
Imports System
Namespace CustomGridControl
	Partial Public Class frmMain
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim gridLevelNode1 As New DevExpress.XtraGrid.GridLevelNode()
			Me.customView1 = New CustomGrid.CustomView()
			Me.customGridControl1 = New CustomGrid.CustomGridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.radioGroup1 = New DevExpress.XtraEditors.RadioGroup()
			CType(Me.customView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.customGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.radioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' customView1
			' 
			Me.customView1.GridControl = Me.customGridControl1
			Me.customView1.InternalControlType = Nothing
			Me.customView1.Name = "customView1"
			' 
			' customGridControl1
			' 
			gridLevelNode1.LevelTemplate = Me.customView1
			gridLevelNode1.RelationName = "relDet1"
			Me.customGridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode1})
			Me.customGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.customGridControl1.MainView = Me.gridView1
			Me.customGridControl1.Name = "customGridControl1"
			Me.customGridControl1.Size = New System.Drawing.Size(1176, 480)
			Me.customGridControl1.TabIndex = 2
			Me.customGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1, Me.customView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.customGridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' radioGroup1
			' 
			Me.radioGroup1.Location = New System.Drawing.Point(12, 486)
			Me.radioGroup1.Name = "radioGroup1"
			Me.radioGroup1.Size = New System.Drawing.Size(1152, 38)
			Me.radioGroup1.TabIndex = 1
'			Me.radioGroup1.SelectedIndexChanged += New System.EventHandler(Me.radioGroup1_SelectedIndexChanged);
			' 
			' frmMain
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1176, 536)
			Me.Controls.Add(Me.customGridControl1)
			Me.Controls.Add(Me.radioGroup1)
			Me.Name = "frmMain"
			Me.Text = "Form1"
			CType(Me.customView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.customGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.radioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents radioGroup1 As DevExpress.XtraEditors.RadioGroup
		Private customGridControl1 As CustomGrid.CustomGridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private customView1 As CustomGrid.CustomView
	End Class
End Namespace

