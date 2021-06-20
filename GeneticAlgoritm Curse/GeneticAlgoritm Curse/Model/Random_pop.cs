using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneticAlgoritm_Curse
{
    class Random_pop
    {
        Random random = new Random();
        int length;
        string[] P = new string[] { };
        
        public Random_pop(int length)
        {
            this.length = length;
        }

        public string[] Random_P(int size)
        {
            Array.Resize(ref P,size);
            string[] Q = new string[] { };
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    double r = random.NextDouble();
                    if (r < 0.5)
                        P[i] = P[i] + "0";
                    else P[i] = P[i] + "1";
                }
            }
            Q = P.ToArray();
            return Q;
        }
    }
}
