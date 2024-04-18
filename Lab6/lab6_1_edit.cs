using System;
public class Program
{
    public class SurveyParticipant
    {
        private string answer = "";
        public SurveyParticipant(string answer)
        {
            this.answer = answer;
        }
        public string result
        {
            get
            {
                return this.answer;
            }
        }
    }
    public struct Survey
    {
        public Survey()
        {

        }
        private List<SurveyParticipant> p = new List<SurveyParticipant>();
        public void AddAnswer(string answer)
        {
            SurveyParticipant a = new SurveyParticipant(answer);
            this.p.Add(a);
        }
        private (List<string>, List<int>) GetUniqueAnswers()
        {
            List<string> uniqueAnswers = new List<string>();
            List<int> uniqueAnswersCount = new List<int>();
            for (int i = 0; i < this.p.Count; i++)
            {
                int isUnique = 1;
                for (int j = 0; j < uniqueAnswers.Count; j++)
                {
                    if (this.p[i].result == uniqueAnswers[j])
                    {
                        isUnique = 0;
                        uniqueAnswersCount[j] += 1;
                    }
                }
                if (isUnique == 1)
                {
                    uniqueAnswers.Add(this.p[i].result);
                    uniqueAnswersCount.Add(1);
                }
            }
            return (uniqueAnswers, uniqueAnswersCount);
        }
        private (List<string>, List<int>) SortUniqueAnswers(List<string> uniqueAnswers, List<int> uniqueAnswersCount)
        {
            for (int i = 0; i < uniqueAnswers.Count; i++)
            {
                for (int j = i + 1; j < uniqueAnswers.Count; j++)
                {
                    if (uniqueAnswersCount[i] < uniqueAnswersCount[j])
                    {
                        string answerBuffer = uniqueAnswers[j];
                        int answerCountBuffer = uniqueAnswersCount[j];
                        uniqueAnswers[j] = uniqueAnswers[i];
                        uniqueAnswersCount[j] = uniqueAnswersCount[i];
                        uniqueAnswers[i] = answerBuffer;
                        uniqueAnswersCount[i] = answerCountBuffer;
                    }
                }
            }
            return (uniqueAnswers, uniqueAnswersCount);
        }
        public void ShowResult()
        {
            var uniqueAnswers = this.GetUniqueAnswers();
            uniqueAnswers = this.SortUniqueAnswers(uniqueAnswers.Item1, uniqueAnswers.Item2);
            Console.WriteLine(String.Format("{0,10} {1,10}", "Ответ:", "Доля: "));
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(String.Format("{0,10} {1,10}", uniqueAnswers.Item1[i], (double)(uniqueAnswers.Item2[i]) / this.p.Count));
            }
        }
    }
    public static void Main(string[] args)
    {
        Survey a = new Survey();
        a.AddAnswer("Быков");
        a.AddAnswer("Быков");
        a.AddAnswer("Быков");
        a.AddAnswer("Быков");
        a.AddAnswer("Быков");
        a.AddAnswer("Круглов");
        a.AddAnswer("Круглов");
        a.AddAnswer("Илон Маск");
        a.AddAnswer("Илон Маск");
        a.AddAnswer("Илон Маск");
        a.AddAnswer("Илон Маск");
        a.AddAnswer("Илон Маск");
        a.AddAnswer("Крутов");
        a.AddAnswer("Крутов");
        a.AddAnswer("Крутов");
        a.AddAnswer("Крутов");
        a.AddAnswer("Харитонов");
        a.ShowResult();
    }
}
