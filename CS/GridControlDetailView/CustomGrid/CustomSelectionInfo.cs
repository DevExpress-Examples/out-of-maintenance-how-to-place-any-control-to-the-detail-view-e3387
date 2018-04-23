using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace CustomGrid
{
    public class CustomSelectionInfo : BaseSelectionInfo
    {
        public CustomSelectionInfo(CustomView view)
            : base(view)
        {
        }

        protected override int GetState()
        {
            throw new NotImplementedException();
        }
    }
}
