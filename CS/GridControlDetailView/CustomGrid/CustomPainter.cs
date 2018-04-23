using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;
using System.Drawing;

namespace CustomGrid
{
    public class CustomPainter : BaseViewPainter
    {
        public CustomPainter(CustomView view)
            : base(view)
        {
        }

        public override void Draw(ViewDrawArgs e)
        {
            CustomView view = (View as CustomView);
            if (view.GridControl.IsDesignMode)
            {
                ShowTitle(e);
                return;
            }
            view.ShowControl(e);
            base.Draw(e);
            DrawBorder(e, e.ViewInfo.Bounds);
        }

        protected virtual void ShowTitle(ViewDrawArgs e)
        {
            CustomView view = (View as CustomView);
            string text = String.Format("{0}: {1}", view.LevelName, view.Name);
            e.Cache.FillRectangle(Color.White, e.Bounds);
            e.Cache.DrawRectangle(new Pen(Color.Gray, 1), e.Bounds);
            Font font = new Font(view.GridControl.Font.FontFamily, 18);
            e.Cache.DrawString(text, font, e.Cache.GetSolidBrush(Color.Gray), e.Bounds, StringFormat.GenericDefault);
        }
    }

    public class CustomViewDrawArgs : ViewDrawArgs
    {
        public CustomViewDrawArgs(GraphicsCache graphicsCache, CustomViewInfo viewInfo, Rectangle bounds)
            : base(graphicsCache, viewInfo, bounds)
        {
        }

        public virtual new CustomViewInfo ViewInfo
        {
            get
            {
                return base.ViewInfo as CustomViewInfo;
            }
        }
    }
}
