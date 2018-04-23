Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Registrator
Imports System.Windows.Forms

Namespace CustomGrid
	<System.ComponentModel.DesignerCategory("")>
	Public Class CustomGridControl
		Inherits GridControl

		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New Registrator())
		End Sub
	End Class

	Public Interface IDetailView
		Property DataSource() As Object

		ReadOnly Property InternalControl() As Control

		ReadOnly Property DetailHeight() As Integer
	End Interface
End Namespace
