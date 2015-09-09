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
            DrawGradient();
        }


        public class line
        {
            public line(double[] point1, double[] point2)
            {
                this.p1 = point1;
                this.p2 = point2;
            }

            public double[] p1;
            public double[] p2;
        }



        private void Generate3dObject()
        {
            double[] frontLeftBottom = new double[] {0,0,0 };
            double[] frontRightBottom = new double[] {1,0,0 };
            double[] frontLeftTop = new double[] {0,0,1 };
            double[] frontRightTop = new double[] { 1,0,1};


            double[] backLeftBottom = new double[] { 0,1,0};
            double[] backRightBottom = new double[] { 1,1,0};
            double[] backLeftTop = new double[] {0,1,1 };
            double[] backRightTop = new double[] { 1,1,1};



            System.Collections.Generic.List<line> ls = new System.Collections.Generic.List<line>();
            ls.Add(new line(frontLeftBottom, frontRightBottom));
            ls.Add(new line(frontLeftBottom, frontLeftTop));
            ls.Add(new line(frontLeftTop, frontRightTop));
            ls.Add(new line(frontRightBottom, frontRightTop));



            double[] cameraPosition = new double[] { 0.5, -1, 0.5 };
            double cameraRotation = 0.0;

            double[][] cameraMatrixx = MatrixExtensions.UnityMatrix(3);

            double[] point = frontLeftBottom;
            double[] vec = MatrixExtensions.VectorSubtract(point, cameraPosition);
            double[] newPoint = MatrixExtensions.MatrixProduct(cameraMatrixx, vec);



            bmp = new System.Drawing.Bitmap(100, 100);
            using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bmp))
            {
                gfx.DrawRectangle(System.Drawing.Pens.Red, 10, 10, 50, 50);
            }

            this.pictureBox1.Image = bmp;

        }


        private void DrawGradient()
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
