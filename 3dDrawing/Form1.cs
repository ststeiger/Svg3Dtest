using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _3dDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        System.Drawing.Bitmap bmp;

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new System.Drawing.Bitmap(100, 100);
            using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bmp))
            {
                gfx.DrawRectangle(System.Drawing.Pens.Red, 10, 10, 50, 50);
            }

            this.pictureBox1.Image = bmp;


        }


    }
}
