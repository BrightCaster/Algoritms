using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutogrammaTasks
{
    internal class Task2 : ITask
    {
        private string _taskString2;
        public Task2(string taskString2)
        {
            _taskString2 = taskString2;
        }
        private int Calculate(string stroke)
        {
            Regex regex = new(@"[0-9]{1,}");
            var list = new List<string>(stroke.Split(" "));
            var sum = 0;
            foreach (var item in list)
            {
                var match = regex.Match(item);
                if (match.Success)
                {
                    sum += Convert.ToInt32(match.Value);
                }
            }
            return sum;
        }
        public void Print()
        {
            if (_taskString2 != null)
            {
                Console.WriteLine($"Ответ на задачу 2: {Calculate(_taskString2)}");
            }
        }
    }
}
