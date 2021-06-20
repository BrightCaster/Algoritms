using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using GeneticAlgoritm_Curse;
using ClassLibrary1;

namespace GeneticAlgoritm_Curse.Model
{
    static class Facade
    {
        static View view = new View();
        
        public static List<string> Run_uravn(List<string> massiv)
        {
            int length = 0;
            for (int i = 0; i < massiv.Count; i++)
            {
                if (massiv[i].Length > length)
                {
                    length = massiv[i].Length;
                }
            }
            string[] Q = Class1.Ravn(massiv.ToArray(), length);
            massiv = Q.ToList<string>();
            return massiv;
        }

        public static List<string> Run_Vvod(List<string> massiv)
        {
            Random_singleton random = Random_singleton.getInstance;
            random.ShowDialog();

            int count = random.P.Count();
            for (int i = 0; i < count; i++)
            {
                massiv.Add(random.P[i]);
            }
            return massiv;
        }
        public static void Run_Button2()
        {
           
        }
    }
}
