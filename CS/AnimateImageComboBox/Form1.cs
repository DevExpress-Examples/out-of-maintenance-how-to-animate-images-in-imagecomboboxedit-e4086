using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace AnimateImageComboBox {
    public partial class Form1 : XtraForm {
        ImageCollection imageCollection;
       
        public Form1() {
            InitializeComponent();

            RepositoryItemMyImageComboBox imageCombo = new RepositoryItemMyImageComboBox();
            imageCombo.GlyphAlignment = HorzAlignment.Center;
            imageCollection = new ImageCollection(false);
            imageCollection.ImageSize = new Size(30, 30);
           
            FillImageCollection();
            AddItemsToRepositoryItem(imageCombo, imageCollection);
            AddItemsToControl(myImageComboboxEdit1, imageCollection);
          
            gridControl1.RepositoryItems.Add(imageCombo);
            CreateDataSource();
            gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            gridView1.Columns["OrderCost"].ColumnEdit = imageCombo;
            
        }



        private void CreateDataSource() {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Order Date", typeof(DateTime));
            dataTable.Columns.Add("OrderCost", typeof(int));

            dataTable.Rows.Add(new object[] { "John Smith", " 01 / 01 / 2010",  imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "Ivanov", "01/01/2011",  imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "Petrov", "01 / 05 / 2011",  imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "John Smith", " 04 / 01 / 2010",  imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "Ivanov", "01/11/2011", imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "Petrov", "01 / 06 / 2011",  imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "John Smith", " 11 / 01 / 2012", imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "Ivanov", "04/04/2011", imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "Petrov", "24 / 05 / 2012",  imageCollection.Images.Count - 1 });
            dataTable.Rows.Add(new object[] { "John Smith", " 26 / 04 / 2012", imageCollection.Images.Count - 1 });
            gridControl1.DataSource = dataTable;
     
        }

        private void AddItemsToRepositoryItem(RepositoryItemMyImageComboBox item, ImageCollection imgList) {
            for (int i = 0; i < imgList.Images.Count; i++)
                item.Items.Add(new ImageComboBoxItem("Item " + (i + 1).ToString(), i, i));
            item.SmallImages = imgList;

        }

        private void AddItemsToControl(MyImageComboboxEdit editor, ImageCollection imgList) {
            for (int i = 0; i < imgList.Images.Count; i++)
                editor.Properties.Items.Add(new ImageComboBoxItem("Item " + (i + 1).ToString(), i, i));
            editor.Properties.SmallImages = imgList;

        }


        private void FillImageCollection() {
            imageCollection.AddImage(Image.FromFile("..\\..\\IMAGES\\low.gif"));
            imageCollection.AddImage(Image.FromFile("..\\..\\IMAGES\\10_1.gif"));
            imageCollection.AddImage(Image.FromFile("..\\..\\IMAGES\\high.gif"));
        }

    }
}
