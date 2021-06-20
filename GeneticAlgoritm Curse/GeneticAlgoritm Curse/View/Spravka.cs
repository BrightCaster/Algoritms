using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgoritm_Curse
{
    public partial class Spravka : Form
    {
        public Spravka()
        {
            InitializeComponent();
            this.label1.Text = "Генетический алгоритм является методом оптимизации, основанный на аналогиях с природой.\n" +
                "Алгоритм делится на три этапа:\n\n" +
                "Скрещивание\n" +
                "Селекция(отбор)\n" +
                "Формирования нового поколения\n\n" +
                "Каждое поколение состоит из определённых видов.\n\n" +
                "Для того чтобы ввести поколение, нужно ввести битовый вектор видов. Пример: 1011010\n\n" +
                "Для этого есть строчка снизу слева программы с выборанной функцией \"Ввести популяцию\" или автоматически заполнить с помощью кнопки справа \"Ввод\"\n\n" +
                "Для начала алгоритма нужно нажать \"Начать\"\n\n" +
                "Для нахождения лучшего вида понадобится кнопка \"BEST\"\n\n" +
                "Для того чтобы сохранить вид или загрузить, нам понадобится вкладка \"Меню\"\n\n" +
                "Данная программа может предложить выбрать лучшее поколение при нажатии кнопки \"Лучшее поколение\"\n\n" +
                "Также мы можем выбрать поколение какое нам нужно при выборе кнопки \"Выбор\"";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
