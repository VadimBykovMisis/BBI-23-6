using System;
using System.Collections.Generic;

public class Program
{
    public class RaceParticipant
    {
        private string lastName = "";
        private int firstResult = 0;
        private int secondResult = 0;
        private int thirdResult = 0;
        private int bestResult = 0;
        public RaceParticipant(string lastName, int firstResult, int secondResult, int thirdResult)
        {
            this.lastName = lastName;
            this.firstResult = firstResult;
            this.secondResult = secondResult;
            this.thirdResult = thirdResult;
        }
        public int getBestResult()
        {
            return Math.Max(this.firstResult, Math.Max(this.secondResult, this.thirdResult));
        }
        public string getLastName()
        {
            return this.lastName;
        }
    }
    public class Race
    {
        private List<RaceParticipant> p = new List<RaceParticipant>();
        public void AddResult(string lastName, int firstResult, int secondResult, int thirdResult)
        {
            RaceParticipant a = new RaceParticipant(lastName, firstResult, secondResult, thirdResult);
            this.p.Add(a);
        }
        private void sortResult()
        {
            for (int i = 0; i < this.p.Count; i++)
            {
                for (int j = i + 1; j < this.p.Count; j++)
                {
                    if (this.p[i].getBestResult() > this.p[j].getBestResult()) {
                        RaceParticipant buf = this.p[i];
                        this.p[i] = this.p[j];
                        this.p[j] = buf;
                    }
                }
            }
        }
        public void ShowResult()
        {
            Console.WriteLine(String.Format("{0,10} {1,10}", "Фамилия:", "Результат: "));
            this.sortResult();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(String.Format("{0,10} {1,10}", this.p[i].getLastName(), this.p[i].getBestResult()));
                }
            }
        }
        public static void Main(string[] args)
        {
            Race a = new Race();
            a.AddResult("Быков", 1, 2, 9);
            a.AddResult("Петров", 1, 4, 3);
            a.AddResult("Данилов", 1, 5, 3);
            a.AddResult("Вадимов", 1, 7, 3);
            a.AddResult("Иванов", 1, 2, 8);
            a.ShowResult();
        }
    }
