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
    public abstract class Race
    {
        protected abstract string GetRaceName();
        private List<RaceParticipant> p = new List<RaceParticipant>();
        public void AddResult(string lastName, int firstResult, int secondResult, int thirdResult)
        {
            RaceParticipant a = new RaceParticipant(lastName, firstResult, secondResult, thirdResult);
            this.p.Add(a);
        }
        private void sortResult()
        {
            void QuickSort(List<RaceParticipant> participants, int low, int high)
            {
                if (low < high)
                {
                    int swaper = Part(participants, low, high);
                    QuickSort(participants, low, swaper - 1);
                    QuickSort(participants, swaper + 1, high);
                }
            }

            int Part(List<RaceParticipant> participants, int low, int high)
            {
                RaceParticipant swaper = participants[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (participants[j].getBestResult() < swaper.getBestResult())
                    {
                        i++;
                        RaceParticipant buf = participants[i];
                        participants[i] = participants[j];
                        participants[j] = buf;
                    }
                }

                RaceParticipant buf1 = participants[i + 1];
                participants[i + 1] = participants[high];
                participants[high] = buf1;

                return i + 1;
            }

            QuickSort(p, 0, p.Count - 1);
        }
    
        public void ShowResult()
        {
            Console.WriteLine(String.Format("Результаты Дисциплины {0}", this.GetRaceName()));
            Console.WriteLine(String.Format("{0,10} {1,10}", "Фамилия:", "Результат: "));
            this.sortResult();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(String.Format("{0,10} {1,10}", this.p[i].getLastName(), this.p[i].getBestResult()));
            }
        }
    }
    public class JumpsInLength : Race
    {
        protected override string GetRaceName()
        {
            return "Прыжки в длину";
        }

    }
    public class JumpsInHeight : Race
    {
        protected override string GetRaceName()
        {
            return "Прыжки в высоту";
        }
    }
    public static void Main(string[] args)
    {
        Race a = new JumpsInHeight();
        a.AddResult("Быков", 1, 2, 9);
        a.AddResult("Петров", 1, 4, 3);
        a.AddResult("Данилов", 1, 5, 3);
        a.AddResult("Вадимов", 1, 7, 3);
        a.AddResult("Иванов", 1, 2, 8);
        a.ShowResult();
        Race b = new JumpsInLength();
        b.AddResult("Живаго", 1, 2, 9);
        b.AddResult("Кириллов", 1, 3, 3);
        b.AddResult("Васильев", 1, 5, 3);
        b.AddResult("Макрон", 1, 7, 3);
        b.AddResult("Грузин", 1, 2, 8);
        b.ShowResult();
    }
}
