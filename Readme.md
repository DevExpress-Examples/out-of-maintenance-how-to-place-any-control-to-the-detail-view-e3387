# How to place any control to the Detail View


<p>This example demonstrates how to place TreeList into the Detail View of GridControl. It is necessary to implement the IDetailView interface in your UserControl. Your UserControl should contain a Control that represents the Detail View. The IDetailView interface has three properties: DataSource, InternalControl and DetailHeight. The DataSource property wraps a datasource in your Control. The InternalControl property returns this Control. The DetailHeight property sets the Detail View height.</p>

<br/>


