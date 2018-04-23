# How to animate images in ImageComboBoxEdit 


<p>This example demonstrates how to show animated images in ImageComboBoxEdit. This behavior isn't available by default, only ImageEdit and PictureEdit can do this.</p><p>Thus, we have created a custom control inherited from ImageComboBoxEdit. Please note that only the ImageCollection can store animated images. In the application we have created a new instance of the ImageCollection class with the allowModifyImages parameter set to false. If the allowModifyImages parameter is set to true and the original image size doesn't equal the image size determined by the ImageCollection, a new non-animated image will be created.  </p><br />
<p>If you are using a custom ImageComboBoxEdit in the GridControl as an in-place editor and want to show animation, the GridView's OptionsView.AnimationType property should be set to the AnimateAllContent value.</p>

<br/>


