Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Base

Namespace CustomGrid
	Public Class CustomViewInfo
		Inherits BaseViewInfo

		Public Sub New(ByVal view As CustomView)
			MyBase.New(view)
			IsReady = True
		End Sub

		Public Overrides ReadOnly Property View() As BaseView
			Get
				Return MyBase.View
			End Get
		End Property

		Protected Overrides Sub AddAnimatedItems()
			Throw New NotImplementedException()
		End Sub

		Public Overrides ReadOnly Property Bounds() As System.Drawing.Rectangle
			Get
				Return View.ViewRect
			End Get
		End Property

		Public Overrides ReadOnly Property ClientBounds() As System.Drawing.Rectangle
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Protected Overrides Function CreatePaintAppearances() As DevExpress.Utils.BaseAppearanceCollection
			Return New DevExpress.Utils.BaseAppearanceCollection()
		End Function

		Protected Overrides Function CreateSelectionInfo() As BaseSelectionInfo
			Return New CustomSelectionInfo(TryCast(View, CustomView))
		End Function

		Protected Overrides Function HasItem(ByVal id As CellId) As DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo
			Throw New NotImplementedException()
		End Function

		Friend Sub UpdateTabControlInternal()
			UpdateTabControl()
		End Sub

		Protected Overrides Sub UpdateTabControl()
			MyBase.UpdateTabControl()
			TabControl.Bounds = CalcBorderRect(Bounds)
		End Sub
	End Class

	Friend Class NullTreeListViewInfo
		Inherits CustomViewInfo

		Public Sub New(ByVal treeListView As CustomView)
			MyBase.New(treeListView)
		End Sub

		Public Overrides ReadOnly Property IsNull() As Boolean
			Get
				Return True
			End Get
		End Property
	End Class
End Namespace
