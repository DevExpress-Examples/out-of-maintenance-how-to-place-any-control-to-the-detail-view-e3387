using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid;

namespace CustomGrid
{
    [System.ComponentModel.DesignerCategory("")]
    public class CustomView : BaseView
    {
        string fInternalControlType;
        public string InternalControlType
        {
            get
            {
                return fInternalControlType;
            }
            set
            {
                if (value == fInternalControlType)
                    return;
                fInternalControlType = value;
                DisposeControl();
                CreateControl();
            }
        }

        private void DisposeControl()
        {
            if (InternalContainer == null)
                return;
            InternalContainer.Dispose();
            fInternalView = null;
        }

        private void CreateControl()
        {
            fInternalView = (IDetailView)Activator.CreateInstance(Type.GetType(InternalControlType));
            InternalContainer.Visible = false;
            InternalControl.GotFocus += _GotFocus;
            GridControl.Controls.Add(InternalContainer);
        }

        void _GotFocus(object sender, EventArgs e)
        {
            GridControl.FocusedView = this;
        }

        IDetailView fInternalView = null;
        [Browsable(false)]
        public IDetailView InternalView
        {
            get
            {
                return fInternalView;
            }
        }

        [Browsable(false)]
        public Control InternalControl
        {
            get
            {
                if (InternalView == null)
                    return null;
                return InternalView.InternalControl;
            }
        }

        [Browsable(false)]
        public Control InternalContainer
        {
            get
            {
                if (InternalControl == null)
                    return null;
                return InternalControl.Parent;
            }
        }

        public CustomView()
        {
            fViewRect = Rectangle.Empty;
            DataSourceChanged += _DataSourceChanged;
        }


        public CustomView(GridControl ownerGrid)
            : this()
        {
            SetGridControl(ownerGrid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataSourceChanged -= _DataSourceChanged;
                DisposeControl();
            }
            base.Dispose(disposing);
        }

        protected override string ViewName
        {
            get
            {
                return "CustomView";
            }
        }

        protected override DevExpress.Data.BaseGridController CreateDataController()
        {
            return new DevExpress.Data.CurrencyDataController();
        }

        void _DataSourceChanged(object sender, EventArgs e)
        {
            if (InternalView == null)
                return;
            InternalView.DataSource = (sender as BaseView).DataSource;
        }

        protected override bool CanLeaveFocusOnTab(bool moveForward)
        {
            throw new NotImplementedException();
        }

        protected override BaseViewAppearanceCollection CreateAppearances()
        {
            return new BaseViewAppearanceCollection(this);
        }

        protected override BaseViewAppearanceCollection CreateAppearancesPrint()
        {
            return new BaseViewAppearanceCollection(this);
        }

        protected override DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateNullViewInfo()
        {
            return new NullTreeListViewInfo(this);
        }

        protected override ViewPrintOptionsBase CreateOptionsPrint()
        {
            return new ViewPrintOptionsBase();
        }

        public override bool IsZoomedView
        {
            get
            {
                return false;
            }
        }

        protected override void LeaveFocusOnTab(bool moveForward)
        {
            throw new NotImplementedException();
        }

        public override void NormalView()
        {
            throw new NotImplementedException();
        }

        protected override void OnChildLayoutChanged(BaseView childView)
        {
            throw new NotImplementedException();
        }

        protected override void OnVisibleChanged()
        {
            throw new NotImplementedException();
        }

        public override void PopulateColumns()
        {
            throw new NotImplementedException();
        }

        protected override void ResetLookUp(bool sameDataSource)
        {
            throw new NotImplementedException();
        }

        protected override int CalcRealViewHeight(Rectangle rect, bool reduceHeightOnly = true)
        {
            return rect.Height < InternalView.DetailHeight ? rect.Height : InternalView.DetailHeight;
        }

        protected override void SetViewRect(Rectangle newValue)
        {
            if (newValue == Rectangle.Empty)
                HideControl();
            fViewRect = newValue;
            InternalContainer.Visible = false;
            LayoutChangedSynchronized();
        }

        Rectangle fViewRect;
        public override Rectangle ViewRect
        {
            get
            {
                return fViewRect;
            }
        }

        protected override void ZoomView(BaseView prevView)
        {
            throw new NotImplementedException();
        }

        protected override void Draw(GraphicsCache e)
        {
            base.Draw(e);
        }

        public virtual void HideControl()
        {
            if (InternalContainer == null)
                return;
            InternalContainer.Visible = false;
        }

        public virtual void ShowControl(ViewDrawArgs e)
        {
            if (InternalContainer == null)
                return;
            InternalContainer.Bounds = TabControl.CalcPageClient(e.Bounds);
            InternalContainer.Visible = true;
        }

        [Description("Gets a value indicating whether the View is visible on screen.")]
        public override bool IsVisible
        {
            get
            {
                return ViewRect.X > -10000 && !ViewRect.IsEmpty && ViewRect.Right > 0 && ViewRect.Bottom > 0;
            }
        }

        protected override ViewDrawArgs CreateDrawArgs(DXPaintEventArgs e, GraphicsCache cache)
        {
            if (cache == null)
                cache = new GraphicsCache(e, Painter.Paint);
            return new CustomViewDrawArgs(cache, ViewInfo as CustomViewInfo, ViewRect);
        }

        public override void Assign(BaseView v, bool copyEvents)
        {
            base.Assign(v, copyEvents);
            InternalControlType = (v as CustomView).InternalControlType;
        }

        protected override bool CalculateLayout() {
            ((CustomViewInfo)ViewInfo).UpdateTabControlInternal();
            return base.CalculateLayout();
        }

        public override void LayoutChanged() {
            base.LayoutChanged();
            CalculateLayout();
        }
    }
}
