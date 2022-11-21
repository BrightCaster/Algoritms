using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutogrammaTasks
{
    internal class Facade
    {
        private Task1 task1;
        private Task2 task2;
        private Task3 task3;
        public Facade(Task1 task1, Task2 task2, Task3 task3)
        {
            this.task1 = task1;
            this.task2 = task2;
            this.task3 = task3;
        }

        public void Start()
        {
            this.task1.Print();
            this.task2.Print();
            this.task3.Print();
        }
    }
}
