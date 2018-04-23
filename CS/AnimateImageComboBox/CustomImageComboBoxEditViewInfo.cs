using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Windows.Forms;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.Utils;
using System.Drawing.Imaging;

namespace AnimateImageComboBox {

    public class CustomImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo, ISupportXtraAnimation, IAnimatedItem {
        public CustomImageComboBoxEditViewInfo(RepositoryItem item)
            : base(item) {
        }

        public Image Image { get { return CanImagesBeAnimated ? (this.Images as ImageCollection).Images[this.ImageIndex] : null; } }

        Image oldImage = null;

        public bool CanImagesBeAnimated { get { return ((this.ImageIndex != -1) && (this.Images is ImageCollection)); } }

        protected override void OnEditValueChanged() {
            base.OnEditValueChanged();
            if (CanImagesBeAnimated) {
                this.StartAnimation();
            }
        }


        public virtual void StopAnimation() {
            XtraAnimator.RemoveObject(this);
        }
        public virtual void StartAnimation() {
            IAnimatedItem animItem = this;
            if (OwnerEdit == null || OwnerEdit.IsDesignMode || animItem.FramesCount < 2) return;
            XtraAnimator.Current.AddEditorAnimation(null, this, animItem, new CustomAnimationInvoker(OnImageAnimation));
        }
        protected virtual void OnImageAnimation(BaseAnimationInfo animInfo) {
            IAnimatedItem animItem = this;
            EditorAnimationInfo info = animInfo as EditorAnimationInfo;
            if (Image == null || OwnerEdit == null || info == null) return;
            if (!info.IsFinalFrame) {
                Image.SelectActiveFrame(FrameDimension.Time, info.CurrentFrame);
                OwnerEdit.Invalidate(animItem.AnimationBounds);
            }
            else {
                StopAnimation();
                StartAnimation();
            }
        }

        public bool CanAnimate {
            get { return (((IAnimatedItem)this).FramesCount > 1); }
        }

        public new Control OwnerControl {
            get { return OwnerEdit; }
        }

        Rectangle IAnimatedItem.AnimationBounds { get { return this.GlyphBounds; } }
        int IAnimatedItem.AnimationInterval { get { return ImageHelper.AnimationInterval; } }
        int[] IAnimatedItem.AnimationIntervals { get { return ImageHelper.AnimationIntervals; } }
        AnimationType IAnimatedItem.AnimationType { get { return ImageHelper.AnimationType; } }
        int IAnimatedItem.FramesCount { get { return ImageHelper.FramesCount; } }
        int IAnimatedItem.GetAnimationInterval(int frameIndex) {
            return ImageHelper.GetAnimationInterval(frameIndex);
        }
        bool IAnimatedItem.IsAnimated {
            get { return ImageHelper.IsAnimated; }
        }
        void IAnimatedItem.OnStart() { }
        void IAnimatedItem.OnStop() { }
        object IAnimatedItem.Owner { get { return OwnerEdit; } }
        void IAnimatedItem.UpdateAnimation(BaseAnimationInfo info) {
            ImageHelper.UpdateAnimation(info);
        }

        AnimatedImageHelper imageHelper;
        protected AnimatedImageHelper ImageHelper {
            get {
                if ((oldImage != Image) || (imageHelper == null)) {
                    imageHelper = new AnimatedImageHelper(Image);
                    oldImage = Image;
                }

                return imageHelper;
            }
        }


    }
}
