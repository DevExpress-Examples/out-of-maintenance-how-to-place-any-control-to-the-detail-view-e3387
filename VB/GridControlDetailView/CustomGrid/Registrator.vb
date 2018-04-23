Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid
Imports DevExpress.Utils

Namespace CustomGrid
	Friend Class Registrator
		Inherits BaseInfoRegistrator
		Public Overrides ReadOnly Property ViewName() As String
			Get
				Return "CustomView"
			End Get
		End Property

		Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
			Return New CustomView(grid)
		End Function

		Public Overrides Function CreateViewInfo(ByVal view As BaseView) As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo
			Return New CustomViewInfo(TryCast(view, CustomView))
		End Function

		Public Overrides Function CreatePainter(ByVal view As BaseView) As BaseViewPainter
			Return New CustomPainter(TryCast(view, CustomView))
		End Function

		Public Overrides Function CreateHandler(ByVal view As BaseView) As DevExpress.XtraGrid.Views.Base.Handler.BaseViewHandler
			Return New CustomHandler(TryCast(view, CustomView))
		End Function

		Protected Overrides Sub RegisterViewPaintStyles()
			PaintStyles.Add(New FakeViewPaintStyle(Function() New CustomViewPaintStyle(), "Flat"))
		End Sub
	End Class

	Friend Delegate Function CreateViewPaintStyle() As ViewPaintStyle
	Friend Class FakeViewPaintStyle
		Inherits ViewPaintStyle
		Private creator As CreateViewPaintStyle
		Private name_Renamed As String

		Public Function Create() As ViewPaintStyle
			Return creator()
		End Function

		Public Sub New(ByVal creator As CreateViewPaintStyle, ByVal name As String)
			Me.creator = creator
			Me.name_Renamed = name
		End Sub

		Public Overrides ReadOnly Property Name() As String
			Get
				Return name_Renamed
			End Get
		End Property

		Public Overrides Function GetAppearanceDefaultInfo(ByVal view As BaseView) As AppearanceDefaultInfo()
			Throw New InvalidOperationException()
		End Function
	End Class

	Public Class CustomViewPaintStyle
		Inherits ViewPaintStyle
		Public Overrides Sub UpdateElementsLookAndFeel(ByVal view As BaseView)
			view.PaintStyleName = Name
		End Sub

		Public Overrides Function GetAppearanceDefaultInfo(ByVal view As BaseView) As AppearanceDefaultInfo()
			Throw New NotImplementedException()
		End Function

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "Flat"
			End Get
		End Property
	End Class
End Namespace
