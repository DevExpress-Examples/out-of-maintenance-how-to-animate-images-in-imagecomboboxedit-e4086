using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Registrator;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace AnimateImageComboBox {
     [UserRepositoryItem("Register")]
    class MyImageComboboxEdit: ImageComboBoxEdit{
         static MyImageComboboxEdit() {
            RepositoryItemMyImageComboBox.Register();
        }

            public MyImageComboboxEdit() {
        }

        public virtual void StartAnimation() { ViewInfo.StartAnimation(); }
        public virtual void StopAnimation() { ViewInfo.StopAnimation(); }

        protected internal new CustomImageComboBoxEditViewInfo ViewInfo { get { return base.ViewInfo as CustomImageComboBoxEditViewInfo; } }

        public override string EditorTypeName {
                get { return RepositoryItemMyImageComboBox.EditorName; }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]

        public new RepositoryItemMyImageComboBox Properties {
            get { return base.Properties as RepositoryItemMyImageComboBox; }
        }

        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            if ((!Visible)&& (ViewInfo.CanImagesBeAnimated) ) StopAnimation();
            else if (Visible && (ViewInfo.CanImagesBeAnimated)) StartAnimation();
            
        }

    }


  






         
     
}
