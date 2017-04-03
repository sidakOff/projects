using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPicture
{
    public partial class SelectPictureForm : Form
    {
        private Image _image;
        private int width;
        private int height;
        private Bitmap image;
        
        public SelectPictureForm()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string startPath;
            GetImage(out startPath);
        }

        private void GetImage(out string startPath)
        {
            startPath = @"C:\";
            OpenFileDialog theDialog = new OpenFileDialog
            {
                Title = "Выберите файл"
            };
            theDialog.InitialDirectory = startPath;
            theDialog.Multiselect = false;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = theDialog.FileName;

                using (var fileStream = File.OpenRead(fileName))
                {
                    _image = Image.FromStream(fileStream);
                    originalPictureBox.Image = _image;
                }
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            var image = DrawImage();
            changedPictureBox.Image = image;
        }

        private Bitmap DrawImage()
        {
            
            var pixels = GetPixelsFromImage();
            width = pixels.Max(o => o.i) + 1;
            height = pixels.Max(o => o.j) + 1;
            image = new Bitmap(width, height);


            foreach (var pix in pixels)
            {
               Drawining(pix);
            }
            return image;
        }

        private void Drawining(object obj)
        {
            var pix = (Pixel) obj;
            image.SetPixel(pix.i, pix.j, pix.pix);
            
        }
        

        private List<Pixel> GetPixelsFromImage()
        {
            var ima = _image;
            Bitmap img = ima as Bitmap;
            var pixels = new List<Pixel>();
            int blue = Convert.ToInt32(blueTextBox.Text);
            int green = Convert.ToInt32(greenTextBox.Text);
            int red = Convert.ToInt32(redTextBox.Text);
            for (int i = 0; i < ima.Width; i++)
            {
                for (int j = 0; j < ima.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if ((pixel.B >= blue) & (pixel.G >= green) & (pixel.R >= red))
                    {
                        pixels.Add(new Pixel
                        {
                            i = i,
                            j = j,
                            pix = pixel
                        });
                    }
                }
            }
            return pixels;
        }
    }
}
