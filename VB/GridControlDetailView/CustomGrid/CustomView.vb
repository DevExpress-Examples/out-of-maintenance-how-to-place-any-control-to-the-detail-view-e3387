Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraGrid

Namespace CustomGrid
	<System.ComponentModel.DesignerCategory("")>
	Public Class CustomView
		Inherits BaseView

		Private fInternalControlType As String
		Public Property InternalControlType() As String
			Get
				Return fInternalControlType
			End Get
			Set(ByVal value As String)
				If value = fInternalControlType Then
					Return
				End If
				fInternalControlType = value
				DisposeControl()
				CreateControl()
			End Set
		End Property

		Private Sub DisposeControl()
			If InternalContainer Is Nothing Then
				Return
			End If
			InternalContainer.Dispose()
			fInternalView = Nothing
		End Sub

		Private Sub CreateControl()
			fInternalView = DirectCast(Activator.CreateInstance(Type.GetType(InternalControlType)), IDetailView)
			InternalContainer.Visible = False
			AddHandler InternalControl.GotFocus, AddressOf _GotFocus
			GridControl.Controls.Add(InternalContainer)
		End Sub

		Private Sub _GotFocus(ByVal sender As Object, ByVal e As EventArgs)
			GridControl.FocusedView = Me
		End Sub

		Private fInternalView As IDetailView = Nothing
		<Browsable(False)>
		Public ReadOnly Property InternalView() As IDetailView
			Get
				Return fInternalView
			End Get
		End Property

		<Browsable(False)>
		Public ReadOnly Property InternalControl() As Control
			Get
				If InternalView Is Nothing Then
					Return Nothing
				End If
				Return InternalView.InternalControl
			End Get
		End Property

		<Browsable(False)>
		Public ReadOnly Property InternalContainer() As Control
			Get
				If InternalControl Is Nothing Then
					Return Nothing
				End If
				Return InternalControl.Parent
			End Get
		End Property

		Public Sub New()
			fViewRect = Rectangle.Empty
			AddHandler DataSourceChanged, AddressOf _DataSourceChanged
		End Sub


		Public Sub New(ByVal ownerGrid As GridControl)
			Me.New()
			SetGridControl(ownerGrid)
		End Sub

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				RemoveHandler DataSourceChanged, AddressOf _DataSourceChanged
				DisposeControl()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "CustomView"
			End Get
		End Property

		Protected Overrides Function CreateDataController() As DevExpress.Data.BaseGridController
			Return New DevExpress.Data.CurrencyDataController()
		End Function

		Private Sub _DataSourceChanged(ByVal sender As Object, ByVal e As EventArgs)
			If InternalView Is Nothing Then
				Return
			End If
			InternalView.DataSource = (TryCast(sender, BaseView)).DataSource
		End Sub

		Protected Overrides Function CanLeaveFocusOnTab(ByVal moveForward As Boolean) As Boolean
			Throw New NotImplementedException()
		End Function

		Protected Overrides Function CreateAppearances() As BaseViewAppearanceCollection
			Return New BaseViewAppearanceCollection(Me)
		End Function

		Protected Overrides Function CreateAppearancesPrint() As BaseViewAppearanceCollection
			Return New BaseViewAppearanceCollection(Me)
		End Function

		Protected Overrides Function CreateNullViewInfo() As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo
			Return New NullTreeListViewInfo(Me)
		End Function

		Protected Overrides Function CreateOptionsPrint() As ViewPrintOptionsBase
			Return New ViewPrintOptionsBase()
		End Function

		Public Overrides ReadOnly Property IsZoomedView() As Boolean
			Get
				Return False
			End Get
		End Property

		Protected Overrides Sub LeaveFocusOnTab(ByVal moveForward As Boolean)
			Throw New NotImplementedException()
		End Sub

		Public Overrides Sub NormalView()
			Throw New NotImplementedException()
		End Sub

		Protected Overrides Sub OnChildLayoutChanged(ByVal childView As BaseView)
			Throw New NotImplementedException()
		End Sub

		Protected Overrides Sub OnVisibleChanged()
			Throw New NotImplementedException()
		End Sub

		Public Overrides Sub PopulateColumns()
			Throw New NotImplementedException()
		End Sub

		Protected Overrides Sub ResetLookUp(ByVal sameDataSource As Boolean)
			Throw New NotImplementedException()
		End Sub

		Protected Overrides Function CalcRealViewHeight(ByVal rect As Rectangle, Optional ByVal reduceHeightOnly As Boolean = True) As Integer
			Return If(rect.Height < InternalView.DetailHeight, rect.Height, InternalView.DetailHeight)
		End Function

		Protected Overrides Sub SetViewRect(ByVal newValue As Rectangle)
			If newValue = Rectangle.Empty Then
				HideControl()
			End If
			fViewRect = newValue
			InternalContainer.Visible = False
			LayoutChangedSynchronized()
		End Sub

		Private fViewRect As Rectangle
		Public Overrides ReadOnly Property ViewRect() As Rectangle
			Get
				Return fViewRect
			End Get
		End Property

		Protected Overrides Sub ZoomView(ByVal prevView As BaseView)
			Throw New NotImplementedException()
		End Sub

		Protected Overrides Sub Draw(ByVal e As GraphicsCache)
			MyBase.Draw(e)
		End Sub

		Public Overridable Sub HideControl()
			If InternalContainer Is Nothing Then
				Return
			End If
			InternalContainer.Visible = False
		End Sub

		Public Overridable Sub ShowControl(ByVal e As ViewDrawArgs)
			If InternalContainer Is Nothing Then
				Return
			End If
			InternalContainer.Bounds = TabControl.CalcPageClient(e.Bounds)
			InternalContainer.Visible = True
		End Sub

		<Description("Gets a value indicating whether the View is visible on screen.")>
		Public Overrides ReadOnly Property IsVisible() As Boolean
			Get
				Return ViewRect.X > -10000 AndAlso (Not ViewRect.IsEmpty) AndAlso ViewRect.Right > 0 AndAlso ViewRect.Bottom > 0
			End Get
		End Property

		Protected Overrides Function CreateDrawArgs(ByVal e As DXPaintEventArgs, ByVal cache As GraphicsCache) As ViewDrawArgs
			If cache Is Nothing Then
				cache = New GraphicsCache(e, Painter.Paint)
			End If
			Return New CustomViewDrawArgs(cache, TryCast(ViewInfo, CustomViewInfo), ViewRect)
		End Function

		Public Overrides Sub Assign(ByVal v As BaseView, ByVal copyEvents As Boolean)
			MyBase.Assign(v, copyEvents)
			InternalControlType = (TryCast(v, CustomView)).InternalControlType
		End Sub

		Protected Overrides Function CalculateLayout() As Boolean
			CType(ViewInfo, CustomViewInfo).UpdateTabControlInternal()
			Return MyBase.CalculateLayout()
		End Function

		Public Overrides Sub LayoutChanged()
			MyBase.LayoutChanged()
			CalculateLayout()
		End Sub
	End Class
End Namespace
