Imports Microsoft.VisualBasic
Imports System
Namespace CustomGridControl
	Partial Public Class MyVGrid
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
			Me.vGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
			CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' vGridControl1
			' 
			Me.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.vGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.vGridControl1.Name = "vGridControl1"
			Me.vGridControl1.Size = New System.Drawing.Size(364, 93)
			Me.vGridControl1.TabIndex = 0
			' 
			' MyVGrid
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.vGridControl1)
			Me.Name = "MyVGrid"
			Me.Size = New System.Drawing.Size(364, 93)
			CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private vGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
	End Class
End Namespace
