using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Drawing.Imaging;

namespace AnimateImageComboBox {

    public class RepositoryItemMyImageComboBox : RepositoryItemImageComboBox {

        static RepositoryItemMyImageComboBox() {
            Register();
        }

        public RepositoryItemMyImageComboBox() {
        }



        internal const string EditorName = "MyImageComboboxEdit";


        public static void Register() {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(MyImageComboboxEdit),
                typeof(RepositoryItemMyImageComboBox), typeof(CustomImageComboBoxEditViewInfo),
                new ImageComboBoxEditPainter(), true, null, typeof(DevExpress.Accessibility.PopupEditAccessible)));
        }

        public override string EditorTypeName {
            get { return EditorName; }
        }

        protected override void RaiseDropDownCustomDrawItem(ListBoxDrawItemEventArgs e) {
            ImageComboBoxItem item = e.Item as ImageComboBoxItem;

            if (item.Images is ImageCollection) {
                Image image = (item.Images as ImageCollection).Images[e.Index];
                image.SelectActiveFrame(new FrameDimension(image.FrameDimensionsList[0]), 0);
            }

            base.RaiseDropDownCustomDrawItem(e);
        }



    }
}
