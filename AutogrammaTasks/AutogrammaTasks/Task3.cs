using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutogrammaTasks
{
    internal class Task3 : ITask
    {
        private List<string> _taskString3;
        public Task3(List<string> taskString3)
        {
            _taskString3 = taskString3;
        }

        private int Calculate(List<string> expression)
        {
            Stack<string> stack = new();
            List<int> numbers = new();
            foreach (string item in expression)
            {   
                if (isOperator(item))
                {
                    stack.Push(item);
                }
                else if (isDigit(item))
                {
                    numbers.Add(int.Parse(item));
                }
            }
            int j = 1;
            int result = numbers.First();
            while (stack.Count != 0)
            {
                string oper = stack.Pop();
                int A = numbers[j];
                switch (oper)
                {
                    case "+": result += A; break;
                    case "-": result -= A; break;
                    case "*": result *= A; break;
                    case "/": result /= A; break;
                    default:
                        break;
                }
                j++;
            }
            return result;
        }

        private bool isOperator(string op)
        {
            if ("+,-,*,/".IndexOf(op) != -1) return true;
            return false;
        }

        private bool isDigit(string d)
        {
            int n;
            if (int.TryParse(d,out n)) return true;
            return false;
        }

        public void Print()
        {
            if (_taskString3 != null)
            {
                Console.WriteLine(Calculate(_taskString3));
            }
            else
            {
                Console.WriteLine("Non found resolve");
            }
        }
    }
}
