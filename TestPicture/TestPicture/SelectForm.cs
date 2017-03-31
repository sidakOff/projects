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

                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(fileName))
                {
                    _image = Image.FromStream(fileStream);
                    originalPictureBox.Image = _image;
                }

                //using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, BufferSize))
                //{

                //}
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            var ima = _image;
            Bitmap img = ima as Bitmap;
            var pixels=new List<Pixel>();
            int  blue = Convert.ToInt32(blueTextBox.Text);
            int green= Convert.ToInt32(greenTextBox.Text);
            int red = Convert.ToInt32(redTextBox.Text);
            for (int i = 0; i < ima.Width; i++)
            {
                for (int j = 0; j < ima.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if ((pixel.B <=blue)&(pixel.G<=green)&(pixel.R<=red))
                    {
                        pixels.Add(new Pixel()
                        {
                            i = i,
                            j = j,
                            pix = pixel
                        });
                    }
                }
            }
            //int maxAge = FindMax(list, x => x.Age);
            var width = pixels.Max(o => o.i)+1;
            var height = pixels.Max(o => o.j)+1;
            var image=new Bitmap(width, height);
            foreach (var pix in pixels)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        image.SetPixel(pix.i, pix.j, pix.pix);
                    }
                }
            }
            changedPictureBox.Image = image;

        }
        public class Pixel
        {
            public int i { get; set; }
            public int j { get; set; }
            public Color pix { get;set; }
        }
    }
}
