using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutogrammaTasks
{
    internal class Task1 : ITask
    {
        private string _taskString1;

        public Task1(string taskString1)
        {
            _taskString1 = taskString1;
        }
        public void Print()
        {
            if (_taskString1 != null)
            {
                var answer = "Ответ на задачу 1: ";
                if (Calculate(_taskString1).Length > 0)
                {
                    Console.WriteLine(answer + Calculate(_taskString1));
                }
                else
                {
                    Console.WriteLine(answer + "-");
                }
            }
        }
        #region private methods
        private string Calculate(string upToCalc)
        {
            var list = new List<string>(upToCalc.Split(" "));//разбиваем на списки 
            var listContainble = new List<string>();
            var minLength = list.First().Length;// берём любой первый элемент
            var firstString = string.Empty;
            foreach (var item in list)
            {
                if (item.Length <= minLength)
                {
                    minLength = item.Length;
                    firstString = item;
                }// находим строку из всего списка с минимальной длиной
            }
            var listForCompare = GetStrings(firstString);// получаем список возможных вариантов сравнения
            var max = 0;
            string maxString = "";
            foreach (var item in listForCompare)
            {
                if (list.All(listItem => listItem.Contains(item) == true))
                {
                    if (item.Length >= max)
                    {
                        maxString = item;
                        max = item.Length;
                    }
                }
            }
            return maxString;
        }

        private List<string> GetStrings(string s)
        {
            var list = new List<string>();
            var newS = s.First().ToString();
            var i = 1;
            var length = s.Length;
            var count = 1;
            while (i <= CalcForCycle(s.Length))
            {
                for (int j = 0; j < length; j++)
                {
                    list.Add(s.Substring(j, count));
                }
                count += 1;
                i += count;
                length--;
            }
            return list;
        }

        private int CalcForCycle(int count)
        {
            var n = 0;
            for (int i = 1; i <= count; i++)
            {
                n += i;
            }
            return n;
        }
        #endregion
    }
}
