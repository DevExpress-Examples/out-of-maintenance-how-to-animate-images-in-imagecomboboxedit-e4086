Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils
Imports System.Drawing.Imaging

Namespace AnimateImageComboBox

	Public Class RepositoryItemMyImageComboBox
		Inherits RepositoryItemImageComboBox

		Shared Sub New()
			Register()
		End Sub

		Public Sub New()
		End Sub



		Friend Const EditorName As String = "MyImageComboboxEdit"


		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MyImageComboboxEdit), GetType(RepositoryItemMyImageComboBox), GetType(CustomImageComboBoxEditViewInfo), New ImageComboBoxEditPainter(), True, 0, GetType(DevExpress.Accessibility.PopupEditAccessible)))
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property

		Protected Overrides Sub RaiseDropDownCustomDrawItem(ByVal e As ListBoxDrawItemEventArgs)
			Dim item As ImageComboBoxItem = TryCast(e.Item, ImageComboBoxItem)

			If TypeOf item.Images Is ImageCollection Then
				Dim image As Image = (TryCast(item.Images, ImageCollection)).Images(e.Index)
				image.SelectActiveFrame(New FrameDimension(image.FrameDimensionsList(0)), 0)
			End If

			MyBase.RaiseDropDownCustomDrawItem(e)
		End Sub



	End Class
End Namespace
