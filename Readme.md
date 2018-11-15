<!-- default file list -->
*Files to look at*:

* [CustomGridControl.cs](./CS/GridControlDetailView/CustomGrid/CustomGridControl.cs) (VB: [CustomGridControl.vb](./VB/GridControlDetailView/CustomGrid/CustomGridControl.vb))
* [CustomHandler.cs](./CS/GridControlDetailView/CustomGrid/CustomHandler.cs) (VB: [CustomHandler.vb](./VB/GridControlDetailView/CustomGrid/CustomHandler.vb))
* [CustomPainter.cs](./CS/GridControlDetailView/CustomGrid/CustomPainter.cs) (VB: [CustomPainter.vb](./VB/GridControlDetailView/CustomGrid/CustomPainter.vb))
* [CustomSelectionInfo.cs](./CS/GridControlDetailView/CustomGrid/CustomSelectionInfo.cs) (VB: [CustomSelectionInfo.vb](./VB/GridControlDetailView/CustomGrid/CustomSelectionInfo.vb))
* [CustomView.cs](./CS/GridControlDetailView/CustomGrid/CustomView.cs) (VB: [CustomView.vb](./VB/GridControlDetailView/CustomGrid/CustomView.vb))
* [CustomViewInfo.cs](./CS/GridControlDetailView/CustomGrid/CustomViewInfo.cs) (VB: [CustomViewInfo.vb](./VB/GridControlDetailView/CustomGrid/CustomViewInfo.vb))
* [Registrator.cs](./CS/GridControlDetailView/CustomGrid/Registrator.cs) (VB: [Registrator.vb](./VB/GridControlDetailView/CustomGrid/Registrator.vb))
<!-- default file list end -->
# How to place any control to the Detail View


<p>This example demonstrates how to place TreeList into the Detail View of GridControl. It is necessary to implement the IDetailView interface in your UserControl. Your UserControl should contain a Control that represents the Detail View. The IDetailView interface has three properties: DataSource, InternalControl and DetailHeight. The DataSource property wraps a datasource in your Control. The InternalControl property returns this Control. The DetailHeight property sets the Detail View height.</p>

<br/>


