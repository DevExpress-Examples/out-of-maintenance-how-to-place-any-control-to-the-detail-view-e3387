Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils.Drawing
Imports System.Drawing

Namespace CustomGrid
	Public Class CustomPainter
		Inherits BaseViewPainter
		Public Sub New(ByVal view As CustomView)
			MyBase.New(view)
		End Sub

		Public Overrides Sub Draw(ByVal e As ViewDrawArgs)
			Dim view As CustomView = (TryCast(View, CustomView))
			If view.GridControl.IsDesignMode Then
				ShowTitle(e)
				Return
			End If
			view.ShowControl(e)
			MyBase.Draw(e)
			DrawBorder(e, e.ViewInfo.Bounds)
		End Sub

		Protected Overridable Sub ShowTitle(ByVal e As ViewDrawArgs)
			Dim view As CustomView = (TryCast(View, CustomView))
			Dim text As String = String.Format("{0}: {1}", view.LevelName, view.Name)
			e.Cache.FillRectangle(Color.White, e.Bounds)
			e.Cache.DrawRectangle(New Pen(Color.Gray, 1), e.Bounds)
			Dim font As New Font(view.GridControl.Font.FontFamily, 18)
			e.Cache.DrawString(text, font, e.Cache.GetSolidBrush(Color.Gray), e.Bounds, StringFormat.GenericDefault)
		End Sub
	End Class

	Public Class CustomViewDrawArgs
		Inherits ViewDrawArgs
		Public Sub New(ByVal graphicsCache As GraphicsCache, ByVal viewInfo As CustomViewInfo, ByVal bounds As Rectangle)
			MyBase.New(graphicsCache, viewInfo, bounds)
		End Sub

		Public Overridable Shadows ReadOnly Property ViewInfo() As CustomViewInfo
			Get
				Return TryCast(MyBase.ViewInfo, CustomViewInfo)
			End Get
		End Property
	End Class
End Namespace
