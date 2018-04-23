using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.Utils;

namespace CustomGrid
{
    class Registrator : BaseInfoRegistrator
    {
        public override string ViewName
        {
            get
            {
                return "CustomView";
            }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new CustomView(grid);
        }

        public override DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new CustomViewInfo(view as CustomView);
        }

        public override BaseViewPainter CreatePainter(BaseView view)
        {
            return new CustomPainter(view as CustomView);
        }

        public override DevExpress.XtraGrid.Views.Base.Handler.BaseViewHandler CreateHandler(BaseView view)
        {
            return new CustomHandler(view as CustomView);
        }

        protected override void RegisterViewPaintStyles()
        {
            PaintStyles.Add(new FakeViewPaintStyle(delegate
            {
                return new CustomViewPaintStyle();
            }, "Flat"));
        }
    }

    delegate ViewPaintStyle CreateViewPaintStyle();
    class FakeViewPaintStyle : ViewPaintStyle
    {
        CreateViewPaintStyle creator;
        string name;

        public ViewPaintStyle Create()
        {
            return creator();
        }

        public FakeViewPaintStyle(CreateViewPaintStyle creator, string name)
        {
            this.creator = creator;
            this.name = name;
        }

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override AppearanceDefaultInfo[] GetAppearanceDefaultInfo(BaseView view)
        {
            throw new InvalidOperationException();
        }
    }

    public class CustomViewPaintStyle : ViewPaintStyle
    {
        public override void UpdateElementsLookAndFeel(BaseView view)
        {
            view.PaintStyleName = Name;
        }

        public override AppearanceDefaultInfo[] GetAppearanceDefaultInfo(BaseView view)
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get
            {
                return "Flat";
            }
        }
    }
}
