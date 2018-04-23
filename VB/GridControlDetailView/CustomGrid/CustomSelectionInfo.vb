Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Base.ViewInfo

Namespace CustomGrid
	Public Class CustomSelectionInfo
		Inherits BaseSelectionInfo

		Public Sub New(ByVal view As CustomView)
			MyBase.New(view)
		End Sub

		Protected Overrides Function GetState() As Integer
			Throw New NotImplementedException()
		End Function
	End Class
End Namespace
