<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630605/16.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3387)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomGridControl.cs](./CS/GridControlDetailView/CustomGrid/CustomGridControl.cs) (VB: [CustomGridControl.vb](./VB/GridControlDetailView/CustomGrid/CustomGridControl.vb))
* [CustomHandler.cs](./CS/GridControlDetailView/CustomGrid/CustomHandler.cs) (VB: [CustomHandler.vb](./VB/GridControlDetailView/CustomGrid/CustomHandler.vb))
* [CustomPainter.cs](./CS/GridControlDetailView/CustomGrid/CustomPainter.cs) (VB: [CustomPainter.vb](./VB/GridControlDetailView/CustomGrid/CustomPainter.vb))
* [CustomSelectionInfo.cs](./CS/GridControlDetailView/CustomGrid/CustomSelectionInfo.cs) (VB: [CustomSelectionInfo.vb](./VB/GridControlDetailView/CustomGrid/CustomSelectionInfo.vb))
* [CustomView.cs](./CS/GridControlDetailView/CustomGrid/CustomView.cs) (VB: [CustomView.vb](./VB/GridControlDetailView/CustomGrid/CustomView.vb))
* [CustomViewInfo.cs](./CS/GridControlDetailView/CustomGrid/CustomViewInfo.cs) (VB: [CustomViewInfo.vb](./VB/GridControlDetailView/CustomGrid/CustomViewInfo.vb))
* [Registrator.cs](./CS/GridControlDetailView/CustomGrid/Registrator.cs) (VB: [Registrator.vb](./VB/GridControlDetailView/CustomGrid/Registrator.vb))
* [frmMain.cs](./CS/GridControlDetailView/frmMain.cs) (VB: [frmMain.vb](./VB/GridControlDetailView/frmMain.vb))
* [MyTreeList.cs](./CS/GridControlDetailView/MyTreeList.cs) (VB: [MyTreeList.vb](./VB/GridControlDetailView/MyTreeList.vb))
* [MyVGrid.cs](./CS/GridControlDetailView/MyVGrid.cs) (VB: [MyVGrid.vb](./VB/GridControlDetailView/MyVGrid.vb))
* [Program.cs](./CS/GridControlDetailView/Program.cs) (VB: [Program.vb](./VB/GridControlDetailView/Program.vb))
<!-- default file list end -->
# How to place any control to the Detail View


<p>This example demonstrates how to place TreeList into the Detail View of GridControl. It is necessary to implement the IDetailView interface in your UserControl. Your UserControl should contain a Control that represents the Detail View. The IDetailView interface has three properties: DataSource, InternalControl and DetailHeight. The DataSource property wraps a datasource in your Control. The InternalControl property returns this Control. The DetailHeight property sets the Detail View height.</p>

<br/>


