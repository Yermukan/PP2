using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw__the_Image
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Point[] points;
        Point[] trinpoints;
        Point[] starpoints1;
        Point[] starpoints_1;
        Point[] starpoints2;
        Point[] starpoints_2;
        Point[] starpoints3;
        Point[] starpoints_3;
        Point[] starpoints4;
        Point[] starpoints_4;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            points = new Point[] { new Point(300, 100), new Point(265, 125), new Point(265, 160), new Point(300, 185), new Point(335, 160), new Point(335, 125) };
            trinpoints = new Point[] { new Point(300, 125), new Point(290, 142), new Point(310, 142) };
            starpoints1 = new Point[]{new Point(80, 97), new Point(60, 127), new Point(100, 127)};
            starpoints_1 = new Point[] { new Point(60, 108), new Point(100, 108), new Point(80, 137) };
            starpoints2 = new Point[] { new Point(470, 92), new Point(450, 122), new Point(490, 122) };
            starpoints_2 = new Point[] { new Point(450, 103), new Point(490, 103), new Point(470, 132) };
            starpoints3 = new Point[] { new Point(100, 200), new Point(80, 230), new Point(120, 230) };
            starpoints_3 = new Point[] { new Point(80, 211), new Point(120, 211), new Point(100, 240) };
            starpoints4 = new Point[] { new Point(400, 250), new Point(380, 280), new Point(420, 280) };
            starpoints_4 = new Point[] { new Point(380, 261), new Point(420, 261), new Point(400, 290) };
            graphics.Clear(Color.DarkBlue);
            SolidBrush solid = new SolidBrush(Color.White);
            SolidBrush solid1 = new SolidBrush(Color.Yellow);
            SolidBrush solid2 = new SolidBrush(Color.Green);
            SolidBrush solid3 = new SolidBrush(Color.Red);
            graphics.FillEllipse(solid, 15, 50, 20, 20);
            graphics.FillEllipse(solid, 18, 300, 20, 20);
            graphics.FillEllipse(solid, 200, 40, 20, 20);
            graphics.FillEllipse(solid, 200, 250, 20, 20);
            graphics.FillEllipse(solid, 350, 60, 20, 20);
            graphics.FillEllipse(solid, 520, 150, 20, 20);
            graphics.FillEllipse(solid, 470, 200, 20, 20);
            graphics.FillEllipse(solid, 520, 300, 20, 20);
            graphics.FillPolygon(solid1, points);
            graphics.FillRectangle(solid2, 295, 142, 10, 20);
            graphics.FillPolygon(solid2, trinpoints);
            graphics.FillEllipse(solid2, 300, 75, 22, 7);
            graphics.FillEllipse(solid2, 308, 67, 7, 22);
            graphics.FillPolygon(solid3, starpoints1);
            graphics.FillPolygon(solid3, starpoints_1);
            graphics.FillPolygon(solid3, starpoints2);
            graphics.FillPolygon(solid3, starpoints_2);
            graphics.FillPolygon(solid3, starpoints3);
            graphics.FillPolygon(solid3, starpoints_3);
            graphics.FillPolygon(solid3, starpoints4);
            graphics.FillPolygon(solid3, starpoints_4);
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
