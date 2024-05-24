abstract class Task
{
    protected string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}
class Task1 : Task
{
    public Task1(string text) : base(text)
    {
    }
    public override string ToString()
    {
        string result = "";
        string ruLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        for (int i = 0; i < ruLetters.Length; i++)
        {
            int counter = 0;
            for (int j = 0; j < text.Length; j++)
            {
                if (text[j] == ruLetters[i]){
                    counter++;
                }
            }
        }
        return result.ToString();
    }
    class Task3 : Task
    {
        public Task3(string text) : base(text)
        {
        }
        public override string ToString()
        {
            string[] words = text.Split(' ');
            string currentLine = "";
            string result = "";

            for (int i = 0; i < words.Count() - 1; i++)
            {
                if ((currentLine + words[i]).Length <= 50)
                {
                    currentLine += words[i] + " ";
                }
                else
                {
                    result += currentLine.Trim() + "\n";
                    currentLine = words[i] + " ";
                }
            }

            result += currentLine.Trim();
            return result;
        }
    }
    class Task5 : Task
    {

        public Task5(string text) : base(text)
        {
        }
        struct letterRarity
        {
            private char letter { get; set; }
            private int count { get; set; }

            public char Letter { get => letter; }
            public int Value { get => count; }
            public letterRarity increment()
            {
                this.count = this.count + 1;
                return this;
            }
            public letterRarity(char x)
            {
                letter = x;
                count = 0;
            }
        }
        public override string ToString()
        {
            List<letterRarity> lettersCounted = new List<letterRarity>();
            bool isNewWord = true;
            string specLetters = "1234567890!@#$%^&*(){},.<>/?~`-_=—''|\"";
            this.text = this.text.ToLower();
            for (int i = 0; i < this.text.Length; ++i)
            {
                char c = this.text[i];
                if (c == ' ' || c == '\n') isNewWord = true;

                if (specLetters.Contains(c)) continue;
                if (Char.IsLetter(c) && isNewWord)
                {
                    bool found = false;
                    for (int j = 0; j < lettersCounted.Count; j++)
                    {
                        if (lettersCounted[j].Letter == c)
                        {
                            lettersCounted[j] = lettersCounted[j].increment();
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        letterRarity newLetter = new letterRarity(c);
                        newLetter.increment();
                        lettersCounted.Add(newLetter);
                    }

                    isNewWord = false;
                }
            }
            for (int i = 0; i < lettersCounted.Count; ++i)
            {
                Console.WriteLine(string.Format("{0} - {1}", lettersCounted[i].Letter, lettersCounted[i].Value));
            }
            return "";

        }
    }
    class Task7 : Task
            {
                public Task7(string text) : base(text)
                {
                }
                public override string ToString()
                {
                    string[] words = text.Split(' ');
                    string subseque = "дом";
                    string result = "";

                    for (int i = 0; i < words.Count() - 1; i++)
                    {
                        if ((words[i].ToLower().Contains(subseque)))
                        {
                            result += words[i] + ", ";
                        }
                    }
                    return result;
                }
            }
            class Task11 : Task
            {
                public Task11(string text) : base(text)
                {
                }
                public override string ToString()
                {
                    string[] names = text.Split(", ");
                    string namesList = "";
                static void SortWords(string[] words)
                {
                    for (int i = 0; i <= words.Length; i++)
                    {
                        for (int j = 0; j < words.Length - i - 1; j++)
                        {
                            if (CompareWords(words[j], words[j + 1]) > 0)
                            {
                                string temp = words[j];
                                words[j] = words[j + 1];
                                words[j + 1] = temp;
                            }
                        }
                    }
                }
                static int CompareWords(string word1, string word2)
                {
                    int minLength = Math.Min(word1.Length, word2.Length);

                    for (int i = 0; i < minLength; i++)
                    {
                        if (word1[i] < word2[i])
                            return -1;
                        if (word1[i] > word2[i])
                            return 1;
                    }
                    if (word1.Length < word2.Length)
                        return -1;
                    if (word1.Length > word2.Length)
                        return 1;
                    return 0;
                }
                SortWords(names);
                for (int i = 0; i < names.Length; i++)
                    {
                        namesList += "\n" + names[i];
                    }
                    return namesList;
                }
            }
            class Task14 : Task
            {
                public Task14(string text) : base(text)
                {
                }
                public override string ToString()
                {
                    int result = 0;
                    for (int i = 1; i <= text.Length - 1; i++)
                    {
                        if (text[i - 1] == '1' && text[i] == '0')
                        {
                            result += 10;
                        }
                        else if ((text[i - 1] == '1' || text[i - 1] == '2' || text[i - 1] == '3' || text[i - 1] == '4' || text[i - 1] == '5' || text[i - 1] == '6' || text[i - 1] == '7' || text[i - 1] == '8' || text[i - 1] == '9'))
                        {
                            result += (int)Char.GetNumericValue((text[i - 1]));
                        }
                    }
                    return result.ToString();
                }
            }
            class Program
            {
                static void Main()
                {
                    Task a = new Task1("Hello мир!!!");
                    Console.WriteLine(a.ToString());
                    Task b = new Task3("Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.");
                    Console.WriteLine(b);
                    Task f = new Task5("Празндик Дом домов добра да.");
                    Console.WriteLine(f);
                    Task c = new Task7("Празндик Дом домов добра.");
                    Console.WriteLine(c);
                    Task q = new Task11("Яков, Вовин, Быков, Зеленский, Яворский");
                    Console.WriteLine(q);
                    Task d = new Task14("10 июля в 9 утра в 8 доме");
                    Console.WriteLine(d);
                }
            }
        }
   
