using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lines
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Pen myPenBlue = new Pen(Color.Blue);
        Pen myPenRed = new Pen(Color.Red);
        Graphics g = null;
        
        static int center_x, center_y;
        static int start_x, start_y;
        static int end_x, end_y;

        static int my_angle = 0;
        static int my_lenght = 0;
        static int my_increment = 0;
        static int num_lines = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            my_lenght = Int32.Parse(lenght.Text);
            my_increment = Int32.Parse(increment.Text);
            my_angle = Int32.Parse(angle.Text);
            num_lines = Int32.Parse(lines.Text);

            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;

            canvas.Refresh();
        }

      

        private void drawLine()
        {
            Point p1 = new Point((canvas.Width / 2), 0);
            Point p2 = new Point(canvas.Width / 2, canvas.Height);
            Point p3 = new Point(0,canvas.Height/2 );
            Point p4 = new Point(canvas.Width , canvas.Height / 2);

            g.DrawLine(myPenRed, p1 ,p2);
            g.DrawLine(myPenBlue, p3, p4);

            my_angle = my_angle + Int32.Parse(angle.Text);
            my_lenght = my_lenght + my_increment;

            end_x = (int)(start_x + Math.Cos(my_angle * .017453292519) * my_lenght);
            end_y = (int)(start_y + Math.Cos(my_angle * .017453292519) * my_lenght);



            Point[] points =
            {
                new Point(start_x,start_y),
                new Point(end_x,end_y)
            };

            start_x = end_x;
            start_y = end_y;

            g.DrawLines(myPen, points);

        }

       

        private void canvas_Paint_1(object sender, PaintEventArgs e)
        {
            myPen.Width = 1;
            my_lenght = Int32.Parse(lenght.Text);
            g = canvas.CreateGraphics();
            for (int i = 0; i < Int32.Parse(lines.Text); i++)
                drawLine();
        }

        public Form1()
        {
            InitializeComponent();
        }

   

        private void canvas_Resize(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
    }
}
