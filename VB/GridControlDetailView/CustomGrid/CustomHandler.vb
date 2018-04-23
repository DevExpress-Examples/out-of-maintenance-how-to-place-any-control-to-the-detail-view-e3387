Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Base.Handler

Namespace CustomGrid
	Friend Class CustomHandler
		Inherits BaseViewHandler

		Public Sub New(ByVal view As CustomView)
			MyBase.New(view)
		End Sub
	End Class
End Namespace

