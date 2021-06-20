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
using System.Threading;
using System.IO;

namespace GeneticAlgoritm_Curse
{
    public partial class View : Form
    {
        Proverka_Func proverka = new Proverka_Func();
        public int i = 1;
        public List<string> massiv = new List<string>();
        public string BEST = null;
        public List<string> massiv_new = new List<string>();
        private List<double> KoefMassiv = new List<double>();
        private List<double> KoefMassiv_new = new List<double>();
        Spravka spravka = new Spravka();
        
        public View()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            listView1.Columns.Add("№", 23);
            listView1.Columns.Add("Вид", 300);
            listView2.Columns.Add("№", 23);
            listView2.Columns.Add("Вид", 300);
            button3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            button1.Enabled = false;
            лучшееПоколениеToolStripMenuItem.Enabled = false;
            лучшийВидToolStripMenuItem.Enabled = false;
            уравнятьToolStripMenuItem.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            button5.Enabled = false;
            очиститьToolStripMenuItem.Enabled = false;
            AutoScroll = true;
            MaximizeBox = false;
            Font x = this.Font;
            float f = x.Size;
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 50;
            toolStripButton1.Enabled = false;
            toolStripStatusLabel1.Text = "Ввод популяции";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int length = 0;
            if ((e.KeyCode == Keys.Enter) && (radioButton1.Checked))
            {
                ListViewItem item;
                if (textBox1.Text.Length > int.MaxValue.ToString().Count()) MessageBox.Show("Значение слишком большое");
                else if (proverka.Proverka(textBox1.Text))
                {
                    item = new ListViewItem(Convert.ToString(i));
                    i++;
                    item.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(item);
                    massiv.Add(textBox1.Text);
                }
                else MessageBox.Show("Вы ввели неверный формат");
                textBox1.Clear();
                if (massiv_new.Count!=0)
                    button1.Enabled = false;
                else button1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                очиститьToolStripMenuItem.Enabled = true;
                лучшийВидToolStripMenuItem.Enabled = true;
                for (int i = 0; i < massiv.Count(); i++)
                {
                    if (massiv[i].Length > length)
                        length = massiv[i].Length;
                }
                for (int i = 0; i < massiv.Count(); i++)
                {
                    if (massiv[i].Length == length)
                        continue;
                    else уравнятьToolStripMenuItem.Enabled = true;
                }

            }
            else if ((e.KeyCode == Keys.Enter) && (radioButton2.Checked))
            {

                try
                {
                    i = 1;
                    int k = Convert.ToInt32(textBox1.Text);
                    massiv[k - 1] = "";
                    Delete_bit delete = new Delete_bit();
                    delete.ShowDialog();
                    massiv[k - 1] = delete.P_vid;
                }
                catch
                {
                    MessageBox.Show("Вы ввели номер вида вне диапозона");
                }
                listView1.Items.Clear();
                for (int j = 0; j < massiv.Count; j++)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(i));
                    i++;
                    listView1.Items.Add(item);
                    item.SubItems.Add(massiv[j]);
                }
                textBox1.Clear();

                for (int i = 0; i < massiv.Count(); i++)
                {
                    if (massiv[i].Length > length)
                        length = massiv[i].Length;
                }
                for (int i = 0; i < massiv.Count(); i++)
                {
                    if (massiv[i].Length == length)
                        continue;
                    else уравнятьToolStripMenuItem.Enabled = true;
                }
            }
            else if ((e.KeyCode == Keys.Enter) && (radioButton3.Checked))
            {
                try
                {
                    i = 1;
                    int k = Convert.ToInt32(textBox1.Text);

                    massiv[k - 1] = "";
                    massiv.RemoveAt(k - 1);
                }
                catch
                {
                    MessageBox.Show("Вы ввели номер вида вне диапозона");
                }
                listView1.Items.Clear();
                for (int j = 0; j < massiv.Count; j++)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(i));
                    i++;
                    listView1.Items.Add(item);
                    item.SubItems.Add(massiv[j]);
                }
                textBox1.Clear();
                button1.Enabled = false;

                if (massiv.Count != 1)
                {
                    if (massiv_new.Count != 0)
                        button1.Enabled = false;
                    else button1.Enabled = true;

                }
                else уравнятьToolStripMenuItem.Enabled = false;
                if (massiv.Count == 0)
                {
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton1.Checked = true;
                    уравнятьToolStripMenuItem.Enabled = false;
                    очиститьToolStripMenuItem.Enabled = false;
                    лучшийВидToolStripMenuItem.Enabled = false;
                }
                for (int i = 0; i < massiv.Count(); i++)
                {
                    if (massiv[i].Length > length)
                        length = massiv[i].Length;
                }
                for (int i = 0; i < massiv.Count(); i++)
                {
                    if (massiv[i].Length == length)
                        continue;
                    else уравнятьToolStripMenuItem.Enabled = true;
                }
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Вводите популяцию";
            toolStripStatusLabel1.Text = "Ввод популяции";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Выберите номер вида";
            toolStripStatusLabel1.Text = "Изменение вида";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Выберите номер вида";
            toolStripStatusLabel1.Text = "Удаление вида";
        }

        private void button1_Click(object sender, EventArgs e)// начать
        {

            int key = 0;
            for (int i = 0; i < massiv.Count - 1; i++)
            {
                if ((massiv.ToArray())[i].Length != (massiv.ToArray())[i + 1].Length)
                {
                    key = 1;
                    break;
                }
            }
            if (key == 0)
            {
                AssessFitness fitness = new AssessFitness();
                KoefMassiv.Add(fitness.AssesSUM(massiv.ToArray()));
                listView2.Items.Clear();
                Algoritm algoritm = new Algoritm(massiv.Count);
                i = 1;
                string[] P = algoritm.Algoritm_pop(massiv.ToArray());
                massiv_new = P.ToList<string>();
                toolStripProgressBar1.Maximum = massiv_new.Count;
                toolStripStatusLabel1.Text = toolStripProgressBar1.Minimum.ToString();
                for (int j = 0; j < massiv_new.Count; j++)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(i));
                    i++;
                    listView2.Items.Add(item);
                    item.SubItems.Add(massiv_new[j]);
                    
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1;
                    Thread.Sleep(500);
                }
                toolStripProgressBar1.Value = 0;
                KoefMassiv_new.Add(fitness.AssesSUM(massiv_new.ToArray()));
                i = 1;
                listView1.Items.Clear();
                for (int j = 0; j < massiv.Count; j++)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(i));
                    i++;
                    listView1.Items.Add(item);
                    item.SubItems.Add(massiv[j]);
                }
                BEST = algoritm.Best_pop(massiv.ToArray());
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                button1.Enabled = false;
                button3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                radioButton1.Enabled = false;
                radioButton1.Checked = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                textBox1.Enabled = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                лучшееПоколениеToolStripMenuItem.Enabled = true;
                toolStripStatusLabel1.Text = "Алгоритм выполнен!";
                toolStripButton1.Enabled = true;

            }
            
            else MessageBox.Show("Вы не уравняли виды!");
        }

        private void button4_Click(object sender, EventArgs e)// ввод
        {
            toolStripStatusLabel1.Text = "Ввод популяции";
            int length = 0;
            List<string> face = Facade.Run_Vvod(massiv);
            massiv = face;
            for (int j = i - 1; j < massiv.Count; j++)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(i));
                i++;
                listView1.Items.Add(item);
                item.SubItems.Add(massiv[j]);
            }
            Algoritm algoritm = new Algoritm(massiv.Count);
            BEST = algoritm.Best_pop(massiv.ToArray());
            button1.Enabled = true;
            лучшийВидToolStripMenuItem.Enabled = true;
            очиститьToolStripMenuItem.Enabled = true;
            уравнятьToolStripMenuItem.Enabled = false;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            for (int i = 0; i < massiv.Count(); i++)
            {
                if (massiv[i].Length > length)
                    length = massiv[i].Length;
            }
            for (int i = 0; i < massiv.Count(); i++)
            {
                if (massiv[i].Length == length)
                    continue;
                else уравнятьToolStripMenuItem.Enabled = true;
            }

            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

        //public string[] Ravn(string[] Q, int length)
        //{
        //    int size = Q.Count();
        //    for (int i = 0; i < size; i++)// делаем одинаковое количество битовых знаков
        //    {
        //        while (Q[i].Length != length)
        //        {
        //            Q[i] = "0" + Q[i];
        //        }
        //    }
        //    return Q;
        //}

        private void button3_Click(object sender, EventArgs e)// выбор
        {

            if (radioButton4.Checked)//старое
            {
                massiv_new.Clear();
                listView2.Items.Clear();
                pictureBox1.BackColor = View.DefaultBackColor;
                Algoritm algoritm = new Algoritm(massiv.Count);
                BEST = algoritm.Best_pop(massiv.ToArray());
                

            }
            else if (radioButton5.Checked)// новое
            {
                listView1.Items.Clear();
                massiv = massiv_new;
                listView2.Items.Clear();
                i = 1;
                for (int j = 0; j < massiv.Count; j++)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(i));
                    i++;
                    listView1.Items.Add(item);
                    item.SubItems.Add(massiv[j]);
                }
                Algoritm algoritm = new Algoritm(massiv.Count);
                BEST = algoritm.Best_pop(massiv.ToArray());
                pictureBox2.BackColor = View.DefaultBackColor;
            }
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            button1.Enabled = true;
            button3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            textBox1.Enabled = true;
            лучшееПоколениеToolStripMenuItem.Enabled = false;
            toolStripStatusLabel1.Text = "Выбор поколения сделан!";
            toolStripButton1.Enabled = false;
        }
        

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string[] files = File.ReadAllLines(openFileDialog1.FileName);
            for (int i = 0; i < files.Count(); i++)
            {
                massiv.Add(files[i]);
            }
            for (int j = 0; j < massiv.Count; j++)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(i));
                i++;
                listView1.Items.Add(item);
                item.SubItems.Add(massiv[j]);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            File.WriteAllLines(saveFileDialog1.FileName + ".txt", massiv.ToArray());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выбор первого поколения";
            if (radioButton4.Checked) pictureBox1.BackColor = Color.LightGreen;
            pictureBox2.BackColor = View.DefaultBackColor;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выбор второго поколения";
            if (radioButton5.Checked) pictureBox2.BackColor = Color.LightGreen;
            pictureBox1.BackColor = View.DefaultBackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Algoritm algoritm = new Algoritm(massiv.Count);
            BEST = algoritm.Best_pop(massiv.ToArray());
            if (BEST != null)
                MessageBox.Show("Лучший вид: " + BEST);
            else MessageBox.Show("Лучший вид отсутсвует!");
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spravka.ShowDialog();
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by BrightCaster 2021.\n\n" +
                "E-mail: mikhail.iukhnovskii.99@mail.ru", "Автор", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label1.Font = fontDialog1.Font;
            label2.Font = fontDialog1.Font;
            label3.Font = fontDialog1.Font;
            label4.Font = fontDialog1.Font;
            label5.Font = fontDialog1.Font;
            label7.Font = fontDialog1.Font;
            radioButton1.Font = fontDialog1.Font;
            radioButton2.Font = fontDialog1.Font;
            radioButton3.Font = fontDialog1.Font;
            radioButton4.Font = fontDialog1.Font;
            radioButton5.Font = fontDialog1.Font;
            button1.Font = fontDialog1.Font;
            очиститьToolStripMenuItem.Font = fontDialog1.Font;
            button3.Font = fontDialog1.Font;
            button4.Font = fontDialog1.Font;
            уравнятьToolStripMenuItem.Font = fontDialog1.Font;
            лучшееПоколениеToolStripMenuItem.Font = fontDialog1.Font;
            лучшийВидToolStripMenuItem.Font = fontDialog1.Font;
            textBox1.Font = fontDialog1.Font;
            menuStrip1.Font = fontDialog1.Font;
            Random_singleton random_Singleton = Random_singleton.getInstance;
            random_Singleton.button1.Font = fontDialog1.Font;
            random_Singleton.checkBox1.Font = fontDialog1.Font;
            random_Singleton.checkBox2.Font = fontDialog1.Font;
            random_Singleton.label1.Font = fontDialog1.Font;
            random_Singleton.textBox1.Font = fontDialog1.Font;
            random_Singleton.textBox2.Font = fontDialog1.Font;
            spravka.button1.Font = fontDialog1.Font;
            spravka.label1.Font = fontDialog1.Font;
            trackBar1.Value = (int)fontDialog1.Font.Size;
            label7.Text = "Текущее значение: " + trackBar1.Value.ToString();


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {


            trackBar1.Minimum = 1;
            trackBar1.Maximum = 50;
            Font font = new Font(Font.FontFamily, (float)trackBar1.Value);
            label7.Text = "Текущее значение: " + trackBar1.Value.ToString();
            label1.Font = font;
            label1.Font = font;
            label2.Font = font;
            label3.Font = font;
            label4.Font = font;
            label5.Font = font;
            radioButton1.Font = font;
            radioButton2.Font = font;
            radioButton3.Font = font;
            radioButton4.Font = font;
            radioButton5.Font = font;
            button1.Font = font;
            очиститьToolStripMenuItem.Font = font;
            button3.Font = font;
            button4.Font = font;
            уравнятьToolStripMenuItem.Font = font;
            лучшееПоколениеToolStripMenuItem.Font = font;
            лучшийВидToolStripMenuItem.Font = font;
            textBox1.Font = font;
            menuStrip1.Font = font;
            Random_singleton random_Singleton = Random_singleton.getInstance;
            random_Singleton.button1.Font = font;
            random_Singleton.checkBox1.Font = font;
            random_Singleton.checkBox2.Font = font;
            random_Singleton.label1.Font = font;
            random_Singleton.textBox1.Font = font;
            random_Singleton.textBox2.Font = font;
            spravka.button1.Font = font;
            spravka.label1.Font = font;

        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы точно хотите очистить всё?", "Очистка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(i));
                listView1.Items.Clear();
                listView2.Items.Clear();
                i = 1;
                massiv.Clear();
                лучшееПоколениеToolStripMenuItem.Enabled = false;
                лучшийВидToolStripMenuItem.Enabled = false;
                button1.Enabled = false;
                очиститьToolStripMenuItem.Enabled = false;
                уравнятьToolStripMenuItem.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton1.Enabled = true;
                textBox1.Enabled = true;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                button3.Enabled = false;
                toolStripButton1.Enabled = false;
            }
        }

        private void уравнятьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<string> face = Facade.Run_uravn(massiv);
            massiv.Clear();
            massiv = face;
            i = 1;
            for (int j = 0; j < massiv.Count; j++)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(i));
                i++;
                listView1.Items.Add(item);
                item.SubItems.Add(massiv[j]);
            }
            уравнятьToolStripMenuItem.Enabled = false;
        }

        private void лучшееПоколениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double koef1 = 0, koef2 = 0;
            string best1 = null, best2 = null;
            int KEY = 0;
            Algoritm algoritm;
            AssessFitness assess = new AssessFitness();
            if (massiv.Count != 0)
            {
                algoritm = new Algoritm(massiv.Count);
                best1 = algoritm.Best_pop(massiv.ToArray());
                koef1 = assess.AssesSUM(massiv.ToArray());
            }
            else KEY++;
            if (massiv_new.Count != 0)
            {
                algoritm = new Algoritm(massiv_new.Count);
                best2 = algoritm.Best_pop(massiv_new.ToArray());
                koef2 = assess.AssesSUM(massiv_new.ToArray());
            }
            else
            {

                KEY += 5;
            }
            if (KEY == 5) MessageBox.Show("Второе поколение пустое");
            if (KEY == 6) MessageBox.Show("Оба поколения пустые");
            else if (KEY == 0)
            {
                string[] best12 = new string[2] { best1, best2 };
                algoritm = new Algoritm(best12.Count());
                BEST = algoritm.Best_pop(best12);
                if (koef1 >= koef2) MessageBox.Show("Лучше первое поколение");
                else if ((koef1 < koef2)) MessageBox.Show("Лучше второе поколение");

            }
            KEY = 0;
        }

        private void лучшийВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algoritm algoritm = new Algoritm(massiv.Count);
            BEST = algoritm.Best_pop(massiv.ToArray());
            if (BEST != null)
                MessageBox.Show("Лучший вид: " + BEST);
            else MessageBox.Show("Лучший вид отсутсвует!");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Grafik grafik = new Grafik(KoefMassiv,KoefMassiv_new);
            grafik.Graf();
            grafik.Show();
        }

        private void вставитьВСтрокуВводаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                textBox1.Text = Clipboard.GetText();
            else MessageBox.Show("Буфер обмена пуст. Вставлять нечего");
        }

        private void dragAndDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
