using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_AppPhoto;
using System.Net;
using System.IO;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Collections;

namespace App_PhotoVacances
{
    public partial class form_Viewer : Form
    {
        private List<Picture> listPictures;
        private Picture picture;
        int index;
 

        public form_Viewer()
        {
            InitializeComponent();


            this.CenterToScreen();

            listView_Picture.ListViewItemSorter = new CompareByIndex(listView_Picture);

 
            listPictures = new List<Picture>();

 
            index = 0;

            using (frmWaitForm frmWaitForm = new frmWaitForm(LoadLinkPictures))
            {
                frmWaitForm.ShowDialog(this);
            }
        }





        private Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;

                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();

                image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }

        private void LoadLinkPictures()
        {
            Image image;

  
            for (int i = 1; i < 11; i++)
            {
                listPictures.Add(new Picture("Photo" + i, "https://source.unsplash.com/random"));
            }

            while (index < listPictures.Count)
            {
                image = DownloadImageFromUrl(listPictures[index].Link);

                AddPicture(image);

  
                Thread.Sleep(1000);

            }

        }


        private void LoadFilePictures()
        {
            openFileDialog_1.FileName = null;
            picture = null;
          
            if (openFileDialog_1.ShowDialog() == DialogResult.OK)
            {

                if (openFileDialog_1.FileName != null)
                {
                    picture = new Picture(openFileDialog_1.SafeFileName, Image.FromFile(openFileDialog_1.FileName));

                    AddPicture(picture);

                    lbl_SelectFile.Text = "Photo : " + picture.Name + "\n\n Ajouter à votre collection !";
                } 
            }
        }


  
        private void AddPicture(Picture pictureFile)
        {
            imageList_1.Images.Add(pictureFile.Thumbnail) ;
           
            listView_Picture.Items.Insert(0, pictureFile.Name, index++);
        }

 
        private void AddPicture(Image imageFile)
        {
            imageList_1.Images.Add(imageFile);

            listView_Picture.Items.Add(listPictures[index].Name, index);

            index++;
        }

        #endregion

        #region Events 
        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            LoadFilePictures();
        }
        #endregion
    }

   
}
