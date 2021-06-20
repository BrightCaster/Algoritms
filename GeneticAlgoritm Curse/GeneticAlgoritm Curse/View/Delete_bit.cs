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
    public partial class Delete_bit : Form
    {
        Proverka_Func proverka = new Proverka_Func();
        internal string P_vid;
        public Delete_bit()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (proverka.Proverka(textBox1.Text))
                {
                    P_vid = textBox1.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }
            }
        }
    }
}
