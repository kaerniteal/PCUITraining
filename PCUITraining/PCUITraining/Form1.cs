using PCUITraining.Test;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PCUITraining
{
    public partial class Form1 : Form
    {
        private int Current { get; set; }
        private List<Bitmap> ImageList { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Current = 0;
            this.ImageList = new List<Bitmap>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGetImageFromGoogle_Click(object sender, EventArgs e)
        {
            var getImageFromGoogle = new GetImageFromGoogle();
            this.ImageList = getImageFromGoogle.Exec(this.txtSearch.Text);
            this.Current = 0;
            this.ShowImage(this.Current);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Current++;
            this.ShowImage(this.Current);
        }

        private void ShowImage(int index)
        {
            if (index < this.ImageList.Count)
            {
                var bitmap = this.ImageList[index];
                pBox.Image = bitmap;
                pBox.Size = bitmap.Size;
            }
        }
    }
}
