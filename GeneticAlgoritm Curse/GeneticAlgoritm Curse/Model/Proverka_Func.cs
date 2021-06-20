using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm_Curse.Model
{
    class Proverka_Func
    {
        public bool Proverka(string P)
        {
            int value;
            int length = P.Length;
            for (int i = 0; i < length; i++)
            {
                value = P[i];
                if ((value == '1') || (value == '0')) continue;
                else return false;
            }
            return true;
        }
    }
}
