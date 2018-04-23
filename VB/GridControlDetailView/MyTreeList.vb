Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports CustomGrid

Namespace CustomGridControl
	Partial Public Class MyTreeList
		Inherits UserControl
		Implements IDetailView

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property DataSource() As Object Implements IDetailView.DataSource
			Get
				Return treeList.DataSource
			End Get
			Set(ByVal value As Object)
				treeList.DataSource = value
			End Set
		End Property

		Public ReadOnly Property InternalControl() As Control Implements IDetailView.InternalControl
			Get
				Return treeList
			End Get
		End Property

'INSTANT VB NOTE: The variable detailHeight was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private detailHeight_Renamed As Integer = 350
		Public ReadOnly Property DetailHeight() As Integer Implements IDetailView.DetailHeight
			Get
				Return detailHeight_Renamed
			End Get
		End Property
	End Class
End Namespace
