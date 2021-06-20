using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm_Curse.Model
{
    class Fitness
    {
        int sum = 0;
        int value;
        float k;
        long chislo;
        public int Fitness_dv(string P)
        {
            int length = P.Length;
            for (int i = 0; i < length; i++)
            {
                value = P[i];
                if (value == '1') sum++;
            }
            chislo = Convert.ToInt64(P);
            k = (float)sum / length;
            if (k > 0.5) return value = Convert.ToInt32(chislo);
            else return 0;
        }
    }
    class AssessFitness
    {
        public double AccessFitness_dv(string P)// РЕШЕНО
        {
            if (P == null) return 0;
            string c = P;
            int sum = 0;
            int value;
            float k;
            int length = P.Length;
            for (int i = 0; i < length; i++)
            {
                value = c[i];
                if (c[i] == ' ') continue;
                if (value == '1') sum++;
            }
            k = (float)sum / length;
            return k;
        }
        public double AssesSUM(string[] P)
        {
            double average = 0;
            for(int i = 0; i < P.Count(); i++)
            {
                double koef = AccessFitness_dv(P[i]);
                average += koef;
            }
            average = average / P.Count();
            return average;
        }
    }
    
}
