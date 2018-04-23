Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Registrator
Imports System.ComponentModel
Imports DevExpress.XtraEditors

Namespace AnimateImageComboBox
	 <UserRepositoryItem("Register")> _
	 Friend Class MyImageComboboxEdit
		 Inherits ImageComboBoxEdit
		 Shared Sub New()
			RepositoryItemMyImageComboBox.Register()
		 End Sub

			Public Sub New()
			End Sub

		Public Overridable Sub StartAnimation()
			ViewInfo.StartAnimation()
		End Sub
		Public Overridable Sub StopAnimation()
			ViewInfo.StopAnimation()
		End Sub

		Protected Friend Shadows ReadOnly Property ViewInfo() As CustomImageComboBoxEditViewInfo
			Get
				Return TryCast(MyBase.ViewInfo, CustomImageComboBoxEditViewInfo)
			End Get
		End Property

		Public Overrides ReadOnly Property EditorTypeName() As String
				Get
					Return RepositoryItemMyImageComboBox.EditorName
				End Get
		End Property


		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMyImageComboBox
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMyImageComboBox)
			End Get
		End Property

		Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
			MyBase.OnVisibleChanged(e)
			If ((Not Visible)) AndAlso (ViewInfo.CanImagesBeAnimated) Then
				StopAnimation()
			ElseIf Visible AndAlso (ViewInfo.CanImagesBeAnimated) Then
				StartAnimation()
			End If

		End Sub

	 End Class











End Namespace
