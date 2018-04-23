using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using System.Windows.Forms;

namespace CustomGrid
{
    [System.ComponentModel.DesignerCategory("")]
    public class CustomGridControl : GridControl
    {
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new Registrator());
        }
    }

    public interface IDetailView
    {
        object DataSource { get; set; }

        Control InternalControl { get; }

        int DetailHeight { get; }
    }
}
