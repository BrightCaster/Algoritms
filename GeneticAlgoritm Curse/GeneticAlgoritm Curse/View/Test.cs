using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GeneticAlgoritm_Curse
{
    public partial class Test : Form
    {
        ColorDialog clrdlg = new ColorDialog();
        Pen p;

        Point[,] line = new Point[100, 2];
        int line_rec = 0;

        Point[,] poly = new Point[100, 100];
        int[] poly_p = new int[100];
        int poly_rec = 0;

        int[,] ell = new int[100, 4];
        bool[] ell_f = new bool[100];
        int ell_rec = 0;

        Point[,] bez = new Point[100, 4];
        int bez_rec = 0;
        int bez_p = 0;


        int type = 0;
        bool is_draw = false;

        Graphics g;
        Thread thread;
        public Test()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            clrdlg.Color = Color.Red;
            p = new Pen(clrdlg.Color, 2.0f);
            panel2.BackColor = clrdlg.Color;
            panel4.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.AllowDrop = true;
            panel3.AllowDrop = true;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            draw();
        }

        void draw()
        {
            groupBox1.Size = new Size(groupBox1.Size.Width, this.Size.Height - 55);
            
            g = panel1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < line_rec; i++)
                g.DrawLine(p, line[i, 0], line[i, 1]);

            for (int i = 0; i < poly_rec; i++)
            {
                for (int j = 0; j + 1 < poly_p[i]; j++)
                    g.DrawLine(p, poly[i, j], poly[i, j + 1]);
            }

            for (int i = 0; i < ell_rec; i++)
            {
                if (ell_f[i] == true)
                    g.FillEllipse(new SolidBrush(clrdlg.Color), ell[i, 0] - ell[i, 2], ell[i, 1] - ell[i, 3], 2 * ell[i, 2], 2 * ell[i, 3]);
                else g.DrawEllipse(p, ell[i, 0] - ell[i, 2], ell[i, 1] - ell[i, 3], 2 * ell[i, 2], 2 * ell[i, 3]);
            }

            for (int i = 0; i < bez_rec; i++)
            {
                g.DrawBezier(p, bez[i, 0], bez[i, 1], bez[i, 2], bez[i, 3]);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (is_draw == false)
            {
                if (type == 1 && poly_rec < 100)
                {
                    is_draw = true;
                    poly_rec++;
                    poly_p[poly_rec - 1] = 2;
                    poly[poly_rec - 1, 0] = new Point(e.X, e.Y);
                    poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                    draw();
                }
                if (type == 2 && ell_rec < 100)
                {
                    is_draw = true;
                    ell_rec++;
                    ell_f[ell_rec - 1] = checkBox1.Checked;
                    ell[ell_rec - 1, 0] = e.X;
                    ell[ell_rec - 1, 1] = e.Y;
                    ell[ell_rec - 1, 2] = 10;
                    ell[ell_rec - 1, 3] = 10;
                    draw();
                }
                if (type == 3 && bez_rec < 100)
                {
                    is_draw = true;
                    bez_rec++;
                    bez[bez_rec - 1, 0] = new Point(e.X, e.Y);
                    bez[bez_rec - 1, 1] = new Point(e.X + 10, e.Y + 25);
                    bez[bez_rec - 1, 2] = new Point(e.X + 25, e.Y + 10);
                    bez[bez_rec - 1, 3] = new Point(e.X, e.Y);
                    bez_p = 1;
                    draw();
                }
            }
            else if (is_draw == true)
            {
                if (type == 1)
                {
                    if (e.Button == MouseButtons.Right)
                        is_draw = false;
                    if (e.Button == MouseButtons.Left)
                    {
                        if (poly_p[poly_rec - 1] < 100)
                        {
                            poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                            poly_p[poly_rec - 1]++;
                            poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                        }
                        else is_draw = false;
                    }

                }
                if (type == 2)
                {
                    is_draw = false;
                }
                if (type == 3 && bez_rec < 100)
                {
                    bez[bez_rec - 1, bez_p] = new Point(e.X, e.Y);
                    bez_p++;
                    if (bez_p == 4) { is_draw = false; bez_p = 0; }
                    draw();
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && is_draw == false)
            {
                if (type == 0 && line_rec < 100)
                {
                    is_draw = true;
                    line_rec++;
                    line[line_rec - 1, 0] = new Point(e.X, e.Y);//(e.X-110, e.Y-10);
                    line[line_rec - 1, 1] = new Point(e.X, e.Y);
                    draw();
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_draw)
            {
                if (type == 0)
                {
                    line[line_rec - 1, 1] = new Point(e.X, e.Y);
                    draw();
                }
                if (type == 1)
                {
                    poly[poly_rec - 1, poly_p[poly_rec - 1] - 1] = new Point(e.X, e.Y);
                    draw();
                }
                if (type == 2)
                {
                    ell[ell_rec - 1, 2] = Math.Abs(ell[ell_rec - 1, 0] - e.X);
                    ell[ell_rec - 1, 3] = Math.Abs(ell[ell_rec - 1, 1] - e.Y);
                    draw();
                }
                if (type == 3)
                {
                    bez[bez_rec - 1, bez_p] = new Point(e.X, e.Y);
                    draw();
                }
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (is_draw)
            {
                if (type == 0)
                {
                    is_draw = false;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled == true) type = 1;
            is_draw = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            line_rec = 0;
            poly_rec = 0;
            ell_rec = 0;
            bez_rec = 0;
            is_draw = false;
            draw();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled == true) type = 2;
            is_draw = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled == true) type = 0;
            is_draw = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Enabled == true) type = 3;
            is_draw = false;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            clrdlg.ShowDialog();
            p = new Pen(clrdlg.Color, 2.0f);
            panel2.BackColor = clrdlg.Color;
            draw();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_DragDrop(object sender, DragEventArgs e)
        {
            Button b = ((Button)e.Data.GetData(typeof(Button)));
            b.Parent = (Panel)sender;
            b.Location = new Point(
                 e.X - this.Location.X -  ((Panel)sender).Location.X - 10 - b.Size.Width / 2,
                 e.Y - this.Location.Y -  ((Panel)sender).Location.Y - 30 - b.Size.Height / 2);
            MessageBox.Show("panel_DragDrop");
        }

        private void panel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.DoDragDrop(button2, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel4_DragDrop(object sender, DragEventArgs e)
        {
            Button b = ((Button)e.Data.GetData(typeof(Button)));
            b.Parent = (Panel)sender;
            b.Location = new Point(
                 e.X - this.Location.X - ((Panel)sender).Location.X - 10 - b.Size.Width / 2,
                 e.Y - this.Location.Y - ((Panel)sender).Location.Y - 30 - b.Size.Height / 2);
            MessageBox.Show("panel_DragDrop");
        }

        private void panel4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        public void Kruchenie()
        {
            Graphics PH = pictureBox1.CreateGraphics();
            PH.TranslateTransform(pictureBox1.Width/2,pictureBox1.Height/2);
            Point[] points =
            {
                new Point(-20,-20),
                new Point(-20,20),
                new Point(20,20),
                new Point(20,-20),
            };
            for (int i =0; ; i++)
            {
                PH.Clear(BackColor);
                PH.RotateTransform(1);
                PH.DrawPolygon(new Pen(Color.Blue), points);
                Thread.Sleep(50);
            }
        }
        int Key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            thread = new Thread(Kruchenie);
            if (Key==0)
            {
                thread.Start();
                Key = 1;
            }
        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            Key = 0;
        }
    }
}
