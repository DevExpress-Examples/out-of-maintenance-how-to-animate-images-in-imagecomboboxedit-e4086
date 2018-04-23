Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Windows.Forms
Imports DevExpress.Utils.Drawing.Animation
Imports DevExpress.Utils
Imports System.Drawing.Imaging

Namespace AnimateImageComboBox

	Public Class CustomImageComboBoxEditViewInfo
		Inherits ImageComboBoxEditViewInfo
		Implements ISupportXtraAnimation, IAnimatedItem
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
		End Sub

		Public ReadOnly Property Image() As Image
			Get
				Return If(CanImagesBeAnimated, (TryCast(Me.Images, ImageCollection)).Images(Me.ImageIndex), Nothing)
			End Get
		End Property

		Private oldImage As Image = Nothing

		Public ReadOnly Property CanImagesBeAnimated() As Boolean
			Get
				Return ((Me.ImageIndex <> -1) AndAlso (TypeOf Me.Images Is ImageCollection))
			End Get
		End Property

		Protected Overrides Sub OnEditValueChanged()
			MyBase.OnEditValueChanged()
			If CanImagesBeAnimated Then
				Me.StartAnimation()
			End If
		End Sub


		Public Overridable Sub StopAnimation()
			XtraAnimator.RemoveObject(Me)
		End Sub
		Public Overridable Sub StartAnimation()
			Dim animItem As IAnimatedItem = Me
			If OwnerEdit Is Nothing OrElse OwnerEdit.IsDesignMode OrElse animItem.FramesCount < 2 Then
				Return
			End If
			XtraAnimator.Current.AddEditorAnimation(Nothing, Me, animItem, New CustomAnimationInvoker(AddressOf OnImageAnimation))
		End Sub
		Protected Overridable Sub OnImageAnimation(ByVal animInfo As BaseAnimationInfo)
			Dim animItem As IAnimatedItem = Me
			Dim info As EditorAnimationInfo = TryCast(animInfo, EditorAnimationInfo)
			If Image Is Nothing OrElse OwnerEdit Is Nothing OrElse info Is Nothing Then
				Return
			End If
			If (Not info.IsFinalFrame) Then
				Image.SelectActiveFrame(FrameDimension.Time, info.CurrentFrame)
				OwnerEdit.Invalidate(animItem.AnimationBounds)
			Else
				StopAnimation()
				StartAnimation()
			End If
		End Sub

		Public ReadOnly Property CanAnimate() As Boolean Implements ISupportXtraAnimation.CanAnimate
			Get
				Return ((CType(Me, IAnimatedItem)).FramesCount > 1)
			End Get
		End Property

		Public Shadows ReadOnly Property OwnerControl() As Control Implements ISupportXtraAnimation.OwnerControl
			Get
				Return OwnerEdit
			End Get
		End Property

		Private ReadOnly Property AnimationBounds() As Rectangle Implements IAnimatedItem.AnimationBounds
			Get
				Return Me.GlyphBounds
			End Get
		End Property
		Private ReadOnly Property AnimationInterval() As Integer Implements IAnimatedItem.AnimationInterval
			Get
				Return ImageHelper.AnimationInterval
			End Get
		End Property
		Private ReadOnly Property AnimationIntervals() As Integer() Implements IAnimatedItem.AnimationIntervals
			Get
				Return ImageHelper.AnimationIntervals
			End Get
		End Property
		Private ReadOnly Property IAnimatedItem_AnimationType() As AnimationType Implements IAnimatedItem.AnimationType
			Get
				Return ImageHelper.AnimationType
			End Get
		End Property
		Private ReadOnly Property FramesCount() As Integer Implements IAnimatedItem.FramesCount
			Get
				Return ImageHelper.FramesCount
			End Get
		End Property
		Private Function GetAnimationInterval(ByVal frameIndex As Integer) As Integer Implements IAnimatedItem.GetAnimationInterval
			Return ImageHelper.GetAnimationInterval(frameIndex)
		End Function
		Private ReadOnly Property IsAnimated() As Boolean Implements IAnimatedItem.IsAnimated
			Get
				Return ImageHelper.IsAnimated
			End Get
		End Property
		Private Sub OnStart() Implements IAnimatedItem.OnStart
		End Sub
		Private Sub OnStop() Implements IAnimatedItem.OnStop
		End Sub
		Private ReadOnly Property Owner() As Object Implements IAnimatedItem.Owner
			Get
				Return OwnerEdit
			End Get
		End Property
		Private Sub UpdateAnimation(ByVal info As BaseAnimationInfo) Implements IAnimatedItem.UpdateAnimation
			ImageHelper.UpdateAnimation(info)
		End Sub

		Private imageHelper_Renamed As AnimatedImageHelper
		Protected ReadOnly Property ImageHelper() As AnimatedImageHelper
			Get
				If (oldImage IsNot Image) OrElse (imageHelper_Renamed Is Nothing) Then
					imageHelper_Renamed = New AnimatedImageHelper(Image)
					oldImage = Image
				End If

				Return imageHelper_Renamed
			End Get
		End Property


	End Class
End Namespace
