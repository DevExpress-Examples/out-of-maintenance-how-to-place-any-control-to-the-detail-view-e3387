Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports CustomGrid

Namespace CustomGridControl
	Partial Public Class MyVGrid
		Inherits UserControl
		Implements IDetailView
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property DataSource() As Object Implements IDetailView.DataSource
			Get
				Return vGridControl1.DataSource
			End Get
			Set(ByVal value As Object)
				vGridControl1.DataSource = value
			End Set
		End Property

		Public ReadOnly Property InternalControl() As Control Implements IDetailView.InternalControl
			Get
				Return vGridControl1
			End Get
		End Property

		Private detailHeight_Renamed As Integer = 95
		Public ReadOnly Property DetailHeight() As Integer Implements IDetailView.DetailHeight
			Get
				Return detailHeight_Renamed
			End Get
		End Property
	End Class
End Namespace
