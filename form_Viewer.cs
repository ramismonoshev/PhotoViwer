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

            //Center the image in the middle of the screen
            this.CenterToScreen();

            // Initialization of the ItemSorter
            listView_Picture.ListViewItemSorter = new CompareByIndex(listView_Picture);

            // Initialization of the listPictures
            listPictures = new List<Picture>();

            // Initialization of the index
            index = 0;

            // Initialization of the WaitForm and show it
            using (frmWaitForm frmWaitForm = new frmWaitForm(LoadLinkPictures))
            {
                frmWaitForm.ShowDialog(this);
            }
        }


        #region Useful methods

        /// <summary>
        /// DownloadImageFromUrl()
        /// Function who return the image from the url
        /// </summary>
        /// <param name="imageUrl">Image url</param>
        /// <returns>return the image from the url</returns>
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

        /// <summary>
        /// LoadLinkPictures()
        /// Load picture from URL
        /// </summary>
        private void LoadLinkPictures()
        {
            Image image;

            // Add 10 pictures to the listPictures
            for (int i = 1; i < 11; i++)
            {
                listPictures.Add(new Picture("Photo" + i, "https://source.unsplash.com/random"));
            }

            // Download all images for the photos
            while (index < listPictures.Count)
            {
                image = DownloadImageFromUrl(listPictures[index].Link);

                AddPicture(image);

                // Add delay betwenn two web request
                Thread.Sleep(1000);

            }

        }

        /// <summary>
        /// LoadFilePictures()
        /// Load picture from your computer
        /// </summary>
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


        /// <summary>
        /// AddPicture()
        /// Add picture to listView
        /// </summary>
        /// <param name="pictureFile">Picture to add to the listview</param>
        private void AddPicture(Picture pictureFile)
        {
            imageList_1.Images.Add(pictureFile.Thumbnail) ;
           
            listView_Picture.Items.Insert(0, pictureFile.Name, index++);
        }

        /// <summary>
        /// AddPicture()
        /// Add picture to listView
        /// </summary>
        /// <param name="imageFile">Picture to add to the listview</param>
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
