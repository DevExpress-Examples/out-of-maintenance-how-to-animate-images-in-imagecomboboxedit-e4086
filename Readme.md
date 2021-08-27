<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619024/11.2.11%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4086)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomImageComboBoxEditViewInfo.cs](./CS/AnimateImageComboBox/CustomImageComboBoxEditViewInfo.cs) (VB: [CustomImageComboBoxEditViewInfo.vb](./VB/AnimateImageComboBox/CustomImageComboBoxEditViewInfo.vb))
* [Form1.cs](./CS/AnimateImageComboBox/Form1.cs) (VB: [Form1.vb](./VB/AnimateImageComboBox/Form1.vb))
* [MyImageComboboxEdit.cs](./CS/AnimateImageComboBox/MyImageComboboxEdit.cs) (VB: [MyImageComboboxEdit.vb](./VB/AnimateImageComboBox/MyImageComboboxEdit.vb))
* [Program.cs](./CS/AnimateImageComboBox/Program.cs) (VB: [Program.vb](./VB/AnimateImageComboBox/Program.vb))
* [RepositoryItemMyImageComboBox.cs](./CS/AnimateImageComboBox/RepositoryItemMyImageComboBox.cs) (VB: [RepositoryItemMyImageComboBox.vb](./VB/AnimateImageComboBox/RepositoryItemMyImageComboBox.vb))
<!-- default file list end -->
# How to animate images in ImageComboBoxEdit 


<p>This example demonstrates how to show animated images in ImageComboBoxEdit. This behavior isn't available by default, only ImageEdit and PictureEdit can do this.</p><p>Thus, we have created a custom control inherited from ImageComboBoxEdit. Please note that only the ImageCollection can store animated images. In the application we have created a new instance of the ImageCollection class with the allowModifyImages parameter set to false. If the allowModifyImages parameter is set to true and the original image size doesn't equal the image size determined by the ImageCollection, a new non-animated image will be created.  </p><br />
<p>If you are using a custom ImageComboBoxEdit in the GridControl as an in-place editor and want to show animation, the GridView's OptionsView.AnimationType property should be set to the AnimateAllContent value.</p>

<br/>


