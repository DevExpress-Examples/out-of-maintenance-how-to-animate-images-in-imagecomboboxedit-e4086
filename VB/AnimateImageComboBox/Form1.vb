Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils
Imports DevExpress.XtraEditors

Namespace AnimateImageComboBox
	Partial Public Class Form1
		Inherits XtraForm
		Private imageCollection As ImageCollection

		Public Sub New()
			InitializeComponent()

			Dim imageCombo As New RepositoryItemMyImageComboBox()
			imageCombo.GlyphAlignment = HorzAlignment.Center
			imageCollection = New ImageCollection(False)
			imageCollection.ImageSize = New Size(30, 30)

			FillImageCollection()
			AddItemsToRepositoryItem(imageCombo, imageCollection)
			AddItemsToControl(myImageComboboxEdit1, imageCollection)

			gridControl1.RepositoryItems.Add(imageCombo)
			CreateDataSource()
			gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent
			gridView1.Columns("OrderCost").ColumnEdit = imageCombo

		End Sub



		Private Sub CreateDataSource()
			Dim dataTable As New DataTable()
			dataTable.Columns.Add("Name", GetType(String))
			dataTable.Columns.Add("Order Date", GetType(DateTime))
			dataTable.Columns.Add("OrderCost", GetType(Integer))

			dataTable.Rows.Add(New Object() { "John Smith", " 01 / 01 / 2010", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "Ivanov", "01/01/2011", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "Petrov", "01 / 05 / 2011", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "John Smith", " 04 / 01 / 2010", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "Ivanov", "01/11/2011", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "Petrov", "01 / 06 / 2011", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "John Smith", " 11 / 01 / 2012", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "Ivanov", "04/04/2011", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "Petrov", "24 / 05 / 2012", imageCollection.Images.Count - 1 })
			dataTable.Rows.Add(New Object() { "John Smith", " 26 / 04 / 2012", imageCollection.Images.Count - 1 })
			gridControl1.DataSource = dataTable

		End Sub

		Private Sub AddItemsToRepositoryItem(ByVal item As RepositoryItemMyImageComboBox, ByVal imgList As ImageCollection)
			For i As Integer = 0 To imgList.Images.Count - 1
				item.Items.Add(New ImageComboBoxItem("Item " & (i + 1).ToString(), i, i))
			Next i
			item.SmallImages = imgList

		End Sub

		Private Sub AddItemsToControl(ByVal editor As MyImageComboboxEdit, ByVal imgList As ImageCollection)
			For i As Integer = 0 To imgList.Images.Count - 1
				editor.Properties.Items.Add(New ImageComboBoxItem("Item " & (i + 1).ToString(), i, i))
			Next i
			editor.Properties.SmallImages = imgList

		End Sub


		Private Sub FillImageCollection()
			imageCollection.AddImage(Image.FromFile("..\..\IMAGES\low.gif"))
			imageCollection.AddImage(Image.FromFile("..\..\IMAGES\10_1.gif"))
			imageCollection.AddImage(Image.FromFile("..\..\IMAGES\high.gif"))
		End Sub

	End Class
End Namespace
