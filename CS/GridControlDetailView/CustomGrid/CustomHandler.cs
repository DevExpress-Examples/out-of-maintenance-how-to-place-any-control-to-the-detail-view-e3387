using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Base.Handler;

namespace CustomGrid
{
    class CustomHandler : BaseViewHandler
    {
        public CustomHandler(CustomView view)
            : base(view)
        {
        }
    }
}

