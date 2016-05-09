using Example2.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        Drawer drawer;
      
        public Form1()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawer.prevPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawer.FixPath();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawer.Draw(e.Location);
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Line;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Eraser;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Circle;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Rectangle;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Pencil;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            drawer.DrawTool = DrawTool.Pen;
        }


        private void button11_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.pen.Color = colorDialog1.Color;
                button11.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
               button11.BackColor = c.Color;
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter= "JPEG Image(.jpeg) | *.jpeg |Bitmap Image (.bmp) | *.bmp | Gif Image(.gif) | *.gif | Png Image(.png) | *.png";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                drawer.Save(saveFileDialog1.FileName);

               
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog () == DialogResult.OK)
            {
                drawer.Load(openFileDialog1.FileName);

               
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawer.pen.Width = trackBar1.Value;
            SizePen.Text = trackBar1.Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Triangle;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        }
    }
    
    

