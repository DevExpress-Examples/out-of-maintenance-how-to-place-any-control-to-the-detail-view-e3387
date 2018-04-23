Namespace CustomGridControl
	Partial Public Class MyTreeList
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.treeList = New DevExpress.XtraTreeList.TreeList()
			DirectCast(Me.treeList, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList
			' 
			Me.treeList.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList.Location = New System.Drawing.Point(0, 0)
			Me.treeList.Name = "treeList"
			Me.treeList.OptionsView.ShowCheckBoxes = True
			Me.treeList.Size = New System.Drawing.Size(657, 380)
			Me.treeList.TabIndex = 0
			' 
			' MyTreeList
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.treeList)
			Me.Name = "MyTreeList"
			Me.Size = New System.Drawing.Size(657, 380)
			DirectCast(Me.treeList, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public treeList As DevExpress.XtraTreeList.TreeList
	End Class
End Namespace
