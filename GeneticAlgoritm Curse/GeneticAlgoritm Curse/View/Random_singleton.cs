using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgoritm_Curse.Model;

namespace GeneticAlgoritm_Curse
{
    public partial class Random_singleton : Form
    {
        public string[] P = new string[] { };
        private static readonly Random_singleton random = new Random_singleton();
        static Random_singleton()
        {
            random.InitializeComponent();
            getInstance.FormClosing += new FormClosingEventHandler(Random_singleton_FormClosing);
            random.textBox1.Enabled = false;
            random.textBox2.Enabled = false;
        }
        public static Random_singleton getInstance
        {
            get { return random; }
        }
        private static bool IsShown = false;
        public new void Show()
        {
            if (IsShown)
                base.Show();
            else
            {
                base.Show();
                IsShown = true;
            }
        }

        private static void Random_singleton_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            IsShown = false;
            getInstance.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand;
            Random_pop pop_r;//length
            if ((checkBox1.Checked) && (checkBox2.Checked))
            {
                pop_r = new Random_pop(Convert.ToInt32(this.textBox2.Text));
                P=pop_r.Random_P(Convert.ToInt32(this.textBox1.Text));//size
                this.Close();
            }
            else if ((checkBox1.Checked) && (!checkBox2.Checked))
            {
                rand = new Random();
                pop_r = new Random_pop(rand.Next(1, 9));//length
                P = pop_r.Random_P(Convert.ToInt32(this.textBox1.Text));
                this.Close();
            }
            else if((!checkBox1.Checked) && (checkBox2.Checked))
            {
                rand = new Random();
                pop_r = new Random_pop(Convert.ToInt32(this.textBox2.Text));
                P = pop_r.Random_P(rand.Next(1,10));
                this.Close();
            }
            else /*if ((!checkBox1.Checked) && (!checkBox2.Checked))*/
            {
                rand = new Random();
                pop_r = new Random_pop(rand.Next(1, 9));
                P = pop_r.Random_P(rand.Next(1, 10));
                this.Close();
            }
        }

       

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Clear();
            }
        }
    }
}
