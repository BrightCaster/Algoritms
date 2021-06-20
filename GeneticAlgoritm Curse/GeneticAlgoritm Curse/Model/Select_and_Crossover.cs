using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm_Curse.Model
{
    class Select
    {
        Random random = new Random();
        AssessFitness fit = new AssessFitness();
        public string SelectWithReplacement(string[] P)
        {
            int sumk = 0;
            int size = P.Count();
            double n = random.NextDouble();
            for (int i = 1; i < size; i++)
            {
                if (P[i - 1] == null)
                {
                    sumk++;
                    continue;
                }
                if ((fit.AccessFitness_dv(P[i - 1]) < n) && (fit.AccessFitness_dv(P[i]) > n))
                {
                    return P[i];
                }
            }
            return P[sumk];
        }
    }
    class Crossover
    {
        Random random = new Random();
        public string Crosover(string Pa, string Pb, int size)
        {
            string paa = null, pbb = null;
            int length = Pa.Length;
            int n = random.Next(0, maxValue: length - 1);
            if (n != 1)
            {
                if (n != 0)
                {
                    int i = 0;
                    while (i < n)
                    {
                        paa += Pa[i];
                        pbb += Pb[i];
                        i++;
                    }
                }
                for (int i = n; i < length; i++)
                {
                    if (Pa[i] != Pb[i])
                    {
                        paa += Pb[i];
                        pbb += Pa[i];
                        continue;
                    }
                    if (Pa[i] == '0') { paa += '0'; } else { paa += '1'; }
                    if (Pb[i] == '0') { pbb += '0'; } else { pbb += '1'; }
                }
            }
            else
            {
                paa = Pa; pbb = Pb;
            }
            return paa + " " + pbb;
        }
        public string Mutate(string C, int size)
        {
            string new_C = C;
            double rand = random.NextDouble();
            double p = 1 / (double)size;
            if (p >= rand)
            {
                new_C = null;
                for (int i = 0; i < C.Length; i++)
                {
                    if (C[i] == '1')
                    {
                        new_C += "0";
                    }
                    if (C[i] == '0')
                    {
                        new_C += "1";
                    }
                }
            }
            return new_C;
        }
    }
}
