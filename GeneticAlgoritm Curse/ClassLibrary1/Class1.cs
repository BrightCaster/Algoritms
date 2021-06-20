using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class Class1
    {
        public static string[] Ravn(string[] Q, int length)
        {
            int size = Q.Count();
            for (int i = 0; i < size; i++)// делаем одинаковое количество битовых знаков
            {
                while (Q[i].Length != length)
                {
                    Q[i] = "0" + Q[i];
                }
            }
            return Q;
        }
    }
}
