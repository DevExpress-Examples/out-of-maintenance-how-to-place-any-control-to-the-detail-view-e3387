using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Base;

namespace CustomGrid
{
    public class CustomViewInfo : BaseViewInfo
    {
        public CustomViewInfo(CustomView view)
            : base(view)
        {
            IsReady = true;
        }

        public override BaseView View
        {
            get
            {
                return base.View;
            }
        }

        protected override void AddAnimatedItems()
        {
            throw new NotImplementedException();
        }

        public override System.Drawing.Rectangle Bounds
        {
            get
            {
                return View.ViewRect;
            }
        }

        public override System.Drawing.Rectangle ClientBounds
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override DevExpress.Utils.BaseAppearanceCollection CreatePaintAppearances()
        {
            return new DevExpress.Utils.BaseAppearanceCollection();
        }

        protected override BaseSelectionInfo CreateSelectionInfo()
        {
            return new CustomSelectionInfo(View as CustomView);
        }

        protected override DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo HasItem(CellId id)
        {
            throw new NotImplementedException();
        }

        internal void UpdateTabControlInternal() {
            UpdateTabControl();
        }

        protected override void UpdateTabControl() {
            base.UpdateTabControl();
            TabControl.Bounds = CalcBorderRect(Bounds);
        }
    }

    internal class NullTreeListViewInfo : CustomViewInfo
    {
        public NullTreeListViewInfo(CustomView treeListView)
            : base(treeListView)
        {
        }

        public override bool IsNull
        {
            get
            {
                return true;
            }
        }
    }
}
