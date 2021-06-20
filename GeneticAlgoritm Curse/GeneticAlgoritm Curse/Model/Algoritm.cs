using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneticAlgoritm_Curse.Model
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }
    abstract class AbstractHandler:IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public virtual object Handle( object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else return null;
        }
    }
    class Algoritm: AbstractHandler
    {
        AssessFitness AF = new AssessFitness();
        Fitness fit = new Fitness();
        Proverka_Func func = new Proverka_Func();
        Select select = new Select();
        Crossover crossover = new Crossover();
        string Best_last;
        int size;
        string Best = null;

        public Algoritm(int size)
        {
            this.size = size;
        }
        public string[] Algoritm_pop(string[] P)
        {
            do
            {
                Best_last = Best;
                for (int i = 0; i < P.Count(); i++)/////      7
                {
                    if ((Best == null) || (fit.Fitness_dv(P[i]) > fit.Fitness_dv(Best)))////      9     
                        Best = P[i];///        10
                    //////////////////////////////////////////////
                }
                if (Best == Best_last)
                    break;

                List<string> Q = new List<string>();///////        11
                for (int j = 0; j < (size / 2); j++)
                {
                    
                    int a;
                    int Key = 0;
                    string Ca = null, Cb = null;
                    string Pa = select.SelectWithReplacement(P);
                    string Pb = select.SelectWithReplacement(P);
                    if (Pa == Pb)
                    {
                        Q.Add(crossover.Mutate(Pa, size));
                        //if (Q.Count == 0)
                        Q.Add(crossover.Mutate(Pb, size));
                        List<string> list1 = P.ToList<string>();
                        a = list1.FindIndex(x => x == Pa);
                        list1[a] = null;
                        P = list1.ToArray();
                        for (int i = 0; i < size - 1; i++)
                        {
                            for (int o = 0; o < size - 1; o++)
                            {
                                if (P[o] != null)
                                {
                                    var t = P[o];
                                    P[o] = P[o + 1];
                                    P[o + 1] = t;
                                }
                            }
                        }
                        continue;
                    }
                    string Cab = crossover.Crosover(Pa, Pb, size);
                    for (int i = 0; i < Cab.Length; i++)
                    {
                        if (Cab[i] == ' ')
                        {
                            Key = 1;
                            continue;
                        }
                        if (Key == 1) { Cb = Cb + Cab[i]; continue; }
                        Ca = Ca + Cab[i];
                    }// Ca и Cb созданы
                    Q.Add(crossover.Mutate(Ca, size));
                    Q.Add(crossover.Mutate(Cb, size));
                    List<string> list = P.ToList<string>();
                    a = list.FindIndex(x => x == Pa);
                    list[a] = null;
                    a = list.FindIndex(x => x == Pb);
                    list[a] = null;
                    P = list.ToArray();
                    for (int i = 0; i < size - 1; i++)
                    {
                        for (int o = 0; o < size - 1; o++)
                        {
                            if (P[o] != null)
                            {
                                var t = P[o];
                                P[o] = P[o + 1];
                                P[o + 1] = t;
                            }
                        }
                    }
                }
                Q.Add(P.Last());
                size = Q.Count();
                Q.Reverse();
                string[] mass_Q = Q.ToArray();
                P = mass_Q;
                

            } while ((Best_last != Best));
            Best = null;
            return P;
        }
        public string Best_pop(string[] P)
        {

            for (int i = 0; i < P.Count(); i++)/////      7
            {
                double a_first = AF.AccessFitness_dv(P[i]);
                double a_next = AF.AccessFitness_dv(Best);
                if ((Best == null) || ((a_first >= a_next) && (fit.Fitness_dv(P[i]) > fit.Fitness_dv(Best))))////      9     
                    Best = P[i];///        10
                //////////////////////////////////////////////
            }
            return Best;
        }
    }
}
